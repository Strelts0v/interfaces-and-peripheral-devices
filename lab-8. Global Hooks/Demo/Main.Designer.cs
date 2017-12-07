namespace Demo
{
    partial class Main
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
            this.suppressMouseCheckBox = new System.Windows.Forms.CheckBox();
            this.labelWheel = new System.Windows.Forms.Label();
            this.labelMousePosition = new System.Windows.Forms.Label();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.suppressAltF4CheckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.clearLogButton = new System.Windows.Forms.Button();
            this.checkBoxSupressMouseWheel = new System.Windows.Forms.CheckBox();
            this.editSettingsButton = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // suppressMouseCheckBox
            // 
            this.suppressMouseCheckBox.AutoSize = true;
            this.suppressMouseCheckBox.Location = new System.Drawing.Point(161, 15);
            this.suppressMouseCheckBox.Name = "suppressMouseCheckBox";
            this.suppressMouseCheckBox.Size = new System.Drawing.Size(159, 17);
            this.suppressMouseCheckBox.TabIndex = 13;
            this.suppressMouseCheckBox.Text = "Suppress Right Mouse Click";
            this.suppressMouseCheckBox.UseVisualStyleBackColor = true;
            this.suppressMouseCheckBox.CheckedChanged += new System.EventHandler(this.checkBoxSuppressMouse_CheckedChanged);
            // 
            // labelWheel
            // 
            this.labelWheel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWheel.AutoSize = true;
            this.labelWheel.BackColor = System.Drawing.Color.White;
            this.labelWheel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWheel.Location = new System.Drawing.Point(9, 42);
            this.labelWheel.Name = "labelWheel";
            this.labelWheel.Size = new System.Drawing.Size(89, 13);
            this.labelWheel.TabIndex = 6;
            this.labelWheel.Text = "Wheel={0:####}";
            // 
            // labelMousePosition
            // 
            this.labelMousePosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMousePosition.AutoSize = true;
            this.labelMousePosition.BackColor = System.Drawing.Color.White;
            this.labelMousePosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMousePosition.Location = new System.Drawing.Point(9, 16);
            this.labelMousePosition.Name = "labelMousePosition";
            this.labelMousePosition.Size = new System.Drawing.Size(125, 13);
            this.labelMousePosition.TabIndex = 2;
            this.labelMousePosition.Text = "x={0:####}; y={1:####}";
            // 
            // textBoxLog
            // 
            this.textBoxLog.BackColor = System.Drawing.Color.White;
            this.textBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLog.Location = new System.Drawing.Point(0, 105);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(599, 292);
            this.textBoxLog.TabIndex = 8;
            this.textBoxLog.WordWrap = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.editSettingsButton);
            this.groupBox2.Controls.Add(this.suppressAltF4CheckBox);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.clearLogButton);
            this.groupBox2.Controls.Add(this.checkBoxSupressMouseWheel);
            this.groupBox2.Controls.Add(this.suppressMouseCheckBox);
            this.groupBox2.Controls.Add(this.labelWheel);
            this.groupBox2.Controls.Add(this.labelMousePosition);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(599, 105);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // suppressAltF4CheckBox
            // 
            this.suppressAltF4CheckBox.AutoSize = true;
            this.suppressAltF4CheckBox.Location = new System.Drawing.Point(161, 62);
            this.suppressAltF4CheckBox.Name = "suppressAltF4CheckBox";
            this.suppressAltF4CheckBox.Size = new System.Drawing.Size(109, 17);
            this.suppressAltF4CheckBox.TabIndex = 18;
            this.suppressAltF4CheckBox.Text = "Suppress Alt + F4";
            this.suppressAltF4CheckBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Send to email";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SendToEmailButton_Click);
            // 
            // clearLogButton
            // 
            this.clearLogButton.Location = new System.Drawing.Point(355, 44);
            this.clearLogButton.Name = "clearLogButton";
            this.clearLogButton.Size = new System.Drawing.Size(107, 23);
            this.clearLogButton.TabIndex = 16;
            this.clearLogButton.Text = "Clear log";
            this.clearLogButton.UseVisualStyleBackColor = true;
            this.clearLogButton.Click += new System.EventHandler(this.ClearLogButton_Click);
            // 
            // checkBoxSupressMouseWheel
            // 
            this.checkBoxSupressMouseWheel.AutoSize = true;
            this.checkBoxSupressMouseWheel.Location = new System.Drawing.Point(161, 38);
            this.checkBoxSupressMouseWheel.Name = "checkBoxSupressMouseWheel";
            this.checkBoxSupressMouseWheel.Size = new System.Drawing.Size(139, 17);
            this.checkBoxSupressMouseWheel.TabIndex = 15;
            this.checkBoxSupressMouseWheel.Text = "Suppress Mouse Wheel";
            this.checkBoxSupressMouseWheel.UseVisualStyleBackColor = true;
            this.checkBoxSupressMouseWheel.CheckedChanged += new System.EventHandler(this.checkBoxSupressMouseWheel_CheckedChanged);
            // 
            // editSettingsButton
            // 
            this.editSettingsButton.Location = new System.Drawing.Point(355, 74);
            this.editSettingsButton.Name = "editSettingsButton";
            this.editSettingsButton.Size = new System.Drawing.Size(107, 23);
            this.editSettingsButton.TabIndex = 19;
            this.editSettingsButton.Text = "Edit settings";
            this.editSettingsButton.UseVisualStyleBackColor = true;
            this.editSettingsButton.Click += new System.EventHandler(this.EditSettingsButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 397);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.groupBox2);
            this.Name = "Main";
            this.Text = "Mouse and Keyboard Hooks";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox suppressMouseCheckBox;
        private System.Windows.Forms.Label labelWheel;
        private System.Windows.Forms.Label labelMousePosition;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxSupressMouseWheel;
        private System.Windows.Forms.Button clearLogButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox suppressAltF4CheckBox;
        private System.Windows.Forms.Button editSettingsButton;
    }
}

