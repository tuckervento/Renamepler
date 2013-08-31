namespace Renamepler
{
    partial class AddRuleDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.findBox = new System.Windows.Forms.TextBox();
            this.replaceBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.helpButton = new System.Windows.Forms.Button();
            this.regexCheck = new System.Windows.Forms.CheckBox();
            this.continuousCheck = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search String:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "New String:";
            // 
            // findBox
            // 
            this.findBox.Location = new System.Drawing.Point(88, 6);
            this.findBox.Name = "findBox";
            this.findBox.Size = new System.Drawing.Size(239, 20);
            this.findBox.TabIndex = 2;
            // 
            // replaceBox
            // 
            this.replaceBox.Location = new System.Drawing.Point(88, 33);
            this.replaceBox.Name = "replaceBox";
            this.replaceBox.Size = new System.Drawing.Size(239, 20);
            this.replaceBox.TabIndex = 3;
            // 
            // addButton
            // 
            this.addButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addButton.Location = new System.Drawing.Point(252, 59);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Add Rule";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(15, 59);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(75, 23);
            this.helpButton.TabIndex = 5;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // regexCheck
            // 
            this.regexCheck.AutoSize = true;
            this.regexCheck.Location = new System.Drawing.Point(96, 63);
            this.regexCheck.Name = "regexCheck";
            this.regexCheck.Size = new System.Drawing.Size(123, 17);
            this.regexCheck.TabIndex = 6;
            this.regexCheck.Text = "Search using RegEx";
            this.regexCheck.UseVisualStyleBackColor = true;
            // 
            // continuousCheck
            // 
            this.continuousCheck.AutoSize = true;
            this.continuousCheck.Location = new System.Drawing.Point(96, 86);
            this.continuousCheck.Name = "continuousCheck";
            this.continuousCheck.Size = new System.Drawing.Size(133, 17);
            this.continuousCheck.TabIndex = 7;
            this.continuousCheck.Text = "Continuous Numbering";
            this.continuousCheck.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(252, 82);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // AddRuleDialog
            // 
            this.AcceptButton = this.addButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(339, 108);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.continuousCheck);
            this.Controls.Add(this.regexCheck);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.replaceBox);
            this.Controls.Add(this.findBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddRuleDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit New Rule";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox findBox;
        private System.Windows.Forms.TextBox replaceBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.CheckBox regexCheck;
        private System.Windows.Forms.CheckBox continuousCheck;
        private System.Windows.Forms.Button cancelButton;
    }
}