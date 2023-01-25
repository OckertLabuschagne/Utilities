namespace APITester.Dialog
{
    partial class CommandEditorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandEditorControl));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtbURL = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtnSCSFileUpload = new System.Windows.Forms.RadioButton();
            this.rbtnRaw = new System.Windows.Forms.RadioButton();
            this.rbtnForm = new System.Windows.Forms.RadioButton();
            this.rbtnParameters = new System.Windows.Forms.RadioButton();
            this.dgvInput = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fctxtbRaw = new FastColoredTextBoxNS.FastColoredTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbtnPatch = new System.Windows.Forms.RadioButton();
            this.rbtnPut = new System.Windows.Forms.RadioButton();
            this.rbtnPost = new System.Windows.Forms.RadioButton();
            this.rbtnGet = new System.Windows.Forms.RadioButton();
            this.scsfIleUpload1 = new APITester.Dialog.Controls.SCSFIleUpload();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbRaw)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1181, 36);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Name";
            // 
            // txtbName
            // 
            this.txtbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbName.Location = new System.Drawing.Point(2, 15);
            this.txtbName.Margin = new System.Windows.Forms.Padding(2);
            this.txtbName.Name = "txtbName";
            this.txtbName.Size = new System.Drawing.Size(1177, 20);
            this.txtbName.TabIndex = 0;
            this.txtbName.TextChanged += new System.EventHandler(this.txtbName_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtbURL);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 36);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(1181, 36);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "URL";
            // 
            // txtbURL
            // 
            this.txtbURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbURL.Location = new System.Drawing.Point(2, 15);
            this.txtbURL.Margin = new System.Windows.Forms.Padding(2);
            this.txtbURL.Name = "txtbURL";
            this.txtbURL.Size = new System.Drawing.Size(1177, 20);
            this.txtbURL.TabIndex = 0;
            this.txtbURL.TextChanged += new System.EventHandler(this.txtbURL_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtnSCSFileUpload);
            this.groupBox3.Controls.Add(this.rbtnRaw);
            this.groupBox3.Controls.Add(this.rbtnForm);
            this.groupBox3.Controls.Add(this.rbtnParameters);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 108);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(1181, 36);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Body";
            // 
            // rbtnSCSFileUpload
            // 
            this.rbtnSCSFileUpload.AutoSize = true;
            this.rbtnSCSFileUpload.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnSCSFileUpload.Location = new System.Drawing.Point(234, 15);
            this.rbtnSCSFileUpload.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnSCSFileUpload.Name = "rbtnSCSFileUpload";
            this.rbtnSCSFileUpload.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.rbtnSCSFileUpload.Size = new System.Drawing.Size(135, 19);
            this.rbtnSCSFileUpload.TabIndex = 3;
            this.rbtnSCSFileUpload.Text = "SCS File Upload (json)";
            this.rbtnSCSFileUpload.UseVisualStyleBackColor = true;
            this.rbtnSCSFileUpload.CheckedChanged += new System.EventHandler(this.rbtnBody_CheckedChanged);
            // 
            // rbtnRaw
            // 
            this.rbtnRaw.AutoSize = true;
            this.rbtnRaw.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnRaw.Location = new System.Drawing.Point(154, 15);
            this.rbtnRaw.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnRaw.Name = "rbtnRaw";
            this.rbtnRaw.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.rbtnRaw.Size = new System.Drawing.Size(80, 19);
            this.rbtnRaw.TabIndex = 2;
            this.rbtnRaw.Text = "Raw (json)";
            this.rbtnRaw.UseVisualStyleBackColor = true;
            this.rbtnRaw.CheckedChanged += new System.EventHandler(this.rbtnBody_CheckedChanged);
            // 
            // rbtnForm
            // 
            this.rbtnForm.AutoSize = true;
            this.rbtnForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnForm.Location = new System.Drawing.Point(101, 15);
            this.rbtnForm.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnForm.Name = "rbtnForm";
            this.rbtnForm.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.rbtnForm.Size = new System.Drawing.Size(53, 19);
            this.rbtnForm.TabIndex = 1;
            this.rbtnForm.Text = "Form";
            this.rbtnForm.UseVisualStyleBackColor = true;
            this.rbtnForm.CheckedChanged += new System.EventHandler(this.rbtnBody_CheckedChanged);
            // 
            // rbtnParameters
            // 
            this.rbtnParameters.AutoSize = true;
            this.rbtnParameters.Checked = true;
            this.rbtnParameters.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnParameters.Location = new System.Drawing.Point(2, 15);
            this.rbtnParameters.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnParameters.Name = "rbtnParameters";
            this.rbtnParameters.Padding = new System.Windows.Forms.Padding(16, 0, 5, 0);
            this.rbtnParameters.Size = new System.Drawing.Size(99, 19);
            this.rbtnParameters.TabIndex = 0;
            this.rbtnParameters.TabStop = true;
            this.rbtnParameters.Text = "Parameters";
            this.rbtnParameters.UseVisualStyleBackColor = true;
            this.rbtnParameters.CheckedChanged += new System.EventHandler(this.rbtnBody_CheckedChanged);
            // 
            // dgvInput
            // 
            this.dgvInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInput.Location = new System.Drawing.Point(0, 144);
            this.dgvInput.Margin = new System.Windows.Forms.Padding(2);
            this.dgvInput.Name = "dgvInput";
            this.dgvInput.RowHeadersWidth = 72;
            this.dgvInput.RowTemplate.Height = 31;
            this.dgvInput.Size = new System.Drawing.Size(1181, 684);
            this.dgvInput.TabIndex = 4;
            this.dgvInput.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInput_CellEndEdit);
            this.dgvInput.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInput_RowEnter);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Key";
            this.Column1.MinimumWidth = 9;
            this.Column1.Name = "Column1";
            this.Column1.Width = 175;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Value";
            this.Column2.MinimumWidth = 9;
            this.Column2.Name = "Column2";
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
            this.fctxtbRaw.Location = new System.Drawing.Point(0, 144);
            this.fctxtbRaw.Margin = new System.Windows.Forms.Padding(2);
            this.fctxtbRaw.Name = "fctxtbRaw";
            this.fctxtbRaw.Paddings = new System.Windows.Forms.Padding(0);
            this.fctxtbRaw.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctxtbRaw.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctxtbRaw.ServiceColors")));
            this.fctxtbRaw.Size = new System.Drawing.Size(1181, 684);
            this.fctxtbRaw.TabIndex = 5;
            this.fctxtbRaw.Visible = false;
            this.fctxtbRaw.Zoom = 100;
            this.fctxtbRaw.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.rtbRaw_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbtnPatch);
            this.groupBox5.Controls.Add(this.rbtnPut);
            this.groupBox5.Controls.Add(this.rbtnPost);
            this.groupBox5.Controls.Add(this.rbtnGet);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 72);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(1181, 36);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Action";
            // 
            // rbtnPatch
            // 
            this.rbtnPatch.AutoSize = true;
            this.rbtnPatch.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnPatch.Location = new System.Drawing.Point(180, 15);
            this.rbtnPatch.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnPatch.Name = "rbtnPatch";
            this.rbtnPatch.Padding = new System.Windows.Forms.Padding(0, 0, 11, 0);
            this.rbtnPatch.Size = new System.Drawing.Size(64, 19);
            this.rbtnPatch.TabIndex = 3;
            this.rbtnPatch.Text = "Patch";
            this.rbtnPatch.UseVisualStyleBackColor = true;
            // 
            // rbtnPut
            // 
            this.rbtnPut.AutoSize = true;
            this.rbtnPut.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnPut.Location = new System.Drawing.Point(128, 15);
            this.rbtnPut.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnPut.Name = "rbtnPut";
            this.rbtnPut.Padding = new System.Windows.Forms.Padding(0, 0, 11, 0);
            this.rbtnPut.Size = new System.Drawing.Size(52, 19);
            this.rbtnPut.TabIndex = 2;
            this.rbtnPut.Text = "Put";
            this.rbtnPut.UseVisualStyleBackColor = true;
            this.rbtnPut.CheckedChanged += new System.EventHandler(this.rbtnAction_CheckedChanged);
            // 
            // rbtnPost
            // 
            this.rbtnPost.AutoSize = true;
            this.rbtnPost.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnPost.Location = new System.Drawing.Point(71, 15);
            this.rbtnPost.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnPost.Name = "rbtnPost";
            this.rbtnPost.Padding = new System.Windows.Forms.Padding(0, 0, 11, 0);
            this.rbtnPost.Size = new System.Drawing.Size(57, 19);
            this.rbtnPost.TabIndex = 1;
            this.rbtnPost.Text = "Post";
            this.rbtnPost.UseVisualStyleBackColor = true;
            this.rbtnPost.CheckedChanged += new System.EventHandler(this.rbtnAction_CheckedChanged);
            // 
            // rbtnGet
            // 
            this.rbtnGet.AutoSize = true;
            this.rbtnGet.Checked = true;
            this.rbtnGet.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbtnGet.Location = new System.Drawing.Point(2, 15);
            this.rbtnGet.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnGet.Name = "rbtnGet";
            this.rbtnGet.Padding = new System.Windows.Forms.Padding(16, 0, 11, 0);
            this.rbtnGet.Size = new System.Drawing.Size(69, 19);
            this.rbtnGet.TabIndex = 0;
            this.rbtnGet.TabStop = true;
            this.rbtnGet.Text = "Get";
            this.rbtnGet.UseVisualStyleBackColor = true;
            this.rbtnGet.CheckedChanged += new System.EventHandler(this.rbtnAction_CheckedChanged);
            // 
            // scsfIleUpload1
            // 
            this.scsfIleUpload1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scsfIleUpload1.FilePath = "";
            this.scsfIleUpload1.Json = "{\r\n  \"FileName\": null,\r\n  \"FileContent\": null,\r\n  \"UserId\": \"\",\r\n  \"Notes\": \"\"\r\n}" +
    "";
            this.scsfIleUpload1.Location = new System.Drawing.Point(0, 144);
            this.scsfIleUpload1.Name = "scsfIleUpload1";
            this.scsfIleUpload1.Note = "";
            this.scsfIleUpload1.Size = new System.Drawing.Size(1181, 684);
            this.scsfIleUpload1.TabIndex = 8;
            this.scsfIleUpload1.UserId = "";
            this.scsfIleUpload1.Visible = false;
            this.scsfIleUpload1.PropertyChanged += new System.EventHandler(this.scsfIleUpload1_PropertyChanged);
            // 
            // CommandEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scsfIleUpload1);
            this.Controls.Add(this.dgvInput);
            this.Controls.Add(this.fctxtbRaw);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CommandEditorControl";
            this.Size = new System.Drawing.Size(1181, 828);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtbRaw)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtbName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtbURL;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtnRaw;
        private System.Windows.Forms.RadioButton rbtnForm;
        private System.Windows.Forms.RadioButton rbtnParameters;
        private System.Windows.Forms.DataGridView dgvInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private FastColoredTextBoxNS.FastColoredTextBox fctxtbRaw;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbtnPut;
        private System.Windows.Forms.RadioButton rbtnPost;
        private System.Windows.Forms.RadioButton rbtnGet;
        private System.Windows.Forms.RadioButton rbtnPatch;
        private System.Windows.Forms.RadioButton rbtnSCSFileUpload;
        private Controls.SCSFIleUpload scsfIleUpload1;
    }
}