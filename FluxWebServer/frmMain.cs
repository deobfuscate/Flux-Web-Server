using System;
using System.Windows.Forms;
using System.Drawing;

namespace FluxWebServer
{
    public partial class frmMain : Form
    {
        private FluxServer fluxServer;
        private bool isRunning;
        private string strPath;
        private int iUptime;

        public frmMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            isRunning = false;
            strPath = "";
            iUptime = 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (isRunning) return;
            if (strPath.Equals(""))
            {
                Log("Error: Public Directory is not set");
                return;
            }
            fluxServer = new FluxServer(this, 80, strPath);
            fluxServer.Start();
            isRunning = true;
            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = "Online";
            tmrUptime.Start();
            Log("Web server started");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!isRunning) return;
            fluxServer.Stop();
            isRunning = false;
            lblStatus.ForeColor = Color.Red;
            lblStatus.Text = "Offline";
            tmrUptime.Stop();
            iUptime = 0;
            lblUptime.Text = "00:00:00";
            Log("Web server stopped");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = dirDialog.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                strPath = dirDialog.SelectedPath.TrimEnd('\\');
                txtPath.Text = strPath;
            }
        }

        private void tmrUptime_Tick(object sender, EventArgs e)
        {
            iUptime++;
            TimeSpan tsTime = TimeSpan.FromSeconds(iUptime);
            lblUptime.Text = tsTime.ToString(@"hh\:mm\:ss");
        }

        public void Log(string text)
        {
            txtLog.AppendText("[" + DateTime.Now.ToString() + "] " + text + Environment.NewLine);
        }
    }
}