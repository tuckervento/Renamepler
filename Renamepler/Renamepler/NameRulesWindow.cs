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
    //DEPRECATED##################################
    /// <summary>
    /// A window allowing the user to name a specified RuleSet. (Deprecated in favor of CustomDialog)
    /// </summary>
    public partial class NameRulesWindow : Form
    {
        private RuleSet _rules;

        /// <summary>
        /// Creates a window allowing the user to name a specified RuleSet.
        /// </summary>
        /// <param name="p_rules">reference to the RuleSet object being named</param>
        public NameRulesWindow(ref RuleSet p_rules)
        {
            InitializeComponent();
            this._rules = p_rules;
        }

        private void saveNameButton_Click(object sender, EventArgs e)
        {
            var regex = new Regex("[" + Regex.Escape(new string(System.IO.Path.GetInvalidPathChars())) + "]");
            if (this.nameBox.Text.Equals("[Enter name for this set of rules]"))
                MessageBox.Show("Enter a name for this set of rules!", "Error: No name!", MessageBoxButtons.OK);
            else if (regex.IsMatch(this.nameBox.Text))
                MessageBox.Show("Invalid name!  Please try again.", "Error: Invalid name", MessageBoxButtons.OK);
            else
            {
                this._rules.SetName = this.nameBox.Text;
                this.Close();
            }
        }
    }
}
