
namespace SelfHostedInstallScriptGenerator
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectTargetFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectsourceFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblSourceFolder = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblTargetFolder = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblReleaseFolder = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblDbReleaseFolder = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblChecked = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbChecked = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslblGroup = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbGroups = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslblFiles = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbFiles = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tstxtbTpa = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tstxtbServer = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSelectTarget = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnBuildDatabaseBatchFiles = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSaveAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCreateZip = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clbBuilds = new System.Windows.Forms.CheckedListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rtxtbCode = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbxBatchFiles = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2116, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectTargetFolderToolStripMenuItem,
            this.selectsourceFolderToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // selectTargetFolderToolStripMenuItem
            // 
            this.selectTargetFolderToolStripMenuItem.Name = "selectTargetFolderToolStripMenuItem";
            this.selectTargetFolderToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.selectTargetFolderToolStripMenuItem.Text = "Select &sarget folder";
            // 
            // selectsourceFolderToolStripMenuItem
            // 
            this.selectsourceFolderToolStripMenuItem.Name = "selectsourceFolderToolStripMenuItem";
            this.selectsourceFolderToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.selectsourceFolderToolStripMenuItem.Text = "Select &source folder";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(174, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslblSourceFolder,
            this.toolStripStatusLabel2,
            this.tsslblTargetFolder,
            this.toolStripStatusLabel3,
            this.tsslblReleaseFolder,
            this.toolStripStatusLabel4,
            this.tsslblDbReleaseFolder,
            this.toolStripStatusLabel5,
            this.tsslblChecked,
            this.tspbChecked,
            this.tsslblGroup,
            this.tspbGroups,
            this.tsslblFiles,
            this.tspbFiles});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1090);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(2116, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(79, 19);
            this.toolStripStatusLabel1.Text = "Source Folder";
            // 
            // tsslblSourceFolder
            // 
            this.tsslblSourceFolder.BackColor = System.Drawing.SystemColors.Control;
            this.tsslblSourceFolder.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslblSourceFolder.Name = "tsslblSourceFolder";
            this.tsslblSourceFolder.Size = new System.Drawing.Size(122, 19);
            this.tsslblSourceFolder.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(75, 19);
            this.toolStripStatusLabel2.Text = "Target Folder";
            // 
            // tsslblTargetFolder
            // 
            this.tsslblTargetFolder.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslblTargetFolder.Name = "tsslblTargetFolder";
            this.tsslblTargetFolder.Size = new System.Drawing.Size(122, 19);
            this.tsslblTargetFolder.Text = "toolStripStatusLabel3";
            this.tsslblTargetFolder.DoubleClick += new System.EventHandler(this.tsslblTargetFolder_DoubleClick);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(82, 19);
            this.toolStripStatusLabel3.Text = "Release Folder";
            // 
            // tsslblReleaseFolder
            // 
            this.tsslblReleaseFolder.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslblReleaseFolder.Name = "tsslblReleaseFolder";
            this.tsslblReleaseFolder.Size = new System.Drawing.Size(122, 19);
            this.tsslblReleaseFolder.Text = "toolStripStatusLabel4";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(128, 19);
            this.toolStripStatusLabel4.Text = "Database release folder";
            // 
            // tsslblDbReleaseFolder
            // 
            this.tsslblDbReleaseFolder.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslblDbReleaseFolder.Name = "tsslblDbReleaseFolder";
            this.tsslblDbReleaseFolder.Size = new System.Drawing.Size(122, 19);
            this.tsslblDbReleaseFolder.Text = "toolStripStatusLabel5";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(662, 19);
            this.toolStripStatusLabel5.Spring = true;
            this.toolStripStatusLabel5.Text = "Progress:";
            this.toolStripStatusLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tsslblChecked
            // 
            this.tsslblChecked.AutoSize = false;
            this.tsslblChecked.Name = "tsslblChecked";
            this.tsslblChecked.Size = new System.Drawing.Size(50, 19);
            this.tsslblChecked.Text = "1 of ?";
            // 
            // tspbChecked
            // 
            this.tspbChecked.Name = "tspbChecked";
            this.tspbChecked.Size = new System.Drawing.Size(100, 18);
            // 
            // tsslblGroup
            // 
            this.tsslblGroup.AutoSize = false;
            this.tsslblGroup.Name = "tsslblGroup";
            this.tsslblGroup.Size = new System.Drawing.Size(50, 19);
            this.tsslblGroup.Text = "0 of 3";
            // 
            // tspbGroups
            // 
            this.tspbGroups.Maximum = 3;
            this.tspbGroups.Name = "tspbGroups";
            this.tspbGroups.Size = new System.Drawing.Size(100, 18);
            // 
            // tsslblFiles
            // 
            this.tsslblFiles.AutoSize = false;
            this.tsslblFiles.Name = "tsslblFiles";
            this.tsslblFiles.Size = new System.Drawing.Size(50, 19);
            this.tsslblFiles.Text = "0 of ?";
            // 
            // tspbFiles
            // 
            this.tspbFiles.AutoSize = false;
            this.tspbFiles.Name = "tspbFiles";
            this.tspbFiles.Size = new System.Drawing.Size(200, 18);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tstxtbTpa,
            this.toolStripLabel2,
            this.tstxtbServer,
            this.toolStripSeparator1,
            this.tsbtnSelectTarget,
            this.toolStripSeparator2,
            this.tsbtnBuildDatabaseBatchFiles,
            this.toolStripSeparator3,
            this.tsbtnSaveAll,
            this.toolStripSeparator4,
            this.tsbtnCopy,
            this.tsbtnCreateZip});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(2116, 39);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(27, 36);
            this.toolStripLabel1.Text = "TPA";
            // 
            // tstxtbTpa
            // 
            this.tstxtbTpa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstxtbTpa.Name = "tstxtbTpa";
            this.tstxtbTpa.Size = new System.Drawing.Size(100, 39);
            this.tstxtbTpa.Leave += new System.EventHandler(this.tstxtbTpa_Leave);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(125, 36);
            this.toolStripLabel2.Text = "Database Server Name";
            // 
            // tstxtbServer
            // 
            this.tstxtbServer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstxtbServer.Name = "tstxtbServer";
            this.tstxtbServer.Size = new System.Drawing.Size(100, 39);
            this.tstxtbServer.Leave += new System.EventHandler(this.tstxtbServer_Leave);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnSelectTarget
            // 
            this.tsbtnSelectTarget.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSelectTarget.Image = global::SelfHostedInstallScriptGenerator.Properties.Resources.ConfigureWrench_64;
            this.tsbtnSelectTarget.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSelectTarget.Name = "tsbtnSelectTarget";
            this.tsbtnSelectTarget.Size = new System.Drawing.Size(36, 36);
            this.tsbtnSelectTarget.Text = "Select Folders";
            this.tsbtnSelectTarget.Click += new System.EventHandler(this.tsbtnSelectTargetFolder_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnBuildDatabaseBatchFiles
            // 
            this.tsbtnBuildDatabaseBatchFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnBuildDatabaseBatchFiles.Image = global::SelfHostedInstallScriptGenerator.Properties.Resources.RunDatabaseScript_32;
            this.tsbtnBuildDatabaseBatchFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnBuildDatabaseBatchFiles.Name = "tsbtnBuildDatabaseBatchFiles";
            this.tsbtnBuildDatabaseBatchFiles.Size = new System.Drawing.Size(36, 36);
            this.tsbtnBuildDatabaseBatchFiles.Text = "Generate database deployment batch files";
            this.tsbtnBuildDatabaseBatchFiles.Click += new System.EventHandler(this.tsbtnBuildDatabaseBatchFiles_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnSaveAll
            // 
            this.tsbtnSaveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSaveAll.Image = global::SelfHostedInstallScriptGenerator.Properties.Resources.FloppyDisk_32;
            this.tsbtnSaveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSaveAll.Name = "tsbtnSaveAll";
            this.tsbtnSaveAll.Size = new System.Drawing.Size(36, 36);
            this.tsbtnSaveAll.Text = "Save all files";
            this.tsbtnSaveAll.Click += new System.EventHandler(this.tsbtnSaveAll_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnCopy
            // 
            this.tsbtnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnCopy.Image = global::SelfHostedInstallScriptGenerator.Properties.Resources.DocumentCopy_32;
            this.tsbtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCopy.Name = "tsbtnCopy";
            this.tsbtnCopy.Size = new System.Drawing.Size(36, 36);
            this.tsbtnCopy.Text = "Copy SQL script files";
            this.tsbtnCopy.Click += new System.EventHandler(this.tsbtnCopy_Click);
            // 
            // tsbtnCreateZip
            // 
            this.tsbtnCreateZip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnCreateZip.Image = global::SelfHostedInstallScriptGenerator.Properties.Resources.Compress_32;
            this.tsbtnCreateZip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCreateZip.Name = "tsbtnCreateZip";
            this.tsbtnCreateZip.Size = new System.Drawing.Size(36, 36);
            this.tsbtnCreateZip.Text = "Create Zip File";
            this.tsbtnCreateZip.Click += new System.EventHandler(this.tsbtnCreateZip_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clbBuilds);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 1027);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available Builds";
            // 
            // clbBuilds
            // 
            this.clbBuilds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbBuilds.FormattingEnabled = true;
            this.clbBuilds.Location = new System.Drawing.Point(3, 16);
            this.clbBuilds.Name = "clbBuilds";
            this.clbBuilds.Size = new System.Drawing.Size(299, 1008);
            this.clbBuilds.TabIndex = 0;
            this.clbBuilds.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbBuilds_ItemCheck);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(305, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1811, 1027);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rtxtbCode);
            this.tabPage1.Controls.Add(this.splitter1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1803, 1001);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Database Batch Files";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rtxtbCode
            // 
            this.rtxtbCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtbCode.Location = new System.Drawing.Point(292, 3);
            this.rtxtbCode.Name = "rtxtbCode";
            this.rtxtbCode.Size = new System.Drawing.Size(1508, 995);
            this.rtxtbCode.TabIndex = 2;
            this.rtxtbCode.Text = "";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(289, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 995);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbxBatchFiles);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 995);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Files";
            // 
            // lbxBatchFiles
            // 
            this.lbxBatchFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxBatchFiles.FormattingEnabled = true;
            this.lbxBatchFiles.Location = new System.Drawing.Point(3, 16);
            this.lbxBatchFiles.Name = "lbxBatchFiles";
            this.lbxBatchFiles.Size = new System.Drawing.Size(280, 976);
            this.lbxBatchFiles.TabIndex = 0;
            this.lbxBatchFiles.SelectedIndexChanged += new System.EventHandler(this.lbxBatchFiles_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1803, 1001);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2116, 1114);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Self-hosted Script Generator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblSourceFolder;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tstxtbTpa;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslblTargetFolder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox clbBuilds;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectTargetFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectsourceFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnSelectTarget;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnBuildDatabaseBatchFiles;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbxBatchFiles;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tsslblReleaseFolder;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tsslblDbReleaseFolder;
        private System.Windows.Forms.RichTextBox rtxtbCode;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnSaveAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbtnCreateZip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel tsslblGroup;
        private System.Windows.Forms.ToolStripProgressBar tspbGroups;
        private System.Windows.Forms.ToolStripStatusLabel tsslblFiles;
        private System.Windows.Forms.ToolStripProgressBar tspbFiles;
        private System.Windows.Forms.ToolStripStatusLabel tsslblChecked;
        private System.Windows.Forms.ToolStripProgressBar tspbChecked;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tstxtbServer;
        private System.Windows.Forms.ToolStripButton tsbtnCopy;
    }
}

