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
    /// A help window for the Renamepler.
    /// </summary>
    public partial class HelpWindow : Form
    {
        /// <summary>
        /// A help window for the Renamepler.
        /// </summary>
        public HelpWindow()
        {
            InitializeComponent();
            this.helpBox.Text = "First, enter a search string to identify re-namable files.  This can be a hard-coded string (i.e. \"KICK_01.wav\") " +
                "or a .NET-compliant regular expression (i.e. \"(KICK_)[0-9]+(.wav)\").  If using a regular expression, check the \"Search using RegEx\" box and MAKE SURE YOU USE ESCAPED CHARACTERS WHEN NECESSARY.\n\n" +
                "Next, enter a string used to re-name all matched files.  This can also be hard-coded, but that is inadvisable unless you are CERTAIN " +
                "that there is only one file to be re-named, otherwise files will be continuously overwritten.  Instead, the Renamepler uses a custom incremental naming system " +
                "allowing you to enter any alphanumeric characters along with the reserved special characters '&' and '#'.  Use contiguous #'s to indicate " +
                "the length of the desired numbering system (i.e. \"KICK_##.wav\" will start at KICK_01.wav and continue through KICK_99.wav, \"KICK_###.wav\" " +
                "to KICK_999.wav, etc).  A '&' prefixing the numbering section tells the Renamepler to preserve the numbers from the original filenames (THIS IS CURRENTLY NOT IMPLEMENTED).\n\n" + 
                "If a file matches multiple rules, it will be re-named according to the first rule matched (the highest on the list).  If you want your numbering " + 
                "scheme to be continuous across directories, check the \"Continuous Numbering\" option.  Otherwise, numbering will start over for each directory searched " + 
                "(this includes subdirectories).";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
