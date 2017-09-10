using System.Collections.Generic;
using System.Management;
using System.Text.RegularExpressions;

namespace PCI
{
    class PciApi
    {
        private readonly static string GET_PCI_DEVICES_QUERY = "SELECT * FROM Win32_PnPEntity";

        private readonly static string DEVICE_ID = "DeviceID";

        private readonly static string DEVICE_DESCRIPTION = "Description";

        private readonly static string DEVICE_ID_REGEXP_PATTERN = "DEV_.{4}";

        private readonly static string VENDOR_ID_REGEXP_PATTERN = "VEN_.{4}";

        public List<string> getAllPciDevices()
        {
            List<string> pciDevices = new List<string>();

            ManagementScope connectionScope = new ManagementScope();

            SelectQuery serialQuery = new SelectQuery(GET_PCI_DEVICES_QUERY);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionScope, serialQuery);
            Regex deviceIdRegExp = new Regex(DEVICE_ID_REGEXP_PATTERN);
            Regex vendorIdRegExp = new Regex(VENDOR_ID_REGEXP_PATTERN);

            try
            {
                foreach (var item in searcher.Get())
                {
                    string deviceId = item[DEVICE_ID].ToString();
                    if (deviceId.Contains("PCI"))
                        pciDevices.Add(
                            "DeviceID: " + deviceIdRegExp.Match(deviceId).Value.Substring(4) + ";\t" +
                            "VendorID: " + vendorIdRegExp.Match(deviceId).Value.Substring(4) + ";\t" +
                             item[DEVICE_DESCRIPTION]
                        );
                }
            }
            catch (ManagementException)
            {
                pciDevices.Add("Error! Cannot get information about devices from WMI");
            }

            return pciDevices;
        }
    }
}
