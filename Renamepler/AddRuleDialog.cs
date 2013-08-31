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
        private bool _edit = false;
        private Rule _rule;

        /// <summary>
        /// Creates a dialog allowing the user to enter renaming rules.
        /// </summary>
        /// <param name="p_rules">the current rule set</param>
        public AddRuleDialog(ref RuleSet p_rules)
        {
            InitializeComponent();
            this._rules = p_rules;
        }

        /// <summary>
        /// Creates a dialog allowing the user to edit a current rule.
        /// </summary>
        /// <param name="p_rules">the current rule set</param>
        /// <param name="p_rule">the rule to edit</param>
        public AddRuleDialog(ref RuleSet p_rules, ref Rule p_rule)
        {
            InitializeComponent();
            this._rules = p_rules;
            this._edit = true;
            this._rule = p_rule;
            this.SetupFields();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!regexCheck.Checked) //if the Regex option is selected, we assume that the user properly escaped any necessary characters
                this.findBox.Text = Regex.Escape(this.findBox.Text);
            int check = 99;
            if (!this._edit)
                check = this._rules.AddRule(this.findBox.Text, this.replaceBox.Text, this.continuousCheck.Checked, this.regexCheck.Checked);
            else
                check = this._rules.EditRule(ref this._rule, this.findBox.Text, this.replaceBox.Text, this.continuousCheck.Checked, this.regexCheck.Checked);
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
                    MessageBox.Show("Search pattern must not be empty!", "Empty String Error", MessageBoxButtons.OK);
                    break;
                case 4:
                    MessageBox.Show("Renaming pattern must not be empty!", "Empty String Error", MessageBoxButtons.OK);
                    break;
                case -1:
                    MessageBox.Show("Preserving previous numbering systems is not currently supported.  Sorry!", "Feature Not Implemented", MessageBoxButtons.OK);
                    break;
                default:
                    break;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose(); //if the user cancels we don't want to hold onto these references
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            var help = new HelpWindow();
            help.ShowDialog();
        }

        /// <summary>
        /// Sets up the fields of AddRuleDialog using the values of _rule.
        /// </summary>
        private void SetupFields()
        {
            this.findBox.Text = this._rule.FindPattern;
            this.replaceBox.Text = this._rule.RenamingPattern;
            this.continuousCheck.Checked = this._rule.ContinuousNumbering;
            this.regexCheck.Checked = this._rule.Regex;
        }
    }
}
