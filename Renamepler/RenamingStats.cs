using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renamepler
{
    /// <summary>
    /// Object containing necessary statistics for each Renamepler operation.
    /// </summary>
    [Serializable]
    public class RenamingStats
    {
        /// <summary>
        /// Object containing actual integers for renaming statistics, used only internally by RenamingStats
        /// </summary>
        [Serializable]
        private class InternalStats
        {
            private int _searched;
            private int _found;
            private int _renamed;
            private Dictionary<string, string> _oldNames;

            /// <summary>
            /// Creates an InternalStats object.
            /// </summary>
            public InternalStats()
            {
                this._searched = 0;
                this._found = 0;
                this._renamed = 0;
                this._oldNames = new Dictionary<string, string>();
            }

            /// <summary>
            /// The number of files searched.
            /// </summary>
            public int TotalSearched { get { return this._searched; } }

            /// <summary>
            /// The number of matches found.
            /// </summary>
            public int TotalFound { get { return this._found; } }

            /// <summary>
            /// The number of files renamed.
            /// </summary>
            public int TotalRenamed { get { return this._renamed; } }

            /// <summary>
            /// The list of old filenames (key is new name, value is previous name).
            /// </summary>
            public Dictionary<string, string> OldFilenames { get { return this._oldNames; } }

            /// <summary>
            /// Increments the number of files searched.
            /// </summary>
            public void Searched()
            {
                this._searched++;
            }

            /// <summary>
            /// Increments the number of matches found.
            /// </summary>
            public void Found()
            {
                this._found++;
            }

            /// <summary>
            /// Increments the number of matches renamed.
            /// </summary>
            public void Renamed()
            {
                this._renamed++;
            }

            /// <summary>
            /// Adds an old name to the records.
            /// </summary>
            /// <param name="p_name">new name of the file</param>
            /// <param name="p_oldName"> previous name of the file</param>
            public void AddOldName(string p_name, string p_oldName)
            {
                this._oldNames.Add(p_name, p_oldName);
            }
        }

        private Dictionary<string, InternalStats> _perRule;
        private InternalStats _overall;

        /// <summary>
        /// Creates an object containing necessary statistics for each Renamepler operation.
        /// </summary>
        /// <param name="p_ruleSet">the set of rules for the current operation</param>
        public RenamingStats(List<Rule> p_ruleSet)
        {
            this._perRule = new Dictionary<string, InternalStats>();
            this._overall = new InternalStats();

            foreach (var rule in p_ruleSet)
                this._perRule.Add(rule.FindPattern, new InternalStats());
        }

        /// <summary>
        /// Increments the number of files searched.
        /// </summary>
        public void Searched()
        {
            this._overall.Searched();
        }

        /// <summary>
        /// Increments the number of matches found using a given search string.
        /// </summary>
        /// <param name="p_find">the matched string</param>
        public void Found(string p_find)
        {
            this._overall.Found();
            this._perRule[p_find].Found();
        }

        /// <summary>
        /// Increments the number of matches renamed using a given renaming pattern.
        /// </summary>
        /// <param name="p_rename">the search pattern used</param>
        public void Renamed(string p_find)
        {
            this._overall.Renamed();
            this._perRule[p_find].Renamed();
        }

        /// <summary>
        /// A list of the rules used in this search.
        /// </summary>
        public List<string> RuleList
        {
            get { return this._perRule.Keys.ToList<string>(); }
            set { }
        }

        /// <summary>
        /// Increments the number of matches renamed using a given renaming pattern.
        /// </summary>
        /// <param name="p_find">the search pattern used</param>
        /// <param name="p_newName">the new filename</param>
        /// <param name="p_oldName">the previous filename</param>
        public void Renamed(string p_find, string p_newName, string p_oldName)
        {
            this.Renamed(p_find);
            this._overall.AddOldName(p_newName, p_oldName);
            this._perRule[p_find].AddOldName(p_newName, p_oldName);
        }

        /// <summary>
        /// The total number of files searched.
        /// </summary>
        public int TotalSearched { get { return this._overall.TotalSearched; } }

        /// <summary>
        /// The total number of matches found.
        /// </summary>
        public int TotalFound { get { return this._overall.TotalFound; } }

        /// <summary>
        /// The total number of files renamed.
        /// </summary>
        public int TotalRenamed { get { return this._overall.TotalRenamed; } }

        /// <summary>
        /// The list of old filenames. (key is new name, value is old name)
        /// </summary>
        public Dictionary<string, string> OldFilenames { get { return this._overall.OldFilenames; } }

        /// <summary>
        /// Returns the number of files matched for the given search pattern .
        /// </summary>
        /// <param name="p_find">the search pattern you want statistics for</param>
        public int FoundForRule(string p_find)
        {
            return this._perRule[p_find].TotalFound;
        }

        /// <summary>
        /// Returns the number of files renamed for the given search pattern.
        /// </summary>
        /// <param name="p_find">the search pattern you want statistics for</param>
        public int RenamedForRule(string p_find)
        {
            return this._perRule[p_find].TotalRenamed;
        }

        /// <summary>
        /// Returns the list of old filenames. (key is new name, value is old name)
        /// </summary>
        /// <param name="p_find">the search pattern you want statistics for</param>
        public Dictionary<string, string> FilenamesForRule(string p_find)
        {
            return this._perRule[p_find].OldFilenames;
        }
    }
}
