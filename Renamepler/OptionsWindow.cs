using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Renamepler.Properties;

namespace Renamepler
{
    /// <summary>
    /// A window allowing the user to select various Renamepler options.
    /// </summary>
    public partial class OptionsWindow : Form
    {
        /// <summary>
        /// Creates a window allowing the user to select various Renamepler options.
        /// </summary>
        public OptionsWindow()
        {
            InitializeComponent();

            this.SetupOptions();
        }

        /// <summary>
        /// Sets up options window with gathered settings.
        /// </summary>
        private void SetupOptions()
        {
            this.confirmClearCheck.Checked = Settings.Default.AskBeforeClear;
            this.confirmLoadCheck.Checked = Settings.Default.AskBeforeLoad;
            this.archiveCheck.Checked = Settings.Default.SaveStatistics;
            this.copyCheck.Checked = Settings.Default.CopyFirst;
            this.openDirCheck.Checked = Settings.Default.OpenDirectory;
            this.saveNameCheck.Checked = Settings.Default.OverallFilenames || Settings.Default.PerRuleFilenames;
            this.overallFilenameCheck.Enabled = this.saveNameCheck.Checked && !Settings.Default.CopyFirst;
            this.perRuleFilenameCheck.Enabled = this.saveNameCheck.Checked;
            this.overallFilenameCheck.Checked = Settings.Default.OverallFilenames || Settings.Default.CopyFirst;
            this.perRuleFilenameCheck.Checked = Settings.Default.PerRuleFilenames;
            this.overallStatCheck.Checked = Settings.Default.OverallStats || Settings.Default.CopyFirst;
            this.overallStatCheck.Enabled = !Settings.Default.CopyFirst;
            this.perRuleStatCheck.Checked = Settings.Default.PerRuleStats;
            this.recursiveCheck.Checked = Settings.Default.RecursiveSearch;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Settings.Default.AskBeforeClear = this.confirmClearCheck.Checked;
            Settings.Default.AskBeforeLoad = this.confirmLoadCheck.Checked;
            Settings.Default.SaveStatistics = this.archiveCheck.Checked;
            Settings.Default.CopyFirst = this.copyCheck.Checked;
            Settings.Default.OpenDirectory = this.openDirCheck.Checked;
            Settings.Default.PerRuleStats = this.perRuleStatCheck.Checked;
            Settings.Default.OverallStats = this.overallStatCheck.Checked;
            Settings.Default.OverallFilenames = this.overallFilenameCheck.Checked;
            Settings.Default.PerRuleFilenames = this.perRuleFilenameCheck.Checked;
            Settings.Default.RecursiveSearch = this.recursiveCheck.Checked;
            Settings.Default.Save();
            this.Close();
            this.Dispose();
        }

        private void saveNameCheck_CheckedChanged(object sender, EventArgs e)
        {
            //Logic dictating the enabled status of the two filename options
            this.perRuleFilenameCheck.Enabled = this.saveNameCheck.Checked && this.perRuleStatCheck.Checked;
            this.perRuleFilenameCheck.Checked = this.saveNameCheck.Checked && this.perRuleStatCheck.Checked && Settings.Default.PerRuleFilenames;
            this.overallFilenameCheck.Enabled = this.saveNameCheck.Checked && this.overallStatCheck.Checked;
            this.overallFilenameCheck.Checked = this.saveNameCheck.Checked && this.overallStatCheck.Checked && Settings.Default.OverallFilenames;
        }

        private void overallStatCheck_CheckedChanged(object sender, EventArgs e)
        {
            this.overallFilenameCheck.Enabled = this.overallStatCheck.Checked && this.saveNameCheck.Checked;
            this.overallFilenameCheck.Checked = this.overallStatCheck.Checked && this.saveNameCheck.Checked && Settings.Default.OverallFilenames;
        }

        private void perRuleStatCheck_CheckedChanged(object sender, EventArgs e)
        {
            this.perRuleFilenameCheck.Enabled = this.perRuleStatCheck.Checked && this.saveNameCheck.Checked;
            this.perRuleFilenameCheck.Checked = this.perRuleStatCheck.Checked && this.saveNameCheck.Checked && Settings.Default.PerRuleFilenames;
        }

        //Contains confusing logic for the overall statistics required by the copy-and-delete feature
        private void copyCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.copyCheck.Checked && (MessageBox.Show("Are you sure you want to change this?  Doing so will result in matched files immediately being re-named, and if any files share a new name they will overwrite each other! (NOTE: An undo feature is planned but not currently implemented)", "Overwrite Warning", MessageBoxButtons.YesNo) != DialogResult.Yes))
                this.copyCheck.Checked = true;

