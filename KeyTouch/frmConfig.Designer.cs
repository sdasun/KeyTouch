namespace KeyTouch
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.tbMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCStatus = new System.Windows.Forms.Label();
            this.chkKeyboard = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSKShortcut = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblShortcut = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblCCreatedBy = new System.Windows.Forms.Label();
            this.lblCVersion = new System.Windows.Forms.Label();
            this.lblCDescription = new System.Windows.Forms.Label();
            this.lblCShortcut = new System.Windows.Forms.Label();
            this.lblCFileName = new System.Windows.Forms.Label();
            this.btnKBUninstall = new System.Windows.Forms.Button();
            this.btnKbInstaller = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkStartUp = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnKeyTouchOn = new System.Windows.Forms.Button();
            this.lblKeyTouchOn = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnKeyTouchOff = new System.Windows.Forms.Button();
            this.lblKeyTouchOff = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGlobleShortcut = new System.Windows.Forms.Button();
            this.lblGlobleShortcut = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.niSystem = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsKeyboards = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmKeyboards = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmEnable = new System.Windows.Forms.ToolStripMenuItem();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ofdKbInstaller = new System.Windows.Forms.OpenFileDialog();
            this.btnRevert = new System.Windows.Forms.Button();
            this.tbMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.cmsOptions.SuspendLayout();
            this.cmsKeyboards.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.tabPage1);
            this.tbMain.Controls.Add(this.tabPage2);
            this.tbMain.Location = new System.Drawing.Point(1, 2);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(338, 292);
            this.tbMain.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblStatus);
            this.tabPage1.Controls.Add(this.lblCStatus);
            this.tabPage1.Controls.Add(this.chkKeyboard);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnKBUninstall);
            this.tabPage1.Controls.Add(this.btnKbInstaller);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(330, 266);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Keyboards";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(171, 250);
            this.lblStatus.MinimumSize = new System.Drawing.Size(125, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(125, 13);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Key Touch is off.";
            // 
            // lblCStatus
            // 
            this.lblCStatus.AutoSize = true;
            this.lblCStatus.Location = new System.Drawing.Point(161, 237);
            this.lblCStatus.Name = "lblCStatus";
            this.lblCStatus.Size = new System.Drawing.Size(37, 13);
            this.lblCStatus.TabIndex = 6;
            this.lblCStatus.Text = "Status";
            // 
            // chkKeyboard
            // 
            this.chkKeyboard.FormattingEnabled = true;
            this.chkKeyboard.Location = new System.Drawing.Point(7, 6);
            this.chkKeyboard.Name = "chkKeyboard";
            this.chkKeyboard.Size = new System.Drawing.Size(142, 199);
            this.chkKeyboard.TabIndex = 3;
            this.chkKeyboard.SelectedIndexChanged += new System.EventHandler(this.chkKeyboard_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSKShortcut);
            this.groupBox1.Controls.Add(this.lblDescription);
            this.groupBox1.Controls.Add(this.lblCreatedBy);
            this.groupBox1.Controls.Add(this.lblVersion);
            this.groupBox1.Controls.Add(this.lblShortcut);
            this.groupBox1.Controls.Add(this.lblFileName);
            this.groupBox1.Controls.Add(this.lblCCreatedBy);
            this.groupBox1.Controls.Add(this.lblCVersion);
            this.groupBox1.Controls.Add(this.lblCDescription);
            this.groupBox1.Controls.Add(this.lblCShortcut);
            this.groupBox1.Controls.Add(this.lblCFileName);
            this.groupBox1.Location = new System.Drawing.Point(155, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 229);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detail";
            // 
            // btnSKShortcut
            // 
            this.btnSKShortcut.Enabled = false;
            this.btnSKShortcut.Location = new System.Drawing.Point(112, 64);
            this.btnSKShortcut.Name = "btnSKShortcut";
            this.btnSKShortcut.Size = new System.Drawing.Size(53, 22);
            this.btnSKShortcut.TabIndex = 10;
            this.btnSKShortcut.Text = "Change";
            this.btnSKShortcut.UseVisualStyleBackColor = true;
            this.btnSKShortcut.Click += new System.EventHandler(this.btnSKShortcut_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(16, 180);
            this.lblDescription.MaximumSize = new System.Drawing.Size(130, 70);
            this.lblDescription.MinimumSize = new System.Drawing.Size(130, 40);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(130, 40);
            this.lblDescription.TabIndex = 9;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(16, 143);
            this.lblCreatedBy.MinimumSize = new System.Drawing.Size(125, 0);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(125, 13);
            this.lblCreatedBy.TabIndex = 8;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(16, 106);
            this.lblVersion.MinimumSize = new System.Drawing.Size(125, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(125, 13);
            this.lblVersion.TabIndex = 7;
            // 
            // lblShortcut
            // 
            this.lblShortcut.AutoSize = true;
            this.lblShortcut.Location = new System.Drawing.Point(16, 69);
            this.lblShortcut.MinimumSize = new System.Drawing.Size(125, 0);
            this.lblShortcut.Name = "lblShortcut";
            this.lblShortcut.Size = new System.Drawing.Size(125, 13);
            this.lblShortcut.TabIndex = 6;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(16, 32);
            this.lblFileName.MinimumSize = new System.Drawing.Size(125, 0);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(125, 13);
            this.lblFileName.TabIndex = 5;
            // 
            // lblCCreatedBy
            // 
            this.lblCCreatedBy.AutoSize = true;
            this.lblCCreatedBy.Location = new System.Drawing.Point(6, 130);
            this.lblCCreatedBy.Name = "lblCCreatedBy";
            this.lblCCreatedBy.Size = new System.Drawing.Size(59, 13);
            this.lblCCreatedBy.TabIndex = 4;
            this.lblCCreatedBy.Text = "Created By";
            // 
            // lblCVersion
            // 
            this.lblCVersion.AutoSize = true;
            this.lblCVersion.Location = new System.Drawing.Point(6, 93);
            this.lblCVersion.Name = "lblCVersion";
            this.lblCVersion.Size = new System.Drawing.Size(42, 13);
            this.lblCVersion.TabIndex = 3;
            this.lblCVersion.Text = "Version";
            // 
            // lblCDescription
            // 
            this.lblCDescription.AutoSize = true;
            this.lblCDescription.Location = new System.Drawing.Point(6, 167);
            this.lblCDescription.Name = "lblCDescription";
            this.lblCDescription.Size = new System.Drawing.Size(34, 13);
            this.lblCDescription.TabIndex = 2;
            this.lblCDescription.Text = "Detail";
            // 
            // lblCShortcut
            // 
            this.lblCShortcut.AutoSize = true;
            this.lblCShortcut.Location = new System.Drawing.Point(6, 56);
            this.lblCShortcut.Name = "lblCShortcut";
            this.lblCShortcut.Size = new System.Drawing.Size(68, 13);
            this.lblCShortcut.TabIndex = 1;
            this.lblCShortcut.Text = "Shortcut Key";
            // 
            // lblCFileName
            // 
            this.lblCFileName.AutoSize = true;
            this.lblCFileName.Location = new System.Drawing.Point(6, 19);
            this.lblCFileName.Name = "lblCFileName";
            this.lblCFileName.Size = new System.Drawing.Size(54, 13);
            this.lblCFileName.TabIndex = 0;
            this.lblCFileName.Text = "File Name";
            // 
            // btnKBUninstall
            // 
            this.btnKBUninstall.Location = new System.Drawing.Point(6, 239);
            this.btnKBUninstall.Name = "btnKBUninstall";
            this.btnKBUninstall.Size = new System.Drawing.Size(143, 24);
            this.btnKBUninstall.TabIndex = 2;
            this.btnKBUninstall.Text = "Uninstall Keyboard";
            this.btnKBUninstall.UseVisualStyleBackColor = true;
            this.btnKBUninstall.Click += new System.EventHandler(this.btnKBUninstall_Click);
            // 
            // btnKbInstaller
            // 
            this.btnKbInstaller.Location = new System.Drawing.Point(6, 211);
            this.btnKbInstaller.Name = "btnKbInstaller";
            this.btnKbInstaller.Size = new System.Drawing.Size(143, 24);
            this.btnKbInstaller.TabIndex = 1;
            this.btnKbInstaller.Text = "Install Keyboard";
            this.btnKbInstaller.UseVisualStyleBackColor = true;
            this.btnKbInstaller.Click += new System.EventHandler(this.btnKbInstaller_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(330, 266);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Option";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkStartUp);
            this.groupBox3.Location = new System.Drawing.Point(7, 137);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(316, 114);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "General";
            // 
            // chkStartUp
            // 
            this.chkStartUp.AutoSize = true;
            this.chkStartUp.Location = new System.Drawing.Point(19, 19);
            this.chkStartUp.Name = "chkStartUp";
            this.chkStartUp.Size = new System.Drawing.Size(153, 17);
            this.chkStartUp.TabIndex = 2;
            this.chkStartUp.Text = "Start when I start Windows";
            this.chkStartUp.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnKeyTouchOn);
            this.groupBox2.Controls.Add(this.lblKeyTouchOn);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnKeyTouchOff);
            this.groupBox2.Controls.Add(this.lblKeyTouchOff);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnGlobleShortcut);
            this.groupBox2.Controls.Add(this.lblGlobleShortcut);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(7, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 125);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Special Keys";
            // 
            // btnKeyTouchOn
            // 
            this.btnKeyTouchOn.Location = new System.Drawing.Point(122, 96);
            this.btnKeyTouchOn.Name = "btnKeyTouchOn";
            this.btnKeyTouchOn.Size = new System.Drawing.Size(53, 22);
            this.btnKeyTouchOn.TabIndex = 18;
            this.btnKeyTouchOn.Text = "Change";
            this.btnKeyTouchOn.UseVisualStyleBackColor = true;
            this.btnKeyTouchOn.Click += new System.EventHandler(this.btnKeyTouchOn_Click);
            // 
            // lblKeyTouchOn
            // 
            this.lblKeyTouchOn.AutoSize = true;
            this.lblKeyTouchOn.Location = new System.Drawing.Point(16, 101);
            this.lblKeyTouchOn.MinimumSize = new System.Drawing.Size(125, 0);
            this.lblKeyTouchOn.Name = "lblKeyTouchOn";
            this.lblKeyTouchOn.Size = new System.Drawing.Size(125, 13);
            this.lblKeyTouchOn.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "KeyTouch Start";
            // 
            // btnKeyTouchOff
            // 
            this.btnKeyTouchOff.Location = new System.Drawing.Point(122, 62);
            this.btnKeyTouchOff.Name = "btnKeyTouchOff";
            this.btnKeyTouchOff.Size = new System.Drawing.Size(53, 22);
            this.btnKeyTouchOff.TabIndex = 15;
            this.btnKeyTouchOff.Text = "Change";
            this.btnKeyTouchOff.UseVisualStyleBackColor = true;
            this.btnKeyTouchOff.Click += new System.EventHandler(this.btnKeyTouchOff_Click);
            // 
            // lblKeyTouchOff
            // 
            this.lblKeyTouchOff.AutoSize = true;
            this.lblKeyTouchOff.Location = new System.Drawing.Point(16, 67);
            this.lblKeyTouchOff.MinimumSize = new System.Drawing.Size(125, 0);
            this.lblKeyTouchOff.Name = "lblKeyTouchOff";
            this.lblKeyTouchOff.Size = new System.Drawing.Size(125, 13);
            this.lblKeyTouchOff.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "KeyTouch Off";
            // 
            // btnGlobleShortcut
            // 
            this.btnGlobleShortcut.Location = new System.Drawing.Point(122, 28);
            this.btnGlobleShortcut.Name = "btnGlobleShortcut";
            this.btnGlobleShortcut.Size = new System.Drawing.Size(53, 22);
            this.btnGlobleShortcut.TabIndex = 13;
            this.btnGlobleShortcut.Text = "Change";
            this.btnGlobleShortcut.UseVisualStyleBackColor = true;
            this.btnGlobleShortcut.Click += new System.EventHandler(this.btnGlobleShortcut_Click);
            // 
            // lblGlobleShortcut
            // 
            this.lblGlobleShortcut.AutoSize = true;
            this.lblGlobleShortcut.Location = new System.Drawing.Point(16, 33);
            this.lblGlobleShortcut.MinimumSize = new System.Drawing.Size(125, 0);
            this.lblGlobleShortcut.Name = "lblGlobleShortcut";
            this.lblGlobleShortcut.Size = new System.Drawing.Size(125, 13);
            this.lblGlobleShortcut.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Switch Keyboard";
            // 
            // niSystem
            // 
            this.niSystem.ContextMenuStrip = this.cmsOptions;
            this.niSystem.Icon = ((System.Drawing.Icon)(resources.GetObject("niSystem.Icon")));
            this.niSystem.Text = "Open Key 1.0";
            this.niSystem.Visible = true;
            this.niSystem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.niSystem_MouseClick);
            // 
            // cmsOptions
            // 
            this.cmsOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmConfig,
            this.toolStripSeparator1,
            this.tsmAbout,
            this.toolStripMenuItem2,
            this.tsmExit});
            this.cmsOptions.Name = "cmsOptions";
            this.cmsOptions.Size = new System.Drawing.Size(149, 82);
            // 
            // tsmConfig
            // 
            this.tsmConfig.Name = "tsmConfig";
            this.tsmConfig.Size = new System.Drawing.Size(148, 22);
            this.tsmConfig.Text = "Configuration";
            this.tsmConfig.Click += new System.EventHandler(this.tsmConfig_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // tsmAbout
            // 
            this.tsmAbout.Name = "tsmAbout";
            this.tsmAbout.Size = new System.Drawing.Size(148, 22);
            this.tsmAbout.Text = "About";
            this.tsmAbout.Click += new System.EventHandler(this.tsmAbout_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(145, 6);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(148, 22);
            this.tsmExit.Text = "Exit";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // cmsKeyboards
            // 
            this.cmsKeyboards.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmKeyboards,
            this.toolStripMenuItem1,
            this.tsmEnable});
            this.cmsKeyboards.Name = "cmsKeyboards";
            this.cmsKeyboards.Size = new System.Drawing.Size(130, 54);
            // 
            // tsmKeyboards
            // 
            this.tsmKeyboards.Name = "tsmKeyboards";
            this.tsmKeyboards.Size = new System.Drawing.Size(129, 22);
            this.tsmKeyboards.Text = "Keyboards";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(126, 6);
            // 
            // tsmEnable
            // 
            this.tsmEnable.Name = "tsmEnable";
            this.tsmEnable.Size = new System.Drawing.Size(129, 22);
            this.tsmEnable.Text = "Disable";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(272, 296);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(63, 25);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "&Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(134, 296);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ofdKbInstaller
            // 
            this.ofdKbInstaller.FileName = "ofdKbInstaller";
            // 
            // btnRevert
            // 
            this.btnRevert.Location = new System.Drawing.Point(203, 296);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(63, 25);
            this.btnRevert.TabIndex = 4;
            this.btnRevert.Text = "&Revert";
            this.btnRevert.UseVisualStyleBackColor = true;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 324);
            this.Controls.Add(this.btnRevert);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.tbMain);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfig";
            this.Text = "KeyTouch";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConfig_FormClosing);
            this.tbMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.cmsOptions.ResumeLayout(false);
            this.cmsKeyboards.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnKbInstaller;
        private System.Windows.Forms.Button btnKBUninstall;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCFileName;
        private System.Windows.Forms.Label lblCDescription;
        private System.Windows.Forms.Label lblCShortcut;
        private System.Windows.Forms.CheckedListBox chkKeyboard;
        private System.Windows.Forms.Label lblCVersion;
        private System.Windows.Forms.Label lblCCreatedBy;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblShortcut;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnSKShortcut;
        private System.Windows.Forms.NotifyIcon niSystem;
        private System.Windows.Forms.ContextMenuStrip cmsKeyboards;
        private System.Windows.Forms.ToolStripMenuItem tsmKeyboards;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmEnable;
        private System.Windows.Forms.ContextMenuStrip cmsOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog ofdKbInstaller;
        private System.Windows.Forms.Button btnRevert;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGlobleShortcut;
        private System.Windows.Forms.Label lblGlobleShortcut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnKeyTouchOff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkStartUp;
        private System.Windows.Forms.Label lblKeyTouchOff;
        private System.Windows.Forms.Button btnKeyTouchOn;
        private System.Windows.Forms.Label lblKeyTouchOn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmAbout;


    }
}

