
namespace APITester.Dialog.Controls
{
    partial class SCSFIleUpload
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCSFIleUpload));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtbNote = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtbUserId = new System.Windows.Forms.TextBox();
            this.fctxtbJson = new FastColoredTextBoxNS.FastColoredTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.gbPreview = new System.Windows.Forms.GroupBox();
            this.pnlImage = new System.Windows.Forms.Panel();
            this.fctxtbTextPreview = new FastColoredTextBoxNS.FastColoredTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbJson)).BeginInit();
            this.gbPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbTextPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1499, 185);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attachment";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtbNote);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 106);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1493, 76);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Note";
            // 
            // txtbNote
            // 
            this.txtbNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbNote.Location = new System.Drawing.Point(3, 16);
            this.txtbNote.Multiline = true;
            this.txtbNote.Name = "txtbNote";
            this.txtbNote.Size = new System.Drawing.Size(1487, 57);
            this.txtbNote.TabIndex = 0;
            this.txtbNote.Leave += new System.EventHandler(this.txtbNote_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblFileName);
            this.groupBox3.Controls.Add(this.btnSelectFile);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 58);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1493, 48);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "File";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(87, 24);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(0, 13);
            this.lblFileName.TabIndex = 1;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(6, 19);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtbUserId);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1493, 42);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Id";
            // 
            // txtbUserId
            // 
            this.txtbUserId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbUserId.Location = new System.Drawing.Point(3, 16);
            this.txtbUserId.Name = "txtbUserId";
            this.txtbUserId.Size = new System.Drawing.Size(1487, 20);
            this.txtbUserId.TabIndex = 0;
            this.txtbUserId.Leave += new System.EventHandler(this.txtbUserId_Leave);
            // 
            // fctxtbJson
            // 
            this.fctxtbJson.AutoCompleteBracketsList = new char[] {
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
            this.fctxtbJson.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:" +
    "]*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.fctxtbJson.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.fctxtbJson.BackBrush = null;
            this.fctxtbJson.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fctxtbJson.CharHeight = 14;
            this.fctxtbJson.CharWidth = 8;
            this.fctxtbJson.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctxtbJson.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctxtbJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctxtbJson.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctxtbJson.IsReplaceMode = false;
            this.fctxtbJson.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fctxtbJson.LeftBracket = '(';
            this.fctxtbJson.LeftBracket2 = '{';
            this.fctxtbJson.Location = new System.Drawing.Point(621, 185);
            this.fctxtbJson.Margin = new System.Windows.Forms.Padding(2);
            this.fctxtbJson.Name = "fctxtbJson";
            this.fctxtbJson.Paddings = new System.Windows.Forms.Padding(0);
            this.fctxtbJson.ReadOnly = true;
            this.fctxtbJson.RightBracket = ')';
            this.fctxtbJson.RightBracket2 = '}';
            this.fctxtbJson.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctxtbJson.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctxtbJson.ServiceColors")));
            this.fctxtbJson.Size = new System.Drawing.Size(878, 635);
            this.fctxtbJson.TabIndex = 1;
            this.fctxtbJson.Zoom = 100;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(618, 185);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 635);
            this.splitter1.TabIndex = 11;
            this.splitter1.TabStop = false;
            // 
            // gbPreview
            // 
            this.gbPreview.Controls.Add(this.fctxtbTextPreview);
            this.gbPreview.Controls.Add(this.pnlImage);
            this.gbPreview.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbPreview.Location = new System.Drawing.Point(0, 185);
            this.gbPreview.Name = "gbPreview";
            this.gbPreview.Size = new System.Drawing.Size(618, 635);
            this.gbPreview.TabIndex = 13;
            this.gbPreview.TabStop = false;
            this.gbPreview.Text = "Content Preview";
            // 
            // pnlImage
            // 
            this.pnlImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImage.Location = new System.Drawing.Point(3, 16);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(612, 616);
            this.pnlImage.TabIndex = 11;
            this.pnlImage.Visible = false;
            // 
            // fctxtbTextPreview
            // 
            this.fctxtbTextPreview.AutoCompleteBracketsList = new char[] {
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
            this.fctxtbTextPreview.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:" +
    "]*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.fctxtbTextPreview.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.fctxtbTextPreview.BackBrush = null;
            this.fctxtbTextPreview.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fctxtbTextPreview.CharHeight = 14;
            this.fctxtbTextPreview.CharWidth = 8;
            this.fctxtbTextPreview.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctxtbTextPreview.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctxtbTextPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctxtbTextPreview.IsReplaceMode = false;
            this.fctxtbTextPreview.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fctxtbTextPreview.LeftBracket = '(';
            this.fctxtbTextPreview.LeftBracket2 = '{';
            this.fctxtbTextPreview.Location = new System.Drawing.Point(3, 16);
            this.fctxtbTextPreview.Margin = new System.Windows.Forms.Padding(2);
            this.fctxtbTextPreview.Name = "fctxtbTextPreview";
            this.fctxtbTextPreview.Paddings = new System.Windows.Forms.Padding(0);
            this.fctxtbTextPreview.ReadOnly = true;
            this.fctxtbTextPreview.RightBracket = ')';
            this.fctxtbTextPreview.RightBracket2 = '}';
            this.fctxtbTextPreview.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctxtbTextPreview.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctxtbTextPreview.ServiceColors")));
            this.fctxtbTextPreview.Size = new System.Drawing.Size(612, 616);
            this.fctxtbTextPreview.TabIndex = 13;
            this.fctxtbTextPreview.Visible = false;
            this.fctxtbTextPreview.Zoom = 100;
            // 
            // SCSFIleUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fctxtbJson);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.gbPreview);
            this.Controls.Add(this.groupBox1);
            this.Name = "SCSFIleUpload";
            this.Size = new System.Drawing.Size(1499, 820);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbJson)).EndInit();
            this.gbPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbTextPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtbNote;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtbUserId;
        private FastColoredTextBoxNS.FastColoredTextBox fctxtbJson;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox gbPreview;
        private FastColoredTextBoxNS.FastColoredTextBox fctxtbTextPreview;
        private System.Windows.Forms.Panel pnlImage;
    }
}