            if (this.copyCheck.Checked)
            {
                this.toolTip.SetToolTip(this.overallStatCheck, "This option is required if you want to copy files during the search and delete afterwards");
                this.toolTip.SetToolTip(this.overallFilenameCheck, "This option is required if you want to copy files during the search and delete afterwards");
                this.toolTip.SetToolTip(this.saveNameCheck, "This option is required if you want to copy files during the search and delete afterwards");
            }
            else
            {
                this.toolTip.SetToolTip(this.overallStatCheck, "Display relevant statistics across all rules (does not interfere with per-rule statistics)");
                this.toolTip.SetToolTip(this.overallFilenameCheck, "");
                this.toolTip.SetToolTip(this.saveNameCheck, "Renamepler will display old filenames and their associated new name along with the generated statistics");
            }

            this.saveNameCheck.Checked = this.copyCheck.Checked || Settings.Default.OverallFilenames || Settings.Default.PerRuleFilenames;
            this.saveNameCheck.Enabled = !this.copyCheck.Checked;
            this.overallStatCheck.Checked = this.copyCheck.Checked || Settings.Default.OverallStats;
            this.overallStatCheck.Enabled = !this.copyCheck.Checked;
            this.overallFilenameCheck.Checked = this.copyCheck.Checked || Settings.Default.OverallFilenames;
            this.overallFilenameCheck.Enabled = !this.copyCheck.Checked;
        }
    }
    /// <summary>
    /// An object representing user options within Renamepler. (Deprecated in favor of .NET Settings object)
    /// </summary>
    public class RenameplerOptions
    {
        private bool _openExplorer;
        private bool _overallStats;
        private bool _perRuleStats;
        private bool _overallFilenames;
        private bool _perRuleFilenames;
        private bool _recursiveSearch;

        /// <summary>
        /// Creates an object representing user options within Renamepler.
        /// </summary>
        /// <param name="p_settings">the default loaded user settings</param>
        public RenameplerOptions()
        {
            this._openExplorer = Settings.Default.OpenDirectory;
            this._overallFilenames = Settings.Default.OverallFilenames;
            this._overallStats = Settings.Default.OverallStats;
            this._perRuleFilenames = Settings.Default.PerRuleFilenames;
            this._perRuleStats = Settings.Default.PerRuleStats;
            this._recursiveSearch = Settings.Default.RecursiveSearch;
        }

        /// <summary>
        /// Saves the current RenameplerOptions object to user settings.
        /// </summary>
        public void SaveOptions()
        {
            Settings.Default.OpenDirectory = this._openExplorer;
            Settings.Default.OverallFilenames = this._overallFilenames;
            Settings.Default.OverallStats = this._overallStats;
            Settings.Default.PerRuleFilenames = this._perRuleFilenames;
            Settings.Default.PerRuleStats = this._perRuleStats;
            Settings.Default.RecursiveSearch = this._recursiveSearch;
            Settings.Default.Save();
        }

        /// <summary>
        /// Indicates whether the Renamepler should open an explorer window of the topmost directory after searching is completed.
        /// </summary>
        public bool OpenExplorer
        {
            get { return this._openExplorer; }
            set { this._openExplorer = value; }
        }

        public bool RecursiveSearch
        {
            get { return this._recursiveSearch; }
            set { this._recursiveSearch = value; }
        }

        /// <summary>
        /// Indicates whether the Renamepler should save original filenames for the overall search.
        /// </summary>
        public bool OverallSaveFilenames
        {
            get { return this._overallFilenames; }
            set { this._overallFilenames = value; }
        }

        /// <summary>
        /// Indicates whether the Renamepler should save original filenames per rule of the search.
        /// </summary>
        public bool PerRuleSaveFilenames
        {
            get { return this._perRuleFilenames; }
            set { this._perRuleFilenames = value; }
        }

        /// <summary>
        /// Indicates whether the Renamepler should generate overall statistics for the search.
        /// </summary>
        public bool OverallStats
        {
            get { return this._overallStats; }
            set { this._overallStats = value; }
        }

        /// <summary>
        /// Indicates whether the Renamepler should generate statistics per rule of the search.
        /// </summary>
        public bool PerRuleStats
        {
            get { return this._perRuleStats; }
            set { this._perRuleStats = value; }
        }
    }
}
