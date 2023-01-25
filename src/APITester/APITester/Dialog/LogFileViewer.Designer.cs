
namespace APITester.Dialog
{
    partial class LogFileViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogFileViewer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnOpenLogFile = new System.Windows.Forms.ToolStripButton();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.lbxLogEntries = new System.Windows.Forms.ListBox();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.tvPerformance = new System.Windows.Forms.TreeView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbxFilterdLogs = new System.Windows.Forms.ListBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tscmbxTPA = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tscmbxLevel = new System.Windows.Forms.ToolStripComboBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.fcrtxtbLogView = new FastColoredTextBoxNS.FastColoredTextBox();
            this.fctxtbStackTrace = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tpStatistics = new System.Windows.Forms.TabPage();
            this.toolStrip1.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fcrtxtbLogView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbStackTrace)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnOpenLogFile});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(2093, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnOpenLogFile
            // 
            this.tsbtnOpenLogFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnOpenLogFile.Image = global::APITester.Properties.Resources.FileOpen_32;
            this.tsbtnOpenLogFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpenLogFile.Name = "tsbtnOpenLogFile";
            this.tsbtnOpenLogFile.Size = new System.Drawing.Size(36, 36);
            this.tsbtnOpenLogFile.Text = "Open log file";
            this.tsbtnOpenLogFile.Click += new System.EventHandler(this.tsbtnOpenLogFile_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.tabControl4);
            this.groupBox12.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox12.Location = new System.Drawing.Point(0, 39);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(425, 1322);
            this.groupBox12.TabIndex = 13;
            this.groupBox12.TabStop = false;
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage11);
            this.tabControl4.Controls.Add(this.tabPage12);
            this.tabControl4.Controls.Add(this.tabPage1);
            this.tabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl4.Location = new System.Drawing.Point(3, 16);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(419, 1303);
            this.tabControl4.TabIndex = 1;
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.lbxLogEntries);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(411, 1277);
            this.tabPage11.TabIndex = 0;
            this.tabPage11.Text = "Log Entries";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // lbxLogEntries
            // 
            this.lbxLogEntries.DisplayMember = "Item1";
            this.lbxLogEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxLogEntries.FormattingEnabled = true;
            this.lbxLogEntries.Location = new System.Drawing.Point(3, 3);
            this.lbxLogEntries.Name = "lbxLogEntries";
            this.lbxLogEntries.Size = new System.Drawing.Size(405, 1271);
            this.lbxLogEntries.Sorted = true;
            this.lbxLogEntries.TabIndex = 0;
            this.lbxLogEntries.SelectedIndexChanged += new System.EventHandler(this.lbxLogEntries_SelectedIndexChanged);
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.tvPerformance);
            this.tabPage12.Location = new System.Drawing.Point(4, 22);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(411, 1277);
            this.tabPage12.TabIndex = 1;
            this.tabPage12.Text = "Performance Log";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // tvPerformance
            // 
            this.tvPerformance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPerformance.Location = new System.Drawing.Point(3, 3);
            this.tvPerformance.Name = "tvPerformance";
            this.tvPerformance.Size = new System.Drawing.Size(405, 1271);
            this.tvPerformance.TabIndex = 0;
            this.tvPerformance.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPerformance_AfterSelect);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbxFilterdLogs);
            this.tabPage1.Controls.Add(this.toolStrip2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(411, 1277);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Filters";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbxFilterdLogs
            // 
            this.lbxFilterdLogs.DisplayMember = "Method";
            this.lbxFilterdLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxFilterdLogs.FormattingEnabled = true;
            this.lbxFilterdLogs.Location = new System.Drawing.Point(3, 28);
            this.lbxFilterdLogs.Name = "lbxFilterdLogs";
            this.lbxFilterdLogs.Size = new System.Drawing.Size(405, 1246);
            this.lbxFilterdLogs.TabIndex = 3;
            this.lbxFilterdLogs.SelectedIndexChanged += new System.EventHandler(this.lbxFilterdLogs_SelectedIndexChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tscmbxTPA,
            this.toolStripLabel2,
            this.tscmbxLevel});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(405, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(27, 22);
            this.toolStripLabel1.Text = "TPA";
            // 
            // tscmbxTPA
            // 
            this.tscmbxTPA.Name = "tscmbxTPA";
            this.tscmbxTPA.Size = new System.Drawing.Size(75, 25);
            this.tscmbxTPA.SelectedIndexChanged += new System.EventHandler(this.tscmbxTPA_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(60, 22);
            this.toolStripLabel2.Text = "Max Level";
            // 
            // tscmbxLevel
            // 
            this.tscmbxLevel.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.tscmbxLevel.Name = "tscmbxLevel";
            this.tscmbxLevel.Size = new System.Drawing.Size(75, 25);
            this.tscmbxLevel.SelectedIndexChanged += new System.EventHandler(this.tscmbxLevel_SelectedIndexChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(425, 39);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 1322);
            this.splitter1.TabIndex = 18;
            this.splitter1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tpStatistics);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(428, 39);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1665, 1322);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.fcrtxtbLogView);
            this.tabPage2.Controls.Add(this.fctxtbStackTrace);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1657, 1296);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Detail";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // fcrtxtbLogView
            // 
            this.fcrtxtbLogView.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fcrtxtbLogView.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\n^\\s*(case|default)\\s*[^:]*(" +
    "?<range>:)\\s*(?<range>[^;]+);";
            this.fcrtxtbLogView.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.fcrtxtbLogView.BackBrush = null;
            this.fcrtxtbLogView.CharHeight = 14;
            this.fcrtxtbLogView.CharWidth = 8;
            this.fcrtxtbLogView.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fcrtxtbLogView.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fcrtxtbLogView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fcrtxtbLogView.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fcrtxtbLogView.IsReplaceMode = false;
            this.fcrtxtbLogView.Location = new System.Drawing.Point(3, 3);
            this.fcrtxtbLogView.Margin = new System.Windows.Forms.Padding(2);
            this.fcrtxtbLogView.Name = "fcrtxtbLogView";
            this.fcrtxtbLogView.Paddings = new System.Windows.Forms.Padding(0);
            this.fcrtxtbLogView.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fcrtxtbLogView.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fcrtxtbLogView.ServiceColors")));
            this.fcrtxtbLogView.Size = new System.Drawing.Size(1651, 755);
            this.fcrtxtbLogView.TabIndex = 17;
            this.fcrtxtbLogView.Zoom = 100;
            // 
            // fctxtbStackTrace
            // 
            this.fctxtbStackTrace.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fctxtbStackTrace.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\n^\\s*(case|default)\\s*[^:]*(" +
    "?<range>:)\\s*(?<range>[^;]+);";
            this.fctxtbStackTrace.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.fctxtbStackTrace.BackBrush = null;
            this.fctxtbStackTrace.CharHeight = 14;
            this.fctxtbStackTrace.CharWidth = 8;
            this.fctxtbStackTrace.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctxtbStackTrace.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctxtbStackTrace.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fctxtbStackTrace.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctxtbStackTrace.IsReplaceMode = false;
            this.fctxtbStackTrace.Location = new System.Drawing.Point(3, 758);
            this.fctxtbStackTrace.Margin = new System.Windows.Forms.Padding(2);
            this.fctxtbStackTrace.Name = "fctxtbStackTrace";
            this.fctxtbStackTrace.Paddings = new System.Windows.Forms.Padding(0);
            this.fctxtbStackTrace.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctxtbStackTrace.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctxtbStackTrace.ServiceColors")));
            this.fctxtbStackTrace.Size = new System.Drawing.Size(1651, 535);
            this.fctxtbStackTrace.TabIndex = 18;
            this.fctxtbStackTrace.Zoom = 100;
            // 
            // tpStatistics
            // 
            this.tpStatistics.Location = new System.Drawing.Point(4, 22);
            this.tpStatistics.Name = "tpStatistics";
            this.tpStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tpStatistics.Size = new System.Drawing.Size(1657, 1296);
            this.tpStatistics.TabIndex = 1;
            this.tpStatistics.Text = "Statistics";
            this.tpStatistics.UseVisualStyleBackColor = true;
            // 
            // LogFileViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2093, 1361);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogFileViewer";
            this.Text = "Log Viewer";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.tabControl4.ResumeLayout(false);
            this.tabPage11.ResumeLayout(false);
            this.tabPage12.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fcrtxtbLogView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbStackTrace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnOpenLogFile;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.ListBox lbxLogEntries;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.TreeView tvPerformance;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox lbxFilterdLogs;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tscmbxTPA;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox tscmbxLevel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private FastColoredTextBoxNS.FastColoredTextBox fcrtxtbLogView;
        private FastColoredTextBoxNS.FastColoredTextBox fctxtbStackTrace;
        private System.Windows.Forms.TabPage tpStatistics;
    }
}