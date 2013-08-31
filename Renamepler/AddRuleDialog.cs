using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Renamepler
{   
    /// <summary>
    /// This dialog allows the user to enter renaming rules.
    /// </summary>
    public partial class AddRuleDialog : Form
    {
        private RuleSet _rules;

        /// <summary>
        /// Creates a dialog allowing the user to enter renaming rules.
        /// </summary>
        /// <param name="p_rules">current rule set</param>
        /// <param name="p_numbered">current "numbered" rule list</param>
        public AddRuleDialog(ref RuleSet p_rules)//, ref Dictionary<string, KeyValuePair<bool, KeyValuePair<int, int>>> p_numbered)
        {
            InitializeComponent();
            this._rules = p_rules;
            //this._numbered = p_numbered;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!regexCheck.Checked) //if the Regex option is selected, we assume that the user properly escaped any necessary characters
                findBox.Text = Regex.Escape(findBox.Text);
            var check = this._rules.AddRule(findBox.Text, replaceBox.Text, this.continuousCheck.Checked);
            switch (check){ //handle return value from AddRule
                case 0:
                    this.Close();
                    this.Dispose();
                    break;
                case 1:
                    MessageBox.Show("Strings must not include illegal filename characters!", "Rule Formatting Error", MessageBoxButtons.OK);
                    break;
                case 2:
                    MessageBox.Show("Unable to add rules with duplicate search strings!", "Search Rule Already Exists", MessageBoxButtons.OK);
                    break;
                case 3:
                    MessageBox.Show("Strings must not be empty!", "Empty String Error", MessageBoxButtons.OK);
                    break;
                case -1:
                    MessageBox.Show("Preserving previous numbering systems is not currently supported.  Sorry!", "Feature Not Implemented", MessageBoxButtons.OK);
                    break;
                default:
                    break;
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            var help = new HelpWindow();
            help.ShowDialog();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose(); //if the user cancels we don't want to hold onto these references
        }
    }
}
