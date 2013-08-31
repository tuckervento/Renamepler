namespace Renamepler
{
    partial class OptionsWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsWindow));
            this.openDirCheck = new System.Windows.Forms.CheckBox();
            this.saveNameCheck = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.perRuleStatCheck = new System.Windows.Forms.CheckBox();
            this.overallStatCheck = new System.Windows.Forms.CheckBox();
            this.overallFilenameCheck = new System.Windows.Forms.CheckBox();
            this.perRuleFilenameCheck = new System.Windows.Forms.CheckBox();
            this.recursiveCheck = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.optionsLabel = new System.Windows.Forms.Label();
            this.settingsLabel = new System.Windows.Forms.Label();
            this.confirmLoadCheck = new System.Windows.Forms.CheckBox();
            this.confirmClearCheck = new System.Windows.Forms.CheckBox();
            this.archiveCheck = new System.Windows.Forms.CheckBox();
            this.copyCheck = new System.Windows.Forms.CheckBox();
            this.postOptions = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openDirCheck
            // 
            this.openDirCheck.AutoSize = true;
            this.openDirCheck.Location = new System.Drawing.Point(30, 166);
            this.openDirCheck.Name = "openDirCheck";
            this.openDirCheck.Size = new System.Drawing.Size(187, 17);
            this.openDirCheck.TabIndex = 0;
            this.openDirCheck.Text = "Open topmost directory in Explorer";
            this.toolTip.SetToolTip(this.openDirCheck, "An Explorer window containing your selected directory will open when the search c" +
        "ompletes");
            this.openDirCheck.UseVisualStyleBackColor = true;
            // 
            // saveNameCheck
            // 
            this.saveNameCheck.AutoSize = true;
            this.saveNameCheck.Location = new System.Drawing.Point(30, 235);
            this.saveNameCheck.Name = "saveNameCheck";
            this.saveNameCheck.Size = new System.Drawing.Size(225, 17);
            this.saveNameCheck.TabIndex = 1;
            this.saveNameCheck.Text = "Display filename records associated with...";
            this.toolTip.SetToolTip(this.saveNameCheck, "Renamepler will display old filenames and their associated new name along with th" +
        "e generated statistics");
            this.saveNameCheck.UseVisualStyleBackColor = true;
            this.saveNameCheck.CheckedChanged += new System.EventHandler(this.saveNameCheck_CheckedChanged);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(164, 303);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(34, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "OK";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // perRuleStatCheck
            // 
            this.perRuleStatCheck.AutoSize = true;
            this.perRuleStatCheck.Location = new System.Drawing.Point(30, 212);
            this.perRuleStatCheck.Name = "perRuleStatCheck";
            this.perRuleStatCheck.Size = new System.Drawing.Size(134, 17);
            this.perRuleStatCheck.TabIndex = 3;
            this.perRuleStatCheck.Text = "Show per-rule statistics";
            this.toolTip.SetToolTip(this.perRuleStatCheck, "Display relevant statistics per-rule (does not interfere with overall statistics)" +
        "");
            this.perRuleStatCheck.UseVisualStyleBackColor = true;
            this.perRuleStatCheck.CheckedChanged += new System.EventHandler(this.perRuleStatCheck_CheckedChanged);
            // 
            // overallStatCheck
            // 
            this.overallStatCheck.AutoSize = true;
            this.overallStatCheck.Location = new System.Drawing.Point(30, 189);
            this.overallStatCheck.Name = "overallStatCheck";
            this.overallStatCheck.Size = new System.Drawing.Size(130, 17);
            this.overallStatCheck.TabIndex = 4;
            this.overallStatCheck.Text = "Show overall statistics";
            this.toolTip.SetToolTip(this.overallStatCheck, "Display relevant statistics across all rules (does not interfere with per-rule st" +
        "atistics)");
            this.overallStatCheck.UseVisualStyleBackColor = true;
            this.overallStatCheck.CheckedChanged += new System.EventHandler(this.overallStatCheck_CheckedChanged);
            // 
            // overallFilenameCheck
            // 
            this.overallFilenameCheck.AutoSize = true;
            this.overallFilenameCheck.Enabled = false;
            this.overallFilenameCheck.Location = new System.Drawing.Point(64, 258);
            this.overallFilenameCheck.Name = "overallFilenameCheck";
            this.overallFilenameCheck.Size = new System.Drawing.Size(144, 17);
            this.overallFilenameCheck.TabIndex = 5;
            this.overallFilenameCheck.Text = "...overall search statistics";
            this.overallFilenameCheck.UseVisualStyleBackColor = true;
            // 
            // perRuleFilenameCheck
            // 
            this.perRuleFilenameCheck.AutoSize = true;
            this.perRuleFilenameCheck.Enabled = false;
            this.perRuleFilenameCheck.Location = new System.Drawing.Point(64, 281);
            this.perRuleFilenameCheck.Name = "perRuleFilenameCheck";
            this.perRuleFilenameCheck.Size = new System.Drawing.Size(113, 17);
            this.perRuleFilenameCheck.TabIndex = 6;
            this.perRuleFilenameCheck.Text = "...per-rule statistics";
            this.perRuleFilenameCheck.UseVisualStyleBackColor = true;
            // 
            // recursiveCheck
            // 
            this.recursiveCheck.AutoSize = true;
            this.recursiveCheck.Location = new System.Drawing.Point(30, 130);
            this.recursiveCheck.Name = "recursiveCheck";
            this.recursiveCheck.Size = new System.Drawing.Size(184, 17);
            this.recursiveCheck.TabIndex = 7;
            this.recursiveCheck.Text = "Recursively search subdirectories";
            this.toolTip.SetToolTip(this.recursiveCheck, "Renamepler will recursively search through every subdirectory contained within yo" +
        "ur specified directory");
            this.recursiveCheck.UseVisualStyleBackColor = true;
            // 
            // optionsLabel
            // 
            this.optionsLabel.AutoSize = true;
            this.optionsLabel.Location = new System.Drawing.Point(12, 114);
            this.optionsLabel.Name = "optionsLabel";
            this.optionsLabel.Size = new System.Drawing.Size(80, 13);
            this.optionsLabel.TabIndex = 8;
            this.optionsLabel.Text = "Search Options";
            this.toolTip.SetToolTip(this.optionsLabel, "These options pertain to actual search operations");
            // 
            // settingsLabel
            // 
            this.settingsLabel.AutoSize = true;
            this.settingsLabel.Location = new System.Drawing.Point(12, 9);
            this.settingsLabel.Name = "settingsLabel";
            this.settingsLabel.Size = new System.Drawing.Size(100, 13);
            this.settingsLabel.TabIndex = 9;
            this.settingsLabel.Text = "Application Settings";
            this.toolTip.SetToolTip(this.settingsLabel, "These are application-wide settings");
            // 
            // confirmLoadCheck
            // 
            this.confirmLoadCheck.AutoSize = true;
            this.confirmLoadCheck.Location = new System.Drawing.Point(30, 25);
            this.confirmLoadCheck.Name = "confirmLoadCheck";
            this.confirmLoadCheck.Size = new System.Drawing.Size(168, 17);
            this.confirmLoadCheck.TabIndex = 10;
            this.confirmLoadCheck.Text = "Confirm before loading rule set";
            this.toolTip.SetToolTip(this.confirmLoadCheck, "This will display a confirmation dialog before loading a rule set (and overwritin" +
        "g current rules!)");
            this.confirmLoadCheck.UseVisualStyleBackColor = true;
            // 
            // confirmClearCheck
            // 
            this.confirmClearCheck.AutoSize = true;
            this.confirmClearCheck.Location = new System.Drawing.Point(30, 48);
            this.confirmClearCheck.Name = "confirmClearCheck";
            this.confirmClearCheck.Size = new System.Drawing.Size(207, 17);
            this.confirmClearCheck.TabIndex = 11;
            this.confirmClearCheck.Text = "Confirm before clearing current rule set";
            this.toolTip.SetToolTip(this.confirmClearCheck, "This will display a confirmation dialog when you clear the rule set");
            this.confirmClearCheck.UseVisualStyleBackColor = true;
            // 
            // archiveCheck
            // 
            this.archiveCheck.AutoSize = true;
            this.archiveCheck.Location = new System.Drawing.Point(30, 71);
            this.archiveCheck.Name = "archiveCheck";
            this.archiveCheck.Size = new System.Drawing.Size(231, 17);
            this.archiveCheck.TabIndex = 13;
            this.archiveCheck.Text = "Archive results and records for each search";
            this.toolTip.SetToolTip(this.archiveCheck, resources.GetString("archiveCheck.ToolTip"));
            this.archiveCheck.UseVisualStyleBackColor = true;
            // 
            // copyCheck
            // 
            this.copyCheck.AutoSize = true;
            this.copyCheck.Location = new System.Drawing.Point(30, 94);
            this.copyCheck.Name = "copyCheck";
            this.copyCheck.Size = new System.Drawing.Size(301, 17);
            this.copyCheck.TabIndex = 14;
            this.copyCheck.Text = "Copy files during search operation, prompt for deletion later";
            this.toolTip.SetToolTip(this.copyCheck, "If this is checked, Renamepler will copy the files using their new names during t" +
        "he search, and after you review the new names and other statistics you will be p" +
        "rompted to delete the old files");
            this.copyCheck.UseVisualStyleBackColor = true;
            this.copyCheck.CheckedChanged += new System.EventHandler(this.copyCheck_CheckedChanged);
            // 
            // postOptions
            // 
            this.postOptions.AutoSize = true;
            this.postOptions.Location = new System.Drawing.Point(12, 150);
            this.postOptions.Name = "postOptions";
            this.postOptions.Size = new System.Drawing.Size(104, 13);
            this.postOptions.TabIndex = 15;
            this.postOptions.Text = "Post-Search Options";
            // 
            // OptionsWindow
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(359, 338);
            this.Controls.Add(this.postOptions);
            this.Controls.Add(this.copyCheck);
            this.Controls.Add(this.archiveCheck);
            this.Controls.Add(this.confirmClearCheck);
            this.Controls.Add(this.confirmLoadCheck);
            this.Controls.Add(this.settingsLabel);
            this.Controls.Add(this.optionsLabel);
            this.Controls.Add(this.recursiveCheck);
            this.Controls.Add(this.perRuleFilenameCheck);
            this.Controls.Add(this.overallFilenameCheck);
            this.Controls.Add(this.overallStatCheck);
            this.Controls.Add(this.perRuleStatCheck);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.saveNameCheck);
            this.Controls.Add(this.openDirCheck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionsWindow";
            this.Text = "Options (mouse-over for help)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox openDirCheck;
        private System.Windows.Forms.CheckBox saveNameCheck;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox perRuleStatCheck;
        private System.Windows.Forms.CheckBox overallStatCheck;
        private System.Windows.Forms.CheckBox overallFilenameCheck;
        private System.Windows.Forms.CheckBox perRuleFilenameCheck;
        private System.Windows.Forms.CheckBox recursiveCheck;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label optionsLabel;
        private System.Windows.Forms.Label settingsLabel;
        private System.Windows.Forms.CheckBox confirmLoadCheck;
        private System.Windows.Forms.CheckBox confirmClearCheck;
        private System.Windows.Forms.CheckBox archiveCheck;
        private System.Windows.Forms.CheckBox copyCheck;
        private System.Windows.Forms.Label postOptions;
    }
}