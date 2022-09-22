using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace FluxWebServer
{
    public partial class frmMain : Form
    {
        private FluxServer fluxServer;
        private bool isRunning;
        private string path, phpPath;
        private int uptime, port;

        public frmMain() {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            isRunning = false;
            path = "";
            uptime = port = 0;
        }

        private void frmMain_Load(object sender, EventArgs e) {
            updateSettings();
        }

        private void btnStart_Click(object sender, EventArgs e) {
            if (!isRunning) {
                if (path.Equals("")) {
                    Log("Error: Public Directory is not set. Go to Tools -> Settings to set.");
                    return;
                }
                if (port == 0) {
                    Log("Error: Port is not set. Go to Tools -> Settings to set.");
                    return;
                }
                if (!Directory.Exists(path)) {
                    Log("Error: Server directory does not exist. Go to Tools -> Settings to set.");
                    return;
                }
                fluxServer = new FluxServer(port, path, phpPath);
                fluxServer.LogMessage += Log;
                if (fluxServer.Start()) {
                    isRunning = true;
                    lblStatus.ForeColor = Color.Green;
                    lblStatus.Text = "Online";
                    tmrUptime.Start();
                    btnStart.Text = "Stop";
                    Log("Web server started.");
                }
            }
            else {
                fluxServer.Stop();
                isRunning = false;
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Offline";
                tmrUptime.Stop();
                uptime = 0;
                lblUptime.Text = "00:00:00";
                btnStart.Text = "Start";
                Log("Web server stopped.");
            }
        }

        private void tmrUptime_Tick(object sender, EventArgs e) {
            uptime++;
            TimeSpan tsTime = TimeSpan.FromSeconds(uptime);
            lblUptime.Text = tsTime.ToString(@"hh\:mm\:ss");
        }

        public void Log(string text) {
            txtLog.AppendText($"[{DateTime.Now}] {text}{Environment.NewLine}");
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
            if (isRunning) {
                MessageBox.Show("Cannot change settings while server is running.", "Error");
                return;
            }

            frmSettings form = new frmSettings();
            form.ShowDialog(this);
            if (form.DialogResult == DialogResult.OK)
                updateSettings();
        }
        private void updateSettings() {
            path = Properties.Settings.Default.httpDir;
            port = Properties.Settings.Default.port;
            phpPath = Properties.Settings.Default.phpPath;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        void Log(object sender, LogMessageEventArgs e) {
            Log(e.Message);
        }
    }

    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}