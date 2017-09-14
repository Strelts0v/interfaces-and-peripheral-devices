using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCI
{
    public partial class PciViewer : Form
    {
        private readonly static int OFFSET_VALUE = 200;

        public PciViewer()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void PciViewer_Load(object sender, EventArgs e)
        {
            PciApi pciApi = new PciApi();
            List<PciDeviceInfo> devices = pciApi.GetAllPciDevices();
            foreach(var device in devices)
            {
                pciListView.Items.Add(device.GetDeviceId());
                pciListView.Items.Add(device.GetVendorId());
                pciListView.Items.Add("-----------------------------------------------------------");
            }
        }
    }
}
