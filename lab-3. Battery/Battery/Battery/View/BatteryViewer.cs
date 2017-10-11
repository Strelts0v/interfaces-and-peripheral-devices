using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Threading;

namespace Battery
{
    public partial class BatteryViewer : Form
    {
        private BatteryApi batteryApi;

        private Thread batteryConditionUpdater;

        private bool isBatteryConditionUpdaterContinueWork;

        // sets time in seconds - how often battery conditon will be updated
        private int batteryConditionUpdatingFrequency = 2000;

        public BatteryViewer()
        {
            InitializeComponent();
        }

        private void BatteryViewer_Load(object sender, EventArgs e)
        {
            batteryApi = BatteryApi.GetInstance();
            batteryApi.SetPowerTimeout(60);
            isBatteryConditionUpdaterContinueWork = true;
            batteryConditionUpdater = new Thread(UpdateBatteryConditIonProcedure);
            batteryConditionUpdater.Start();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            TurnOffBatteryConditionUpdater();
            System.Windows.Forms.Application.Exit();
        }

        private void UpdateBatteryConditIonProcedure()
        {
            while (isBatteryConditionUpdaterContinueWork)
            {
                var batteryCondition = batteryApi.getCurrentBatteryCondition();
                UpdateBatteryCondition(batteryCondition);
                Thread.Sleep(batteryConditionUpdatingFrequency);
            }
        }

        // This delegate enables asynchronous calls for setting
        // updated battery condition on BatteryListBox.
        delegate void UpdateBatteryConditionCallBack(BatteryCondition batteryCondition);

        private void UpdateBatteryCondition(BatteryCondition batteryCondition)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.batteryListBox.InvokeRequired)
            {
                UpdateBatteryConditionCallBack callBack
                    = new UpdateBatteryConditionCallBack(UpdateBatteryCondition);
                this.Invoke(callBack, new object[] { batteryCondition});
            }
            else
            {
                SetUpdatedBatteryCondition(batteryCondition);
            }
        }

        private void SetUpdatedBatteryCondition(BatteryCondition batteryCondition) 
        {
            this.batteryListBox.Items.Clear();
            this.batteryListBox.Items.Add($"Battery plug type: \t\t{batteryCondition.PlugType}");
            this.batteryListBox.Items.Add($"Battery charge status: \t{batteryCondition.ChargeStatus}");
            this.batteryListBox.Items.Add($"Battery estimated runtime: \t{batteryCondition.EstimatedRunTime}");
        }

        private void TurnOffBatteryConditionUpdater()
        {
            isBatteryConditionUpdaterContinueWork = false;
            batteryConditionUpdater.Abort();
        }

        private void powerTimeoutTrackBar_Scroll(object sender, EventArgs e)
        {
            int powerTimeoutInMunites = powerTimeoutTrackBar.Value;
            if(powerTimeoutInMunites == 0)
            {
                powerTimeoutInMunites = 1;
            }
            batteryApi.SetPowerTimeout(powerTimeoutInMunites);
        }
    }
}
