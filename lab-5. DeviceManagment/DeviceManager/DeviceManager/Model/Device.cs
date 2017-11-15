using System.Management;
using DeviceManager.Api;

namespace DeviceManager.Model
{
    internal class Device
    {
        public string Guid { get; set; }
        public string HardwareId { get; set; }
        public string Manufacturer { get; set; }
        public string Provider { get; set; }
        public string DriverDescription { get; set; }
        public string SystemFilePath { get; set; }
        public string DevicePath { get; set; }
        public string Status { get; set; }
        public bool IsEnabled { get; set; }

        private ManagementObject _devicePnpEntityManagmentObject;

        private const string DeviceEnableMethodName = "Enable";
        private const string DeviceDisableMethodName = "Disable";
        private const string GetDevicePnpEntitiesQuery = "SELECT * FROM Win32_PNPEntity";

        public Device(
            string guid,
            string hardwareId,
            string manufacturer,
            string provider,
            string driverDescription,
            string systemFilePath,
            string devicePath,
            string status)
        {
            Guid = guid;
            HardwareId = hardwareId;
            Manufacturer = manufacturer;
            Provider = provider;
            DriverDescription = driverDescription;
            SystemFilePath = systemFilePath;
            DevicePath = devicePath;
            Status = status;
            IsEnabled = true;
        }

        public bool EnableDevice()
        {
            var isEnabled = false;
            try
            {
                var devicePnpEntity = GetDevicePnpEntityManagmentObject();
                devicePnpEntity?.InvokeMethod(DeviceEnableMethodName, new object[] { false });
                isEnabled = true;
                this.Status = "OK";
            } catch (ManagementException)
            {}
            return isEnabled;
        }

        public bool DisableDevice()
        {
            var isDisabled = false;
            try
            {
                var devicePnpEntity = GetDevicePnpEntityManagmentObject();
                devicePnpEntity?.InvokeMethod(DeviceDisableMethodName, new object[] {false});
                isDisabled = true;
                this.Status = "ERROR";
            }
            catch (ManagementException)
            {}
            return isDisabled;
        }

        private ManagementObject GetDevicePnpEntityManagmentObject()
        {
            if (_devicePnpEntityManagmentObject == null)
            {
                var deviceList = new ManagementObjectSearcher(GetDevicePnpEntitiesQuery);
                foreach (var o in deviceList.Get())
                {
                    var item = (ManagementObject)o;
                    if (this.DevicePath == item[DeviceProperties.DevicePathProperty].ToString())
                    {
                        _devicePnpEntityManagmentObject = item;
                    }
                }
            }
            return _devicePnpEntityManagmentObject;
        }
    }
}