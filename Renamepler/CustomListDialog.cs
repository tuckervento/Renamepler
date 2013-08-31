using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Renamepler
{
    /// <summary>
    /// A custom dialog containing a ComboBox object.
    /// </summary>
    public partial class CustomListDialog : Form
    {
        private List<string> _list;
        /// <summary>
        /// Creates a custom dialog containing a ComboBox object.
        /// </summary>
        /// <param name="p_name">the name of the dialog</param>
        /// <param name="p_list">the list to populate the ComboBox</param>
        /// <param name="p_button1">the text to display on the OK button (left button)</param>
        /// <param name="p_button2">the text to display on the Cancel button (right button)</param>
        public CustomListDialog(string p_name, List<string> p_list, string p_button1, string p_button2)
        {
            InitializeComponent();
            this.Text = p_name;
            this.comboBox.Items.AddRange(p_list.ToArray());
            this._list = p_list;
            this.button1.Text = p_button1;
            this.button2.Text = p_button2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// The DialogResult returned by Button1.
        /// </summary>
        public DialogResult Button1Result
        {
            get { return this.button1.DialogResult; }
            set { this.button1.DialogResult = value; }
        }

        /// <summary>
        /// The text displayed on Button1.
        /// </summary>
        public string Button1Text
        {
            get { return this.button1.Text; }
            set { this.button1.Text = value; }
        }

        /// <summary>
        /// The DialogResult returned by Button2.
        /// </summary>
        public DialogResult Button2Result
        {
            get { return this.button2.DialogResult; }
            set { this.button2.DialogResult = value; }
        }

        /// <summary>
        /// The text displayed on Button2.
        /// </summary>
        public string Button2Text
        {
            get { return this.button2.Text; }
            set { this.button2.Text = value; }
        }

        /// <summary>
        /// The source list for the ComboBox.
        /// </summary>
        public List<string> ComboBoxList
        {
            get { return this._list; }
            set
            {
                this._list = value;
                this.comboBox.Items.Clear();
                this.comboBox.Items.AddRange(value.ToArray());
            }
        }

        /// <summary>
        /// The name of the dialog window.
        /// </summary>
        public string DialogName
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        /// <summary>
        /// The currently selected item in the ComboBox.
        /// </summary>
        public string SelectedItem
        {
            get { return (string)this.comboBox.SelectedItem; }
            set { }
        }
    }
}
