namespace USB
{
    partial class UsbBrowser
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
            this.usbDevicesListView = new System.Windows.Forms.ListView();
            this.deviceDiskColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deviceNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deviceAllMemoryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deviceFreeMemoryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deviceUsedMemoryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // usbDevicesListView
            // 
            this.usbDevicesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.deviceDiskColumn,
            this.deviceNameColumn,
            this.deviceAllMemoryColumn,
            this.deviceFreeMemoryColumn,
            this.deviceUsedMemoryColumn});
            this.usbDevicesListView.GridLines = true;
            this.usbDevicesListView.Location = new System.Drawing.Point(12, 12);
            this.usbDevicesListView.Name = "usbDevicesListView";
            this.usbDevicesListView.Size = new System.Drawing.Size(722, 211);
            this.usbDevicesListView.TabIndex = 1;
            this.usbDevicesListView.UseCompatibleStateImageBehavior = false;
            this.usbDevicesListView.View = System.Windows.Forms.View.Details;
            this.usbDevicesListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.UsbDevicesListView_MouseDoubleClick);
            // 
            // deviceDiskColumn
            // 
            this.deviceDiskColumn.Text = "Device disk";
            this.deviceDiskColumn.Width = 79;
            // 
            // deviceNameColumn
            // 
            this.deviceNameColumn.Text = "Device name";
            this.deviceNameColumn.Width = 202;
            // 
            // deviceAllMemoryColumn
            // 
            this.deviceAllMemoryColumn.Text = "All memory";
            this.deviceAllMemoryColumn.Width = 154;
            // 
            // deviceFreeMemoryColumn
            // 
            this.deviceFreeMemoryColumn.Text = "Free memory";
            this.deviceFreeMemoryColumn.Width = 146;
            // 
            // deviceUsedMemoryColumn
            // 
            this.deviceUsedMemoryColumn.Text = "Used memory";
            this.deviceUsedMemoryColumn.Width = 134;
            // 
            // UsbBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 240);
            this.Controls.Add(this.usbDevicesListView);
            this.Name = "UsbBrowser";
            this.Text = "USB Browser";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView usbDevicesListView;
        private System.Windows.Forms.ColumnHeader deviceDiskColumn;
        private System.Windows.Forms.ColumnHeader deviceNameColumn;
        private System.Windows.Forms.ColumnHeader deviceAllMemoryColumn;
        private System.Windows.Forms.ColumnHeader deviceFreeMemoryColumn;
        private System.Windows.Forms.ColumnHeader deviceUsedMemoryColumn;
    }
}

