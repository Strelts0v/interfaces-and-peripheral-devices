using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Battery
{
    class BatteryCondition
    {
        public string PlugType { get; private set; }

        public string ChargeStatus { get; private set; }

        public string EstimatedRunTime { get; private set; }

        private enum PlugTypeEnum : short { Battery = 1, AC = 2};

        private static readonly int MAX_BATTERY_STATUS = 100;
        private static readonly int MIN_BATTERY_STATUS = 0;
        private static readonly string BATTERY_IS_CHARGING_MESSAGE = "battery is charging";

        public void SetPlugType(int plugTypeId)
        {
            PlugType = ((PlugTypeEnum) plugTypeId).ToString();
        }

        public void SetChargeStatus(int chargeStatus)
        {
            if(IsChargeStatusValid(chargeStatus))
            {
                ChargeStatus = $"{chargeStatus} %";
            }
        }
        
        public void SetEstimatedRunTime(int estimatedRunTime)
        {
            if(IsEstimatedRunTimeValid(estimatedRunTime))
            {
                if (IsEstimatedRunTimeOfChargingBattery(estimatedRunTime))
                {
                    EstimatedRunTime = BATTERY_IS_CHARGING_MESSAGE;
                }
                else
                {
                    EstimatedRunTime = $"{estimatedRunTime} minutes";
                }
            }
        }

        private bool IsChargeStatusValid(int chargeStatus)
        {
            return chargeStatus > MIN_BATTERY_STATUS && chargeStatus <= MAX_BATTERY_STATUS;
        }

        private bool IsEstimatedRunTimeValid(int estimatedRunTime)
        {
            return estimatedRunTime > 0;
        }

        private bool IsEstimatedRunTimeOfChargingBattery(int estimatedRunTime)
        {
            const UInt32 ESTIMATED_RUN_TIME_OF_CHARGING_BATTERY = 71582788;
            return estimatedRunTime == ESTIMATED_RUN_TIME_OF_CHARGING_BATTERY;
        }
    }
}
