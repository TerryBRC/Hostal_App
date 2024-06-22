using Hostal_App.Models;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostal_App
{
    public partial class DashboardForm : MaterialForm

    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.Clientes cliente = new Views.Clientes();
            cliente.ShowDialog();
        }
    }
}
