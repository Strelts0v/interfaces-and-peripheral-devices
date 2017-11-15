using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DeviceManager.Model;
using DeviceManager.Api;

namespace DeviceManager.View
{
    public partial class DeviceViewer : Form
    {
        private readonly Api.DeviceManager _deviceManager = new Api.DeviceManager();
        private List<Device> _deviceList;
        private readonly DataTable _table = new DataTable();

        private const string DeviceOkStatus = "OK";
        private const string DeviceErrorStatus = "ERROR";
        
        public DeviceViewer()
        {
            InitializeComponent();
        }

        private void LoadForm(object sender, EventArgs e)
        {
            _deviceList = new List<Device>();
            _table.Columns.Add("Device GUID", typeof(string));

            ReloadForm();
            deviceList.DataSource = _table;
            disableButton.Enabled = false;
            enableButton.Enabled = false;
        }

        private void ReloadForm()
        {
            var currentPosition = 0;

            if (deviceList.CurrentRow != null)
            {
                currentPosition = deviceList.CurrentRow.Index;
            }

            _table.Clear();
            _deviceList = _deviceManager.GetDevices();

            foreach (var device in _deviceList)
            {
                _table.Rows.Add(device.Guid);
            }

            if (deviceList.RowCount - 1 > currentPosition)
            {
                deviceList.Rows[currentPosition].Selected = true;
            }
        }

        private void ChangeSelect(object sender, EventArgs e)
        {
           
            if (deviceList.CurrentRow == null) return;
            
            if (deviceList.CurrentRow.Index >= 0 && deviceList.CurrentRow.Index < _deviceList.Count)
            {
                deviceDetailsTextBox.Text = 
                    $"Guid: {_deviceList[deviceList.CurrentRow.Index].Guid}\r\n" +
                    $"HardwareID: {_deviceList[deviceList.CurrentRow.Index].HardwareId}\r\n" +
                    $"Manufacture: {_deviceList[deviceList.CurrentRow.Index].Manufacturer}\r\n" + 
                    $"Provider: {_deviceList[deviceList.CurrentRow.Index].Provider}\r\n" +
                    $"Driver description: {_deviceList[deviceList.CurrentRow.Index].DriverDescription}\r\n" + 
                    $"System file path: {_deviceList[deviceList.CurrentRow.Index].SystemFilePath}\r\n" +
                    $"Status: {_deviceList[deviceList.CurrentRow.Index].Status}\r\n";

                switch (_deviceList[deviceList.CurrentRow.Index].Status)
                {
                    case DeviceOkStatus when _deviceList[deviceList.CurrentRow.Index].IsEnabled == true:
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
            
            var device = _deviceList[deviceList.CurrentRow.Index];
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
            
            var device = _deviceList[deviceList.CurrentRow.Index];
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
    }
}
