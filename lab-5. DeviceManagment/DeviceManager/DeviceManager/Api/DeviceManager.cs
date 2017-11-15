using System.Collections.Generic;
using System.Management;
using DeviceManager.Model;

namespace DeviceManager.Api
{
    internal class DeviceManager
    {
        private const string Scope = "\\\\.\\root\\cimv2";
        private const string GetPnpEntitiesQuery = "SELECT * FROM Win32_PnPEntity";
        private const string Win32SystemDriverProperty = "Win32_SystemDriver";

        public List<Device> GetDevices()
        {
            var devices = new List<Device>();
            var deviceList = new ManagementObjectSearcher(Scope, GetPnpEntitiesQuery);
            foreach (var o in deviceList.Get())
            {
                var item = (ManagementObject)o;

                var guid = item[DeviceProperties.GuIdProperty]?.ToString() ?? "";
                var manufacturer = item[DeviceProperties.ManufacturerProperty]?.ToString() ?? "";
                var provider = item[DeviceProperties.ProviderProperty]?.ToString() ?? "";
                var devicePath = item[DeviceProperties.DevicePathProperty]?.ToString() ?? "";
                var status = item[DeviceProperties.StatusProperty]?.ToString() ?? "";

                var systemDriver = item.GetRelated(Win32SystemDriverProperty);
                string driverDescription = "", systemFilePath = "";
                foreach (var systemDriverProperty in systemDriver)
                {
                    driverDescription += systemDriverProperty[DeviceProperties.DriverDescriptionProperty].ToString();
                    systemFilePath += systemDriverProperty[DeviceProperties.SystemFilePathProperty].ToString();
                }

                var hardwareId = item[DeviceProperties.HardwareIdProperty] == null
                    ? ""
                    : string.Join("\r\n", (string[])item[DeviceProperties.HardwareIdProperty]);

                devices.Add(new Device(guid, hardwareId, manufacturer, provider, driverDescription,
                    systemFilePath, devicePath, status));
            }
            return devices;
        }
    }
}
