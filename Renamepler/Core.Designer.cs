namespace Renamepler
{
    partial class Core
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
            this.ruleButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.dirDialogButton = new System.Windows.Forms.Button();
            this.ruleBox = new System.Windows.Forms.RichTextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.goButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.directoryPanel = new System.Windows.Forms.Panel();
            this.directoryBox = new System.Windows.Forms.TextBox();
            this.secondPanel = new System.Windows.Forms.Panel();
            this.loadPreviousButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.loadRulesButton = new System.Windows.Forms.Button();
            this.saveRulesButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.directoryPanel.SuspendLayout();
            this.secondPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ruleButton
            // 
            this.ruleButton.Location = new System.Drawing.Point(12, 3);
            this.ruleButton.Name = "ruleButton";
            this.ruleButton.Size = new System.Drawing.Size(97, 23);
            this.ruleButton.TabIndex = 0;
            this.ruleButton.Text = "Add Rule";
            this.toolTip.SetToolTip(this.ruleButton, "Click here to add a new renaming rule");
            this.ruleButton.UseVisualStyleBackColor = true;
            this.ruleButton.Click += new System.EventHandler(this.ruleButton_Click);
            // 
            // dirDialogButton
            // 
            this.dirDialogButton.Location = new System.Drawing.Point(12, 3);
            this.dirDialogButton.Name = "dirDialogButton";
            this.dirDialogButton.Size = new System.Drawing.Size(97, 23);
            this.dirDialogButton.TabIndex = 3;
            this.dirDialogButton.Text = "Choose Directory";
            this.toolTip.SetToolTip(this.dirDialogButton, "Select the topmost directory containing files you wish to rename");
            this.dirDialogButton.UseVisualStyleBackColor = true;
            this.dirDialogButton.Click += new System.EventHandler(this.dirDialogButton_Click);
            // 
            // ruleBox
            // 
            this.ruleBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ruleBox.Location = new System.Drawing.Point(12, 32);
            this.ruleBox.Name = "ruleBox";
            this.ruleBox.ReadOnly = true;
            this.ruleBox.Size = new System.Drawing.Size(588, 158);
            this.ruleBox.TabIndex = 5;
            this.ruleBox.Text = "";
            this.toolTip.SetToolTip(this.ruleBox, "This is a list of all current renaming rules");
            // 
            // clearButton
            // 
            this.clearButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.clearButton.Location = new System.Drawing.Point(58, 196);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Clear Rules";
            this.toolTip.SetToolTip(this.clearButton, "Clear all added rules");
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // goButton
            // 
            this.goButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goButton.Location = new System.Drawing.Point(525, 3);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 7;
            this.goButton.Text = "Go!";
            this.toolTip.SetToolTip(this.goButton, "Start renaming");
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // directoryPanel
            // 
            this.directoryPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryPanel.Controls.Add(this.dirDialogButton);
            this.directoryPanel.Controls.Add(this.directoryBox);
            this.directoryPanel.Location = new System.Drawing.Point(0, 3);
            this.directoryPanel.Name = "directoryPanel";
            this.directoryPanel.Size = new System.Drawing.Size(615, 27);
            this.directoryPanel.TabIndex = 1;
            // 
            // directoryBox
            // 
            this.directoryBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryBox.Location = new System.Drawing.Point(115, 5);
            this.directoryBox.Name = "directoryBox";
            this.directoryBox.ReadOnly = true;
            this.directoryBox.Size = new System.Drawing.Size(485, 20);
            this.directoryBox.TabIndex = 2;
            // 
            // secondPanel
            // 
            this.secondPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.secondPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.secondPanel.Controls.Add(this.editButton);
            this.secondPanel.Controls.Add(this.loadPreviousButton);
            this.secondPanel.Controls.Add(this.exitButton);
            this.secondPanel.Controls.Add(this.loadRulesButton);
            this.secondPanel.Controls.Add(this.saveRulesButton);
            this.secondPanel.Controls.Add(this.optionsButton);
            this.secondPanel.Controls.Add(this.goButton);
            this.secondPanel.Controls.Add(this.clearButton);
            this.secondPanel.Controls.Add(this.ruleBox);
            this.secondPanel.Controls.Add(this.ruleButton);
            this.secondPanel.Location = new System.Drawing.Point(0, 34);
            this.secondPanel.Name = "secondPanel";
            this.secondPanel.Size = new System.Drawing.Size(615, 225);
            this.secondPanel.TabIndex = 4;
            // 
            // loadPreviousButton
            // 
            this.loadPreviousButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.loadPreviousButton.Location = new System.Drawing.Point(301, 196);
            this.loadPreviousButton.Name = "loadPreviousButton";
            this.loadPreviousButton.Size = new System.Drawing.Size(131, 23);
            this.loadPreviousButton.TabIndex = 5;
            this.loadPreviousButton.Text = "Load Previous Results";
            this.loadPreviousButton.UseVisualStyleBackColor = true;
            this.loadPreviousButton.Click += new System.EventHandler(this.loadPreviousButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.Location = new System.Drawing.Point(479, 196);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 10;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // loadRulesButton
            // 
            this.loadRulesButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.loadRulesButton.Location = new System.Drawing.Point(220, 196);
            this.loadRulesButton.Name = "loadRulesButton";
            this.loadRulesButton.Size = new System.Drawing.Size(75, 23);
            this.loadRulesButton.TabIndex = 9;
            this.loadRulesButton.Text = "Load Rules";
            this.loadRulesButton.UseVisualStyleBackColor = true;
            this.loadRulesButton.Click += new System.EventHandler(this.loadRulesButton_Click);
            // 
            // saveRulesButton
            // 
            this.saveRulesButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveRulesButton.Location = new System.Drawing.Point(139, 196);
            this.saveRulesButton.Name = "saveRulesButton";
            this.saveRulesButton.Size = new System.Drawing.Size(75, 23);
            this.saveRulesButton.TabIndex = 5;
            this.saveRulesButton.Text = "Save Rules";
            this.saveRulesButton.UseVisualStyleBackColor = true;
            this.saveRulesButton.Click += new System.EventHandler(this.saveRulesButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsButton.Location = new System.Drawing.Point(444, 3);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(75, 23);
            this.optionsButton.TabIndex = 8;
            this.optionsButton.Text = "Options";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(115, 3);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 11;
            this.editButton.Text = "Edit Rule";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // Core
            // 
            this.AcceptButton = this.goButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.CancelButton = this.exitButton;
            this.ClientSize = new System.Drawing.Size(612, 261);
            this.Controls.Add(this.secondPanel);
            this.Controls.Add(this.directoryPanel);
            this.Name = "Core";
            this.Text = "Renamepler";
            this.directoryPanel.ResumeLayout(false);
            this.directoryPanel.PerformLayout();
            this.secondPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ruleButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Panel directoryPanel;
        private System.Windows.Forms.Button dirDialogButton;
        private System.Windows.Forms.TextBox directoryBox;
        private System.Windows.Forms.Panel secondPanel;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.RichTextBox ruleBox;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Button saveRulesButton;
        private System.Windows.Forms.Button loadRulesButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button loadPreviousButton;
        private System.Windows.Forms.Button editButton;
    }
}

