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
    public partial class ExportAsHandoutsForm : Form
    {
        public ExportJob job;

        public ExportAsHandoutsForm()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            job.options = cbExportNotes.Checked ? "exportNotes" : "";
            job.run(this);
        }
    }
}
