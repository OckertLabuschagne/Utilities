
namespace APITester.Dialog
{
    partial class DatabaseActions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseActions));
            this.fctxtbSQLCommand = new FastColoredTextBoxNS.FastColoredTextBox();
            this.toolStrip14 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tslblDatabase = new System.Windows.Forms.ToolStripLabel();
            this.tsbtnChangeConnection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRunSQLCommand = new System.Windows.Forms.ToolStripButton();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.rbtnDeleteClaim = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbSQLCommand)).BeginInit();
            this.toolStrip14.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.fctxtbSQLCommand.AutoScrollMinSize = new System.Drawing.Size(27, 14);
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
            this.fctxtbSQLCommand.Location = new System.Drawing.Point(380, 39);
            this.fctxtbSQLCommand.Margin = new System.Windows.Forms.Padding(2);
            this.fctxtbSQLCommand.Name = "fctxtbSQLCommand";
            this.fctxtbSQLCommand.Paddings = new System.Windows.Forms.Padding(0);
            this.fctxtbSQLCommand.RightBracket = ')';
            this.fctxtbSQLCommand.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctxtbSQLCommand.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctxtbSQLCommand.ServiceColors")));
            this.fctxtbSQLCommand.Size = new System.Drawing.Size(1125, 1059);
            this.fctxtbSQLCommand.TabIndex = 19;
            this.fctxtbSQLCommand.Zoom = 100;
            // 
            // toolStrip14
            // 
            this.toolStrip14.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip14.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tslblDatabase,
            this.tsbtnChangeConnection,
            this.toolStripSeparator1,
            this.tsbtnRunSQLCommand});
            this.toolStrip14.Location = new System.Drawing.Point(0, 0);
            this.toolStrip14.Name = "toolStrip14";
            this.toolStrip14.Size = new System.Drawing.Size(1505, 39);
            this.toolStrip14.TabIndex = 20;
            this.toolStrip14.Text = "toolStrip14";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(58, 36);
            this.toolStripLabel1.Text = "Database:";
            // 
            // tslblDatabase
            // 
            this.tslblDatabase.AutoSize = false;
            this.tslblDatabase.Name = "tslblDatabase";
            this.tslblDatabase.Size = new System.Drawing.Size(300, 36);
            this.tslblDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsbtnChangeConnection
            // 
            this.tsbtnChangeConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnChangeConnection.Image = global::APITester.Properties.Resources.DatabaseConnectio_32n;
            this.tsbtnChangeConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnChangeConnection.Name = "tsbtnChangeConnection";
            this.tsbtnChangeConnection.Size = new System.Drawing.Size(36, 36);
            this.tsbtnChangeConnection.Text = "Change connection";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
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
            this.groupBox13.Controls.Add(this.groupBox2);
            this.groupBox13.Controls.Add(this.groupBox1);
            this.groupBox13.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox13.Location = new System.Drawing.Point(0, 39);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(380, 1059);
            this.groupBox13.TabIndex = 18;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Commands";
            // 
            // rbtnDeleteClaim
            // 
            this.rbtnDeleteClaim.Location = new System.Drawing.Point(15, 18);
            this.rbtnDeleteClaim.Name = "rbtnDeleteClaim";
            this.rbtnDeleteClaim.Size = new System.Drawing.Size(302, 24);
            this.rbtnDeleteClaim.TabIndex = 0;
            this.rbtnDeleteClaim.TabStop = true;
            this.rbtnDeleteClaim.Text = "Delete CLaim";
            this.rbtnDeleteClaim.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnDeleteClaim);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 199);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Predefined";
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 215);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(374, 841);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User defined";
            // 
            // DatabaseActions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1505, 1098);
            this.Controls.Add(this.fctxtbSQLCommand);
            this.Controls.Add(this.groupBox13);
            this.Controls.Add(this.toolStrip14);
            this.Name = "DatabaseActions";
            this.Text = "Database Actions";
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbSQLCommand)).EndInit();
            this.toolStrip14.ResumeLayout(false);
            this.toolStrip14.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox fctxtbSQLCommand;
        private System.Windows.Forms.ToolStrip toolStrip14;
        private System.Windows.Forms.ToolStripButton tsbtnRunSQLCommand;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.RadioButton rbtnDeleteClaim;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel tslblDatabase;
        private System.Windows.Forms.ToolStripButton tsbtnChangeConnection;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}