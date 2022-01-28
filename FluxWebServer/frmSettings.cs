using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FluxWebServer
{
    public partial class frmSettings : Form
    {
        private string httpDir;
        private string phpPath;
        private int port = 0;
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        protected override void OnHandleCreated(EventArgs e)
        {
            try
            {
                if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                    DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
            }
            catch { return; }
        }

        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            httpDir = Properties.Settings.Default.httpDir;
            phpPath = Properties.Settings.Default.phpPath;
            port = Properties.Settings.Default.port;

            if (httpDir != null)
                txtHttpDir.Text = httpDir;
            if (phpPath != null)
                txtPHPPath.Text = phpPath;
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

        private void btnBroowsePHP_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = dirDialog.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                txtPHPPath.Text = dirDialog.SelectedPath.TrimEnd('\\');
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.httpDir = txtHttpDir.Text;
            Properties.Settings.Default.phpPath = txtPHPPath.Text;
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
