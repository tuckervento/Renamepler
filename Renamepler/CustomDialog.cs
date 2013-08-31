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
    /// A customizable dialog class.
    /// </summary>
    public partial class CustomDialog : Form
    {
        /// <summary>
        /// Creates a dialog window with custom text in all fields. (button1 is DialogResult.OK, button2 is DialogResult.Cancel)
        /// </summary>
        /// <param name="p_name">the name of the dialog</param>
        /// <param name="p_text">the message of the dialog</param>
        /// <param name="p_button1">the text to display on the DialogResult.OK button</param>
        /// <param name="p_button2">the text to display on the DialogResult.Cancel button</param>
        public CustomDialog(string p_name, string p_text, string p_button1, string p_button2)
        {
            InitializeComponent();

            this.Text = p_name;
            this.textBox.Text = p_text;
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
        /// The DialogResult type of Button1.
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
        /// The DialogResult type of Button2.
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
        /// The name displayed in the title bar of the dialog.
        /// </summary>
        public string DialogName
        {
            get { return this.Text; }
            set { this.Text = value; }
        }


        /// <summary>
        /// The text displayed by the dialog.
        /// </summary>
        public string DialogText
        {
            get { return this.textBox.Text; }
            set { this.textBox.Text = value; }
        }

        /// <summary>
        /// Allows the user to edit the dialog text box. (useful for custom prompts, CustomDialog does not Dispose() when closing)
        /// </summary>
        public bool EnableEditing
        {
            get { return !this.textBox.ReadOnly; }
            set { this.textBox.ReadOnly = !value; }
        }
    }
}
