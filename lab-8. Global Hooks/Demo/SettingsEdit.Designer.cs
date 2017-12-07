namespace Demo
{
    partial class SettingsEdit
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
            this.emailFromTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.emailToTextBox = new System.Windows.Forms.TextBox();
            this.isHiddenModeCheckBox = new System.Windows.Forms.CheckBox();
            this.fileSizeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // emailFromTextBox
            // 
            this.emailFromTextBox.Location = new System.Drawing.Point(132, 24);
            this.emailFromTextBox.Name = "emailFromTextBox";
            this.emailFromTextBox.Size = new System.Drawing.Size(144, 20);
            this.emailFromTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(132, 63);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(144, 20);
            this.passwordTextBox.TabIndex = 1;
            // 
            // emailToTextBox
            // 
            this.emailToTextBox.Location = new System.Drawing.Point(132, 102);
            this.emailToTextBox.Name = "emailToTextBox";
            this.emailToTextBox.Size = new System.Drawing.Size(144, 20);
            this.emailToTextBox.TabIndex = 2;
            // 
            // isHiddenModeCheckBox
            // 
            this.isHiddenModeCheckBox.AutoSize = true;
            this.isHiddenModeCheckBox.Location = new System.Drawing.Point(16, 169);
            this.isHiddenModeCheckBox.Name = "isHiddenModeCheckBox";
            this.isHiddenModeCheckBox.Size = new System.Drawing.Size(125, 17);
            this.isHiddenModeCheckBox.TabIndex = 3;
            this.isHiddenModeCheckBox.Text = "Hidden mode is initial";
            this.isHiddenModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // fileSizeTextBox
            // 
            this.fileSizeTextBox.Location = new System.Drawing.Point(132, 142);
            this.fileSizeTextBox.Name = "fileSizeTextBox";
            this.fileSizeTextBox.Size = new System.Drawing.Size(144, 20);
            this.fileSizeTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Email from:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password for email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Email to:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "File of size in MB";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(15, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(96, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Ok";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // SettingsEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 238);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileSizeTextBox);
            this.Controls.Add(this.isHiddenModeCheckBox);
            this.Controls.Add(this.emailToTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.emailFromTextBox);
            this.Name = "SettingsEdit";
            this.Text = "SettingsEdit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox emailFromTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox emailToTextBox;
        private System.Windows.Forms.CheckBox isHiddenModeCheckBox;
        private System.Windows.Forms.TextBox fileSizeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}