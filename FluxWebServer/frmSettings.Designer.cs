namespace FluxWebServer
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtHttpDir = new System.Windows.Forms.TextBox();
            this.lblHttpDirText = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.dirDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPHPPath = new System.Windows.Forms.TextBox();
            this.btnBroowsePHP = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.tabContainer.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(84, 140);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 29);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(195, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 29);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(295, 7);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(61, 25);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtHttpDir
            // 
            this.txtHttpDir.Location = new System.Drawing.Point(83, 10);
            this.txtHttpDir.Name = "txtHttpDir";
            this.txtHttpDir.ReadOnly = true;
            this.txtHttpDir.Size = new System.Drawing.Size(206, 20);
            this.txtHttpDir.TabIndex = 8;
            // 
            // lblHttpDirText
            // 
            this.lblHttpDirText.AutoSize = true;
            this.lblHttpDirText.Location = new System.Drawing.Point(6, 13);
            this.lblHttpDirText.Name = "lblHttpDirText";
            this.lblHttpDirText.Size = new System.Drawing.Size(71, 13);
            this.lblHttpDirText.TabIndex = 7;
            this.lblHttpDirText.Text = "Public Folder:";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(48, 66);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 10;
            this.lblPort.Text = "Port:";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(83, 64);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(48, 20);
            this.numPort.TabIndex = 11;
            this.numPort.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // dirDialog
            // 
            this.dirDialog.Description = "Choose the directory to be used as the base public folder";
            // 
            // tabContainer
            // 
            this.tabContainer.Controls.Add(this.tabGeneral);
            this.tabContainer.Controls.Add(this.tabPage1);
            this.tabContainer.Location = new System.Drawing.Point(12, 12);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(368, 121);
            this.tabContainer.TabIndex = 12;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.label1);
            this.tabGeneral.Controls.Add(this.txtPHPPath);
            this.tabGeneral.Controls.Add(this.btnBroowsePHP);
            this.tabGeneral.Controls.Add(this.lblHttpDirText);
            this.tabGeneral.Controls.Add(this.txtHttpDir);
            this.tabGeneral.Controls.Add(this.btnBrowse);
            this.tabGeneral.Controls.Add(this.numPort);
            this.tabGeneral.Controls.Add(this.lblPort);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(360, 95);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "PHP Path:";
            // 
            // txtPHPPath
            // 
            this.txtPHPPath.Location = new System.Drawing.Point(83, 38);
            this.txtPHPPath.Name = "txtPHPPath";
            this.txtPHPPath.ReadOnly = true;
            this.txtPHPPath.Size = new System.Drawing.Size(206, 20);
            this.txtPHPPath.TabIndex = 13;
            // 
            // btnBroowsePHP
            // 
            this.btnBroowsePHP.Location = new System.Drawing.Point(295, 35);
            this.btnBroowsePHP.Name = "btnBroowsePHP";
            this.btnBroowsePHP.Size = new System.Drawing.Size(61, 25);
            this.btnBroowsePHP.TabIndex = 14;
            this.btnBroowsePHP.Text = "Browse...";
            this.btnBroowsePHP.UseVisualStyleBackColor = true;
            this.btnBroowsePHP.Click += new System.EventHandler(this.btnBroowsePHP_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(360, 95);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Logging";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 178);
            this.Controls.Add(this.tabContainer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Flux - Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.tabContainer.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtHttpDir;
        private System.Windows.Forms.Label lblHttpDirText;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.FolderBrowserDialog dirDialog;
        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPHPPath;
        private System.Windows.Forms.Button btnBroowsePHP;
        private System.Windows.Forms.TabPage tabPage1;
    }
}