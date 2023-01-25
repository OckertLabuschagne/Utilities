
namespace CodeGenerator.UI
{
    partial class TestObjectForClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestObjectForClass));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnSelectAssembly = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslblAssembly = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbxTypes = new System.Windows.Forms.ListBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.fctxtbAssemblies = new FastColoredTextBoxNS.FastColoredTextBox();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tscmbxCode = new System.Windows.Forms.ToolStripComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gbTestData = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.fctxtbQuery = new FastColoredTextBoxNS.FastColoredTextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbtnConnect = new System.Windows.Forms.ToolStripButton();
            this.tsbtnExecute = new System.Windows.Forms.ToolStripButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtnFormValues = new System.Windows.Forms.RadioButton();
            this.rbtnFromDb = new System.Windows.Forms.RadioButton();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tslblMappingClassAssembly = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tscmbxMappingClass = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tscmbxInterface = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnCreateCode = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbAssemblies)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbTestData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbQuery)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStrip5.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSelectAssembly});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1347, 39);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnSelectAssembly
            // 
            this.tsbtnSelectAssembly.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSelectAssembly.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSelectAssembly.Image")));
            this.tsbtnSelectAssembly.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSelectAssembly.Name = "tsbtnSelectAssembly";
            this.tsbtnSelectAssembly.Size = new System.Drawing.Size(36, 36);
            this.tsbtnSelectAssembly.Text = "Load Class Assembly";
            this.tsbtnSelectAssembly.Click += new System.EventHandler(this.tsbtnSelectAssembly_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblAssembly});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1046);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1347, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslblAssembly
            // 
            this.tsslblAssembly.Name = "tsslblAssembly";
            this.tsslblAssembly.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbxTypes);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 1007);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Classes";
            // 
            // lbxTypes
            // 
            this.lbxTypes.DisplayMember = "Name";
            this.lbxTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxTypes.FormattingEnabled = true;
            this.lbxTypes.IntegralHeight = false;
            this.lbxTypes.Location = new System.Drawing.Point(3, 16);
            this.lbxTypes.Name = "lbxTypes";
            this.lbxTypes.Size = new System.Drawing.Size(287, 988);
            this.lbxTypes.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(293, 39);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 1007);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.gbTestData);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.toolStrip5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(296, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1051, 1007);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Class";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.fctxtbAssemblies);
            this.groupBox5.Controls.Add(this.toolStrip3);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 627);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1045, 377);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Code";
            // 
            // fctxtbAssemblies
            // 
            this.fctxtbAssemblies.AutoCompleteBracketsList = new char[] {
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
            this.fctxtbAssemblies.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:" +
    "]*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.fctxtbAssemblies.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.fctxtbAssemblies.BackBrush = null;
            this.fctxtbAssemblies.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fctxtbAssemblies.CharHeight = 14;
            this.fctxtbAssemblies.CharWidth = 8;
            this.fctxtbAssemblies.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctxtbAssemblies.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctxtbAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctxtbAssemblies.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctxtbAssemblies.IsReplaceMode = false;
            this.fctxtbAssemblies.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fctxtbAssemblies.LeftBracket = '(';
            this.fctxtbAssemblies.LeftBracket2 = '{';
            this.fctxtbAssemblies.Location = new System.Drawing.Point(3, 41);
            this.fctxtbAssemblies.Name = "fctxtbAssemblies";
            this.fctxtbAssemblies.Paddings = new System.Windows.Forms.Padding(0);
            this.fctxtbAssemblies.RightBracket = ')';
            this.fctxtbAssemblies.RightBracket2 = '}';
            this.fctxtbAssemblies.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctxtbAssemblies.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctxtbAssemblies.ServiceColors")));
            this.fctxtbAssemblies.Size = new System.Drawing.Size(1039, 333);
            this.fctxtbAssemblies.TabIndex = 8;
            this.fctxtbAssemblies.Zoom = 100;
            // 
            // toolStrip3
            // 
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.tscmbxCode});
            this.toolStrip3.Location = new System.Drawing.Point(3, 16);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(1039, 25);
            this.toolStrip3.TabIndex = 9;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(38, 22);
            this.toolStripLabel4.Text = "Code:";
            // 
            // tscmbxCode
            // 
            this.tscmbxCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscmbxCode.Name = "tscmbxCode";
            this.tscmbxCode.Size = new System.Drawing.Size(121, 25);
            this.tscmbxCode.Click += new System.EventHandler(this.tscmbxCode_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 495);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1045, 132);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Test Object Values";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1039, 113);
            this.dataGridView1.TabIndex = 0;
            // 
            // gbTestData
            // 
            this.gbTestData.Controls.Add(this.dgvData);
            this.gbTestData.Controls.Add(this.fctxtbQuery);
            this.gbTestData.Controls.Add(this.toolStrip2);
            this.gbTestData.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTestData.Location = new System.Drawing.Point(3, 100);
            this.gbTestData.Name = "gbTestData";
            this.gbTestData.Size = new System.Drawing.Size(1045, 395);
            this.gbTestData.TabIndex = 10;
            this.gbTestData.TabStop = false;
            this.gbTestData.Text = "Test object data set";
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
            this.dgvData.Size = new System.Drawing.Size(1039, 167);
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
            this.fctxtbQuery.Size = new System.Drawing.Size(1039, 170);
            this.fctxtbQuery.TabIndex = 12;
            this.fctxtbQuery.Zoom = 100;
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnConnect,
            this.tsbtnExecute});
            this.toolStrip2.Location = new System.Drawing.Point(3, 16);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip2.Size = new System.Drawing.Size(1039, 39);
            this.toolStrip2.TabIndex = 14;
            this.toolStrip2.Text = "toolStrip2";
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtnFormValues);
            this.groupBox3.Controls.Add(this.rbtnFromDb);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1045, 45);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Options";
            // 
            // rbtnFormValues
            // 
            this.rbtnFormValues.AutoSize = true;
            this.rbtnFormValues.Location = new System.Drawing.Point(109, 19);
            this.rbtnFormValues.Name = "rbtnFormValues";
            this.rbtnFormValues.Size = new System.Drawing.Size(83, 17);
            this.rbtnFormValues.TabIndex = 1;
            this.rbtnFormValues.Text = "From Values";
            this.rbtnFormValues.UseVisualStyleBackColor = true;
            this.rbtnFormValues.CheckedChanged += new System.EventHandler(this.rbtnFormDb_CheckedChanged);
            // 
            // rbtnFromDb
            // 
            this.rbtnFromDb.AutoSize = true;
            this.rbtnFromDb.Checked = true;
            this.rbtnFromDb.Location = new System.Drawing.Point(6, 19);
            this.rbtnFromDb.Name = "rbtnFromDb";
            this.rbtnFromDb.Size = new System.Drawing.Size(97, 17);
            this.rbtnFromDb.TabIndex = 0;
            this.rbtnFromDb.TabStop = true;
            this.rbtnFromDb.Text = "From Database";
            this.rbtnFromDb.UseVisualStyleBackColor = true;
            this.rbtnFromDb.CheckedChanged += new System.EventHandler(this.rbtnFormDb_CheckedChanged);
            // 
            // toolStrip5
            // 
            this.toolStrip5.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.tslblMappingClassAssembly,
            this.toolStripLabel1,
            this.tscmbxMappingClass,
            this.toolStripButton2,
            this.toolStripLabel2,
            this.toolStripLabel3,
            this.tscmbxInterface,
            this.toolStripSeparator1,
            this.tsbtnCreateCode});
            this.toolStrip5.Location = new System.Drawing.Point(3, 16);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip5.Size = new System.Drawing.Size(1045, 39);
            this.toolStrip5.TabIndex = 14;
            this.toolStrip5.Text = "toolStrip5";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton1.Text = "Select class file";
            // 
            // tslblMappingClassAssembly
            // 
            this.tslblMappingClassAssembly.Name = "tslblMappingClassAssembly";
            this.tslblMappingClassAssembly.Size = new System.Drawing.Size(19, 36);
            this.tslblMappingClassAssembly.Text = "FI.";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(88, 36);
            this.toolStripLabel1.Text = "Mapping Class:";
            // 
            // tscmbxMappingClass
            // 
            this.tscmbxMappingClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscmbxMappingClass.Name = "tscmbxMappingClass";
            this.tscmbxMappingClass.Size = new System.Drawing.Size(200, 39);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton2.Text = "Select Lookup Service Interface Assembly";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(146, 36);
            this.toolStripLabel2.Text = "FI.Services.IlookupService?";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(56, 36);
            this.toolStripLabel3.Text = "Interface:";
            // 
            // tscmbxInterface
            // 
            this.tscmbxInterface.Name = "tscmbxInterface";
            this.tscmbxInterface.Size = new System.Drawing.Size(200, 39);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnCreateCode
            // 
            this.tsbtnCreateCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnCreateCode.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCreateCode.Image")));
            this.tsbtnCreateCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCreateCode.Name = "tsbtnCreateCode";
            this.tsbtnCreateCode.Size = new System.Drawing.Size(36, 36);
            this.tsbtnCreateCode.Text = "toolStripButton3";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Class source file (*.cs|*.cs|All files (*.*)|*.*";
            // 
            // TestObjectForClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 1068);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestObjectForClass";
            this.Text = "Test Object For Class";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbAssemblies)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbTestData.ResumeLayout(false);
            this.gbTestData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbQuery)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnSelectAssembly;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblAssembly;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbxTypes;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbTestData;
        private System.Windows.Forms.DataGridView dgvData;
        private FastColoredTextBoxNS.FastColoredTextBox fctxtbQuery;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtnFormValues;
        private System.Windows.Forms.RadioButton rbtnFromDb;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbtnConnect;
        private System.Windows.Forms.ToolStripButton tsbtnExecute;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel tslblMappingClassAssembly;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tscmbxMappingClass;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox tscmbxInterface;
        private FastColoredTextBoxNS.FastColoredTextBox fctxtbAssemblies;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnCreateCode;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripComboBox tscmbxCode;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}