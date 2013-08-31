using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Renamepler.Properties;

namespace Renamepler
{
    //FEATURES:
    //1. Progress bar during execute
    //  REQUIRES: Pre-parsing of files to compute number, update progress based on that number
    //2. Individual rule-running
    //  REQUIRES: Usage of overloaded Search()
    //3. Original numbering retention
    //  REQUIRES: A whole lot of shit I don't know
    //4. Modularity in naming rules
    //  REQUIRES: More "fields" similar to the numbering format, but for names, etc. (maybe even custom "fields"?)
    //  REQUIRES: Parsing of fields denoted by a delimiter (e.g. :NAME: or #NAME#) (NOTE: this delimiter must not be an illegal filename character because of the
    //      sanitization check in AddRuleDialog, or that check must be re-worked)
    //5. Search-specific options that get saved along with rules
    //  REQUIRES: Re-implement RenameplerOptions object, but only for search-specific options
    //  REQUIRES: Continued use of Settings for app settings
    //6. Check rules against each other so that there will be no cross-over
    //  REQUIRES: Regexing the other regexes?
    //7. Relaxed renaming pattern system
    //  REQUIRES: If no extension is present in the pattern, retain the previous extension
    //8. Add "ignore" rules to the app

    //REFACTORING:
    //1. Move the name sanitization (regex, default name check, etc.) to a static function
    //  REQUIRES: New function

    //BUGS:

    public partial class Core : Form
    {
        public static string _appData;
        private string _path = "";
        private RuleSet _rules;
        private RenamingStats _stats;

