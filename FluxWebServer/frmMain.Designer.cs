namespace FluxWebServer
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tmrUptime = new System.Windows.Forms.Timer(this.components);
            this.txtLog = new System.Windows.Forms.TextBox();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblFolderText = new System.Windows.Forms.Label();
            this.lblUptime = new System.Windows.Forms.Label();
            this.lblUptimeText = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusText = new System.Windows.Forms.Label();
            this.dirDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.grpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(93, 382);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(102, 30);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(201, 382);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(102, 30);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tmrUptime
            // 
            this.tmrUptime.Interval = 1000;
            this.tmrUptime.Tick += new System.EventHandler(this.tmrUptime_Tick);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 12);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(369, 266);
            this.txtLog.TabIndex = 1;
            this.txtLog.WordWrap = false;
            // 
            // grpBox
            // 
            this.grpBox.Controls.Add(this.btnBrowse);
            this.grpBox.Controls.Add(this.txtPath);
            this.grpBox.Controls.Add(this.lblFolderText);
            this.grpBox.Controls.Add(this.lblUptime);
            this.grpBox.Controls.Add(this.lblUptimeText);
            this.grpBox.Controls.Add(this.lblStatus);
            this.grpBox.Controls.Add(this.lblStatusText);
            this.grpBox.Location = new System.Drawing.Point(12, 284);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(369, 92);
            this.grpBox.TabIndex = 2;
            this.grpBox.TabStop = false;
            this.grpBox.Text = "Information";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(302, 58);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(61, 25);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(90, 61);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(206, 20);
            this.txtPath.TabIndex = 5;
            // 
            // lblFolderText
            // 
            this.lblFolderText.AutoSize = true;
            this.lblFolderText.Location = new System.Drawing.Point(6, 64);
            this.lblFolderText.Name = "lblFolderText";
            this.lblFolderText.Size = new System.Drawing.Size(71, 13);
            this.lblFolderText.TabIndex = 4;
            this.lblFolderText.Text = "Public Folder:";
            // 
            // lblUptime
            // 
            this.lblUptime.AutoSize = true;
            this.lblUptime.Location = new System.Drawing.Point(87, 42);
            this.lblUptime.Name = "lblUptime";
            this.lblUptime.Size = new System.Drawing.Size(49, 13);
            this.lblUptime.TabIndex = 3;
            this.lblUptime.Text = "00:00:00";
            // 
            // lblUptimeText
            // 
            this.lblUptimeText.AutoSize = true;
            this.lblUptimeText.Location = new System.Drawing.Point(34, 42);
            this.lblUptimeText.Name = "lblUptimeText";
            this.lblUptimeText.Size = new System.Drawing.Size(43, 13);
            this.lblUptimeText.TabIndex = 2;
            this.lblUptimeText.Text = "Uptime:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(87, 20);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Offline";
            // 
            // lblStatusText
            // 
            this.lblStatusText.AutoSize = true;
            this.lblStatusText.Location = new System.Drawing.Point(37, 20);
            this.lblStatusText.Name = "lblStatusText";
            this.lblStatusText.Size = new System.Drawing.Size(40, 13);
            this.lblStatusText.TabIndex = 0;
            this.lblStatusText.Text = "Status:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 422);
            this.Controls.Add(this.grpBox);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Flux Web Server";
            this.grpBox.ResumeLayout(false);
            this.grpBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Timer tmrUptime;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblFolderText;
        private System.Windows.Forms.Label lblUptime;
        private System.Windows.Forms.Label lblUptimeText;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusText;
        private System.Windows.Forms.FolderBrowserDialog dirDialog;
    }
}
