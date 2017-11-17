namespace DeviceManager.View
{
    partial class DeviceViewer
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
            this.deviceList = new System.Windows.Forms.DataGridView();
            this.disableButton = new System.Windows.Forms.Button();
            this.deviceDetailsTextBox = new System.Windows.Forms.TextBox();
            this.enableButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.deviceList)).BeginInit();
            this.SuspendLayout();
            // 
            // deviceList
            // 
            this.deviceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.deviceList.BackgroundColor = System.Drawing.Color.White;
            this.deviceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deviceList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.deviceList.Location = new System.Drawing.Point(12, 12);
            this.deviceList.Name = "deviceList";
            this.deviceList.Size = new System.Drawing.Size(278, 266);
            this.deviceList.TabIndex = 0;
            this.deviceList.SelectionChanged += new System.EventHandler(this.SelectedItemChanged);
            // 
            // disableButton
            // 
            this.disableButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.disableButton.Location = new System.Drawing.Point(105, 284);
            this.disableButton.Name = "disableButton";
            this.disableButton.Size = new System.Drawing.Size(87, 24);
            this.disableButton.TabIndex = 1;
            this.disableButton.Text = "Disable";
            this.disableButton.UseVisualStyleBackColor = true;
            this.disableButton.Click += new System.EventHandler(this.DisableButton);
            // 
            // deviceDetailsTextBox
            // 
            this.deviceDetailsTextBox.BackColor = System.Drawing.Color.White;
            this.deviceDetailsTextBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deviceDetailsTextBox.Location = new System.Drawing.Point(296, 12);
            this.deviceDetailsTextBox.Multiline = true;
            this.deviceDetailsTextBox.Name = "deviceDetailsTextBox";
            this.deviceDetailsTextBox.Size = new System.Drawing.Size(377, 298);
            this.deviceDetailsTextBox.TabIndex = 2;
            // 
            // enableButton
            // 
            this.enableButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enableButton.Location = new System.Drawing.Point(12, 284);
            this.enableButton.Name = "enableButton";
            this.enableButton.Size = new System.Drawing.Size(87, 24);
            this.enableButton.TabIndex = 4;
            this.enableButton.Text = "Enable";
            this.enableButton.UseVisualStyleBackColor = true;
            this.enableButton.Click += new System.EventHandler(this.EnableButton);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.exitButton.Location = new System.Drawing.Point(199, 284);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(91, 23);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // DeviceViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(677, 322);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.enableButton);
            this.Controls.Add(this.deviceDetailsTextBox);
            this.Controls.Add(this.disableButton);
            this.Controls.Add(this.deviceList);
            this.Name = "DeviceViewer";
            this.Text = "Device Manager ";
            this.Load += new System.EventHandler(this.InitializeDeviceViewer);
            ((System.ComponentModel.ISupportInitialize)(this.deviceList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView deviceList;
        private System.Windows.Forms.Button disableButton;
        private System.Windows.Forms.TextBox deviceDetailsTextBox;
        private System.Windows.Forms.Button enableButton;
        private System.Windows.Forms.Button exitButton;
    }
}
