using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renamepler
{
    [Serializable]
    public class Rule
    {
        private string _find;
        private string _rename;
        private int _numberOfNumbers;
        private bool _numbered = false;
        private bool _continuousNumbering;
        private bool _regex;
        private int _currentNumber = 0;

        /// <summary>
        /// Creates a Rule object.
        /// </summary>
        /// <param name="p_find">the search pattern for the rule</param>
        /// <param name="p_rename">the renaming pattern for the rule</param>
        /// <param name="p_cont">indicates whether the numbering should be continuous through subdirectories</param>
        /// <param name="p_regex">indicates whether the search pattern is a regex</param>
        public Rule(string p_find, string p_rename, bool p_cont, bool p_regex)
        {
            this._find = p_find;
            this._rename = p_rename;

            if (this._rename.Contains('#'))
            {
                this._numbered = true;
                this._numberOfNumbers = this._rename.Count(s => s == '#');
            }

            this.ContinuousNumbering = p_cont;
            this._regex = p_regex;
        }

        private void ChangeRenamingPattern(string p_pattern)
        {
            if (p_pattern.Contains('#'))
            {
                this._numbered = true;
                this._numberOfNumbers = p_pattern.Count(s => s == '#');
            }

            this._rename = p_pattern;
        }

        /// <summary>
        /// Indicates whether the numbering should be continuous through subdirectories.
        /// </summary>
        public bool ContinuousNumbering
        {
            get { return this._continuousNumbering; }
            set { this._continuousNumbering = value && this._numbered; }
        }

        /// <summary>
        /// The search pattern for this rule.
        /// </summary>
        public string FindPattern
        {
            get { return this._find; }
            set { this._find = value; }
        }

        /// <summary>
        /// Number of digits in the renaming pattern.
        /// </summary>
        public int NumberLength
        {
            get { return this._numberOfNumbers; }
            set { }
        }

        /// <summary>
        /// The next number in the numbering pattern.
        /// </summary>
        public int NextNumber
        {
            get { return ++this._currentNumber; }
            set { }
        }

        /// <summary>
        /// Indicates whether the renaming pattern contains numbering.
        /// </summary>
        public bool Numbered
        {
            get { return this._numbered; }
            set { }
        }

        /// <summary>
        /// Indicates whether the search pattern is a RegEx.
        /// </summary>
        public bool Regex
        {
            get { return this._regex; }
            set { this._regex = value; }
        }

        /// <summary>
        /// The renaming pattern for this rule.
        /// </summary>
        public string RenamingPattern
        {
            get { return this._rename; }
            set { this.ChangeRenamingPattern(value); }
        }

        /// <summary>
        /// Resets the number of the naming pattern.
        /// </summary>
        public void ResetNumbering() { if (!this._continuousNumbering) this._currentNumber = 0; }

        /// <summary>
        /// Updates the Rule with new parameters.
        /// </summary>
        /// <param name="p_find">the new search pattern</param>
        /// <param name="p_rename">the new renaming pattern</param>
        /// <param name="p_cont">indicates continuous numbering</param>
        /// <param name="p_regex">indicates the search pattern is a regex</param>
        public void Update(string p_find, string p_rename, bool p_cont, bool p_regex)
        {
            this.FindPattern = p_find;
            this.ChangeRenamingPattern(p_rename);
            this._regex = p_regex;
            this.ContinuousNumbering = p_cont;
        }
    }
}