        public Core()
        {
            InitializeComponent();
            this._rules = new RuleSet();
            _appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+Path.DirectorySeparatorChar+"Bitslave"+Path.DirectorySeparatorChar+"Renamepler";

            //Creates the appdata directory on initial run
            if (!Directory.Exists(_appData))
            {
                Directory.CreateDirectory(_appData);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (!this._rules.IsEmpty() && ((Settings.Default.AskBeforeClear && (MessageBox.Show("Are you sure you want to remove all rules?", "Clear Rules", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)) || !Settings.Default.AskBeforeClear))
            {
                this.ruleBox.Clear();
                this._rules = new RuleSet();
            }
        }

        private void dirDialogButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = Settings.Default.LastDirectory;
            var result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Settings.Default.LastDirectory = folderBrowserDialog.SelectedPath;
                Settings.Default.Save();
                this.ruleBox.Text = this._rules.ToString();

                //Confirms clear if the rules actually exist and if the directory was not empty previously
                if (!this._rules.IsEmpty() && !this._path.Equals("") && (MessageBox.Show("Do you want to clear all current rules?", "Clear Rules", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes))
                {
                    //New rules and numbered names objects
                    this._rules = new RuleSet();
                    this.ruleBox.Text = this._rules.ToString();
                }

                this.directoryBox.Text = folderBrowserDialog.SelectedPath;
                this._path = folderBrowserDialog.SelectedPath;
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            var ruleStrings = new List<string>();

            foreach (var rule in this._rules.RuleList)
                ruleStrings.Add(rule.FindPattern);

            var editSelect = new CustomListDialog("Select Rule...", ruleStrings, "OK", "Cancel");

            if (editSelect.ShowDialog() == DialogResult.OK)
            {
                var editing = this._rules.GetRule(editSelect.SelectedItem);
                var editDialog = new AddRuleDialog(ref this._rules, ref editing);
                if (editDialog.ShowDialog() == DialogResult.OK)
                    this.ruleBox.Text = this._rules.ToString();

                editDialog.Dispose();
                editSelect.Dispose();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Confirm Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
                this.Dispose();
            }
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            if (this._path.Equals(""))
                this.dirDialogButton_Click(sender, e);
            if (this._path.Equals(""))
                goto Quit;

            if (this._rules.IsEmpty() && MessageBox.Show("No rules have been entered!", "Error", MessageBoxButtons.OK) != DialogResult.No)
                goto Quit;


            //Give the user the option to name the rules
            //This might be phased out later when there are RuleSet-specific options (including naming, hopefully)
            //We just want the user to be comfortable with naming rule sets, to allow for a more object-oriented paradigm with the RuleSet object in the future
            if (this._rules.SetName.Equals("Unnamed") && (MessageBox.Show("Do you want to name this rule set?", "", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                var namingDialog = new CustomDialog("Edit Name...", "[Enter name for this set of rules]", "OK", "Cancel");
                namingDialog.EnableEditing = true;

            //goto header in case the name is invalid
            Name:
                if (namingDialog.ShowDialog() == DialogResult.OK)
                {
                    var regex = new Regex("[" + Regex.Escape(new string(System.IO.Path.GetInvalidPathChars())) + "]");
                    if (namingDialog.DialogText.Equals("[Enter name for this set of rules]"))
                    {
                        MessageBox.Show("Enter a name for this set of rules!", "Error: No name!", MessageBoxButtons.OK);
                        goto Name;
                    }
                    else if (regex.IsMatch(namingDialog.DialogText))
                    {
                        MessageBox.Show("Invalid name!  Please try again.", "Error: Invalid name", MessageBoxButtons.OK);
                        goto Name;
                    }
                    else
                    {
                        this._rules.SetName = namingDialog.DialogText;
                        namingDialog.Dispose(); //Only dispose after grabbing the message text
                        this._stats = new RenamingStats(this._rules.RuleList);
                        this.Execute();
                    }
                }
            }
            else
            {
                this._stats = new RenamingStats(this._rules.RuleList);
                this.Execute();
            }
        Quit:
            return;
        }

        private void loadPreviousButton_Click(object sender, EventArgs e)
        {
            var list = new List<string>();

            foreach (var item in Directory.GetFiles(Core._appData, "*_stats.bin"))
                list.Add(Path.GetFileNameWithoutExtension(item).Replace("_stats", ""));

            var loadStatsWindow = new CustomListDialog("Load...", list, "OK", "Cancel");

            if (loadStatsWindow.ShowDialog() == DialogResult.OK)
            {
                var formatter = new BinaryFormatter();
                var reader = new FileStream(_appData + Path.DirectorySeparatorChar + loadStatsWindow.SelectedItem + "_stats.bin", FileMode.Open, FileAccess.Read);
                var statsWindow = new StatsWindow((RenamingStats)formatter.Deserialize(reader));
                statsWindow.Show();
                reader.Close();
            }

            loadStatsWindow.Dispose();
        }

        private void loadRulesButton_Click(object sender, EventArgs e)
        {
            var list = new List<string>();

            foreach (var item in Directory.GetFiles(Core._appData, "*_rules.bin"))
                list.Add(Path.GetFileNameWithoutExtension(item).Replace("_rules", ""));

            var loadWindow = new CustomListDialog("Load...", list, "OK", "Cancel");

            if ((loadWindow.ShowDialog() == DialogResult.OK) && (this._rules.IsEmpty() || (Settings.Default.AskBeforeLoad && (MessageBox.Show("Are you sure you want to load these rules?  This action will overwrite all rules currently loaded.", "Overwrite Warning", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)) || !Settings.Default.AskBeforeLoad))
            {
                var formatter = new BinaryFormatter();
                var reader = new FileStream(_appData + Path.DirectorySeparatorChar + loadWindow.SelectedItem + "_rules.bin", FileMode.Open, FileAccess.Read);
                this._rules = (RuleSet)formatter.Deserialize(reader);
                this.ruleBox.Text = this._rules.ToString();
                reader.Close();
            }

            loadWindow.Dispose();
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            var optWindow = new OptionsWindow();
            optWindow.ShowDialog();
        }

        private void ruleButton_Click(object sender, EventArgs e)
        {
            var dialog = new AddRuleDialog(ref this._rules);
            
            if (dialog.ShowDialog() == DialogResult.OK)
                this.ruleBox.Text = this._rules.ToString();

            dialog.Dispose();
        }

        private void saveRulesButton_Click(object sender, EventArgs e)
        {
            if (this._rules.IsEmpty())
                MessageBox.Show("There are no rules to save!", "Error", MessageBoxButtons.OK);
            else
            {
                var saveWindow = new CustomDialog("Save Rules As...", "[Enter a name for this set of rules]", "OK", "Cancel");
                saveWindow.EnableEditing = true;
            Saving: //Jump here if the file already exists but they don't want to overwrite

                if (saveWindow.ShowDialog() == DialogResult.OK)
                {
                    var named = saveWindow.DialogText;
                    var regex = new Regex("[" + Regex.Escape(new string(System.IO.Path.GetInvalidPathChars())) + "]");

                    if (named.Equals("[Enter a name for this set of rules]"))
                    {
                        MessageBox.Show("Enter a name for this set of rules!", "Error: No name!", MessageBoxButtons.OK);
                        goto Saving;
                    }
                    else if (regex.IsMatch(named))
                    {
                        MessageBox.Show("Invalid name!  Please try again.", "Error: Invalid name", MessageBoxButtons.OK);
                        goto Saving;
                    }
                    else if (named.Equals(""))
                    {
                        MessageBox.Show("Your name can not be empty!  Please try again.", "Error: Invalid name", MessageBoxButtons.OK);
                        goto Saving;
                    }

                    if (File.Exists(_appData + Path.DirectorySeparatorChar + named + "_rules.bin") && (MessageBox.Show("A rule set with this name already exists.  Do you want to overwrite it?", "Confirm Overwrite", MessageBoxButtons.YesNo) == DialogResult.No))
                        goto Saving;
                    if (this._rules.SetName.Equals("Unnamed")) //Set the name if it hasn't been
                        this._rules.SetName = named;
                    var formatter = new BinaryFormatter();
                    var writer = new FileStream(_appData + Path.DirectorySeparatorChar + named + "_rules.bin", FileMode.Create, FileAccess.Write);
                    formatter.Serialize(writer, this._rules);
                    writer.Close();
                }

                saveWindow.Dispose(); //Only dispose after everything has been used
            }

            this.ruleBox.Text = this._rules.ToString();
        }

        /// <summary>
        /// Removes specified files in the given file list Dictionary.
        /// </summary>
        /// <param name="p_files">the dictionary containing directories and associated files to be removed</param>
        private void CleanupFiles(Dictionary<string, List<string>> p_files)
        {
            foreach (var list in p_files)
            {
                foreach (var file in list.Value)
                    File.Delete(file);
            }
        }

        /// <summary>
        /// Executes the re-naming process.
        /// </summary>
        private void Execute()
        {
            List<string> dirArray = new List<string>();
            if (Settings.Default.RecursiveSearch) //Only add subdirectories if the user wants a recursive search
                foreach (var path in Directory.EnumerateDirectories(_path, "*", SearchOption.AllDirectories))
                    dirArray.Add(path);
            dirArray.Add(_path);

            foreach (var dir in dirArray)
            {
                this._rules.CleanNumbers(); //CleanNumbers handles the continuous numbering option, so call it for every directory and it will know what to do
                this._rules.AddFileList(dir, this.Search(dir, this._rules.RuleList)); //nested function calls...adds the file list from the result of the search from the result of GetRules()
            }

            if (Settings.Default.OpenDirectory)
                Process.Start("explorer.exe", "\root," + _path);

            if (Settings.Default.SaveStatistics)
            {   //Saves the statistics to a binary file using a DateTime format prefixed by the ruleset name to prevent any overwriting
                var formatter = new BinaryFormatter();
                var writer = new FileStream(_appData + Path.DirectorySeparatorChar + this._rules.SetName + "_" + DateTime.Now.ToString("MM-dd-yy_[HH-mm-ss]") + "_stats.bin", FileMode.Create, FileAccess.Write);
                formatter.Serialize(writer, this._stats);
                writer.Close();
            }

            //We obviously want to show stats if the user options call for it, but also if the CopyFirst flag is set (so the user can review renamings)
            if (Settings.Default.OverallStats || Settings.Default.PerRuleStats || Settings.Default.CopyFirst)
            {
                var statsWindow = new StatsWindow(this._stats);
                statsWindow.ShowDialog();

                if (Settings.Default.CopyFirst)
                {//Code to allow for deletion after the search
                    var deleteDialog = new CustomDialog("Confirm Deletion", "Would you like to delete all old files?", "Yes", "No");
                    deleteDialog.Button1Result = DialogResult.Yes;
                    deleteDialog.Button2Result = DialogResult.No;

                    if (deleteDialog.ShowDialog() == DialogResult.Yes)
                        this.CleanupFiles(this._rules.FileListCollection);
                    deleteDialog.Dispose();
                }
            }
        }

        /// <summary>
        /// Searches the specified directory using all provided rules, returning a list of all renamed files.
        /// </summary>
        /// <param name="p_dir">the path to the directory to be searched</param>
        /// <param name="p_rules">the path to the directory to be searched</param>
        private List<string> Search(string p_dir, List<Rule> p_rules)
        {
            bool errorcheck = false;
            var fileList = new List<string>();

            foreach (var file in Directory.GetFiles(p_dir))
            {
                this._stats.Searched();
                
                foreach (var rule in p_rules)
                {
                    var match = Regex.Match(Path.GetFileName(file), rule.FindPattern);
                    if (match.Success)
                    {
                        this._stats.Found(rule.FindPattern);
                        var newName = rule.RenamingPattern;
                        if (rule.Numbered)
                        {
                            var numMatch = Regex.Match(newName, "#+");
                            newName = newName.Replace(numMatch.Value, rule.NextNumber.ToString("D" + rule.NumberLength.ToString()));
                        }
                        try {
                            if (!Settings.Default.CopyFirst)
                                File.Move(file, Path.GetDirectoryName(file) + Path.DirectorySeparatorChar + newName);
                            else
                                File.Copy(file, Path.GetDirectoryName(file) + Path.DirectorySeparatorChar + newName);
                        }
                        catch { errorcheck = true; }
                        if (!errorcheck)
                        {
                            this._stats.Renamed(rule.FindPattern, newName, file);
                            fileList.Add(file);
                        }
                        errorcheck = false;
                    }
                }
            }

            return fileList;
        }

        //NOT IMPLEMENTED################################
        /// <summary>
        /// Searches the specified directory using the specified rule. (Not yet implemented)
        /// </summary>
        /// <param name="p_dir">the path to the directory to be searched</param>
        /// <param name="p_rule">the rule to use while searching</param>
        private void Search(string p_dir, KeyValuePair<string, string> p_rule)
        {
            //to be implemented
        }
    }
}
