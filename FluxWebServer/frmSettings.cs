using System;
using System.Windows.Forms;

namespace FluxWebServer {
    public partial class frmSettings : Form {
        private string httpDir;
        private string phpPath;
        private int port = 0;

        public frmSettings() {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e) {
            httpDir = Properties.Settings.Default.httpDir;
            phpPath = Properties.Settings.Default.phpPath;
            port = Properties.Settings.Default.port;

            if (httpDir != null) {
                txtHTTPDir.Text = httpDir;
            }
            if (phpPath != null) {
                txtPHPPath.Text = phpPath;
            }
            if (port != 0) {
                numPort.Value = Properties.Settings.Default.port;
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e) {
            DialogResult result = dirDialog.ShowDialog();
            if (result == DialogResult.OK) {
                txtHTTPDir.Text = dirDialog.SelectedPath.TrimEnd('\\');
            }
        }

        private void btnBroowsePHP_Click(object sender, EventArgs e) {
            DialogResult result = dirDialog.ShowDialog();
            if (result == DialogResult.OK) {
                txtPHPPath.Text = dirDialog.SelectedPath.TrimEnd('\\');
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            Properties.Settings.Default.httpDir = txtHTTPDir.Text;
            Properties.Settings.Default.phpPath = txtPHPPath.Text;
            Properties.Settings.Default.port = (int) numPort.Value;
            Properties.Settings.Default.Save();
            Close();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            if (checkBox1.Checked) {
                txtPHPPath.Enabled = true;
                btnBrowsePHP.Enabled = true;
            } 
            else {
                txtPHPPath.Enabled = false;
                btnBrowsePHP.Enabled = false;
            }
        }
    }
}
