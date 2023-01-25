
namespace CodeGenerator.UI
{
    partial class DataAccessBuilder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataAccessBuilder));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslblConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clbxTables = new System.Windows.Forms.CheckedListBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tscmbxDbObjectType = new System.Windows.Forms.ToolStripComboBox();
            this.tsbtnFilter = new System.Windows.Forms.ToolStripButton();
            this.tstxtbFilter = new System.Windows.Forms.ToolStripTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvFields = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tschkbxCheckAll = new SEFI.UserControls.ToolStripCheckBox();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tscmbxClass = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.fctxtbCode = new FastColoredTextBoxNS.FastColoredTextBox();
            this.gbTestData = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.fctxtbQuery = new FastColoredTextBoxNS.FastColoredTextBox();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.tsbtnConnect = new System.Windows.Forms.ToolStripButton();
            this.tsbtnExecute = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFields)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbCode)).BeginInit();
            this.gbTestData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbQuery)).BeginInit();
            this.toolStrip5.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1749, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblConnection});
            this.statusStrip1.Location = new System.Drawing.Point(0, 829);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1749, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslblConnection
            // 
            this.tslblConnection.Name = "tslblConnection";
            this.tslblConnection.Size = new System.Drawing.Size(118, 17);
            this.tslblConnection.Text = "toolStripStatusLabel1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clbxTables);
            this.groupBox1.Controls.Add(this.toolStrip2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 790);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tables";
            // 
            // clbxTables
            // 
            this.clbxTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbxTables.FormattingEnabled = true;
            this.clbxTables.Location = new System.Drawing.Point(3, 55);
            this.clbxTables.Name = "clbxTables";
            this.clbxTables.Size = new System.Drawing.Size(266, 732);
            this.clbxTables.TabIndex = 3;
            this.clbxTables.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbxTables_ItemCheck);
            this.clbxTables.SelectedIndexChanged += new System.EventHandler(this.clbxTables_SelectedIndexChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscmbxDbObjectType,
            this.tsbtnFilter,
            this.tstxtbFilter});
            this.toolStrip2.Location = new System.Drawing.Point(3, 16);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip2.Size = new System.Drawing.Size(266, 39);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tscmbxDbObjectType
            // 
            this.tscmbxDbObjectType.Items.AddRange(new object[] {
            "Tables",
            "Views",
            "Procedures"});
            this.tscmbxDbObjectType.Name = "tscmbxDbObjectType";
            this.tscmbxDbObjectType.Size = new System.Drawing.Size(75, 39);
            // 
            // tsbtnFilter
            // 
            this.tsbtnFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnFilter.Image = global::CodeGenerator.Properties.Resources.FilterList_321;
            this.tsbtnFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFilter.Name = "tsbtnFilter";
            this.tsbtnFilter.Size = new System.Drawing.Size(36, 36);
            this.tsbtnFilter.Text = "Filter tables";
            // 
            // tstxtbFilter
            // 
            this.tstxtbFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstxtbFilter.Name = "tstxtbFilter";
            this.tstxtbFilter.Size = new System.Drawing.Size(100, 39);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(272, 39);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 790);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvFields);
            this.groupBox4.Controls.Add(this.toolStrip3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(275, 39);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(673, 790);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Fields";
            // 
            // dgvFields
            // 
            this.dgvFields.AllowUserToAddRows = false;
            this.dgvFields.AllowUserToDeleteRows = false;
            this.dgvFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFields.Location = new System.Drawing.Point(3, 41);
            this.dgvFields.Name = "dgvFields";
            this.dgvFields.RowHeadersWidth = 72;
            this.dgvFields.Size = new System.Drawing.Size(667, 746);
            this.dgvFields.TabIndex = 1;
            this.dgvFields.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFields_CellEndEdit);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Include";
            this.Column1.MinimumWidth = 9;
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column Name";
            this.Column2.MinimumWidth = 9;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 175;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Property Name";
            this.Column3.MinimumWidth = 9;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Filter Field";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Key Column";
            this.Column5.Name = "Column5";
            this.Column5.Width = 70;
            // 
            // toolStrip3
            // 
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tschkbxCheckAll});
            this.toolStrip3.Location = new System.Drawing.Point(3, 16);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip3.Size = new System.Drawing.Size(667, 25);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // tschkbxCheckAll
            // 
            this.tschkbxCheckAll.BackColor = System.Drawing.Color.Transparent;
            this.tschkbxCheckAll.Checked = false;
            this.tschkbxCheckAll.Name = "tschkbxCheckAll";
            this.tschkbxCheckAll.Size = new System.Drawing.Size(76, 22);
            this.tschkbxCheckAll.Text = "Check All";
            // 
            // toolStrip4
            // 
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tscmbxClass,
            this.toolStripLabel2,
            this.toolStripTextBox1});
            this.toolStrip4.Location = new System.Drawing.Point(948, 39);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(801, 25);
            this.toolStrip4.TabIndex = 7;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(34, 22);
            this.toolStripLabel1.Text = "Class";
            // 
            // tscmbxClass
            // 
            this.tscmbxClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscmbxClass.Items.AddRange(new object[] {
            "Entity",
            "Mapping",
            "Query",
            "Lookup Service",
            "Save Service",
            "Delete Service",
            "Test Data Reader",
            "Test Object Factory",
            "Mapping Unit Tests",
            "Query Unit Tests"});
            this.tscmbxClass.Name = "tscmbxClass";
            this.tscmbxClass.Size = new System.Drawing.Size(121, 25);
            this.tscmbxClass.SelectedIndexChanged += new System.EventHandler(this.tscmbxClass_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(69, 22);
            this.toolStripLabel2.Text = "Class Name";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(200, 25);
            // 
            // fctxtbCode
            // 
            this.fctxtbCode.AutoCompleteBracketsList = new char[] {
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
            this.fctxtbCode.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:" +
    "]*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.fctxtbCode.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.fctxtbCode.BackBrush = null;
            this.fctxtbCode.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fctxtbCode.CharHeight = 14;
            this.fctxtbCode.CharWidth = 8;
            this.fctxtbCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctxtbCode.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctxtbCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctxtbCode.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctxtbCode.IsReplaceMode = false;
            this.fctxtbCode.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fctxtbCode.LeftBracket = '(';
            this.fctxtbCode.LeftBracket2 = '{';
            this.fctxtbCode.Location = new System.Drawing.Point(948, 459);
            this.fctxtbCode.Name = "fctxtbCode";
            this.fctxtbCode.Paddings = new System.Windows.Forms.Padding(0);
            this.fctxtbCode.RightBracket = ')';
            this.fctxtbCode.RightBracket2 = '}';
            this.fctxtbCode.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctxtbCode.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctxtbCode.ServiceColors")));
            this.fctxtbCode.Size = new System.Drawing.Size(801, 370);
            this.fctxtbCode.TabIndex = 8;
            this.fctxtbCode.Zoom = 100;
            // 
            // gbTestData
            // 
            this.gbTestData.Controls.Add(this.dgvData);
            this.gbTestData.Controls.Add(this.fctxtbQuery);
            this.gbTestData.Controls.Add(this.toolStrip5);
            this.gbTestData.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTestData.Location = new System.Drawing.Point(948, 64);
            this.gbTestData.Name = "gbTestData";
            this.gbTestData.Size = new System.Drawing.Size(801, 395);
            this.gbTestData.TabIndex = 9;
            this.gbTestData.TabStop = false;
            this.gbTestData.Text = "Test data set";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 225);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 72;
            this.dgvData.Size = new System.Drawing.Size(795, 167);
            this.dgvData.TabIndex = 13;
            // 
            // fctxtbQuery
            // 
            this.fctxtbQuery.AutoCompleteBracketsList = new char[] {
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
            this.fctxtbQuery.AutoIndentCharsPatterns = "";
            this.fctxtbQuery.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.fctxtbQuery.BackBrush = null;
            this.fctxtbQuery.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fctxtbQuery.CharHeight = 14;
            this.fctxtbQuery.CharWidth = 8;
            this.fctxtbQuery.CommentPrefix = "--";
            this.fctxtbQuery.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctxtbQuery.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctxtbQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.fctxtbQuery.IsReplaceMode = false;
            this.fctxtbQuery.Language = FastColoredTextBoxNS.Language.SQL;
            this.fctxtbQuery.LeftBracket = '(';
            this.fctxtbQuery.Location = new System.Drawing.Point(3, 55);
            this.fctxtbQuery.Name = "fctxtbQuery";
            this.fctxtbQuery.Paddings = new System.Windows.Forms.Padding(0);
            this.fctxtbQuery.RightBracket = ')';
            this.fctxtbQuery.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctxtbQuery.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctxtbQuery.ServiceColors")));
            this.fctxtbQuery.Size = new System.Drawing.Size(795, 170);
            this.fctxtbQuery.TabIndex = 12;
            this.fctxtbQuery.Zoom = 100;
            this.fctxtbQuery.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctxtbQuery_TextChanged);
            // 
            // toolStrip5
            // 
            this.toolStrip5.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnConnect,
            this.tsbtnExecute});
            this.toolStrip5.Location = new System.Drawing.Point(3, 16);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip5.Size = new System.Drawing.Size(795, 39);
            this.toolStrip5.TabIndex = 11;
            this.toolStrip5.Text = "toolStrip5";
            // 
            // tsbtnConnect
            // 
            this.tsbtnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnConnect.Image = global::CodeGenerator.Properties.Resources.DatabaseConnection_32;
            this.tsbtnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnConnect.Name = "tsbtnConnect";
            this.tsbtnConnect.Size = new System.Drawing.Size(36, 36);
            this.tsbtnConnect.Text = "Connect to a database";
            this.tsbtnConnect.Click += new System.EventHandler(this.tsbtnConnect_Click);
            // 
            // tsbtnExecute
            // 
            this.tsbtnExecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnExecute.Enabled = false;
            this.tsbtnExecute.Image = global::CodeGenerator.Properties.Resources.base_exclamationmark_32;
            this.tsbtnExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnExecute.Name = "tsbtnExecute";
            this.tsbtnExecute.Size = new System.Drawing.Size(36, 36);
            this.tsbtnExecute.Text = "Execute query";
            this.tsbtnExecute.Click += new System.EventHandler(this.tsbtnExecute_Click);
            // 
            // DataAccessBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1749, 851);
            this.Controls.Add(this.fctxtbCode);
            this.Controls.Add(this.gbTestData);
            this.Controls.Add(this.toolStrip4);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DataAccessBuilder";
            this.Text = "DataAccessBuilder";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFields)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbCode)).EndInit();
            this.gbTestData.ResumeLayout(false);
            this.gbTestData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbQuery)).EndInit();
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox clbxTables;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripComboBox tscmbxDbObjectType;
        private System.Windows.Forms.ToolStripButton tsbtnFilter;
        private System.Windows.Forms.ToolStripTextBox tstxtbFilter;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvFields;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private SEFI.UserControls.ToolStripCheckBox tschkbxCheckAll;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tscmbxClass;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private FastColoredTextBoxNS.FastColoredTextBox fctxtbCode;
        private System.Windows.Forms.ToolStripStatusLabel tslblConnection;
        private System.Windows.Forms.GroupBox gbTestData;
        private System.Windows.Forms.DataGridView dgvData;
        private FastColoredTextBoxNS.FastColoredTextBox fctxtbQuery;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripButton tsbtnConnect;
        private System.Windows.Forms.ToolStripButton tsbtnExecute;
    }
}