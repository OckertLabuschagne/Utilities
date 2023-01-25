namespace APITester
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEnvironment = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLocal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnGetToken = new System.Windows.Forms.ToolStripButton();
            this.tsbtnUserCredentials = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnConfigureCommands = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tslblDownloadFolder = new System.Windows.Forms.ToolStripLabel();
            this.tsbtnGetDownloadFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.tstxtbTPA = new System.Windows.Forms.ToolStripTextBox();
            this.tsbtnOpenLogViewer = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblEnvironment = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblUserId = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblToken = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblResultCode = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblExecuting = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tcCommand = new System.Windows.Forms.TabControl();
            this.tpResponse = new System.Windows.Forms.TabPage();
            this.pnlImage = new System.Windows.Forms.Panel();
            this.documentPreview1 = new MigraDoc.Rendering.Forms.DocumentPreview();
            this.rtbResults = new FastColoredTextBoxNS.FastColoredTextBox();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.tslblFileName = new System.Windows.Forms.ToolStripLabel();
            this.tsbtnViewFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnViewAsImage = new System.Windows.Forms.ToolStripButton();
            this.tpCommandConfig = new System.Windows.Forms.TabPage();
            this.commandEditorControl1 = new APITester.Dialog.CommandEditorControl();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tvCommands = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneSelectedCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRun = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tslblCommandName = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tscmbxVerbs = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.tstxtbURL = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSaveCommand = new System.Windows.Forms.ToolStripButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.fctxtbResult = new FastColoredTextBoxNS.FastColoredTextBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fctxtbRaw = new FastColoredTextBoxNS.FastColoredTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbtnGet = new System.Windows.Forms.RadioButton();
            this.rbtnPut = new System.Windows.Forms.RadioButton();
            this.rbtnPost = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtbURL = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbxFiles = new System.Windows.Forms.ListBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tstxtbFolder = new System.Windows.Forms.ToolStripTextBox();
            this.tsbtnSelectGolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tscmbxAPi = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnExecute = new System.Windows.Forms.ToolStripButton();
            this.tsbtnQueryData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsbtnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.fctxtbLog = new FastColoredTextBoxNS.FastColoredTextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lblDudation = new System.Windows.Forms.Label();
            this.lblAverageDuration = new System.Windows.Forms.Label();
            this.lblMaxTasks = new System.Windows.Forms.Label();
            this.lblErrors = new System.Windows.Forms.Label();
            this.lblNumCallsMade = new System.Windows.Forms.Label();
            this.lblActiveTasks = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbEndLoad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbStartLoad = new System.Windows.Forms.TextBox();
            this.txtbLoadIncrement = new System.Windows.Forms.TextBox();
            this.rbtnMultipleLoads = new System.Windows.Forms.RadioButton();
            this.txtbTBC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbTestDuration = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbNumCalls = new System.Windows.Forms.TextBox();
            this.rbtnTime = new System.Windows.Forms.RadioButton();
            this.rbtnNumberOfCalls = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtbTestURL = new System.Windows.Forms.TextBox();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.tsbtnAddPerformanceTest = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEditLoadTests = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSaveLoadTests = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel10 = new System.Windows.Forms.ToolStripLabel();
            this.tscmbxTPA = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel11 = new System.Windows.Forms.ToolStripLabel();
            this.tscmbxCommand = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnStartTest = new System.Windows.Forms.ToolStripButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.commandEditorControl2 = new APITester.Dialog.CommandEditorControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dgvSequenceResults = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.lbxSequence = new System.Windows.Forms.ListBox();
            this.toolStrip7 = new System.Windows.Forms.ToolStrip();
            this.tsbtnAddStep = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDeleteStep = new System.Windows.Forms.ToolStripButton();
            this.toolStrip6 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
            this.tscmbxSequences = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnAddSequence = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDeleteSequence = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSequenceZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSequenceZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnStartSequence = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSequenceSave = new System.Windows.Forms.ToolStripButton();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.cePerformance = new APITester.Dialog.CommandEditorControl();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.dgvChange = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbSamplePayloads = new System.Windows.Forms.GroupBox();
            this.fctxtbSamplePayload = new FastColoredTextBoxNS.FastColoredTextBox();
            this.toolStrip12 = new System.Windows.Forms.ToolStrip();
            this.tsbtnNextPayload = new System.Windows.Forms.ToolStripButton();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.rbtnChangePayload = new System.Windows.Forms.CheckBox();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.fctxtbIncomingPayload = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.txtbIncommingPayloadSize = new System.Windows.Forms.TextBox();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.txtbOutgoingPayloadSize = new System.Windows.Forms.TextBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.txtbAverageDuration = new System.Windows.Forms.TextBox();
            this.gbEndpoints = new System.Windows.Forms.GroupBox();
            this.rbtnDeleteDocument = new System.Windows.Forms.RadioButton();
            this.rbtnCreatePayments = new System.Windows.Forms.RadioButton();
            this.rbtnUpdateClaim = new System.Windows.Forms.RadioButton();
            this.rbtnAttachDocument = new System.Windows.Forms.RadioButton();
            this.rbtnCreateInspectionRequest = new System.Windows.Forms.RadioButton();
            this.rbtnCreateClaim = new System.Windows.Forms.RadioButton();
            this.rbtnGetCreditCard = new System.Windows.Forms.RadioButton();
            this.rbtnGetInspectionHistory = new System.Windows.Forms.RadioButton();
            this.rbtnGetInspectionRequests = new System.Windows.Forms.RadioButton();
            this.rbtnGetInspectionPartners = new System.Windows.Forms.RadioButton();
            this.rbtnGetClaimPayees = new System.Windows.Forms.RadioButton();
            this.rbtnGetOutgoingDocument = new System.Windows.Forms.RadioButton();
            this.rbtnGetDocument = new System.Windows.Forms.RadioButton();
            this.rbtnGetClaimDocuments = new System.Windows.Forms.RadioButton();
            this.rbtnGetSingleClaim = new System.Windows.Forms.RadioButton();
            this.rbtnGetAllClaims = new System.Windows.Forms.RadioButton();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.txtbLoginURL = new System.Windows.Forms.TextBox();
            this.toolStrip10 = new System.Windows.Forms.ToolStrip();
            this.tsbtnAddTPA = new System.Windows.Forms.ToolStripButton();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.txtbUserSecret = new System.Windows.Forms.TextBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.txtbUserId = new System.Windows.Forms.TextBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.txtbBaseURL = new System.Windows.Forms.TextBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.cmbxTPA = new System.Windows.Forms.ComboBox();
            this.toolStrip9 = new System.Windows.Forms.ToolStrip();
            this.tsbtnSavePerformnceCommands = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel9 = new System.Windows.Forms.ToolStripLabel();
            this.tstxtbNumberOfIterations = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRunPerformanceCommand = new System.Windows.Forms.ToolStripButton();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.fcrtxtbLogView = new FastColoredTextBoxNS.FastColoredTextBox();
            this.splitter7 = new System.Windows.Forms.Splitter();
            this.fctxtbStackTrace = new FastColoredTextBoxNS.FastColoredTextBox();
            this.splitter6 = new System.Windows.Forms.Splitter();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.lbxLogEntries = new System.Windows.Forms.ListBox();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.tvPerformance = new System.Windows.Forms.TreeView();
            this.splitter5 = new System.Windows.Forms.Splitter();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.tvLogFiles = new System.Windows.Forms.TreeView();
            this.toolStrip11 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel12 = new System.Windows.Forms.ToolStripLabel();
            this.tsbtnLoadNextPage = new System.Windows.Forms.ToolStripButton();
            this.tsbtnLoadPreviousPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel14 = new System.Windows.Forms.ToolStripLabel();
            this.tstxtbPageSize = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip8 = new System.Windows.Forms.ToolStrip();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbtnFilterLog = new System.Windows.Forms.ToolStripButton();
            this.tslblMinDate = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnOpenLogFile = new System.Windows.Forms.ToolStripButton();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.fctxtbSQLCommand = new FastColoredTextBoxNS.FastColoredTextBox();
            this.toolStrip14 = new System.Windows.Forms.ToolStrip();
            this.tsbtnRunSQLCommand = new System.Windows.Forms.ToolStripButton();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.rbtnDeleteClaim = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tcCommand.SuspendLayout();
            this.tpResponse.SuspendLayout();
            this.pnlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rtbResults)).BeginInit();
            this.toolStrip4.SuspendLayout();
            this.tpCommandConfig.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbResult)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbRaw)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbLog)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.toolStrip5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSequenceResults)).BeginInit();
            this.groupBox10.SuspendLayout();
            this.toolStrip7.SuspendLayout();
            this.toolStrip6.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChange)).BeginInit();
            this.gbSamplePayloads.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbSamplePayload)).BeginInit();
            this.toolStrip12.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbIncomingPayload)).BeginInit();
            this.tabPage15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.groupBox19.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.gbEndpoints.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.toolStrip10.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.toolStrip9.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fcrtxtbLogView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbStackTrace)).BeginInit();
            this.groupBox12.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.toolStrip11.SuspendLayout();
            this.toolStrip8.SuspendLayout();
            this.tabPage14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbSQLCommand)).BeginInit();
            this.toolStrip14.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tsmiEnvironment});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1987, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Ex&it";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tsmiEnvironment
            // 
            this.tsmiEnvironment.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLocal});
            this.tsmiEnvironment.Name = "tsmiEnvironment";
            this.tsmiEnvironment.Size = new System.Drawing.Size(87, 22);
            this.tsmiEnvironment.Text = "&Environment";
            // 
            // tsmiLocal
            // 
            this.tsmiLocal.Name = "tsmiLocal";
            this.tsmiLocal.Size = new System.Drawing.Size(102, 22);
            this.tsmiLocal.Text = "Local";
            this.tsmiLocal.Click += new System.EventHandler(this.localToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnGetToken,
            this.tsbtnUserCredentials,
            this.toolStripSeparator1,
            this.tsbtnConfigureCommands,
            this.toolStripSeparator8,
            this.toolStripLabel1,
            this.tslblDownloadFolder,
            this.tsbtnGetDownloadFolder,
            this.toolStripSeparator9,
            this.toolStripLabel7,
            this.tstxtbTPA,
            this.tsbtnOpenLogViewer});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1987, 39);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnGetToken
            // 
            this.tsbtnGetToken.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnGetToken.Image = global::APITester.Properties.Resources.PadLock_32;
            this.tsbtnGetToken.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGetToken.Name = "tsbtnGetToken";
            this.tsbtnGetToken.Size = new System.Drawing.Size(36, 36);
            this.tsbtnGetToken.Text = "Get Token";
            this.tsbtnGetToken.Click += new System.EventHandler(this.tsbtnGetToken_Click);
            // 
            // tsbtnUserCredentials
            // 
            this.tsbtnUserCredentials.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnUserCredentials.Image = global::APITester.Properties.Resources.UserPassword_32;
            this.tsbtnUserCredentials.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnUserCredentials.Name = "tsbtnUserCredentials";
            this.tsbtnUserCredentials.Size = new System.Drawing.Size(36, 36);
            this.tsbtnUserCredentials.Text = "toolStripButton3";
            this.tsbtnUserCredentials.ToolTipText = "Set user credentials";
            this.tsbtnUserCredentials.Click += new System.EventHandler(this.tsbtnUserCredentials_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnConfigureCommands
            // 
            this.tsbtnConfigureCommands.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnConfigureCommands.Image = global::APITester.Properties.Resources.RunProcess_32;
            this.tsbtnConfigureCommands.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnConfigureCommands.Name = "tsbtnConfigureCommands";
            this.tsbtnConfigureCommands.Size = new System.Drawing.Size(36, 36);
            this.tsbtnConfigureCommands.Text = "Configure Commands";
            this.tsbtnConfigureCommands.Click += new System.EventHandler(this.tsbtnConfigureCommands_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(97, 36);
            this.toolStripLabel1.Text = "Download Folder";
            // 
            // tslblDownloadFolder
            // 
            this.tslblDownloadFolder.Name = "tslblDownloadFolder";
            this.tslblDownloadFolder.Size = new System.Drawing.Size(0, 36);
            // 
            // tsbtnGetDownloadFolder
            // 
            this.tsbtnGetDownloadFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnGetDownloadFolder.Image = global::APITester.Properties.Resources.OpenDocumentFolder_32;
            this.tsbtnGetDownloadFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGetDownloadFolder.Name = "tsbtnGetDownloadFolder";
            this.tsbtnGetDownloadFolder.Size = new System.Drawing.Size(36, 36);
            this.tsbtnGetDownloadFolder.Text = "toolStripButton3";
            this.tsbtnGetDownloadFolder.ToolTipText = "Select download folder";
            this.tsbtnGetDownloadFolder.Click += new System.EventHandler(this.tsbtnGetDownloadFolder_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(27, 36);
            this.toolStripLabel7.Text = "TPA";
            // 
            // tstxtbTPA
            // 
            this.tstxtbTPA.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstxtbTPA.Name = "tstxtbTPA";
            this.tstxtbTPA.Size = new System.Drawing.Size(34, 39);
            this.tstxtbTPA.Text = "fias";
            this.tstxtbTPA.Leave += new System.EventHandler(this.tstxtbTPA_Leave);
            // 
            // tsbtnOpenLogViewer
            // 
            this.tsbtnOpenLogViewer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnOpenLogViewer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnOpenLogViewer.Image = global::APITester.Properties.Resources.View_32;
            this.tsbtnOpenLogViewer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpenLogViewer.Name = "tsbtnOpenLogViewer";
            this.tsbtnOpenLogViewer.Size = new System.Drawing.Size(36, 36);
            this.tsbtnOpenLogViewer.Text = "Open Log Viewer";
            this.tsbtnOpenLogViewer.Click += new System.EventHandler(this.tsbtnOpenLogViewer_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslblEnvironment,
            this.tsslblUser,
            this.tsslblUserId,
            this.toolStripStatusLabel3,
            this.tsslblToken,
            this.toolStripStatusLabel2,
            this.tsslblResultCode,
            this.tsslblMessage,
            this.tsslblExecuting,
            this.tsslblProgress,
            this.tspbProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1362);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1987, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "Result";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatusLabel1.Text = "Environment";
            // 
            // tsslblEnvironment
            // 
            this.tsslblEnvironment.Name = "tsslblEnvironment";
            this.tsslblEnvironment.Size = new System.Drawing.Size(35, 17);
            this.tsslblEnvironment.Text = "Local";
            // 
            // tsslblUser
            // 
            this.tsslblUser.Name = "tsslblUser";
            this.tsslblUser.Size = new System.Drawing.Size(30, 17);
            this.tsslblUser.Text = "User";
            // 
            // tsslblUserId
            // 
            this.tsslblUserId.Name = "tsslblUserId";
            this.tsslblUserId.Size = new System.Drawing.Size(330, 17);
            this.tsslblUserId.Text = "FIAS|apiuser|20181120|DFA68ED137A4A3FE3719106D270A2008";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel3.Text = "Token";
            // 
            // tsslblToken
            // 
            this.tsslblToken.BackColor = System.Drawing.Color.Red;
            this.tsslblToken.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsslblToken.ForeColor = System.Drawing.Color.White;
            this.tsslblToken.Name = "tsslblToken";
            this.tsslblToken.Size = new System.Drawing.Size(73, 17);
            this.tsslblToken.Text = "Not aquired";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel2.Text = "Result";
            // 
            // tsslblResultCode
            // 
            this.tsslblResultCode.Name = "tsslblResultCode";
            this.tsslblResultCode.Size = new System.Drawing.Size(13, 17);
            this.tsslblResultCode.Text = "0";
            // 
            // tsslblMessage
            // 
            this.tsslblMessage.Name = "tsslblMessage";
            this.tsslblMessage.Size = new System.Drawing.Size(1339, 17);
            this.tsslblMessage.Spring = true;
            this.tsslblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsslblExecuting
            // 
            this.tsslblExecuting.BackColor = System.Drawing.Color.Red;
            this.tsslblExecuting.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsslblExecuting.ForeColor = System.Drawing.Color.White;
            this.tsslblExecuting.Name = "tsslblExecuting";
            this.tsslblExecuting.Size = new System.Drawing.Size(62, 17);
            this.tsslblExecuting.Text = "Executing";
            this.tsslblExecuting.Visible = false;
            // 
            // tsslblProgress
            // 
            this.tsslblProgress.Name = "tsslblProgress";
            this.tsslblProgress.Size = new System.Drawing.Size(36, 17);
            this.tsslblProgress.Text = "1 of 1";
            this.tsslblProgress.Visible = false;
            // 
            // tspbProgress
            // 
            this.tspbProgress.Name = "tspbProgress";
            this.tspbProgress.Size = new System.Drawing.Size(100, 16);
            this.tspbProgress.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage14);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 63);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1987, 1299);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tcCommand);
            this.tabPage1.Controls.Add(this.splitter3);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.toolStrip3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(1979, 1273);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Commands";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tcCommand
            // 
            this.tcCommand.Controls.Add(this.tpResponse);
            this.tcCommand.Controls.Add(this.tpCommandConfig);
            this.tcCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCommand.Location = new System.Drawing.Point(258, 41);
            this.tcCommand.Name = "tcCommand";
            this.tcCommand.SelectedIndex = 0;
            this.tcCommand.Size = new System.Drawing.Size(1719, 1230);
            this.tcCommand.TabIndex = 3;
            // 
            // tpResponse
            // 
            this.tpResponse.Controls.Add(this.pnlImage);
            this.tpResponse.Controls.Add(this.rtbResults);
            this.tpResponse.Controls.Add(this.toolStrip4);
            this.tpResponse.Location = new System.Drawing.Point(4, 22);
            this.tpResponse.Name = "tpResponse";
            this.tpResponse.Padding = new System.Windows.Forms.Padding(3);
            this.tpResponse.Size = new System.Drawing.Size(1711, 1204);
            this.tpResponse.TabIndex = 0;
            this.tpResponse.Text = "Response";
            this.tpResponse.UseVisualStyleBackColor = true;
            // 
            // pnlImage
            // 
            this.pnlImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlImage.Controls.Add(this.documentPreview1);
            this.pnlImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImage.Location = new System.Drawing.Point(3, 42);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(1705, 1159);
            this.pnlImage.TabIndex = 5;
            this.pnlImage.Visible = false;
            // 
            // documentPreview1
            // 
            this.documentPreview1.Ddl = null;
            this.documentPreview1.DesktopColor = System.Drawing.SystemColors.ControlDark;
            this.documentPreview1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentPreview1.Document = null;
            this.documentPreview1.Location = new System.Drawing.Point(0, 0);
            this.documentPreview1.Name = "documentPreview1";
            this.documentPreview1.Page = 0;
            this.documentPreview1.PageColor = System.Drawing.Color.GhostWhite;
            this.documentPreview1.PageSize = new System.Drawing.Size(595, 842);
            this.documentPreview1.Size = new System.Drawing.Size(1705, 1159);
            this.documentPreview1.TabIndex = 0;
            this.documentPreview1.ZoomPercent = 100;
            // 
            // rtbResults
            // 
            this.rtbResults.AutoCompleteBracketsList = new char[] {
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
            this.rtbResults.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:" +
    "]*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.rtbResults.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.rtbResults.BackBrush = null;
            this.rtbResults.BackColor = System.Drawing.SystemColors.Window;
            this.rtbResults.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.rtbResults.CharHeight = 14;
            this.rtbResults.CharWidth = 8;
            this.rtbResults.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rtbResults.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.rtbResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbResults.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.rtbResults.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rtbResults.IsReplaceMode = false;
            this.rtbResults.Language = FastColoredTextBoxNS.Language.CSharp;
            this.rtbResults.LeftBracket = '(';
            this.rtbResults.LeftBracket2 = '{';
            this.rtbResults.Location = new System.Drawing.Point(3, 42);
            this.rtbResults.Margin = new System.Windows.Forms.Padding(2);
            this.rtbResults.Name = "rtbResults";
            this.rtbResults.Paddings = new System.Windows.Forms.Padding(0);
            this.rtbResults.ReadOnly = true;
            this.rtbResults.RightBracket = ')';
            this.rtbResults.RightBracket2 = '}';
            this.rtbResults.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.rtbResults.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("rtbResults.ServiceColors")));
            this.rtbResults.Size = new System.Drawing.Size(1705, 1159);
            this.rtbResults.TabIndex = 0;
            this.rtbResults.Zoom = 100;
            // 
            // toolStrip4
            // 
            this.toolStrip4.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel6,
            this.tslblFileName,
            this.tsbtnViewFile,
            this.toolStripSeparator10,
            this.tsbtnViewAsImage});
            this.toolStrip4.Location = new System.Drawing.Point(3, 3);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip4.Size = new System.Drawing.Size(1705, 39);
            this.toolStrip4.TabIndex = 2;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(60, 36);
            this.toolStripLabel6.Text = "File Name";
            // 
            // tslblFileName
            // 
            this.tslblFileName.Name = "tslblFileName";
            this.tslblFileName.Size = new System.Drawing.Size(0, 36);
            // 
            // tsbtnViewFile
            // 
            this.tsbtnViewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnViewFile.Enabled = false;
            this.tsbtnViewFile.Image = global::APITester.Properties.Resources.FileOpen_32;
            this.tsbtnViewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnViewFile.Name = "tsbtnViewFile";
            this.tsbtnViewFile.Size = new System.Drawing.Size(36, 36);
            this.tsbtnViewFile.Text = "toolStripButton3";
            this.tsbtnViewFile.ToolTipText = "View file in application";
            this.tsbtnViewFile.Click += new System.EventHandler(this.tsbtnViewFile_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnViewAsImage
            // 
            this.tsbtnViewAsImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnViewAsImage.Enabled = false;
            this.tsbtnViewAsImage.Image = global::APITester.Properties.Resources.ViewImage_32;
            this.tsbtnViewAsImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnViewAsImage.Name = "tsbtnViewAsImage";
            this.tsbtnViewAsImage.Size = new System.Drawing.Size(36, 36);
            this.tsbtnViewAsImage.Text = "View string as image";
            this.tsbtnViewAsImage.Click += new System.EventHandler(this.tsbtnViewAsImage_Click);
            // 
            // tpCommandConfig
            // 
            this.tpCommandConfig.Controls.Add(this.commandEditorControl1);
            this.tpCommandConfig.Location = new System.Drawing.Point(4, 22);
            this.tpCommandConfig.Name = "tpCommandConfig";
            this.tpCommandConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tpCommandConfig.Size = new System.Drawing.Size(1711, 1204);
            this.tpCommandConfig.TabIndex = 1;
            this.tpCommandConfig.Text = "Command";
            this.tpCommandConfig.UseVisualStyleBackColor = true;
            // 
            // commandEditorControl1
            // 
            this.commandEditorControl1.CanGet = false;
            this.commandEditorControl1.CanPatch = false;
            this.commandEditorControl1.CanPost = false;
            this.commandEditorControl1.CanPut = false;
            this.commandEditorControl1.Command = null;
            this.commandEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandEditorControl1.Location = new System.Drawing.Point(3, 3);
            this.commandEditorControl1.Margin = new System.Windows.Forms.Padding(1);
            this.commandEditorControl1.Name = "commandEditorControl1";
            this.commandEditorControl1.Size = new System.Drawing.Size(1705, 1198);
            this.commandEditorControl1.TabIndex = 1;
            this.commandEditorControl1.URLChanged += new System.EventHandler(this.commandEditorControl1_URLChanged);
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(255, 41);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 1230);
            this.splitter3.TabIndex = 4;
            this.splitter3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tvCommands);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(2, 41);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(253, 1230);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Commands";
            // 
            // tvCommands
            // 
            this.tvCommands.ContextMenuStrip = this.contextMenuStrip1;
            this.tvCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCommands.Location = new System.Drawing.Point(3, 16);
            this.tvCommands.Name = "tvCommands";
            this.tvCommands.Size = new System.Drawing.Size(247, 1211);
            this.tvCommands.TabIndex = 0;
            this.tvCommands.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCommands_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewCommandToolStripMenuItem,
            this.deleteSelectedCommandToolStripMenuItem,
            this.cloneSelectedCommandToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(212, 70);
            // 
            // addNewCommandToolStripMenuItem
            // 
            this.addNewCommandToolStripMenuItem.Enabled = false;
            this.addNewCommandToolStripMenuItem.Name = "addNewCommandToolStripMenuItem";
            this.addNewCommandToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.addNewCommandToolStripMenuItem.Text = "Add new command";
            this.addNewCommandToolStripMenuItem.Click += new System.EventHandler(this.addNewCommandToolStripMenuItem_Click);
            // 
            // deleteSelectedCommandToolStripMenuItem
            // 
            this.deleteSelectedCommandToolStripMenuItem.Enabled = false;
            this.deleteSelectedCommandToolStripMenuItem.Name = "deleteSelectedCommandToolStripMenuItem";
            this.deleteSelectedCommandToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.deleteSelectedCommandToolStripMenuItem.Text = "Delete selected command";
            this.deleteSelectedCommandToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedCommandToolStripMenuItem_Click);
            // 
            // cloneSelectedCommandToolStripMenuItem
            // 
            this.cloneSelectedCommandToolStripMenuItem.Enabled = false;
            this.cloneSelectedCommandToolStripMenuItem.Name = "cloneSelectedCommandToolStripMenuItem";
            this.cloneSelectedCommandToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.cloneSelectedCommandToolStripMenuItem.Text = "Clone selected command";
            this.cloneSelectedCommandToolStripMenuItem.Click += new System.EventHandler(this.cloneSelectedCommandToolStripMenuItem_Click);
            // 
            // toolStrip3
            // 
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator4,
            this.tsbtnRun,
            this.toolStripSeparator5,
            this.tslblCommandName,
            this.toolStripLabel4,
            this.tscmbxVerbs,
            this.toolStripSeparator6,
            this.toolStripLabel5,
            this.tstxtbURL,
            this.toolStripSeparator7,
            this.tsbtnSaveCommand});
            this.toolStrip3.Location = new System.Drawing.Point(2, 2);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip3.Size = new System.Drawing.Size(1975, 39);
            this.toolStrip3.TabIndex = 1;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::APITester.Properties.Resources.ZoomIn_32;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton1.Text = "Zoom In";
            this.toolStripButton1.ToolTipText = "Zoom in";
            this.toolStripButton1.Click += new System.EventHandler(this.tsbtnZoomIn_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::APITester.Properties.Resources.ZoomOut_32;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton2.Text = "Zoom Out";
            this.toolStripButton2.ToolTipText = "Zoom out";
            this.toolStripButton2.Click += new System.EventHandler(this.tsbtnZoomOut_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnRun
            // 
            this.tsbtnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRun.Enabled = false;
            this.tsbtnRun.Image = global::APITester.Properties.Resources.Play_32;
            this.tsbtnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRun.Name = "tsbtnRun";
            this.tsbtnRun.Size = new System.Drawing.Size(36, 36);
            this.tsbtnRun.Text = "Run";
            this.tsbtnRun.Click += new System.EventHandler(this.tsbtnRun_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // tslblCommandName
            // 
            this.tslblCommandName.Name = "tslblCommandName";
            this.tslblCommandName.Size = new System.Drawing.Size(86, 36);
            this.tslblCommandName.Text = "toolStripLabel6";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(30, 36);
            this.toolStripLabel4.Text = "Verb";
            // 
            // tscmbxVerbs
            // 
            this.tscmbxVerbs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscmbxVerbs.Items.AddRange(new object[] {
            "PUT",
            "POST",
            "GET"});
            this.tscmbxVerbs.Name = "tscmbxVerbs";
            this.tscmbxVerbs.Size = new System.Drawing.Size(121, 39);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(28, 36);
            this.toolStripLabel5.Text = "URL";
            // 
            // tstxtbURL
            // 
            this.tstxtbURL.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstxtbURL.Name = "tstxtbURL";
            this.tstxtbURL.ReadOnly = true;
            this.tstxtbURL.Size = new System.Drawing.Size(1000, 39);
            this.tstxtbURL.Leave += new System.EventHandler(this.tstxtbURL_Leave);
            this.tstxtbURL.TextChanged += new System.EventHandler(this.tstxtbURL_TextChanged);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnSaveCommand
            // 
            this.tsbtnSaveCommand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSaveCommand.Image = global::APITester.Properties.Resources.FloppyDisk_32;
            this.tsbtnSaveCommand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSaveCommand.Name = "tsbtnSaveCommand";
            this.tsbtnSaveCommand.Size = new System.Drawing.Size(36, 36);
            this.tsbtnSaveCommand.Text = "toolStripButton3";
            this.tsbtnSaveCommand.Click += new System.EventHandler(this.tsbtnSaveCommand_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.fctxtbResult);
            this.tabPage3.Controls.Add(this.splitter2);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.splitter1);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.toolStrip2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1979, 1273);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "QA Json";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // fctxtbResult
            // 
            this.fctxtbResult.AutoCompleteBracketsList = new char[] {
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
            this.fctxtbResult.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\n^\\s*(case|default)\\s*[^:]*(" +
    "?<range>:)\\s*(?<range>[^;]+);";
            this.fctxtbResult.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.fctxtbResult.BackBrush = null;
            this.fctxtbResult.CharHeight = 14;
            this.fctxtbResult.CharWidth = 8;
            this.fctxtbResult.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctxtbResult.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctxtbResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctxtbResult.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctxtbResult.IsReplaceMode = false;
            this.fctxtbResult.Location = new System.Drawing.Point(347, 406);
            this.fctxtbResult.Margin = new System.Windows.Forms.Padding(2);
            this.fctxtbResult.Name = "fctxtbResult";
            this.fctxtbResult.Paddings = new System.Windows.Forms.Padding(0);
            this.fctxtbResult.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctxtbResult.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctxtbResult.ServiceColors")));
            this.fctxtbResult.Size = new System.Drawing.Size(1629, 864);
            this.fctxtbResult.TabIndex = 10;
            this.fctxtbResult.Zoom = 100;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(347, 403);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1629, 3);
            this.splitter2.TabIndex = 8;
            this.splitter2.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fctxtbRaw);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(347, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1629, 361);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Command";
            // 
            // fctxtbRaw
            // 
            this.fctxtbRaw.AutoCompleteBracketsList = new char[] {
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
            this.fctxtbRaw.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\n^\\s*(case|default)\\s*[^:]*(" +
    "?<range>:)\\s*(?<range>[^;]+);";
            this.fctxtbRaw.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.fctxtbRaw.BackBrush = null;
            this.fctxtbRaw.CharHeight = 14;
            this.fctxtbRaw.CharWidth = 8;
            this.fctxtbRaw.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctxtbRaw.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctxtbRaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctxtbRaw.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctxtbRaw.IsReplaceMode = false;
            this.fctxtbRaw.Location = new System.Drawing.Point(3, 88);
            this.fctxtbRaw.Margin = new System.Windows.Forms.Padding(2);
            this.fctxtbRaw.Name = "fctxtbRaw";
            this.fctxtbRaw.Paddings = new System.Windows.Forms.Padding(0);
            this.fctxtbRaw.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctxtbRaw.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctxtbRaw.ServiceColors")));
            this.fctxtbRaw.Size = new System.Drawing.Size(1623, 270);
            this.fctxtbRaw.TabIndex = 9;
            this.fctxtbRaw.Zoom = 100;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbtnGet);
            this.groupBox5.Controls.Add(this.rbtnPut);
            this.groupBox5.Controls.Add(this.rbtnPost);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 52);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(1623, 36);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Action";
            // 
            // rbtnGet
            // 
            this.rbtnGet.AutoSize = true;
            this.rbtnGet.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnGet.Location = new System.Drawing.Point(111, 15);
            this.rbtnGet.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnGet.Name = "rbtnGet";
            this.rbtnGet.Padding = new System.Windows.Forms.Padding(0, 0, 11, 0);
            this.rbtnGet.Size = new System.Drawing.Size(53, 19);
            this.rbtnGet.TabIndex = 3;
            this.rbtnGet.Text = "Get";
            this.rbtnGet.UseVisualStyleBackColor = true;
            this.rbtnGet.Visible = false;
            this.rbtnGet.CheckedChanged += new System.EventHandler(this.rbtnPut_CheckedChanged);
            // 
            // rbtnPut
            // 
            this.rbtnPut.AutoSize = true;
            this.rbtnPut.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnPut.Location = new System.Drawing.Point(59, 15);
            this.rbtnPut.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnPut.Name = "rbtnPut";
            this.rbtnPut.Padding = new System.Windows.Forms.Padding(0, 0, 11, 0);
            this.rbtnPut.Size = new System.Drawing.Size(52, 19);
            this.rbtnPut.TabIndex = 2;
            this.rbtnPut.Text = "Put";
            this.rbtnPut.UseVisualStyleBackColor = true;
            this.rbtnPut.CheckedChanged += new System.EventHandler(this.rbtnPut_CheckedChanged);
            // 
            // rbtnPost
            // 
            this.rbtnPost.AutoSize = true;
            this.rbtnPost.Checked = true;
            this.rbtnPost.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnPost.Location = new System.Drawing.Point(2, 15);
            this.rbtnPost.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnPost.Name = "rbtnPost";
            this.rbtnPost.Padding = new System.Windows.Forms.Padding(0, 0, 11, 0);
            this.rbtnPost.Size = new System.Drawing.Size(57, 19);
            this.rbtnPost.TabIndex = 1;
            this.rbtnPost.TabStop = true;
            this.rbtnPost.Text = "Post";
            this.rbtnPost.UseVisualStyleBackColor = true;
            this.rbtnPost.CheckedChanged += new System.EventHandler(this.rbtnPut_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtbURL);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 16);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(1623, 36);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "URL";
            // 
            // txtbURL
            // 
            this.txtbURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbURL.Location = new System.Drawing.Point(2, 15);
            this.txtbURL.Margin = new System.Windows.Forms.Padding(2);
            this.txtbURL.Name = "txtbURL";
            this.txtbURL.Size = new System.Drawing.Size(1619, 20);
            this.txtbURL.TabIndex = 0;
            this.txtbURL.TextChanged += new System.EventHandler(this.txtbURL_TextChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(344, 42);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 1228);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbxFiles);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 1228);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Files";
            // 
            // lbxFiles
            // 
            this.lbxFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxFiles.FormattingEnabled = true;
            this.lbxFiles.IntegralHeight = false;
            this.lbxFiles.Location = new System.Drawing.Point(3, 16);
            this.lbxFiles.Name = "lbxFiles";
            this.lbxFiles.Size = new System.Drawing.Size(335, 1209);
            this.lbxFiles.TabIndex = 0;
            this.lbxFiles.SelectedIndexChanged += new System.EventHandler(this.lbxFiles_SelectedIndexChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.tstxtbFolder,
            this.tsbtnSelectGolder,
            this.toolStripLabel3,
            this.tscmbxAPi,
            this.toolStripSeparator2,
            this.tsbtnExecute,
            this.tsbtnQueryData,
            this.toolStripSeparator3,
            this.tsbtnZoomIn,
            this.tsbtnZoomOut});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip2.Size = new System.Drawing.Size(1973, 39);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(40, 36);
            this.toolStripLabel2.Text = "Folder";
            // 
            // tstxtbFolder
            // 
            this.tstxtbFolder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstxtbFolder.Name = "tstxtbFolder";
            this.tstxtbFolder.ReadOnly = true;
            this.tstxtbFolder.Size = new System.Drawing.Size(535, 39);
            this.tstxtbFolder.TextChanged += new System.EventHandler(this.tstxtbFolder_TextChanged);
            // 
            // tsbtnSelectGolder
            // 
            this.tsbtnSelectGolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSelectGolder.Image = global::APITester.Properties.Resources.OpenDocumentFolder_32;
            this.tsbtnSelectGolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSelectGolder.Name = "tsbtnSelectGolder";
            this.tsbtnSelectGolder.Size = new System.Drawing.Size(36, 36);
            this.tsbtnSelectGolder.Text = "Select Folder";
            this.tsbtnSelectGolder.Click += new System.EventHandler(this.tsbtnSelectGolder_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(25, 36);
            this.toolStripLabel3.Text = "API";
            // 
            // tscmbxAPi
            // 
            this.tscmbxAPi.Items.AddRange(new object[] {
            "Claim",
            "Contract"});
            this.tscmbxAPi.Name = "tscmbxAPi";
            this.tscmbxAPi.Size = new System.Drawing.Size(82, 39);
            this.tscmbxAPi.SelectedIndexChanged += new System.EventHandler(this.tscmbxAPi_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnExecute
            // 
            this.tsbtnExecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnExecute.Image = global::APITester.Properties.Resources.Play_32;
            this.tsbtnExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnExecute.Name = "tsbtnExecute";
            this.tsbtnExecute.Size = new System.Drawing.Size(36, 36);
            this.tsbtnExecute.Text = "Post request";
            this.tsbtnExecute.Click += new System.EventHandler(this.tsbtnExecute_Click);
            // 
            // tsbtnQueryData
            // 
            this.tsbtnQueryData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnQueryData.Image = global::APITester.Properties.Resources.DataFind_32;
            this.tsbtnQueryData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnQueryData.Name = "tsbtnQueryData";
            this.tsbtnQueryData.Size = new System.Drawing.Size(36, 36);
            this.tsbtnQueryData.Text = "View data";
            this.tsbtnQueryData.ToolTipText = "Query the database records.";
            this.tsbtnQueryData.Click += new System.EventHandler(this.tsbtnQueryData_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnZoomIn
            // 
            this.tsbtnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnZoomIn.Image = global::APITester.Properties.Resources.ZoomIn_32;
            this.tsbtnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnZoomIn.Name = "tsbtnZoomIn";
            this.tsbtnZoomIn.Size = new System.Drawing.Size(36, 36);
            this.tsbtnZoomIn.Text = "Zoom in";
            this.tsbtnZoomIn.Click += new System.EventHandler(this.tsbtnZoomIn_Click);
            // 
            // tsbtnZoomOut
            // 
            this.tsbtnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnZoomOut.Image = global::APITester.Properties.Resources.ZoomOut_32;
            this.tsbtnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnZoomOut.Name = "tsbtnZoomOut";
            this.tsbtnZoomOut.Size = new System.Drawing.Size(36, 36);
            this.tsbtnZoomOut.Text = "Zoom out";
            this.tsbtnZoomOut.Click += new System.EventHandler(this.tsbtnZoomOut_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chart1);
            this.tabPage2.Controls.Add(this.groupBox9);
            this.tabPage2.Controls.Add(this.groupBox8);
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.toolStrip5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1979, 1273);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Load Testing";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(11, 449);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Number of calls per 100 ms";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1841, 748);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "Duration distribution";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.fctxtbLog);
            this.groupBox9.Location = new System.Drawing.Point(375, 96);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(976, 347);
            this.groupBox9.TabIndex = 4;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Error Log";
            // 
            // fctxtbLog
            // 
            this.fctxtbLog.AutoCompleteBracketsList = new char[] {
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
            this.fctxtbLog.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\n^\\s*(case|default)\\s*[^:]*(" +
    "?<range>:)\\s*(?<range>[^;]+);";
            this.fctxtbLog.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.fctxtbLog.BackBrush = null;
            this.fctxtbLog.CharHeight = 14;
            this.fctxtbLog.CharWidth = 8;
            this.fctxtbLog.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctxtbLog.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctxtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctxtbLog.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctxtbLog.IsReplaceMode = false;
            this.fctxtbLog.Location = new System.Drawing.Point(3, 16);
            this.fctxtbLog.Margin = new System.Windows.Forms.Padding(2);
            this.fctxtbLog.Name = "fctxtbLog";
            this.fctxtbLog.Paddings = new System.Windows.Forms.Padding(0);
            this.fctxtbLog.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctxtbLog.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctxtbLog.ServiceColors")));
            this.fctxtbLog.Size = new System.Drawing.Size(970, 328);
            this.fctxtbLog.TabIndex = 10;
            this.fctxtbLog.Zoom = 100;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lblDudation);
            this.groupBox8.Controls.Add(this.lblAverageDuration);
            this.groupBox8.Controls.Add(this.lblMaxTasks);
            this.groupBox8.Controls.Add(this.lblErrors);
            this.groupBox8.Controls.Add(this.lblNumCallsMade);
            this.groupBox8.Controls.Add(this.lblActiveTasks);
            this.groupBox8.Location = new System.Drawing.Point(8, 256);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(361, 184);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Results";
            // 
            // lblDudation
            // 
            this.lblDudation.AutoSize = true;
            this.lblDudation.Location = new System.Drawing.Point(22, 131);
            this.lblDudation.Name = "lblDudation";
            this.lblDudation.Size = new System.Drawing.Size(71, 13);
            this.lblDudation.TabIndex = 2;
            this.lblDudation.Text = "Running for 0";
            // 
            // lblAverageDuration
            // 
            this.lblAverageDuration.AutoSize = true;
            this.lblAverageDuration.Location = new System.Drawing.Point(22, 157);
            this.lblAverageDuration.Name = "lblAverageDuration";
            this.lblAverageDuration.Size = new System.Drawing.Size(113, 13);
            this.lblAverageDuration.TabIndex = 5;
            this.lblAverageDuration.Text = "Average duration 0 ms";
            // 
            // lblMaxTasks
            // 
            this.lblMaxTasks.AutoSize = true;
            this.lblMaxTasks.Location = new System.Drawing.Point(22, 53);
            this.lblMaxTasks.Name = "lblMaxTasks";
            this.lblMaxTasks.Size = new System.Drawing.Size(201, 13);
            this.lblMaxTasks.TabIndex = 4;
            this.lblMaxTasks.Text = "Maximum number of concurrent tasks = 0";
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.Location = new System.Drawing.Point(22, 105);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(103, 13);
            this.lblErrors.TabIndex = 3;
            this.lblErrors.Text = "Number of errors = 0";
            // 
            // lblNumCallsMade
            // 
            this.lblNumCallsMade.AutoSize = true;
            this.lblNumCallsMade.Location = new System.Drawing.Point(22, 79);
            this.lblNumCallsMade.Name = "lblNumCallsMade";
            this.lblNumCallsMade.Size = new System.Drawing.Size(127, 13);
            this.lblNumCallsMade.TabIndex = 1;
            this.lblNumCallsMade.Text = "Number of calls made = 0";
            // 
            // lblActiveTasks
            // 
            this.lblActiveTasks.AutoSize = true;
            this.lblActiveTasks.Location = new System.Drawing.Point(22, 27);
            this.lblActiveTasks.Name = "lblActiveTasks";
            this.lblActiveTasks.Size = new System.Drawing.Size(134, 13);
            this.lblActiveTasks.TabIndex = 0;
            this.lblActiveTasks.Text = "Number of active tasks = 0";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.txtbEndLoad);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.txtbStartLoad);
            this.groupBox7.Controls.Add(this.txtbLoadIncrement);
            this.groupBox7.Controls.Add(this.rbtnMultipleLoads);
            this.groupBox7.Controls.Add(this.txtbTBC);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.txtbTestDuration);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.txtbNumCalls);
            this.groupBox7.Controls.Add(this.rbtnTime);
            this.groupBox7.Controls.Add(this.rbtnNumberOfCalls);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Location = new System.Drawing.Point(8, 96);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(361, 128);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Run Parameters";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(219, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "calls/s incr. by:";
            // 
            // txtbEndLoad
            // 
            this.txtbEndLoad.Location = new System.Drawing.Point(188, 70);
            this.txtbEndLoad.Name = "txtbEndLoad";
            this.txtbEndLoad.Size = new System.Drawing.Size(25, 20);
            this.txtbEndLoad.TabIndex = 12;
            this.txtbEndLoad.Text = "20";
            this.txtbEndLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "to";
            // 
            // txtbStartLoad
            // 
            this.txtbStartLoad.Location = new System.Drawing.Point(141, 70);
            this.txtbStartLoad.Name = "txtbStartLoad";
            this.txtbStartLoad.Size = new System.Drawing.Size(19, 20);
            this.txtbStartLoad.TabIndex = 10;
            this.txtbStartLoad.Text = "2";
            this.txtbStartLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtbLoadIncrement
            // 
            this.txtbLoadIncrement.Location = new System.Drawing.Point(303, 70);
            this.txtbLoadIncrement.Name = "txtbLoadIncrement";
            this.txtbLoadIncrement.Size = new System.Drawing.Size(19, 20);
            this.txtbLoadIncrement.TabIndex = 9;
            this.txtbLoadIncrement.Text = "2";
            this.txtbLoadIncrement.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rbtnMultipleLoads
            // 
            this.rbtnMultipleLoads.AutoSize = true;
            this.rbtnMultipleLoads.Location = new System.Drawing.Point(6, 71);
            this.rbtnMultipleLoads.Name = "rbtnMultipleLoads";
            this.rbtnMultipleLoads.Size = new System.Drawing.Size(89, 17);
            this.rbtnMultipleLoads.TabIndex = 8;
            this.rbtnMultipleLoads.TabStop = true;
            this.rbtnMultipleLoads.Text = "Multiple loads";
            this.rbtnMultipleLoads.UseVisualStyleBackColor = true;
            // 
            // txtbTBC
            // 
            this.txtbTBC.Location = new System.Drawing.Point(276, 96);
            this.txtbTBC.Name = "txtbTBC";
            this.txtbTBC.Size = new System.Drawing.Size(46, 20);
            this.txtbTBC.TabIndex = 7;
            this.txtbTBC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Time between calls (ms):";
            // 
            // txtbTestDuration
            // 
            this.txtbTestDuration.Location = new System.Drawing.Point(276, 44);
            this.txtbTestDuration.Name = "txtbTestDuration";
            this.txtbTestDuration.Size = new System.Drawing.Size(46, 20);
            this.txtbTestDuration.TabIndex = 5;
            this.txtbTestDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Duration (hours):";
            // 
            // txtbNumCalls
            // 
            this.txtbNumCalls.Location = new System.Drawing.Point(276, 18);
            this.txtbNumCalls.Name = "txtbNumCalls";
            this.txtbNumCalls.Size = new System.Drawing.Size(46, 20);
            this.txtbNumCalls.TabIndex = 3;
            this.txtbNumCalls.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rbtnTime
            // 
            this.rbtnTime.AutoSize = true;
            this.rbtnTime.Location = new System.Drawing.Point(6, 45);
            this.rbtnTime.Name = "rbtnTime";
            this.rbtnTime.Size = new System.Drawing.Size(154, 17);
            this.rbtnTime.TabIndex = 2;
            this.rbtnTime.Text = "Execute for a period of time";
            this.rbtnTime.UseVisualStyleBackColor = true;
            // 
            // rbtnNumberOfCalls
            // 
            this.rbtnNumberOfCalls.AutoSize = true;
            this.rbtnNumberOfCalls.Checked = true;
            this.rbtnNumberOfCalls.Location = new System.Drawing.Point(6, 19);
            this.rbtnNumberOfCalls.Name = "rbtnNumberOfCalls";
            this.rbtnNumberOfCalls.Size = new System.Drawing.Size(141, 17);
            this.rbtnNumberOfCalls.TabIndex = 1;
            this.rbtnNumberOfCalls.TabStop = true;
            this.rbtnNumberOfCalls.Text = "Execute number of calls.";
            this.rbtnNumberOfCalls.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of calls:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtbTestURL);
            this.groupBox6.Location = new System.Drawing.Point(8, 45);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1409, 45);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "URL";
            // 
            // txtbTestURL
            // 
            this.txtbTestURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbTestURL.Location = new System.Drawing.Point(3, 16);
            this.txtbTestURL.Name = "txtbTestURL";
            this.txtbTestURL.Size = new System.Drawing.Size(1403, 20);
            this.txtbTestURL.TabIndex = 0;
            // 
            // toolStrip5
            // 
            this.toolStrip5.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAddPerformanceTest,
            this.tsbtnEditLoadTests,
            this.tsbtnSaveLoadTests,
            this.toolStripSeparator20,
            this.toolStripLabel10,
            this.tscmbxTPA,
            this.toolStripSeparator18,
            this.toolStripLabel11,
            this.tscmbxCommand,
            this.toolStripSeparator19,
            this.tsbtnStartTest});
            this.toolStrip5.Location = new System.Drawing.Point(3, 3);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip5.Size = new System.Drawing.Size(1973, 39);
            this.toolStrip5.TabIndex = 0;
            this.toolStrip5.Text = "toolStrip5";
            // 
            // tsbtnAddPerformanceTest
            // 
            this.tsbtnAddPerformanceTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnAddPerformanceTest.Image = global::APITester.Properties.Resources.GreenAdd_32;
            this.tsbtnAddPerformanceTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAddPerformanceTest.Name = "tsbtnAddPerformanceTest";
            this.tsbtnAddPerformanceTest.Size = new System.Drawing.Size(36, 36);
            this.tsbtnAddPerformanceTest.Text = "Add a performance test";
            this.tsbtnAddPerformanceTest.Click += new System.EventHandler(this.tsbtnAddPerformanceTest_Click);
            // 
            // tsbtnEditLoadTests
            // 
            this.tsbtnEditLoadTests.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnEditLoadTests.Enabled = false;
            this.tsbtnEditLoadTests.Image = global::APITester.Properties.Resources.EditDocument32;
            this.tsbtnEditLoadTests.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEditLoadTests.Name = "tsbtnEditLoadTests";
            this.tsbtnEditLoadTests.Size = new System.Drawing.Size(36, 36);
            this.tsbtnEditLoadTests.Text = "Edit load test";
            this.tsbtnEditLoadTests.Click += new System.EventHandler(this.tsbtnEditLoadTests_Click);
            // 
            // tsbtnSaveLoadTests
            // 
            this.tsbtnSaveLoadTests.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSaveLoadTests.Image = global::APITester.Properties.Resources.FloppyDisk_32;
            this.tsbtnSaveLoadTests.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSaveLoadTests.Name = "tsbtnSaveLoadTests";
            this.tsbtnSaveLoadTests.Size = new System.Drawing.Size(36, 36);
            this.tsbtnSaveLoadTests.Text = "Save load tests";
            this.tsbtnSaveLoadTests.Click += new System.EventHandler(this.tsbtnSaveLoadTests_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel10
            // 
            this.toolStripLabel10.Name = "toolStripLabel10";
            this.toolStripLabel10.Size = new System.Drawing.Size(27, 36);
            this.toolStripLabel10.Text = "TPA";
            // 
            // tscmbxTPA
            // 
            this.tscmbxTPA.Name = "tscmbxTPA";
            this.tscmbxTPA.Size = new System.Drawing.Size(80, 39);
            this.tscmbxTPA.SelectedIndexChanged += new System.EventHandler(this.tscmbxTPA_SelectedIndexChanged);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel11
            // 
            this.toolStripLabel11.Name = "toolStripLabel11";
            this.toolStripLabel11.Size = new System.Drawing.Size(64, 36);
            this.toolStripLabel11.Text = "Command";
            // 
            // tscmbxCommand
            // 
            this.tscmbxCommand.Name = "tscmbxCommand";
            this.tscmbxCommand.Size = new System.Drawing.Size(300, 39);
            this.tscmbxCommand.SelectedIndexChanged += new System.EventHandler(this.tscmbxCommand_SelectedIndexChanged);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnStartTest
            // 
            this.tsbtnStartTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnStartTest.Enabled = false;
            this.tsbtnStartTest.Image = global::APITester.Properties.Resources.Play_32;
            this.tsbtnStartTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnStartTest.Name = "tsbtnStartTest";
            this.tsbtnStartTest.Size = new System.Drawing.Size(36, 36);
            this.tsbtnStartTest.Text = "Start test";
            this.tsbtnStartTest.Click += new System.EventHandler(this.tsbtnStartTest_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tabControl2);
            this.tabPage4.Controls.Add(this.splitter4);
            this.tabPage4.Controls.Add(this.groupBox10);
            this.tabPage4.Controls.Add(this.toolStrip6);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1979, 1273);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Sequence Test";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(313, 42);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1663, 1228);
            this.tabControl2.TabIndex = 4;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.commandEditorControl2);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1655, 1202);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Command";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // commandEditorControl2
            // 
            this.commandEditorControl2.CanGet = false;
            this.commandEditorControl2.CanPatch = false;
            this.commandEditorControl2.CanPost = false;
            this.commandEditorControl2.CanPut = false;
            this.commandEditorControl2.Command = null;
            this.commandEditorControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandEditorControl2.Location = new System.Drawing.Point(3, 3);
            this.commandEditorControl2.Margin = new System.Windows.Forms.Padding(2);
            this.commandEditorControl2.Name = "commandEditorControl2";
            this.commandEditorControl2.Size = new System.Drawing.Size(1649, 1196);
            this.commandEditorControl2.TabIndex = 3;
            this.commandEditorControl2.NameChanged += new System.EventHandler(this.commandEditorControl2_NameChanged);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.dgvSequenceResults);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1655, 1202);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Rezults";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // dgvSequenceResults
            // 
            this.dgvSequenceResults.AllowUserToAddRows = false;
            this.dgvSequenceResults.AllowUserToDeleteRows = false;
            this.dgvSequenceResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSequenceResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvSequenceResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSequenceResults.Location = new System.Drawing.Point(3, 3);
            this.dgvSequenceResults.Name = "dgvSequenceResults";
            this.dgvSequenceResults.ReadOnly = true;
            this.dgvSequenceResults.Size = new System.Drawing.Size(1649, 1196);
            this.dgvSequenceResults.TabIndex = 0;
            this.dgvSequenceResults.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSequenceResults_CellMouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Duration";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column3.HeaderText = "Result";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // splitter4
            // 
            this.splitter4.Location = new System.Drawing.Point(310, 42);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(3, 1228);
            this.splitter4.TabIndex = 2;
            this.splitter4.TabStop = false;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.lbxSequence);
            this.groupBox10.Controls.Add(this.toolStrip7);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox10.Location = new System.Drawing.Point(3, 42);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(307, 1228);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Sequences";
            // 
            // lbxSequence
            // 
            this.lbxSequence.DisplayMember = "Name";
            this.lbxSequence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxSequence.FormattingEnabled = true;
            this.lbxSequence.IntegralHeight = false;
            this.lbxSequence.Location = new System.Drawing.Point(3, 55);
            this.lbxSequence.Name = "lbxSequence";
            this.lbxSequence.Size = new System.Drawing.Size(301, 1170);
            this.lbxSequence.TabIndex = 1;
            this.lbxSequence.SelectedIndexChanged += new System.EventHandler(this.lbxSequence_SelectedIndexChanged);
            // 
            // toolStrip7
            // 
            this.toolStrip7.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAddStep,
            this.tsbtnDeleteStep});
            this.toolStrip7.Location = new System.Drawing.Point(3, 16);
            this.toolStrip7.Name = "toolStrip7";
            this.toolStrip7.Size = new System.Drawing.Size(301, 39);
            this.toolStrip7.TabIndex = 0;
            this.toolStrip7.Text = "toolStrip7";
            // 
            // tsbtnAddStep
            // 
            this.tsbtnAddStep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnAddStep.Enabled = false;
            this.tsbtnAddStep.Image = global::APITester.Properties.Resources.GreenAdd_32;
            this.tsbtnAddStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAddStep.Name = "tsbtnAddStep";
            this.tsbtnAddStep.Size = new System.Drawing.Size(36, 36);
            this.tsbtnAddStep.Text = "Add Step";
            this.tsbtnAddStep.Click += new System.EventHandler(this.tsbtnAddStep_Click);
            // 
            // tsbtnDeleteStep
            // 
            this.tsbtnDeleteStep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnDeleteStep.Enabled = false;
            this.tsbtnDeleteStep.Image = global::APITester.Properties.Resources.RedDelete_32;
            this.tsbtnDeleteStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDeleteStep.Name = "tsbtnDeleteStep";
            this.tsbtnDeleteStep.Size = new System.Drawing.Size(36, 36);
            this.tsbtnDeleteStep.Text = "Delete selected step";
            this.tsbtnDeleteStep.Click += new System.EventHandler(this.tsbtnDeleteStep_Click);
            // 
            // toolStrip6
            // 
            this.toolStrip6.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel8,
            this.tscmbxSequences,
            this.toolStripSeparator13,
            this.tsbtnAddSequence,
            this.tsbtnDeleteSequence,
            this.toolStripSeparator14,
            this.tsbtnSequenceZoomIn,
            this.tsbtnSequenceZoomOut,
            this.toolStripSeparator11,
            this.tsbtnStartSequence,
            this.toolStripSeparator12,
            this.tsbtnSequenceSave});
            this.toolStrip6.Location = new System.Drawing.Point(3, 3);
            this.toolStrip6.Name = "toolStrip6";
            this.toolStrip6.Size = new System.Drawing.Size(1973, 39);
            this.toolStrip6.TabIndex = 1;
            this.toolStrip6.Text = "toolStrip6";
            // 
            // toolStripLabel8
            // 
            this.toolStripLabel8.Name = "toolStripLabel8";
            this.toolStripLabel8.Size = new System.Drawing.Size(58, 36);
            this.toolStripLabel8.Text = "Sequence";
            // 
            // tscmbxSequences
            // 
            this.tscmbxSequences.Name = "tscmbxSequences";
            this.tscmbxSequences.Size = new System.Drawing.Size(200, 39);
            this.tscmbxSequences.SelectedIndexChanged += new System.EventHandler(this.tscmbxSequences_SelectedIndexChanged);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnAddSequence
            // 
            this.tsbtnAddSequence.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnAddSequence.Image = global::APITester.Properties.Resources.GreenAdd_32;
            this.tsbtnAddSequence.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAddSequence.Name = "tsbtnAddSequence";
            this.tsbtnAddSequence.Size = new System.Drawing.Size(36, 36);
            this.tsbtnAddSequence.Text = "Add a new sequence";
            this.tsbtnAddSequence.Click += new System.EventHandler(this.tsbtnAddSequence_Click);
            // 
            // tsbtnDeleteSequence
            // 
            this.tsbtnDeleteSequence.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnDeleteSequence.Enabled = false;
            this.tsbtnDeleteSequence.Image = global::APITester.Properties.Resources.RedDelete_32;
            this.tsbtnDeleteSequence.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDeleteSequence.Name = "tsbtnDeleteSequence";
            this.tsbtnDeleteSequence.Size = new System.Drawing.Size(36, 36);
            this.tsbtnDeleteSequence.Text = "Delete selected sequence";
            this.tsbtnDeleteSequence.Click += new System.EventHandler(this.tsbtnDeleteSequence_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnSequenceZoomIn
            // 
            this.tsbtnSequenceZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSequenceZoomIn.Image = global::APITester.Properties.Resources.ZoomIn_32;
            this.tsbtnSequenceZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSequenceZoomIn.Name = "tsbtnSequenceZoomIn";
            this.tsbtnSequenceZoomIn.Size = new System.Drawing.Size(36, 36);
            this.tsbtnSequenceZoomIn.Text = "Zoom In";
            this.tsbtnSequenceZoomIn.Click += new System.EventHandler(this.tsbtnSequenceZoomIn_Click);
            // 
            // tsbtnSequenceZoomOut
            // 
            this.tsbtnSequenceZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSequenceZoomOut.Image = global::APITester.Properties.Resources.ZoomOut_32;
            this.tsbtnSequenceZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSequenceZoomOut.Name = "tsbtnSequenceZoomOut";
            this.tsbtnSequenceZoomOut.Size = new System.Drawing.Size(36, 36);
            this.tsbtnSequenceZoomOut.Text = "Zoom Out";
            this.tsbtnSequenceZoomOut.Click += new System.EventHandler(this.tsbtnSequenceZoomOut_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnStartSequence
            // 
            this.tsbtnStartSequence.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnStartSequence.Enabled = false;
            this.tsbtnStartSequence.Image = global::APITester.Properties.Resources.Play_32;
            this.tsbtnStartSequence.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnStartSequence.Name = "tsbtnStartSequence";
            this.tsbtnStartSequence.Size = new System.Drawing.Size(36, 36);
            this.tsbtnStartSequence.Text = "Start Sequence";
            this.tsbtnStartSequence.Click += new System.EventHandler(this.tsbtnStartSequence_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnSequenceSave
            // 
            this.tsbtnSequenceSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSequenceSave.Image = global::APITester.Properties.Resources.FloppyDisk_32;
            this.tsbtnSequenceSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSequenceSave.Name = "tsbtnSequenceSave";
            this.tsbtnSequenceSave.Size = new System.Drawing.Size(36, 36);
            this.tsbtnSequenceSave.Text = "Save Sequence";
            this.tsbtnSequenceSave.Click += new System.EventHandler(this.tsbtnSequenceSave_Click);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.tabControl3);
            this.tabPage8.Controls.Add(this.groupBox19);
            this.tabPage8.Controls.Add(this.toolStrip9);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1979, 1273);
            this.tabPage8.TabIndex = 5;
            this.tabPage8.Text = "Performance Testing";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage9);
            this.tabControl3.Controls.Add(this.tabPage13);
            this.tabControl3.Controls.Add(this.tabPage10);
            this.tabControl3.Controls.Add(this.tabPage15);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(367, 42);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(1609, 1228);
            this.tabControl3.TabIndex = 3;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.cePerformance);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(1601, 1202);
            this.tabPage9.TabIndex = 0;
            this.tabPage9.Text = "Outgoing Paylod";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // cePerformance
            // 
            this.cePerformance.CanGet = false;
            this.cePerformance.CanPatch = false;
            this.cePerformance.CanPost = false;
            this.cePerformance.CanPut = false;
            this.cePerformance.Command = null;
            this.cePerformance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cePerformance.Location = new System.Drawing.Point(3, 3);
            this.cePerformance.Margin = new System.Windows.Forms.Padding(1);
            this.cePerformance.Name = "cePerformance";
            this.cePerformance.Size = new System.Drawing.Size(1595, 1196);
            this.cePerformance.TabIndex = 2;
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.dgvChange);
            this.tabPage13.Controls.Add(this.gbSamplePayloads);
            this.tabPage13.Controls.Add(this.groupBox25);
            this.tabPage13.Location = new System.Drawing.Point(4, 22);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage13.Size = new System.Drawing.Size(1601, 1202);
            this.tabPage13.TabIndex = 2;
            this.tabPage13.Text = "Change Payload";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // dgvChange
            // 
            this.dgvChange.AllowUserToAddRows = false;
            this.dgvChange.AllowUserToDeleteRows = false;
            this.dgvChange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChange.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgvChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChange.Location = new System.Drawing.Point(3, 49);
            this.dgvChange.Name = "dgvChange";
            this.dgvChange.Size = new System.Drawing.Size(1595, 640);
            this.dgvChange.TabIndex = 0;
            this.dgvChange.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChange_CellEndEdit);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Property";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Value";
            this.Column5.Name = "Column5";
            this.Column5.Width = 200;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Change ";
            this.Column6.Name = "Column6";
            this.Column6.Width = 60;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Format String";
            this.Column7.Name = "Column7";
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Increment";
            this.Column8.Name = "Column8";
            // 
            // gbSamplePayloads
            // 
            this.gbSamplePayloads.Controls.Add(this.fctxtbSamplePayload);
            this.gbSamplePayloads.Controls.Add(this.toolStrip12);
            this.gbSamplePayloads.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbSamplePayloads.Enabled = false;
            this.gbSamplePayloads.Location = new System.Drawing.Point(3, 689);
            this.gbSamplePayloads.Name = "gbSamplePayloads";
            this.gbSamplePayloads.Size = new System.Drawing.Size(1595, 510);
            this.gbSamplePayloads.TabIndex = 2;
            this.gbSamplePayloads.TabStop = false;
            this.gbSamplePayloads.Text = "Sample Payloads";
            // 
            // fctxtbSamplePayload
            // 
            this.fctxtbSamplePayload.AutoCompleteBracketsList = new char[] {
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
            this.fctxtbSamplePayload.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\n^\\s*(case|default)\\s*[^:]*(" +
    "?<range>:)\\s*(?<range>[^;]+);";
            this.fctxtbSamplePayload.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.fctxtbSamplePayload.BackBrush = null;
            this.fctxtbSamplePayload.CharHeight = 14;
            this.fctxtbSamplePayload.CharWidth = 8;
            this.fctxtbSamplePayload.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctxtbSamplePayload.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctxtbSamplePayload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctxtbSamplePayload.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctxtbSamplePayload.IsReplaceMode = false;
            this.fctxtbSamplePayload.Location = new System.Drawing.Point(3, 55);
            this.fctxtbSamplePayload.Margin = new System.Windows.Forms.Padding(2);
            this.fctxtbSamplePayload.Name = "fctxtbSamplePayload";
            this.fctxtbSamplePayload.Paddings = new System.Windows.Forms.Padding(0);
            this.fctxtbSamplePayload.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctxtbSamplePayload.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctxtbSamplePayload.ServiceColors")));
            this.fctxtbSamplePayload.Size = new System.Drawing.Size(1589, 452);
            this.fctxtbSamplePayload.TabIndex = 13;
            this.fctxtbSamplePayload.Zoom = 100;
            // 
            // toolStrip12
            // 
            this.toolStrip12.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip12.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnNextPayload});
            this.toolStrip12.Location = new System.Drawing.Point(3, 16);
            this.toolStrip12.Name = "toolStrip12";
            this.toolStrip12.Size = new System.Drawing.Size(1589, 39);
            this.toolStrip12.TabIndex = 0;
            this.toolStrip12.Text = "toolStrip12";
            // 
            // tsbtnNextPayload
            // 
            this.tsbtnNextPayload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnNextPayload.Image = global::APITester.Properties.Resources.Play_32;
            this.tsbtnNextPayload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNextPayload.Name = "tsbtnNextPayload";
            this.tsbtnNextPayload.Size = new System.Drawing.Size(36, 36);
            this.tsbtnNextPayload.Text = "Show Next Payload";
            this.tsbtnNextPayload.Click += new System.EventHandler(this.tsbtnNextPayload_Click);
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.rbtnChangePayload);
            this.groupBox25.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox25.Location = new System.Drawing.Point(3, 3);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(1595, 46);
            this.groupBox25.TabIndex = 1;
            this.groupBox25.TabStop = false;
            // 
            // rbtnChangePayload
            // 
            this.rbtnChangePayload.AutoSize = true;
            this.rbtnChangePayload.Location = new System.Drawing.Point(3, 16);
            this.rbtnChangePayload.Name = "rbtnChangePayload";
            this.rbtnChangePayload.Size = new System.Drawing.Size(168, 17);
            this.rbtnChangePayload.TabIndex = 0;
            this.rbtnChangePayload.Text = "Change payload for each post";
            this.rbtnChangePayload.UseVisualStyleBackColor = true;
            this.rbtnChangePayload.CheckedChanged += new System.EventHandler(this.rbtnChangePayload_CheckedChanged);
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.fctxtbIncomingPayload);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(1601, 1202);
            this.tabPage10.TabIndex = 1;
            this.tabPage10.Text = "Response Payload";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // fctxtbIncomingPayload
            // 
            this.fctxtbIncomingPayload.AutoCompleteBracketsList = new char[] {
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
            this.fctxtbIncomingPayload.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\n^\\s*(case|default)\\s*[^:]*(" +
    "?<range>:)\\s*(?<range>[^;]+);";
            this.fctxtbIncomingPayload.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.fctxtbIncomingPayload.BackBrush = null;
            this.fctxtbIncomingPayload.CharHeight = 14;
            this.fctxtbIncomingPayload.CharWidth = 8;
            this.fctxtbIncomingPayload.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctxtbIncomingPayload.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctxtbIncomingPayload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctxtbIncomingPayload.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctxtbIncomingPayload.IsReplaceMode = false;
            this.fctxtbIncomingPayload.Location = new System.Drawing.Point(3, 3);
            this.fctxtbIncomingPayload.Margin = new System.Windows.Forms.Padding(2);
            this.fctxtbIncomingPayload.Name = "fctxtbIncomingPayload";
            this.fctxtbIncomingPayload.Paddings = new System.Windows.Forms.Padding(0);
            this.fctxtbIncomingPayload.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctxtbIncomingPayload.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctxtbIncomingPayload.ServiceColors")));
            this.fctxtbIncomingPayload.Size = new System.Drawing.Size(1595, 1196);
            this.fctxtbIncomingPayload.TabIndex = 12;
            this.fctxtbIncomingPayload.Zoom = 100;
            // 
            // tabPage15
            // 
            this.tabPage15.Controls.Add(this.chart2);
            this.tabPage15.Location = new System.Drawing.Point(4, 22);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage15.Size = new System.Drawing.Size(1601, 1202);
            this.tabPage15.TabIndex = 3;
            this.tabPage15.Text = "Chart";
            this.tabPage15.UseVisualStyleBackColor = true;
            // 
            // chart2
            // 
            chartArea2.AxisX.Title = "Duration (ms)";
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(3, 3);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Calls per duration";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(1595, 1196);
            this.chart2.TabIndex = 0;
            this.chart2.Text = "chart2";
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.groupBox20);
            this.groupBox19.Controls.Add(this.gbEndpoints);
            this.groupBox19.Controls.Add(this.groupBox14);
            this.groupBox19.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox19.Location = new System.Drawing.Point(3, 42);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(364, 1228);
            this.groupBox19.TabIndex = 2;
            this.groupBox19.TabStop = false;
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.groupBox23);
            this.groupBox20.Controls.Add(this.groupBox22);
            this.groupBox20.Controls.Add(this.groupBox21);
            this.groupBox20.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox20.Location = new System.Drawing.Point(3, 695);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(358, 141);
            this.groupBox20.TabIndex = 2;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Performance";
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.txtbIncommingPayloadSize);
            this.groupBox23.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox23.Location = new System.Drawing.Point(3, 96);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(352, 40);
            this.groupBox23.TabIndex = 3;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Incoming Payload Size";
            // 
            // txtbIncommingPayloadSize
            // 
            this.txtbIncommingPayloadSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbIncommingPayloadSize.Location = new System.Drawing.Point(3, 16);
            this.txtbIncommingPayloadSize.Name = "txtbIncommingPayloadSize";
            this.txtbIncommingPayloadSize.Size = new System.Drawing.Size(346, 20);
            this.txtbIncommingPayloadSize.TabIndex = 0;
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.txtbOutgoingPayloadSize);
            this.groupBox22.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox22.Location = new System.Drawing.Point(3, 56);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(352, 40);
            this.groupBox22.TabIndex = 2;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Outgoing Payload Size";
            // 
            // txtbOutgoingPayloadSize
            // 
            this.txtbOutgoingPayloadSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbOutgoingPayloadSize.Location = new System.Drawing.Point(3, 16);
            this.txtbOutgoingPayloadSize.Name = "txtbOutgoingPayloadSize";
            this.txtbOutgoingPayloadSize.Size = new System.Drawing.Size(346, 20);
            this.txtbOutgoingPayloadSize.TabIndex = 0;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.txtbAverageDuration);
            this.groupBox21.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox21.Location = new System.Drawing.Point(3, 16);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(352, 40);
            this.groupBox21.TabIndex = 1;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Response Time (ms)";
            // 
            // txtbAverageDuration
            // 
            this.txtbAverageDuration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbAverageDuration.Location = new System.Drawing.Point(3, 16);
            this.txtbAverageDuration.Name = "txtbAverageDuration";
            this.txtbAverageDuration.Size = new System.Drawing.Size(346, 20);
            this.txtbAverageDuration.TabIndex = 0;
            // 
            // gbEndpoints
            // 
            this.gbEndpoints.Controls.Add(this.rbtnDeleteDocument);
            this.gbEndpoints.Controls.Add(this.rbtnCreatePayments);
            this.gbEndpoints.Controls.Add(this.rbtnUpdateClaim);
            this.gbEndpoints.Controls.Add(this.rbtnAttachDocument);
            this.gbEndpoints.Controls.Add(this.rbtnCreateInspectionRequest);
            this.gbEndpoints.Controls.Add(this.rbtnCreateClaim);
            this.gbEndpoints.Controls.Add(this.rbtnGetCreditCard);
            this.gbEndpoints.Controls.Add(this.rbtnGetInspectionHistory);
            this.gbEndpoints.Controls.Add(this.rbtnGetInspectionRequests);
            this.gbEndpoints.Controls.Add(this.rbtnGetInspectionPartners);
            this.gbEndpoints.Controls.Add(this.rbtnGetClaimPayees);
            this.gbEndpoints.Controls.Add(this.rbtnGetOutgoingDocument);
            this.gbEndpoints.Controls.Add(this.rbtnGetDocument);
            this.gbEndpoints.Controls.Add(this.rbtnGetClaimDocuments);
            this.gbEndpoints.Controls.Add(this.rbtnGetSingleClaim);
            this.gbEndpoints.Controls.Add(this.rbtnGetAllClaims);
            this.gbEndpoints.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbEndpoints.Enabled = false;
            this.gbEndpoints.Location = new System.Drawing.Point(3, 260);
            this.gbEndpoints.Name = "gbEndpoints";
            this.gbEndpoints.Size = new System.Drawing.Size(358, 435);
            this.gbEndpoints.TabIndex = 0;
            this.gbEndpoints.TabStop = false;
            this.gbEndpoints.Text = "Endpoints";
            // 
            // rbtnDeleteDocument
            // 
            this.rbtnDeleteDocument.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtnDeleteDocument.Location = new System.Drawing.Point(3, 376);
            this.rbtnDeleteDocument.Name = "rbtnDeleteDocument";
            this.rbtnDeleteDocument.Size = new System.Drawing.Size(352, 24);
            this.rbtnDeleteDocument.TabIndex = 14;
            this.rbtnDeleteDocument.Text = "Delete Document";
            this.rbtnDeleteDocument.UseVisualStyleBackColor = true;
            this.rbtnDeleteDocument.CheckedChanged += new System.EventHandler(this.rbtnDeleteDocument_CheckedChanged);
            // 
            // rbtnCreatePayments
            // 
            this.rbtnCreatePayments.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtnCreatePayments.Location = new System.Drawing.Point(3, 352);
            this.rbtnCreatePayments.Name = "rbtnCreatePayments";
            this.rbtnCreatePayments.Size = new System.Drawing.Size(352, 24);
            this.rbtnCreatePayments.TabIndex = 13;
            this.rbtnCreatePayments.Text = "Create Payments";
            this.rbtnCreatePayments.UseVisualStyleBackColor = true;
            this.rbtnCreatePayments.CheckedChanged += new System.EventHandler(this.rbtnCreatePayments_CheckedChanged);
            // 
            // rbtnUpdateClaim
            // 
            this.rbtnUpdateClaim.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtnUpdateClaim.Location = new System.Drawing.Point(3, 328);
            this.rbtnUpdateClaim.Name = "rbtnUpdateClaim";
            this.rbtnUpdateClaim.Size = new System.Drawing.Size(352, 24);
            this.rbtnUpdateClaim.TabIndex = 12;
            this.rbtnUpdateClaim.Text = "Update Claim";
            this.rbtnUpdateClaim.UseVisualStyleBackColor = true;
            this.rbtnUpdateClaim.CheckedChanged += new System.EventHandler(this.rbtnUpdateClaim_CheckedChanged);
            // 
            // rbtnAttachDocument
            // 
            this.rbtnAttachDocument.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtnAttachDocument.Location = new System.Drawing.Point(3, 304);
            this.rbtnAttachDocument.Name = "rbtnAttachDocument";
            this.rbtnAttachDocument.Size = new System.Drawing.Size(352, 24);
            this.rbtnAttachDocument.TabIndex = 11;
            this.rbtnAttachDocument.Text = "Attach Document";
            this.rbtnAttachDocument.UseVisualStyleBackColor = true;
            this.rbtnAttachDocument.CheckedChanged += new System.EventHandler(this.rbtnAttachDocument_CheckedChanged);
            // 
            // rbtnCreateInspectionRequest
            // 
            this.rbtnCreateInspectionRequest.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtnCreateInspectionRequest.Location = new System.Drawing.Point(3, 280);
            this.rbtnCreateInspectionRequest.Name = "rbtnCreateInspectionRequest";
            this.rbtnCreateInspectionRequest.Size = new System.Drawing.Size(352, 24);
            this.rbtnCreateInspectionRequest.TabIndex = 10;
            this.rbtnCreateInspectionRequest.Text = "Create Inspection Request";
            this.rbtnCreateInspectionRequest.UseVisualStyleBackColor = true;
            this.rbtnCreateInspectionRequest.CheckedChanged += new System.EventHandler(this.rbtnCreateInspectionRequest_CheckedChanged);
            // 
            // rbtnCreateClaim
            // 
            this.rbtnCreateClaim.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtnCreateClaim.Location = new System.Drawing.Point(3, 256);
            this.rbtnCreateClaim.Name = "rbtnCreateClaim";
            this.rbtnCreateClaim.Size = new System.Drawing.Size(352, 24);
            this.rbtnCreateClaim.TabIndex = 9;
            this.rbtnCreateClaim.Text = "Create Claim";
            this.rbtnCreateClaim.UseVisualStyleBackColor = true;
            this.rbtnCreateClaim.CheckedChanged += new System.EventHandler(this.rbtnCreateClaim_CheckedChanged);
            // 
            // rbtnGetCreditCard
            // 
            this.rbtnGetCreditCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtnGetCreditCard.Location = new System.Drawing.Point(3, 232);
            this.rbtnGetCreditCard.Name = "rbtnGetCreditCard";
            this.rbtnGetCreditCard.Size = new System.Drawing.Size(352, 24);
            this.rbtnGetCreditCard.TabIndex = 8;
            this.rbtnGetCreditCard.Text = "Get Credit Card";
            this.rbtnGetCreditCard.UseVisualStyleBackColor = true;
            this.rbtnGetCreditCard.CheckedChanged += new System.EventHandler(this.rbtnGetCreditCard_CheckedChanged);
            // 
            // rbtnGetInspectionHistory
            // 
            this.rbtnGetInspectionHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtnGetInspectionHistory.Location = new System.Drawing.Point(3, 208);
            this.rbtnGetInspectionHistory.Name = "rbtnGetInspectionHistory";
            this.rbtnGetInspectionHistory.Size = new System.Drawing.Size(352, 24);
            this.rbtnGetInspectionHistory.TabIndex = 7;
            this.rbtnGetInspectionHistory.Text = "Get Inspection History";
            this.rbtnGetInspectionHistory.UseVisualStyleBackColor = true;
            this.rbtnGetInspectionHistory.CheckedChanged += new System.EventHandler(this.rbtnGetInspectionHistory_CheckedChanged);
            // 
            // rbtnGetInspectionRequests
            // 
            this.rbtnGetInspectionRequests.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtnGetInspectionRequests.Location = new System.Drawing.Point(3, 184);
            this.rbtnGetInspectionRequests.Name = "rbtnGetInspectionRequests";
            this.rbtnGetInspectionRequests.Size = new System.Drawing.Size(352, 24);
            this.rbtnGetInspectionRequests.TabIndex = 6;
            this.rbtnGetInspectionRequests.Text = "Get Inspection Requests";
            this.rbtnGetInspectionRequests.UseVisualStyleBackColor = true;
            this.rbtnGetInspectionRequests.CheckedChanged += new System.EventHandler(this.rbtnGetInspectionRequests_CheckedChanged);
            // 
            // rbtnGetInspectionPartners
            // 
            this.rbtnGetInspectionPartners.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtnGetInspectionPartners.Location = new System.Drawing.Point(3, 160);
            this.rbtnGetInspectionPartners.Name = "rbtnGetInspectionPartners";
            this.rbtnGetInspectionPartners.Size = new System.Drawing.Size(352, 24);
            this.rbtnGetInspectionPartners.TabIndex = 5;
            this.rbtnGetInspectionPartners.Text = "Get Inspection Partners";
            this.rbtnGetInspectionPartners.UseVisualStyleBackColor = true;
            this.rbtnGetInspectionPartners.CheckedChanged += new System.EventHandler(this.rbtnGetInspectionPartners_CheckedChanged);
            // 
            // rbtnGetClaimPayees
            // 
            this.rbtnGetClaimPayees.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtnGetClaimPayees.Location = new System.Drawing.Point(3, 136);
            this.rbtnGetClaimPayees.Name = "rbtnGetClaimPayees";
            this.rbtnGetClaimPayees.Size = new System.Drawing.Size(352, 24);
            this.rbtnGetClaimPayees.TabIndex = 4;
            this.rbtnGetClaimPayees.Text = "Get Claim Payees";
            this.rbtnGetClaimPayees.UseVisualStyleBackColor = true;
            this.rbtnGetClaimPayees.CheckedChanged += new System.EventHandler(this.rbtnGetClaimPayees_CheckedChanged);
            // 
            // rbtnGetOutgoingDocument
            // 
            this.rbtnGetOutgoingDocument.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtnGetOutgoingDocument.Location = new System.Drawing.Point(3, 112);
            this.rbtnGetOutgoingDocument.Name = "rbtnGetOutgoingDocument";
            this.rbtnGetOutgoingDocument.Size = new System.Drawing.Size(352, 24);
            this.rbtnGetOutgoingDocument.TabIndex = 15;
            this.rbtnGetOutgoingDocument.Text = "Get Outgoing Dicument";
            this.rbtnGetOutgoingDocument.UseVisualStyleBackColor = true;
            this.rbtnGetOutgoingDocument.CheckedChanged += new System.EventHandler(this.rbtnGetOutgoingDocument_CheckedChanged);
            // 
            // rbtnGetDocument
            // 
            this.rbtnGetDocument.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtnGetDocument.Location = new System.Drawing.Point(3, 88);
            this.rbtnGetDocument.Name = "rbtnGetDocument";
            this.rbtnGetDocument.Size = new System.Drawing.Size(352, 24);
            this.rbtnGetDocument.TabIndex = 2;
            this.rbtnGetDocument.Text = "Get Incoming Dicument";
            this.rbtnGetDocument.UseVisualStyleBackColor = true;
            this.rbtnGetDocument.CheckedChanged += new System.EventHandler(this.rbtnGetDocument_CheckedChanged);
            // 
            // rbtnGetClaimDocuments
            // 
            this.rbtnGetClaimDocuments.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtnGetClaimDocuments.Location = new System.Drawing.Point(3, 64);
            this.rbtnGetClaimDocuments.Name = "rbtnGetClaimDocuments";
            this.rbtnGetClaimDocuments.Size = new System.Drawing.Size(352, 24);
            this.rbtnGetClaimDocuments.TabIndex = 3;
            this.rbtnGetClaimDocuments.Text = "Get Claim Documents";
            this.rbtnGetClaimDocuments.UseVisualStyleBackColor = true;
            this.rbtnGetClaimDocuments.CheckedChanged += new System.EventHandler(this.rbtnGetClaimDocuments_CheckedChanged);
            // 
            // rbtnGetSingleClaim
            // 
            this.rbtnGetSingleClaim.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtnGetSingleClaim.Location = new System.Drawing.Point(3, 40);
            this.rbtnGetSingleClaim.Name = "rbtnGetSingleClaim";
            this.rbtnGetSingleClaim.Size = new System.Drawing.Size(352, 24);
            this.rbtnGetSingleClaim.TabIndex = 1;
            this.rbtnGetSingleClaim.Text = "Get Single Claim";
            this.rbtnGetSingleClaim.UseVisualStyleBackColor = true;
            this.rbtnGetSingleClaim.CheckedChanged += new System.EventHandler(this.rbtnGetSingleClaim_CheckedChanged);
            // 
            // rbtnGetAllClaims
            // 
            this.rbtnGetAllClaims.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtnGetAllClaims.Location = new System.Drawing.Point(3, 16);
            this.rbtnGetAllClaims.Name = "rbtnGetAllClaims";
            this.rbtnGetAllClaims.Size = new System.Drawing.Size(352, 24);
            this.rbtnGetAllClaims.TabIndex = 0;
            this.rbtnGetAllClaims.Text = "Get All Claims";
            this.rbtnGetAllClaims.UseVisualStyleBackColor = true;
            this.rbtnGetAllClaims.CheckedChanged += new System.EventHandler(this.rbtnGetAllClaims_CheckedChanged);
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.groupBox24);
            this.groupBox14.Controls.Add(this.toolStrip10);
            this.groupBox14.Controls.Add(this.groupBox18);
            this.groupBox14.Controls.Add(this.groupBox17);
            this.groupBox14.Controls.Add(this.groupBox16);
            this.groupBox14.Controls.Add(this.groupBox15);
            this.groupBox14.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox14.Location = new System.Drawing.Point(3, 16);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(358, 244);
            this.groupBox14.TabIndex = 1;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "TPA Information";
            // 
            // groupBox24
            // 
            this.groupBox24.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox24.Controls.Add(this.txtbLoginURL);
            this.groupBox24.Location = new System.Drawing.Point(6, 104);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(346, 40);
            this.groupBox24.TabIndex = 5;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Login URL";
            // 
            // txtbLoginURL
            // 
            this.txtbLoginURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbLoginURL.Location = new System.Drawing.Point(3, 16);
            this.txtbLoginURL.Name = "txtbLoginURL";
            this.txtbLoginURL.Size = new System.Drawing.Size(340, 20);
            this.txtbLoginURL.TabIndex = 0;
            this.txtbLoginURL.Leave += new System.EventHandler(this.txtbLoginURL_Leave);
            // 
            // toolStrip10
            // 
            this.toolStrip10.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip10.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAddTPA});
            this.toolStrip10.Location = new System.Drawing.Point(3, 16);
            this.toolStrip10.Name = "toolStrip10";
            this.toolStrip10.Size = new System.Drawing.Size(352, 39);
            this.toolStrip10.TabIndex = 4;
            this.toolStrip10.Text = "toolStrip10";
            // 
            // tsbtnAddTPA
            // 
            this.tsbtnAddTPA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnAddTPA.Image = global::APITester.Properties.Resources.GreenAdd_32;
            this.tsbtnAddTPA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAddTPA.Name = "tsbtnAddTPA";
            this.tsbtnAddTPA.Size = new System.Drawing.Size(36, 36);
            this.tsbtnAddTPA.Text = "Add A TPA";
            this.tsbtnAddTPA.Click += new System.EventHandler(this.tsbtnAddTPA_Click);
            // 
            // groupBox18
            // 
            this.groupBox18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox18.Controls.Add(this.txtbUserSecret);
            this.groupBox18.Location = new System.Drawing.Point(6, 196);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(346, 40);
            this.groupBox18.TabIndex = 3;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "User Secret";
            // 
            // txtbUserSecret
            // 
            this.txtbUserSecret.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbUserSecret.Location = new System.Drawing.Point(3, 16);
            this.txtbUserSecret.Name = "txtbUserSecret";
            this.txtbUserSecret.PasswordChar = '*';
            this.txtbUserSecret.Size = new System.Drawing.Size(340, 20);
            this.txtbUserSecret.TabIndex = 0;
            this.txtbUserSecret.Leave += new System.EventHandler(this.txtbUserSecret_Leave);
            // 
            // groupBox17
            // 
            this.groupBox17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox17.Controls.Add(this.txtbUserId);
            this.groupBox17.Location = new System.Drawing.Point(6, 150);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(346, 40);
            this.groupBox17.TabIndex = 2;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "User Id";
            // 
            // txtbUserId
            // 
            this.txtbUserId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbUserId.Location = new System.Drawing.Point(3, 16);
            this.txtbUserId.Name = "txtbUserId";
            this.txtbUserId.Size = new System.Drawing.Size(340, 20);
            this.txtbUserId.TabIndex = 0;
            this.txtbUserId.Leave += new System.EventHandler(this.txtbUserId_Leave);
            // 
            // groupBox16
            // 
            this.groupBox16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox16.Controls.Add(this.txtbBaseURL);
            this.groupBox16.Location = new System.Drawing.Point(72, 58);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(280, 40);
            this.groupBox16.TabIndex = 1;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Base URL";
            // 
            // txtbBaseURL
            // 
            this.txtbBaseURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbBaseURL.Location = new System.Drawing.Point(3, 16);
            this.txtbBaseURL.Name = "txtbBaseURL";
            this.txtbBaseURL.Size = new System.Drawing.Size(274, 20);
            this.txtbBaseURL.TabIndex = 0;
            this.txtbBaseURL.Leave += new System.EventHandler(this.txtbBaseURL_Leave);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.cmbxTPA);
            this.groupBox15.Location = new System.Drawing.Point(6, 58);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(60, 40);
            this.groupBox15.TabIndex = 0;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "TPA";
            // 
            // cmbxTPA
            // 
            this.cmbxTPA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbxTPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxTPA.FormattingEnabled = true;
            this.cmbxTPA.Location = new System.Drawing.Point(3, 16);
            this.cmbxTPA.Name = "cmbxTPA";
            this.cmbxTPA.Size = new System.Drawing.Size(54, 21);
            this.cmbxTPA.Sorted = true;
            this.cmbxTPA.TabIndex = 0;
            this.cmbxTPA.SelectedIndexChanged += new System.EventHandler(this.cmbxTPA_SelectedIndexChanged);
            // 
            // toolStrip9
            // 
            this.toolStrip9.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip9.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSavePerformnceCommands,
            this.toolStripSeparator15,
            this.toolStripLabel9,
            this.tstxtbNumberOfIterations,
            this.toolStripSeparator16,
            this.tsbtnRunPerformanceCommand});
            this.toolStrip9.Location = new System.Drawing.Point(3, 3);
            this.toolStrip9.Name = "toolStrip9";
            this.toolStrip9.Size = new System.Drawing.Size(1973, 39);
            this.toolStrip9.TabIndex = 4;
            this.toolStrip9.Text = "toolStrip9";
            // 
            // tsbtnSavePerformnceCommands
            // 
            this.tsbtnSavePerformnceCommands.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSavePerformnceCommands.Image = global::APITester.Properties.Resources.FloppyDisk_32;
            this.tsbtnSavePerformnceCommands.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSavePerformnceCommands.Name = "tsbtnSavePerformnceCommands";
            this.tsbtnSavePerformnceCommands.Size = new System.Drawing.Size(36, 36);
            this.tsbtnSavePerformnceCommands.Text = "Save test suite";
            this.tsbtnSavePerformnceCommands.Click += new System.EventHandler(this.tsbtnSavePerformnceCommands_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel9
            // 
            this.toolStripLabel9.Name = "toolStripLabel9";
            this.toolStripLabel9.Size = new System.Drawing.Size(94, 36);
            this.toolStripLabel9.Text = "Number of runs:";
            // 
            // tstxtbNumberOfIterations
            // 
            this.tstxtbNumberOfIterations.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstxtbNumberOfIterations.Name = "tstxtbNumberOfIterations";
            this.tstxtbNumberOfIterations.Size = new System.Drawing.Size(100, 39);
            this.tstxtbNumberOfIterations.Leave += new System.EventHandler(this.tstxtbNumberOfIterations_Leave);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnRunPerformanceCommand
            // 
            this.tsbtnRunPerformanceCommand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRunPerformanceCommand.Enabled = false;
            this.tsbtnRunPerformanceCommand.Image = global::APITester.Properties.Resources.Play_32;
            this.tsbtnRunPerformanceCommand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRunPerformanceCommand.Name = "tsbtnRunPerformanceCommand";
            this.tsbtnRunPerformanceCommand.Size = new System.Drawing.Size(36, 36);
            this.tsbtnRunPerformanceCommand.Text = "toolStripButton4";
            this.tsbtnRunPerformanceCommand.Click += new System.EventHandler(this.tsbtnRunPerformanceCommand_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.fcrtxtbLogView);
            this.tabPage7.Controls.Add(this.splitter7);
            this.tabPage7.Controls.Add(this.fctxtbStackTrace);
            this.tabPage7.Controls.Add(this.splitter6);
            this.tabPage7.Controls.Add(this.groupBox12);
            this.tabPage7.Controls.Add(this.splitter5);
            this.tabPage7.Controls.Add(this.groupBox11);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1979, 1273);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "Logs";
            this.tabPage7.UseVisualStyleBackColor = true;
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
            this.fcrtxtbLogView.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.fcrtxtbLogView.BackBrush = null;
            this.fcrtxtbLogView.CharHeight = 14;
            this.fcrtxtbLogView.CharWidth = 8;
            this.fcrtxtbLogView.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fcrtxtbLogView.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fcrtxtbLogView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fcrtxtbLogView.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fcrtxtbLogView.IsReplaceMode = false;
            this.fcrtxtbLogView.Location = new System.Drawing.Point(784, 3);
            this.fcrtxtbLogView.Margin = new System.Windows.Forms.Padding(2);
            this.fcrtxtbLogView.Name = "fcrtxtbLogView";
            this.fcrtxtbLogView.Paddings = new System.Windows.Forms.Padding(0);
            this.fcrtxtbLogView.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fcrtxtbLogView.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fcrtxtbLogView.ServiceColors")));
            this.fcrtxtbLogView.Size = new System.Drawing.Size(1192, 729);
            this.fcrtxtbLogView.TabIndex = 11;
            this.fcrtxtbLogView.Zoom = 100;
            // 
            // splitter7
            // 
            this.splitter7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter7.Location = new System.Drawing.Point(784, 732);
            this.splitter7.Name = "splitter7";
            this.splitter7.Size = new System.Drawing.Size(1192, 3);
            this.splitter7.TabIndex = 14;
            this.splitter7.TabStop = false;
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
            this.fctxtbStackTrace.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.fctxtbStackTrace.BackBrush = null;
            this.fctxtbStackTrace.CharHeight = 14;
            this.fctxtbStackTrace.CharWidth = 8;
            this.fctxtbStackTrace.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctxtbStackTrace.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctxtbStackTrace.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fctxtbStackTrace.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctxtbStackTrace.IsReplaceMode = false;
            this.fctxtbStackTrace.Location = new System.Drawing.Point(784, 735);
            this.fctxtbStackTrace.Margin = new System.Windows.Forms.Padding(2);
            this.fctxtbStackTrace.Name = "fctxtbStackTrace";
            this.fctxtbStackTrace.Paddings = new System.Windows.Forms.Padding(0);
            this.fctxtbStackTrace.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctxtbStackTrace.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctxtbStackTrace.ServiceColors")));
            this.fctxtbStackTrace.Size = new System.Drawing.Size(1192, 535);
            this.fctxtbStackTrace.TabIndex = 15;
            this.fctxtbStackTrace.Zoom = 100;
            // 
            // splitter6
            // 
            this.splitter6.Location = new System.Drawing.Point(781, 3);
            this.splitter6.Name = "splitter6";
            this.splitter6.Size = new System.Drawing.Size(3, 1267);
            this.splitter6.TabIndex = 13;
            this.splitter6.TabStop = false;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.tabControl4);
            this.groupBox12.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox12.Location = new System.Drawing.Point(356, 3);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(425, 1267);
            this.groupBox12.TabIndex = 12;
            this.groupBox12.TabStop = false;
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage11);
            this.tabControl4.Controls.Add(this.tabPage12);
            this.tabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl4.Location = new System.Drawing.Point(3, 16);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(419, 1248);
            this.tabControl4.TabIndex = 1;
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.lbxLogEntries);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(411, 1222);
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
            this.lbxLogEntries.Size = new System.Drawing.Size(405, 1216);
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
            this.tabPage12.Size = new System.Drawing.Size(411, 1222);
            this.tabPage12.TabIndex = 1;
            this.tabPage12.Text = "Performance Log";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // tvPerformance
            // 
            this.tvPerformance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPerformance.Location = new System.Drawing.Point(3, 3);
            this.tvPerformance.Name = "tvPerformance";
            this.tvPerformance.Size = new System.Drawing.Size(405, 1216);
            this.tvPerformance.TabIndex = 0;
            this.tvPerformance.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPerformance_AfterSelect);
            // 
            // splitter5
            // 
            this.splitter5.Location = new System.Drawing.Point(353, 3);
            this.splitter5.Name = "splitter5";
            this.splitter5.Size = new System.Drawing.Size(3, 1267);
            this.splitter5.TabIndex = 1;
            this.splitter5.TabStop = false;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.tvLogFiles);
            this.groupBox11.Controls.Add(this.toolStrip11);
            this.groupBox11.Controls.Add(this.toolStrip8);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox11.Location = new System.Drawing.Point(3, 3);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(350, 1267);
            this.groupBox11.TabIndex = 0;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Log Files";
            // 
            // tvLogFiles
            // 
            this.tvLogFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvLogFiles.Location = new System.Drawing.Point(3, 94);
            this.tvLogFiles.Name = "tvLogFiles";
            this.tvLogFiles.Size = new System.Drawing.Size(344, 1170);
            this.tvLogFiles.TabIndex = 1;
            this.tvLogFiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvLogFiles_AfterSelect);
            // 
            // toolStrip11
            // 
            this.toolStrip11.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip11.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel12,
            this.tsbtnLoadNextPage,
            this.tsbtnLoadPreviousPage,
            this.toolStripLabel14,
            this.tstxtbPageSize});
            this.toolStrip11.Location = new System.Drawing.Point(3, 55);
            this.toolStrip11.Name = "toolStrip11";
            this.toolStrip11.Size = new System.Drawing.Size(344, 39);
            this.toolStrip11.TabIndex = 2;
            this.toolStrip11.Text = "toolStrip11";
            // 
            // toolStripLabel12
            // 
            this.toolStripLabel12.AutoSize = false;
            this.toolStripLabel12.Name = "toolStripLabel12";
            this.toolStripLabel12.Size = new System.Drawing.Size(50, 36);
            this.toolStripLabel12.Text = "Page 1";
            // 
            // tsbtnLoadNextPage
            // 
            this.tsbtnLoadNextPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnLoadNextPage.Enabled = false;
            this.tsbtnLoadNextPage.Image = global::APITester.Properties.Resources.Down_32;
            this.tsbtnLoadNextPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLoadNextPage.Name = "tsbtnLoadNextPage";
            this.tsbtnLoadNextPage.Size = new System.Drawing.Size(36, 36);
            this.tsbtnLoadNextPage.Text = "Load next page";
            this.tsbtnLoadNextPage.Click += new System.EventHandler(this.tsbtnLoadNextPage_Click);
            // 
            // tsbtnLoadPreviousPage
            // 
            this.tsbtnLoadPreviousPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnLoadPreviousPage.Enabled = false;
            this.tsbtnLoadPreviousPage.Image = global::APITester.Properties.Resources.Up_32;
            this.tsbtnLoadPreviousPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLoadPreviousPage.Name = "tsbtnLoadPreviousPage";
            this.tsbtnLoadPreviousPage.Size = new System.Drawing.Size(36, 36);
            this.tsbtnLoadPreviousPage.Text = "Load previous page";
            this.tsbtnLoadPreviousPage.Click += new System.EventHandler(this.tsbtnLoadPreviousPage_Click);
            // 
            // toolStripLabel14
            // 
            this.toolStripLabel14.Name = "toolStripLabel14";
            this.toolStripLabel14.Size = new System.Drawing.Size(78, 36);
            this.toolStripLabel14.Text = "Log page size";
            // 
            // tstxtbPageSize
            // 
            this.tstxtbPageSize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstxtbPageSize.Name = "tstxtbPageSize";
            this.tstxtbPageSize.Size = new System.Drawing.Size(60, 39);
            this.tstxtbPageSize.Leave += new System.EventHandler(this.tstxtbPageSize_Leave);
            // 
            // toolStrip8
            // 
            this.toolStrip8.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip8.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnRefresh,
            this.tsbtnFilterLog,
            this.tslblMinDate,
            this.toolStripSeparator17,
            this.tsbtnOpenLogFile});
            this.toolStrip8.Location = new System.Drawing.Point(3, 16);
            this.toolStrip8.Name = "toolStrip8";
            this.toolStrip8.Size = new System.Drawing.Size(344, 39);
            this.toolStrip8.TabIndex = 0;
            this.toolStrip8.Text = "toolStrip8";
            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRefresh.Image = global::APITester.Properties.Resources.Refresh_32;
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(36, 36);
            this.tsbtnRefresh.Text = "Refresh";
            this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
            // 
            // tsbtnFilterLog
            // 
            this.tsbtnFilterLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnFilterLog.Image = global::APITester.Properties.Resources.FilterList_32;
            this.tsbtnFilterLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFilterLog.Name = "tsbtnFilterLog";
            this.tsbtnFilterLog.Size = new System.Drawing.Size(36, 36);
            this.tsbtnFilterLog.Text = "Filter the log files";
            this.tsbtnFilterLog.Click += new System.EventHandler(this.tsbtnFilterLog_Click);
            // 
            // tslblMinDate
            // 
            this.tslblMinDate.Name = "tslblMinDate";
            this.tslblMinDate.Size = new System.Drawing.Size(94, 36);
            this.tslblMinDate.Text = "After 10/28/2021";
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnOpenLogFile
            // 
            this.tsbtnOpenLogFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnOpenLogFile.Image = global::APITester.Properties.Resources.OpenDocumentFolder_32;
            this.tsbtnOpenLogFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpenLogFile.Name = "tsbtnOpenLogFile";
            this.tsbtnOpenLogFile.Size = new System.Drawing.Size(36, 36);
            this.tsbtnOpenLogFile.Text = "Open Log File";
            this.tsbtnOpenLogFile.Click += new System.EventHandler(this.tsbtnOpenLogFile_Click);
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.fctxtbSQLCommand);
            this.tabPage14.Controls.Add(this.toolStrip14);
            this.tabPage14.Controls.Add(this.groupBox13);
            this.tabPage14.Location = new System.Drawing.Point(4, 22);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(1979, 1273);
            this.tabPage14.TabIndex = 6;
            this.tabPage14.Text = "Database Actions";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // fctxtbSQLCommand
            // 
            this.fctxtbSQLCommand.AutoCompleteBracketsList = new char[] {
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
            this.fctxtbSQLCommand.AutoIndentCharsPatterns = "";
            this.fctxtbSQLCommand.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.fctxtbSQLCommand.BackBrush = null;
            this.fctxtbSQLCommand.CharHeight = 14;
            this.fctxtbSQLCommand.CharWidth = 8;
            this.fctxtbSQLCommand.CommentPrefix = "--";
            this.fctxtbSQLCommand.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctxtbSQLCommand.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctxtbSQLCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctxtbSQLCommand.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctxtbSQLCommand.IsReplaceMode = false;
            this.fctxtbSQLCommand.Language = FastColoredTextBoxNS.Language.SQL;
            this.fctxtbSQLCommand.LeftBracket = '(';
            this.fctxtbSQLCommand.Location = new System.Drawing.Point(383, 42);
            this.fctxtbSQLCommand.Margin = new System.Windows.Forms.Padding(2);
            this.fctxtbSQLCommand.Name = "fctxtbSQLCommand";
            this.fctxtbSQLCommand.Paddings = new System.Windows.Forms.Padding(0);
            this.fctxtbSQLCommand.RightBracket = ')';
            this.fctxtbSQLCommand.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctxtbSQLCommand.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctxtbSQLCommand.ServiceColors")));
            this.fctxtbSQLCommand.Size = new System.Drawing.Size(1593, 1228);
            this.fctxtbSQLCommand.TabIndex = 16;
            this.fctxtbSQLCommand.Zoom = 100;
            // 
            // toolStrip14
            // 
            this.toolStrip14.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip14.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnRunSQLCommand});
            this.toolStrip14.Location = new System.Drawing.Point(383, 3);
            this.toolStrip14.Name = "toolStrip14";
            this.toolStrip14.Size = new System.Drawing.Size(1593, 39);
            this.toolStrip14.TabIndex = 17;
            this.toolStrip14.Text = "toolStrip14";
            // 
            // tsbtnRunSQLCommand
            // 
            this.tsbtnRunSQLCommand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRunSQLCommand.Enabled = false;
            this.tsbtnRunSQLCommand.Image = global::APITester.Properties.Resources.Play_32;
            this.tsbtnRunSQLCommand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRunSQLCommand.Name = "tsbtnRunSQLCommand";
            this.tsbtnRunSQLCommand.Size = new System.Drawing.Size(36, 36);
            this.tsbtnRunSQLCommand.Text = "Execute command";
            this.tsbtnRunSQLCommand.Click += new System.EventHandler(this.tsbtnRunSQLCommand_Click);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.rbtnDeleteClaim);
            this.groupBox13.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox13.Location = new System.Drawing.Point(3, 3);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(380, 1267);
            this.groupBox13.TabIndex = 0;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Commands";
            // 
            // rbtnDeleteClaim
            // 
            this.rbtnDeleteClaim.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtnDeleteClaim.Location = new System.Drawing.Point(3, 16);
            this.rbtnDeleteClaim.Name = "rbtnDeleteClaim";
            this.rbtnDeleteClaim.Size = new System.Drawing.Size(374, 24);
            this.rbtnDeleteClaim.TabIndex = 0;
            this.rbtnDeleteClaim.TabStop = true;
            this.rbtnDeleteClaim.Text = "Delete CLaim";
            this.rbtnDeleteClaim.UseVisualStyleBackColor = true;
            this.rbtnDeleteClaim.CheckedChanged += new System.EventHandler(this.rbtnDeleteClaim_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1987, 1384);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "API Tester";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tcCommand.ResumeLayout(false);
            this.tpResponse.ResumeLayout(false);
            this.tpResponse.PerformLayout();
            this.pnlImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rtbResults)).EndInit();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.tpCommandConfig.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbResult)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbRaw)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbLog)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSequenceResults)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.toolStrip7.ResumeLayout(false);
            this.toolStrip7.PerformLayout();
            this.toolStrip6.ResumeLayout(false);
            this.toolStrip6.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.tabControl3.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChange)).EndInit();
            this.gbSamplePayloads.ResumeLayout(false);
            this.gbSamplePayloads.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbSamplePayload)).EndInit();
            this.toolStrip12.ResumeLayout(false);
            this.toolStrip12.PerformLayout();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbIncomingPayload)).EndInit();
            this.tabPage15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.groupBox19.ResumeLayout(false);
            this.groupBox20.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.gbEndpoints.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            this.toolStrip10.ResumeLayout(false);
            this.toolStrip10.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.toolStrip9.ResumeLayout(false);
            this.toolStrip9.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fcrtxtbLogView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbStackTrace)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.tabControl4.ResumeLayout(false);
            this.tabPage11.ResumeLayout(false);
            this.tabPage12.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.toolStrip11.ResumeLayout(false);
            this.toolStrip11.PerformLayout();
            this.toolStrip8.ResumeLayout(false);
            this.toolStrip8.PerformLayout();
            this.tabPage14.ResumeLayout(false);
            this.tabPage14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbSQLCommand)).EndInit();
            this.toolStrip14.ResumeLayout(false);
            this.toolStrip14.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiEnvironment;
        private System.Windows.Forms.ToolStripMenuItem tsmiLocal;
        private System.Windows.Forms.ToolStripButton tsbtnGetToken;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnConfigureCommands;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblEnvironment;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private FastColoredTextBoxNS.FastColoredTextBox rtbResults;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslblResultCode;
        private System.Windows.Forms.ToolStripStatusLabel tsslblMessage;
        private System.Windows.Forms.ToolStripStatusLabel tsslblExecuting;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tstxtbFolder;
        private System.Windows.Forms.ToolStripButton tsbtnSelectGolder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ListBox lbxFiles;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtbURL;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbtnPut;
        private System.Windows.Forms.RadioButton rbtnPost;
        private FastColoredTextBoxNS.FastColoredTextBox fctxtbRaw;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox tscmbxAPi;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnExecute;
        private FastColoredTextBoxNS.FastColoredTextBox fctxtbResult;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ToolStripButton tsbtnQueryData;
        private System.Windows.Forms.RadioButton rbtnGet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnZoomIn;
        private System.Windows.Forms.ToolStripButton tsbtnZoomOut;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TreeView tvCommands;
        private System.Windows.Forms.TabControl tcCommand;
        private System.Windows.Forms.TabPage tpResponse;
        private System.Windows.Forms.TabPage tpCommandConfig;
        private Dialog.CommandEditorControl commandEditorControl1;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbtnRun;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel tslblCommandName;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripComboBox tscmbxVerbs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripTextBox tstxtbURL;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tsbtnSaveCommand;
        private System.Windows.Forms.ToolStripMenuItem cloneSelectedCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel tslblDownloadFolder;
        private System.Windows.Forms.ToolStripButton tsbtnGetDownloadFolder;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton tsbtnViewFile;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripLabel tslblFileName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripLabel toolStripLabel7;
        private System.Windows.Forms.ToolStripTextBox tstxtbTPA;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton tsbtnViewAsImage;
        private System.Windows.Forms.Panel pnlImage;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtbTBC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbTestDuration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbNumCalls;
        private System.Windows.Forms.RadioButton rbtnTime;
        private System.Windows.Forms.RadioButton rbtnNumberOfCalls;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtbTestURL;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripButton tsbtnStartTest;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label lblActiveTasks;
        private System.Windows.Forms.Label lblNumCallsMade;
        private System.Windows.Forms.Label lblDudation;
        private System.Windows.Forms.Label lblErrors;
        private System.Windows.Forms.Label lblMaxTasks;
        private System.Windows.Forms.GroupBox groupBox9;
        private FastColoredTextBoxNS.FastColoredTextBox fctxtbLog;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ListBox lbxSequence;
        private System.Windows.Forms.ToolStrip toolStrip7;
        private System.Windows.Forms.ToolStrip toolStrip6;
        private System.Windows.Forms.ToolStripButton tsbtnSequenceZoomIn;
        private Dialog.CommandEditorControl commandEditorControl2;
        private System.Windows.Forms.ToolStripButton tsbtnAddStep;
        private System.Windows.Forms.ToolStripButton tsbtnDeleteStep;
        private System.Windows.Forms.ToolStripButton tsbtnSequenceZoomOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton tsbtnStartSequence;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton tsbtnSequenceSave;
        private System.Windows.Forms.ToolStripLabel toolStripLabel8;
        private System.Windows.Forms.ToolStripComboBox tscmbxSequences;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton tsbtnAddSequence;
        private System.Windows.Forms.ToolStripButton tsbtnDeleteSequence;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView dgvSequenceResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ToolStripButton tsbtnUserCredentials;
        private System.Windows.Forms.ToolStripStatusLabel tsslblUser;
        private System.Windows.Forms.ToolStripStatusLabel tsslblUserId;
        private System.Windows.Forms.TabPage tabPage7;
        private FastColoredTextBoxNS.FastColoredTextBox fcrtxtbLogView;
        private System.Windows.Forms.Splitter splitter6;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Splitter splitter5;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.ToolStrip toolStrip8;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.ListBox lbxLogEntries;
        private System.Windows.Forms.Splitter splitter7;
        private FastColoredTextBoxNS.FastColoredTextBox fctxtbStackTrace;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.GroupBox gbEndpoints;
        private System.Windows.Forms.RadioButton rbtnDeleteDocument;
        private System.Windows.Forms.RadioButton rbtnCreatePayments;
        private System.Windows.Forms.RadioButton rbtnUpdateClaim;
        private System.Windows.Forms.RadioButton rbtnAttachDocument;
        private System.Windows.Forms.RadioButton rbtnCreateInspectionRequest;
        private System.Windows.Forms.RadioButton rbtnCreateClaim;
        private System.Windows.Forms.RadioButton rbtnGetCreditCard;
        private System.Windows.Forms.RadioButton rbtnGetInspectionHistory;
        private System.Windows.Forms.RadioButton rbtnGetInspectionRequests;
        private System.Windows.Forms.RadioButton rbtnGetInspectionPartners;
        private System.Windows.Forms.RadioButton rbtnGetClaimPayees;
        private System.Windows.Forms.RadioButton rbtnGetClaimDocuments;
        private System.Windows.Forms.RadioButton rbtnGetDocument;
        private System.Windows.Forms.RadioButton rbtnGetSingleClaim;
        private System.Windows.Forms.RadioButton rbtnGetAllClaims;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.TextBox txtbUserSecret;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.TextBox txtbUserId;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.TextBox txtbBaseURL;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TabPage tabPage10;
        private FastColoredTextBoxNS.FastColoredTextBox fctxtbIncomingPayload;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.TextBox txtbIncommingPayloadSize;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.TextBox txtbOutgoingPayloadSize;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.TextBox txtbAverageDuration;
        private System.Windows.Forms.ToolStrip toolStrip9;
        private System.Windows.Forms.ToolStripButton tsbtnSavePerformnceCommands;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripButton tsbtnRunPerformanceCommand;
        private System.Windows.Forms.ComboBox cmbxTPA;
        private System.Windows.Forms.ToolStrip toolStrip10;
        private System.Windows.Forms.ToolStripButton tsbtnAddTPA;
        private Dialog.CommandEditorControl cePerformance;
        private System.Windows.Forms.RadioButton rbtnGetOutgoingDocument;
        private MigraDoc.Rendering.Forms.DocumentPreview documentPreview1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel9;
        private System.Windows.Forms.ToolStripTextBox tstxtbNumberOfIterations;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripButton tsbtnOpenLogFile;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tsslblToken;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.TextBox txtbLoginURL;
        private System.Windows.Forms.ToolStripButton tsbtnFilterLog;
        private System.Windows.Forms.ToolStripLabel tslblMinDate;
        private System.Windows.Forms.TreeView tvLogFiles;
        private System.Windows.Forms.ToolStripStatusLabel tsslblProgress;
        private System.Windows.Forms.ToolStripProgressBar tspbProgress;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblAverageDuration;
        private System.Windows.Forms.ToolStripLabel toolStripLabel10;
        private System.Windows.Forms.ToolStripComboBox tscmbxTPA;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripButton tsbtnAddPerformanceTest;
        private System.Windows.Forms.ToolStripLabel toolStripLabel11;
        private System.Windows.Forms.ToolStripComboBox tscmbxCommand;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripButton tsbtnSaveLoadTests;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ToolStripButton tsbtnEditLoadTests;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtbEndLoad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbStartLoad;
        private System.Windows.Forms.TextBox txtbLoadIncrement;
        private System.Windows.Forms.RadioButton rbtnMultipleLoads;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.TreeView tvPerformance;
        private System.Windows.Forms.ToolStrip toolStrip11;
        private System.Windows.Forms.ToolStripLabel toolStripLabel12;
        private System.Windows.Forms.ToolStripButton tsbtnLoadNextPage;
        private System.Windows.Forms.ToolStripButton tsbtnLoadPreviousPage;
        private System.Windows.Forms.ToolStripLabel toolStripLabel14;
        private System.Windows.Forms.ToolStripTextBox tstxtbPageSize;
        private System.Windows.Forms.TabPage tabPage13;
        private System.Windows.Forms.DataGridView dgvChange;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.CheckBox rbtnChangePayload;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.GroupBox gbSamplePayloads;
        private FastColoredTextBoxNS.FastColoredTextBox fctxtbSamplePayload;
        private System.Windows.Forms.ToolStrip toolStrip12;
        private System.Windows.Forms.ToolStripButton tsbtnNextPayload;
        private System.Windows.Forms.TabPage tabPage14;
        private FastColoredTextBoxNS.FastColoredTextBox fctxtbSQLCommand;
        private System.Windows.Forms.ToolStrip toolStrip14;
        private System.Windows.Forms.ToolStripButton tsbtnRunSQLCommand;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.RadioButton rbtnDeleteClaim;
        private System.Windows.Forms.TabPage tabPage15;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.ToolStripButton tsbtnOpenLogViewer;
    }
}

