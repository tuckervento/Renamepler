using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Renamepler
{
    /// <summary>
    /// A window allowing the user to serialize and save a RuleSet object for later retrieval at %APPDATA%/Bitslave/Renamepler/.
    /// </summary>
    public partial class SaveRulesWindow : Form
    {
        private StringBuilder _loc;

        /// <summary>
        /// Creates a window allowing the user to serialize and save a RuleSet object for later retrieval at %APPDATA%/Bitslave/Renamepler/.
        /// </summary>
        /// <param name="p_loc">reference to the StringBuilder object that will contain the save name</param>
        /// <param name="p_curName">current name given for a rule set</param>
        public SaveRulesWindow(ref StringBuilder p_loc, string p_curName)
        {
            if (!p_curName.Equals("Unnamed"))
                this.nameBox.Text = p_curName;
            InitializeComponent();
            this._loc = p_loc;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var regex = new Regex("[" + Regex.Escape(new string(System.IO.Path.GetInvalidPathChars())) + "]");
            if (this.nameBox.Text.Equals("[Enter name for this set of rules]"))
                MessageBox.Show("Enter a name for this set of rules!", "Error: No name!", MessageBoxButtons.OK);
            else if (regex.IsMatch(this.nameBox.Text))
                MessageBox.Show("Invalid name!  Please try again.", "Error: Invalid name", MessageBoxButtons.OK);
            else if (this.nameBox.Text.Equals(""))
                MessageBox.Show("Your name can not be empty!  Please try again.", "Error: Invalid name", MessageBoxButtons.OK);
            else
            {
                this._loc = this._loc.Clear().Append(this.nameBox.Text); //first clears the string builder to fix the issue of "doubling" the name
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
