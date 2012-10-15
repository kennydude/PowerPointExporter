using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PowerPointExporter
{
    public partial class ExportingDialog : Form
    {
        public ExportJob job;
        delegate void StringParameterDelegate(string value);

        public ExportingDialog()
        {
            InitializeComponent();
        }

        public void addDebug(String line)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new StringParameterDelegate(addDebug), new object[] { line });
                return;
            }
            tbDebug.Text += line + Environment.NewLine;
            tbDebug.SelectionStart = tbDebug.Text.Length;
            tbDebug.ScrollToCaret();
        }

        public void finishJob(String line)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new StringParameterDelegate(finishJob), new object[] { line });
                return;
            }
            btnClose.Enabled = true;
            lblTitle.Text = "Export Complete!";
        }

        private void ExportingDialog_Load(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(job.runInForm));
            t.IsBackground = true;
            t.Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
