using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using USB.Api;
using USB.Model;

namespace USB
{
    public partial class UsbBrowser : Form
    {
        private UsbManager usbManager;

        private readonly int UPDATE_FREQUENSY_MILLIS = 3000;

        public UsbBrowser()
        {
            InitializeComponent();
            this.usbManager = new UsbManager();
            RefreshStatus();
        }

        private void UsbDevicesListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var text = ((ListView)sender).FocusedItem.Text;
            bool errorDisplayed = false;
            try
            {
                this.usbManager.EjectDrive(text);
            }
            catch (Win32Exception)
            {
                MessageBox.Show(string.Format("{0} disk is being used. Please, try again later", text));
                errorDisplayed = true;
            }
            finally
            {
                if (!errorDisplayed)
                {
                    MessageBox.Show(string.Format("{0} disk has been ejected", text));
                }
            }
        }

        private async void RefreshStatus()
        {
            // The UI Thread TaskScheduler instance
            var taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

            while (true)
            {
                var task = Task.Run(() => {
                    return usbManager.GetUserUsbDevices();
                }).ContinueWith(t => RefreshItems(t.Result), taskScheduler);
                await Task.Delay(UPDATE_FREQUENSY_MILLIS);
            }
        }

        private void RefreshItems(List<UsbDevice> usbDeviceList)
        {
            usbDevicesListView.Items.Clear();
            foreach (var usbDevice in usbDeviceList)
            {
                ListViewItem item = new ListViewItem(usbDevice.DeviceLetter);
                item.SubItems.Add(usbDevice.DeviceName);
                item.SubItems.Add(usbDevice.DeviceAllMemory);
                item.SubItems.Add(usbDevice.DeviceFreeMemory);
                item.SubItems.Add(usbDevice.DeviceUsedMemory);

                this.usbDevicesListView.Items.Add(item);
            }
        }
    }
}
