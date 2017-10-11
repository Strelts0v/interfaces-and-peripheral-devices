using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Diagnostics;

namespace Battery
{
    class BatteryApi
    {
        private static BatteryApi _instance;

        private const string GET_WMI_BATTERY_SQL_QUERY = "Select * FROM Win32_Battery";

        private const string BATTERY_STATUS_PROPERTY_NAME = "BatteryStatus";
        private const string BATTERY_ESTIMATED_CHARGE_REMAINING_PROPERTY_NAME = "EstimatedChargeRemaining";
        private const string BATTERY_ESTIMATED_RUNTIME_PROPERTY_NAME = "EstimatedRunTime";

        private BatteryApi()
        { }

        public static BatteryApi GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BatteryApi();
            }
            return _instance;
        }

        public BatteryCondition getCurrentBatteryCondition()
        {
            var query = new ObjectQuery(GET_WMI_BATTERY_SQL_QUERY);
            var searcher = new ManagementObjectSearcher(query);

            var collection = searcher.Get();

            var batteryCondition = new BatteryCondition();
            foreach (ManagementObject wmiBattery in collection)
            {
                batteryCondition
                    .SetPlugType(Convert.ToInt32(wmiBattery[BATTERY_STATUS_PROPERTY_NAME]));

                batteryCondition
                    .SetChargeStatus(Convert.ToInt32(wmiBattery[BATTERY_ESTIMATED_CHARGE_REMAINING_PROPERTY_NAME]));

                batteryCondition
                    .SetEstimatedRunTime(Convert.ToInt32(wmiBattery[BATTERY_ESTIMATED_RUNTIME_PROPERTY_NAME]));
            }

            return batteryCondition;
        }

        public void SetPowerTimeout(int minutes)
        {
            var process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.Arguments = "/c powercfg /x -monitor-timeout-dc " + minutes;
            process.Start();
        }
    }
}
