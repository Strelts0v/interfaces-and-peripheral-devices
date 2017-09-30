using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace Battery
{
    class BatteryApi
    {
        private static BatteryApi INSTANCE;

        private const string GET_WMI_BATTERY_SQL_QUERY = "Select * FROM Win32_Battery";

        private const string BATTERY_STATUS_PROPERTY_NAME = "BatteryStatus";
        private const string BATTERY_ESTIMATED_CHARGE_REMAINING_PROPERTY_NAME = "EstimatedChargeRemaining";
        private const string BATTERY_ESTIMATED_RUNTIME_PROPERTY_NAME = "EstimatedRunTime";

        private BatteryApi()
        { }

        public static BatteryApi GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new BatteryApi();
            }
            return INSTANCE;
        }

        public BatteryCondition getCurrentBatteryCondition()
        {
            ObjectQuery query = new ObjectQuery(GET_WMI_BATTERY_SQL_QUERY);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

            ManagementObjectCollection collection = searcher.Get();

            BatteryCondition batteryCondition = new BatteryCondition();
            foreach (ManagementObject wmiBattery in collection)
            {
                batteryCondition
                    .SetPlugType((UInt16)wmiBattery[BATTERY_STATUS_PROPERTY_NAME]);

                batteryCondition
                    .SetChargeStatus((UInt16)wmiBattery[BATTERY_ESTIMATED_CHARGE_REMAINING_PROPERTY_NAME]);

                batteryCondition
                    .SetEstimatedRunTime((UInt32)wmiBattery[BATTERY_ESTIMATED_RUNTIME_PROPERTY_NAME]);
            }

            return batteryCondition;
        }
    }
}
