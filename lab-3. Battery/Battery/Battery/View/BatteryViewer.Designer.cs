namespace Battery
{
    partial class BatteryViewer
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
            this.batteryListBox = new System.Windows.Forms.ListBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.powerTimeoutTrackBar = new System.Windows.Forms.TrackBar();
            this.PowerTimeoutLabel = new System.Windows.Forms.Label();
            this.min1Label = new System.Windows.Forms.Label();
            this.min10Label = new System.Windows.Forms.Label();
            this.min30Label = new System.Windows.Forms.Label();
            this.min40Label = new System.Windows.Forms.Label();
            this.min20Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.powerTimeoutTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // batteryListBox
            // 
            this.batteryListBox.FormattingEnabled = true;
            this.batteryListBox.Location = new System.Drawing.Point(7, 10);
            this.batteryListBox.Name = "batteryListBox";
            this.batteryListBox.Size = new System.Drawing.Size(286, 121);
            this.batteryListBox.TabIndex = 0;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(218, 225);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // powerTimeoutTrackBar
            // 
            this.powerTimeoutTrackBar.Location = new System.Drawing.Point(7, 159);
            this.powerTimeoutTrackBar.Maximum = 40;
            this.powerTimeoutTrackBar.Name = "powerTimeoutTrackBar";
            this.powerTimeoutTrackBar.Size = new System.Drawing.Size(286, 45);
            this.powerTimeoutTrackBar.TabIndex = 2;
            this.powerTimeoutTrackBar.TickFrequency = 5;
            this.powerTimeoutTrackBar.Scroll += new System.EventHandler(this.powerTimeoutTrackBar_Scroll);
            // 
            // PowerTimeoutLabel
            // 
            this.PowerTimeoutLabel.AutoSize = true;
            this.PowerTimeoutLabel.Location = new System.Drawing.Point(13, 140);
            this.PowerTimeoutLabel.Name = "PowerTimeoutLabel";
            this.PowerTimeoutLabel.Size = new System.Drawing.Size(92, 13);
            this.PowerTimeoutLabel.TabIndex = 3;
            this.PowerTimeoutLabel.Text = "Set power timeout";
            // 
            // min1Label
            // 
            this.min1Label.AutoSize = true;
            this.min1Label.Location = new System.Drawing.Point(4, 191);
            this.min1Label.Name = "min1Label";
            this.min1Label.Size = new System.Drawing.Size(32, 13);
            this.min1Label.TabIndex = 4;
            this.min1Label.Text = "1 min";
            // 
            // min10Label
            // 
            this.min10Label.AutoSize = true;
            this.min10Label.Location = new System.Drawing.Point(64, 191);
            this.min10Label.Name = "min10Label";
            this.min10Label.Size = new System.Drawing.Size(38, 13);
            this.min10Label.TabIndex = 5;
            this.min10Label.Text = "10 min";
            // 
            // min30Label
            // 
            this.min30Label.AutoSize = true;
            this.min30Label.Location = new System.Drawing.Point(191, 191);
            this.min30Label.Name = "min30Label";
            this.min30Label.Size = new System.Drawing.Size(38, 13);
            this.min30Label.TabIndex = 6;
            this.min30Label.Text = "min 30";
            // 
            // min40Label
            // 
            this.min40Label.AutoSize = true;
            this.min40Label.Location = new System.Drawing.Point(255, 191);
            this.min40Label.Name = "min40Label";
            this.min40Label.Size = new System.Drawing.Size(38, 13);
            this.min40Label.TabIndex = 7;
            this.min40Label.Text = "min 40";
            // 
            // min20Label
            // 
            this.min20Label.AutoSize = true;
            this.min20Label.Location = new System.Drawing.Point(129, 191);
            this.min20Label.Name = "min20Label";
            this.min20Label.Size = new System.Drawing.Size(38, 13);
            this.min20Label.TabIndex = 8;
            this.min20Label.Text = "20 min";
            // 
            // BatteryViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 260);
            this.Controls.Add(this.min20Label);
            this.Controls.Add(this.min40Label);
            this.Controls.Add(this.min30Label);
            this.Controls.Add(this.min10Label);
            this.Controls.Add(this.min1Label);
            this.Controls.Add(this.PowerTimeoutLabel);
            this.Controls.Add(this.powerTimeoutTrackBar);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.batteryListBox);
            this.Name = "BatteryViewer";
            this.Text = "BatteryViewer";
            this.Load += new System.EventHandler(this.BatteryViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.powerTimeoutTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox batteryListBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TrackBar powerTimeoutTrackBar;
        private System.Windows.Forms.Label PowerTimeoutLabel;
        private System.Windows.Forms.Label min1Label;
        private System.Windows.Forms.Label min10Label;
        private System.Windows.Forms.Label min30Label;
        private System.Windows.Forms.Label min40Label;
        private System.Windows.Forms.Label min20Label;
    }
}

