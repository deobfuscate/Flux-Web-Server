using System;
using System.Windows.Forms;

namespace FluxWebServer
{
    public partial class frmSettings : Form
    {
        private string httpDir;
        private int port = 0;

        public frmSettings()
        {
            InitializeComponent();
        }
        
        private void frmSettings_Load(object sender, EventArgs e)
        {
            httpDir = Properties.Settings.Default.httpDir;
            port = Properties.Settings.Default.port;
            
            if (httpDir != null)
                txtHttpDir.Text = httpDir;
            if (port != 0)
                numPort.Value = Properties.Settings.Default.port;
            else
                numPort.Value = 80;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = dirDialog.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                txtHttpDir.Text = dirDialog.SelectedPath.TrimEnd('\\');
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.httpDir = txtHttpDir.Text;
            Properties.Settings.Default.port = (int) numPort.Value;
            Properties.Settings.Default.Save();
            Close();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
