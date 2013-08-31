using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renamepler
{
    class Rule
    {
        private string _find;
        private string _rename;
        private bool _numbered = false;
        private bool _continuousNumbering = false;
        private int _currentNumber = 0;

        /// <summary>
        /// Creates a Rule object.
        /// </summary>
        /// <param name="p_find">the search pattern for the rule</param>
        /// <param name="p_rename">the renaming pattern for the rule</param>
        public Rule(string p_find, string p_rename)
        {
            this._find = p_find;
            this._rename = p_rename;

            if (this._rename.Contains('#'))
                this._numbered = true;
        }

        /// <summary>
        /// Creates a Rule object.
        /// </summary>
        /// <param name="p_find">the search pattern for the rule</param>
        /// <param name="p_rename">the renaming pattern for the rule</param>
        /// <param name="p_cont">indicating whether the numbering should be continuous through subdirectories</param>
        public Rule(string p_find, string p_rename, bool p_cont)
        {
            this._find = p_find;
            this._rename = p_rename;

            if (this._rename.Contains('#'))
                this._numbered = true;

            this._continuousNumbering = p_cont;
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
        /// Indicates the current number of the numbering system, and increments to the next one.
        /// </summary>
        public int CurrentNumber
        {
            get { return ++this._currentNumber; }
            set { }
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
        /// The renaming pattern for this rule.
        /// </summary>
        public string RenamingPattern
        {
            get { return this._rename; }
            set { this._rename = value; }
        }
    }
}
