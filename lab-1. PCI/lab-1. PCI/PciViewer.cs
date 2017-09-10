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
            List<string> devices = pciApi.getAllPciDevices();
            foreach(var device in devices)
            {
                pciListView.Items.Add(device);
            }
        }
    }
}
