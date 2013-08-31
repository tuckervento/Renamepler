using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Renamepler.Properties;

namespace Renamepler
{
    /// <summary>
    /// Window containing relevant statistics about a given Renamepler operation.
    /// </summary>
    public partial class StatsWindow : Form
    {
        private string _display;

        /// <summary>
        /// Creates a window containing relevant statistics about a given Renamepler operation.
        /// </summary>
        /// <param name="p_stats">RenamingStats object for the search</param>
        public StatsWindow(RenamingStats p_stats)
        {
            InitializeComponent();

            this.Setup(p_stats);

            this.statsBox.Text = this._display;
        }

        /// <summary>
        /// Sets up the statistics display string.
        /// </summary>
        /// <param name="p_stats">RenamingStats object for the search</param>
        private void Setup(RenamingStats p_stats)
        {
            this._display = "";
            this._display += "DATE: " + DateTime.Now.Date.ToString();
            if (Settings.Default.OverallStats || Settings.Default.CopyFirst) //Overall stats must be shown if the user wants to copy first
            {
                this._display += Environment.NewLine + Environment.NewLine + "OVERALL STATS" + Environment.NewLine + "******************" + 
                    Environment.NewLine + Environment.NewLine + "FILES SEARCHED: " + p_stats.TotalSearched + Environment.NewLine + "FILES MATCHED: " + 
                    p_stats.TotalFound + Environment.NewLine + "FILES RENAMED: " + p_stats.TotalRenamed;
                if (Settings.Default.OverallFilenames)
                {
                    var nameList = p_stats.OldFilenames;
                    this._display += Environment.NewLine + Environment.NewLine + "FILE(S) RENAMED:";

                    foreach (var name in nameList)
                        this._display += Environment.NewLine + "\t" + name.Value + "\t--->\t" + name.Key;
                }
            }

            if (Settings.Default.PerRuleStats)
            {
                this._display += Environment.NewLine + Environment.NewLine + "PER RULE STATS" + Environment.NewLine + "******************";

                foreach (var rule in p_stats.RuleList)
                {
                    this._display += Environment.NewLine + "RULE: " + rule + Environment.NewLine + "FILES MATCHED: " + p_stats.FoundForRule(rule) + 
                        Environment.NewLine + "FILES RENAMED: " + p_stats.RenamedForRule(rule);

                    if (Settings.Default.PerRuleFilenames)
                    {
                        var nameList = p_stats.FilenamesForRule(rule);
                        this._display += Environment.NewLine + Environment.NewLine + "FILE(S) RENAMED:";

                        foreach (var name in nameList)
                            this._display += Environment.NewLine + "\t" + name.Value + "\t--->\t" + name.Key;
                    }
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, this._display);
                Process.Start(saveFileDialog.FileName);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
