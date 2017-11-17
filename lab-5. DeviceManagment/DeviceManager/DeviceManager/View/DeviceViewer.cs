using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DeviceManager.Model;
using System.Management;
using System.Threading.Tasks;

namespace DeviceManager.View
{
    public partial class DeviceViewer : Form
    {
        private readonly Api.DeviceManager _deviceManager = new Api.DeviceManager();
        private List<Device> _systemDeviceList;
        private readonly DataTable _table = new DataTable();

        private const string DeviceColumnName = "Device GUID";
        private const string DeviceOkStatus = "OK";
        private const string DeviceErrorStatus = "ERROR";

        private const string UsbChangedStateWqlQuery =
            "SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2 or EventType = 3";

        public DeviceViewer()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }

        private void InitializeBackgroundWorker()
        {
            var query = new WqlEventQuery(UsbChangedStateWqlQuery);
            var watcher = new ManagementEventWatcher(query);

            watcher.EventArrived += (o, e) =>
            {
                RefreshDeviceViewerProcedure();
            };
            watcher.Start();
        }

        private void InitializeDeviceViewer(object sender, EventArgs e)
        {
            _systemDeviceList = new List<Device>();
            _table.Columns.Add(DeviceColumnName, typeof(string));

            deviceList.DataSource = _table;
            RefreshDeviceViewer();
            disableButton.Enabled = false;
            enableButton.Enabled = false;
        }

        private void RefreshDeviceViewer()
        {
            var currentPosition = 0;

            if (deviceList.CurrentRow != null)
            {
                currentPosition = deviceList.CurrentRow.Index;
            }

            deviceList.ClearSelection();
            _table.Rows.Clear();
            _systemDeviceList = _deviceManager.GetDevices();

            foreach (var device in _systemDeviceList)
            {
                _table.Rows.Add(device.Guid);
            }

            if (deviceList.RowCount - 1 > currentPosition)
            {
                deviceList.Rows[currentPosition].Selected = true;
            }
        }

        private void SelectedItemChanged(object sender, EventArgs e)
        {
           
            if (deviceList.CurrentRow == null) return;

            var currentIndex = deviceList.CurrentRow.Index;

            if (currentIndex >= 0 && currentIndex < _systemDeviceList.Count)
            {
                deviceDetailsTextBox.Text = 
                    $"Guid: {_systemDeviceList[currentIndex].Guid}\r\n" +
                    $"HardwareID: {_systemDeviceList[currentIndex].HardwareId}\r\n" +
                    $"Manufacture: {_systemDeviceList[currentIndex].Manufacturer}\r\n" + 
                    $"Provider: {_systemDeviceList[currentIndex].Provider}\r\n" +
                    $"Driver description: {_systemDeviceList[currentIndex].DriverDescription}\r\n" + 
                    $"System file path: {_systemDeviceList[currentIndex].SystemFilePath}\r\n" +
                    $"Status: {_systemDeviceList[currentIndex].Status}\r\n";

                switch (_systemDeviceList[deviceList.CurrentRow.Index].Status)
                {
                    case DeviceOkStatus when _systemDeviceList[deviceList.CurrentRow.Index].IsEnabled == true:
                        disableButton.Enabled = true;
                        enableButton.Enabled = false;
                        break;
                    case DeviceErrorStatus:
                        disableButton.Enabled = false;
                        enableButton.Enabled = true;
                        break;
                }
            }
            else
            {
                disableButton.Enabled = false;
                deviceDetailsTextBox.Text = "";
            }
        }

        private void DisableButton(object sender, EventArgs e)
        {
            
            if (deviceList.CurrentRow == null) return;
            
            var device = _systemDeviceList[deviceList.CurrentRow.Index];
            if (device.DisableDevice())
            {
                device.IsEnabled = false;
                disableButton.Enabled = false;
                enableButton.Enabled = true;
            }
            else
            {
                MessageBox.Show(@"Error! Cannot disable device...");
            }
        }

        private void EnableButton(object sender, EventArgs e)
        {
            if (deviceList.CurrentRow == null) return;
            
            var device = _systemDeviceList[deviceList.CurrentRow.Index];
            if (device.EnableDevice())
            {
                device.IsEnabled = true;
                enableButton.Enabled = false;
                disableButton.Enabled = true;
            }
            else
            {
                MessageBox.Show(@"Error! Cannot enable device...");
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void RefreshDeviceViewerProcedure()
        {}
    }
}
