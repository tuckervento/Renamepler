using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Renamepler
{
    /// <summary>
    /// A window allowing the user to restore previously serialized RuleSet objects from %APPDATA%/Bitslave/Renamepler/.
    /// </summary>
    public partial class LoadRulesWindow : Form
    {
        private StringBuilder _load;

        /// <summary>
        /// Creates a window allowing the user to restore previously serialized RuleSet objects from %APPDATA%/Bitslave/Renamepler/.
        /// </summary>
        /// <param name="p_load">reference to the StringBuilder object that will contain the load name</param>
        /// <param name="p_loadType">int indicating type of load function (0 = rule set load, 1 = statistics load)</param>
        public LoadRulesWindow(ref StringBuilder p_load, int p_loadType)
        {
            InitializeComponent();
            this._load = p_load;
            
            var typeString = "";

            //Switch case to set the type of the load
            switch (p_loadType)
            {
                case 0:
                    typeString = "_rules";
                    break;
                case 1:
                    typeString = "_stats";
                    break;
            }

            var list = Directory.GetFiles(Start._appData, "*" + typeString + ".bin");

            foreach (var item in list)
                this.rulesListBox.Items.Add(Path.GetFileNameWithoutExtension(item).Replace(typeString, ""));
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            this._load = this._load.Append((string)this.rulesListBox.SelectedItem);
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose(); //if they are canceling we don't care about this memory
        }
    }
}
