namespace EnableBase64
{
    partial class EnableBase64Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnableBase64Form));
            this.lblInputFile = new System.Windows.Forms.Label();
            this.txtbInputFile = new System.Windows.Forms.TextBox();
            this.btnOpenInputFile = new System.Windows.Forms.Button();
            this.lblOutputFile = new System.Windows.Forms.Label();
            this.txtbOutputFile = new System.Windows.Forms.TextBox();
            this.btnOpenOutputFile = new System.Windows.Forms.Button();
            this.btnEncode = new System.Windows.Forms.Button();
            this.lblEncoded = new System.Windows.Forms.Label();
            this.txtbEnableBase64File = new System.Windows.Forms.TextBox();
            this.prgbEncoding = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblInputFile
            // 
            this.lblInputFile.AutoSize = true;
            this.lblInputFile.Location = new System.Drawing.Point(8, 22);
            this.lblInputFile.Name = "lblInputFile";
            this.lblInputFile.Size = new System.Drawing.Size(23, 13);
            this.lblInputFile.TabIndex = 0;
            this.lblInputFile.Text = "Input File";
            // 
            // txtbInputFile
            // 
            this.txtbInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbInputFile.Location = new System.Drawing.Point(8, 38);
            this.txtbInputFile.Name = "txtbInputFile";
            this.txtbInputFile.Size = new System.Drawing.Size(578, 20);
            this.txtbInputFile.TabIndex = 1;
            // 
            // btnOpenInputFile
            // 
            this.btnOpenInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenInputFile.Location = new System.Drawing.Point(595, 37);
            this.btnOpenInputFile.Name = "btnOpenInputFile";
            this.btnOpenInputFile.Size = new System.Drawing.Size(56, 23);
            this.btnOpenInputFile.TabIndex = 2;
            this.btnOpenInputFile.Text = "Select";
            this.btnOpenInputFile.UseVisualStyleBackColor = true;
            this.btnOpenInputFile.Click += new System.EventHandler(this.BtnOpenInputFile_Click);
            // 
            // lblOutputFile
            // 
            this.lblOutputFile.AutoSize = true;
            this.lblOutputFile.Location = new System.Drawing.Point(8, 64);
            this.lblOutputFile.Name = "lblOutputFile";
            this.lblOutputFile.Size = new System.Drawing.Size(23, 13);
            this.lblOutputFile.TabIndex = 3;
            this.lblOutputFile.Text = "Output File";
            // 
            // txtbOutputFile
            // 
            this.txtbOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbOutputFile.Location = new System.Drawing.Point(8, 80);
            this.txtbOutputFile.Name = "txtbOutputFile";
            this.txtbOutputFile.Size = new System.Drawing.Size(578, 20);
            this.txtbOutputFile.TabIndex = 4;
            // 
            // btnOpenOutputFile
            // 
            this.btnOpenOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenOutputFile.Location = new System.Drawing.Point(595, 79);
            this.btnOpenOutputFile.Name = "btnOpenOutputFile";
            this.btnOpenOutputFile.Size = new System.Drawing.Size(56, 23);
            this.btnOpenOutputFile.TabIndex = 5;
            this.btnOpenOutputFile.Text = "Select";
            this.btnOpenOutputFile.UseVisualStyleBackColor = true;
            this.btnOpenOutputFile.Click += new System.EventHandler(this.BtnOpenOutputFile_Click);
            // 
            // btnEncode
            // 
            this.btnEncode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEncode.Location = new System.Drawing.Point(595, 123);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(56, 23);
            this.btnEncode.TabIndex = 5;
            this.btnEncode.Text = "Encode";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.BtnEncode_Click);
            // 
            // lblEncoded
            // 
            this.lblEncoded.AutoSize = true;
            this.lblEncoded.Location = new System.Drawing.Point(8, 135);
            this.lblEncoded.Name = "lblEncoded";
            this.lblEncoded.Size = new System.Drawing.Size(90, 13);
            this.lblEncoded.TabIndex = 6;
            this.lblEncoded.Text = "Encoded Content Previewer";
            // 
            // txtbEnableBase64File
            // 
            this.txtbEnableBase64File.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbEnableBase64File.Location = new System.Drawing.Point(8, 150);
            this.txtbEnableBase64File.Multiline = true;
            this.txtbEnableBase64File.ReadOnly = true;
            this.txtbEnableBase64File.Name = "txtbEnableBase64File";
            this.txtbEnableBase64File.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbEnableBase64File.Size = new System.Drawing.Size(642, 243);
            this.txtbEnableBase64File.TabIndex = 7;

            //
            // prgbEncoding
            //
            this.prgbEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgbEncoding.Location = new System.Drawing.Point(8, 398);
            this.prgbEncoding.Size = new System.Drawing.Size(642, 20);
            // 
            // EnableBase64Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 425);
            this.Controls.Add(this.lblInputFile);
            this.Controls.Add(this.txtbInputFile);
            this.Controls.Add(this.btnOpenInputFile);
            this.Controls.Add(this.lblOutputFile);
            this.Controls.Add(this.txtbOutputFile);
            this.Controls.Add(this.btnOpenOutputFile);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.lblEncoded);
            this.Controls.Add(this.txtbEnableBase64File);
            this.Controls.Add(this.prgbEncoding);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EnableBase64Form";
            this.Text = "Encode file to Base64";
            this.Load += new System.EventHandler(this.EnableBase64Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblInputFile;
        private System.Windows.Forms.TextBox txtbInputFile;
        private System.Windows.Forms.Button btnOpenInputFile;
        private System.Windows.Forms.Label lblOutputFile;
        private System.Windows.Forms.TextBox txtbOutputFile;
        private System.Windows.Forms.Button btnOpenOutputFile;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.Label lblEncoded;
        private System.Windows.Forms.TextBox txtbEnableBase64File;
        private System.Windows.Forms.ProgressBar prgbEncoding;
    }
}