using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Renamepler
{
    /// <summary>
    /// A set of renaming rules.
    /// </summary>
    [Serializable]
    public class RuleSet
    {
        private Dictionary<string, List<string>> _fileList;
        private List<Rule> _rules;
        //key is search, value is rename
        private string _ruleDisplay;
        private string _setName;

        /// <summary>
        /// Creates a set of renaming rules.
        /// </summary>
        public RuleSet()
        {
            this._fileList = new Dictionary<string, List<string>>();
            this._rules = new List<Rule>();
            this._ruleDisplay = "";
            this._setName = "Unnamed";
        }

        /// <summary>
        /// Checks the input string against all search pattern strings in the present rules.
        /// </summary>
        /// <param name="p_find">the search pattern to search for</param>
        private int CheckIfExists(string p_find)
        {
            int check = -1;

            foreach (var rule in this._rules)
                if (rule.FindPattern.Equals(p_find))
                    check = this._rules.IndexOf(rule);

            return check;
        }

        /// <summary>
        /// Updates the _ruleDisplay string for any new or changed rules.
        /// </summary>
        private void UpdateDisplayString()
        {
            this._ruleDisplay = "";

            foreach (var rule in this._rules)
                this._ruleDisplay += rule.FindPattern + "\t\t-->\t\t" + rule.RenamingPattern + "\n";
        }

        /// <summary>
        /// A collection of all the lists of renamed files, ordered by the directories they were contained in.
        /// </summary>
        public Dictionary<string, List<String>> FileListCollection
        {
            get { return this._fileList; }
            set { }
        }

        /// <summary>
        /// A list of all current rules.
        /// </summary>
        public List<Rule> RuleList
        {
            get { return this._rules; }
            set { }
        }

        /// <summary>
        /// An identifier for the RuleSet.
        /// </summary>
        public string SetName
        {
            get { return this._setName; }
            set { this._setName = value; }
        }

        /// <summary>
        /// Adds a list of files renamed within a specified directory for the RuleSet. (if a list exists for the directory, it will be overwritten)
        /// </summary>
        /// <param name="p_dir">the directory searched</param>
        /// <param name="p_list">the list of files renamed</param>
        public void AddFileList(string p_dir, List<string> p_list)
        {
            if (this._fileList.Keys.Contains(p_dir))
                this._fileList[p_dir] = p_list;
            else
                this._fileList.Add(p_dir, p_list);
        }

        /// <summary>
        /// Adds a rule to the rule set.
        /// </summary>
        /// <param name="p_find">the search pattern for this rule</param>
        /// <param name="p_rename">the renaming pattern for this rule</param>
        /// <param name="p_contNumb">indicates whether the numbering should be continuous through any subdirectories</param>
        /// <param name="p_regex">indicates whether the search pattern is a regex</param>
        /// <returns>0 - successful add, 1 - illegal character, 2 - p_find exists in the rule set, 3 - p_find or p_replace is empty, -1 - attempting to use an unsupported feature</returns>
        public int AddRule(string p_find, string p_rename, bool p_contNumb, bool p_regex)
        {
            if (p_rename.Contains('&'))
                return -1;
            Regex containsABadCharacter = new Regex("[" + Regex.Escape(new string(System.IO.Path.GetInvalidPathChars())) + "]");
            if (containsABadCharacter.IsMatch(p_find) || containsABadCharacter.IsMatch(p_rename)) { return 1; }
            if (p_find.Trim().Equals("")) { return 3; }
            if (p_rename.Trim().Equals("")) { return 4; }
            var check = this.CheckIfExists(p_find);
            if (check == -1)
            {
                this._rules.Add(new Rule(p_find, p_rename, p_contNumb, p_regex));
                this._ruleDisplay += p_find + "\t\t-->\t\t" + p_rename + "\n";
                return 0;
            }
            else
                return 2;
        }

        /// <summary>
        /// Resets numbering of any naming patterns not using continuous numbering.
        /// </summary>
        public void CleanNumbers()
        {
            foreach (var rule in this._rules)
                if (!rule.ContinuousNumbering)
                    rule.ResetNumbering();
        }

        /// <summary>
        /// Edits an existing rule of the rule set.
        /// </summary>
        /// <param name="p_rule">the existing rule to edit</param>
        /// <param name="p_find">the new search pattern</param>
        /// <param name="p_rename">the new renaming pattern</param>
        /// <param name="p_contNumb">indicates continuous numbering</param>
        /// <param name="p_regex">indicates regex search pattern</param>
        public int EditRule(ref Rule p_rule, string p_find, string p_rename, bool p_contNumb, bool p_regex)
        {
            int check = this.AddRule(p_rule.FindPattern, p_rename, p_contNumb, p_regex);
            if (check != 2)
                return check;
            check = this.AddRule(p_find, "", p_contNumb, p_regex);
            if (check != 4)
                return check;

            this._rules[this._rules.IndexOf(p_rule)].RenamingPattern = p_rename;
            this._rules[this._rules.IndexOf(p_rule)].FindPattern = p_find;
            this._rules[this._rules.IndexOf(p_rule)].Regex = p_regex;
            this._rules[this._rules.IndexOf(p_rule)].ContinuousNumbering = p_contNumb;

            this.UpdateDisplayString();

            return 0;
        }

        /// <summary>
        /// Returns the Rule object corresponding to the specified search pattern string.
        /// </summary>
        /// <param name="p_find">the search pattern to search for</param>
        public Rule GetRule(string p_find)
        {
            foreach (var rule in this._rules)
                if (rule.FindPattern.Equals(p_find))
                    return rule;
            return null;
        }

        /// <summary>
        /// Returns a bool indicating whether or not the rule set is empty.
        /// </summary>
        public bool IsEmpty() { return (this._rules.Count == 0); }

        /// <summary>
        /// Returns a formatted string representing the current rule set.
        /// </summary>
        public override string ToString() { return "Rule Set: " + this._setName + "\n\n" + this._ruleDisplay; }
    }
}
