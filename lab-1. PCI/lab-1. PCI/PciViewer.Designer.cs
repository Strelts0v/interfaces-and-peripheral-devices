namespace PCI
{
    partial class PciViewer
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
            this.pciListView = new System.Windows.Forms.ListBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pciListView
            // 
            this.pciListView.FormattingEnabled = true;
            this.pciListView.Location = new System.Drawing.Point(9, 12);
            this.pciListView.Name = "pciListView";
            this.pciListView.Size = new System.Drawing.Size(445, 277);
            this.pciListView.TabIndex = 0;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(379, 295);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // PciViewer
            // 
            this.ClientSize = new System.Drawing.Size(461, 322);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.pciListView);
            this.Name = "PciViewer";
            this.Text = "PCI Viewer";
            this.Load += new System.EventHandler(this.PciViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox pciListView;
        private System.Windows.Forms.Button exitButton;
    }
}