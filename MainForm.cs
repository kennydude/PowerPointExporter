using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPointExporter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog(this);
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            lblFile.Text = openFileDialog.FileName;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportJob eb = new ExportJob();
            eb.file = lblFile.Text;

            if (eb.file == "")
            {
                MessageBox.Show("Pick a file first!");
                return;
            }

            if (rbHandouts.Checked == true)
            {
                ExportAsHandoutsForm easf = new ExportAsHandoutsForm();
                eb.method = "handouts";
                easf.job = eb;
                easf.ShowDialog(this);
            }
        }
    }
}
