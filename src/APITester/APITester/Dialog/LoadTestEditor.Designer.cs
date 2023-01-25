
namespace APITester.Dialog
{
    partial class LoadTestEditor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tsbtnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.commandEditorControl1 = new APITester.Dialog.CommandEditorControl();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.txtbLoginURL = new System.Windows.Forms.TextBox();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.txtbUserSecret = new System.Windows.Forms.TextBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.txtbUserId = new System.Windows.Forms.TextBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.txtbBaseURL = new System.Windows.Forms.TextBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.txtbTPA = new System.Windows.Forms.TextBox();
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
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.lbxCommands = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnAddCommand = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDeleteCommand = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tsbtnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 844);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1591, 32);
            this.panel1.TabIndex = 1;
            // 
            // tsbtnCancel
            // 
            this.tsbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.tsbtnCancel.Location = new System.Drawing.Point(1427, 3);
            this.tsbtnCancel.Name = "tsbtnCancel";
            this.tsbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.tsbtnCancel.TabIndex = 2;
            this.tsbtnCancel.Text = "Cancel";
            this.tsbtnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(1507, 2);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(73, 25);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // commandEditorControl1
            // 
            this.commandEditorControl1.CanGet = true;
            this.commandEditorControl1.CanPatch = true;
            this.commandEditorControl1.CanPost = true;
            this.commandEditorControl1.CanPut = true;
            this.commandEditorControl1.Command = null;
            this.commandEditorControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.commandEditorControl1.Location = new System.Drawing.Point(410, 0);
            this.commandEditorControl1.Margin = new System.Windows.Forms.Padding(2);
            this.commandEditorControl1.Name = "commandEditorControl1";
            this.commandEditorControl1.Size = new System.Drawing.Size(1181, 844);
            this.commandEditorControl1.TabIndex = 2;
            this.commandEditorControl1.NameChanged += new System.EventHandler(this.commandEditorControl1_NameChanged);
            // 
            // groupBox24
            // 
            this.groupBox24.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox24.Controls.Add(this.txtbLoginURL);
            this.groupBox24.Location = new System.Drawing.Point(12, 58);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(346, 40);
            this.groupBox24.TabIndex = 10;
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
            // groupBox18
            // 
            this.groupBox18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox18.Controls.Add(this.txtbUserSecret);
            this.groupBox18.Location = new System.Drawing.Point(12, 150);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(346, 40);
            this.groupBox18.TabIndex = 9;
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
            this.groupBox17.Location = new System.Drawing.Point(12, 104);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(346, 40);
            this.groupBox17.TabIndex = 8;
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
            this.groupBox16.Location = new System.Drawing.Point(78, 12);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(280, 40);
            this.groupBox16.TabIndex = 7;
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
            this.groupBox15.Controls.Add(this.txtbTPA);
            this.groupBox15.Location = new System.Drawing.Point(12, 12);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(60, 40);
            this.groupBox15.TabIndex = 6;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "TPA";
            // 
            // txtbTPA
            // 
            this.txtbTPA.Location = new System.Drawing.Point(6, 16);
            this.txtbTPA.Name = "txtbTPA";
            this.txtbTPA.Size = new System.Drawing.Size(48, 20);
            this.txtbTPA.TabIndex = 0;
            this.txtbTPA.Leave += new System.EventHandler(this.txtbTPA_Leave);
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
            this.groupBox7.Location = new System.Drawing.Point(12, 208);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(361, 143);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Run Parameters";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(222, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "calls/s incr. by:";
            // 
            // txtbEndLoad
            // 
            this.txtbEndLoad.Location = new System.Drawing.Point(191, 71);
            this.txtbEndLoad.Name = "txtbEndLoad";
            this.txtbEndLoad.Size = new System.Drawing.Size(25, 20);
            this.txtbEndLoad.TabIndex = 18;
            this.txtbEndLoad.Text = "20";
            this.txtbEndLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtbEndLoad.Leave += new System.EventHandler(this.txtbEndLoad_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "to";
            // 
            // txtbStartLoad
            // 
            this.txtbStartLoad.Location = new System.Drawing.Point(144, 71);
            this.txtbStartLoad.Name = "txtbStartLoad";
            this.txtbStartLoad.Size = new System.Drawing.Size(19, 20);
            this.txtbStartLoad.TabIndex = 16;
            this.txtbStartLoad.Text = "2";
            this.txtbStartLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtbStartLoad.Leave += new System.EventHandler(this.txtmStartLoad_Leave);
            // 
            // txtbLoadIncrement
            // 
            this.txtbLoadIncrement.Location = new System.Drawing.Point(306, 71);
            this.txtbLoadIncrement.Name = "txtbLoadIncrement";
            this.txtbLoadIncrement.Size = new System.Drawing.Size(19, 20);
            this.txtbLoadIncrement.TabIndex = 15;
            this.txtbLoadIncrement.Text = "2";
            this.txtbLoadIncrement.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtbLoadIncrement.Leave += new System.EventHandler(this.txtbLoadIncrement_Leave);
            // 
            // rbtnMultipleLoads
            // 
            this.rbtnMultipleLoads.AutoSize = true;
            this.rbtnMultipleLoads.Location = new System.Drawing.Point(6, 72);
            this.rbtnMultipleLoads.Name = "rbtnMultipleLoads";
            this.rbtnMultipleLoads.Size = new System.Drawing.Size(89, 17);
            this.rbtnMultipleLoads.TabIndex = 14;
            this.rbtnMultipleLoads.TabStop = true;
            this.rbtnMultipleLoads.Text = "Multiple loads";
            this.rbtnMultipleLoads.UseVisualStyleBackColor = true;
            this.rbtnMultipleLoads.CheckedChanged += new System.EventHandler(this.rbtnNumberOfCalls_CheckedChanged);
            // 
            // txtbTBC
            // 
            this.txtbTBC.Location = new System.Drawing.Point(276, 100);
            this.txtbTBC.Name = "txtbTBC";
            this.txtbTBC.Size = new System.Drawing.Size(49, 20);
            this.txtbTBC.TabIndex = 7;
            this.txtbTBC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtbTBC.Leave += new System.EventHandler(this.txtbTBC_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Time between calls (ms):";
            // 
            // txtbTestDuration
            // 
            this.txtbTestDuration.Location = new System.Drawing.Point(276, 44);
            this.txtbTestDuration.Name = "txtbTestDuration";
            this.txtbTestDuration.Size = new System.Drawing.Size(49, 20);
            this.txtbTestDuration.TabIndex = 5;
            this.txtbTestDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtbTestDuration.Leave += new System.EventHandler(this.txtbTestDuration_Leave);
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
            this.txtbNumCalls.Size = new System.Drawing.Size(49, 20);
            this.txtbNumCalls.TabIndex = 3;
            this.txtbNumCalls.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtbNumCalls.Leave += new System.EventHandler(this.txtbNumCalls_Leave);
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
            this.rbtnTime.CheckedChanged += new System.EventHandler(this.rbtnNumberOfCalls_CheckedChanged);
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
            this.rbtnNumberOfCalls.CheckedChanged += new System.EventHandler(this.rbtnNumberOfCalls_CheckedChanged);
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
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.lbxCommands);
            this.groupBox13.Controls.Add(this.toolStrip1);
            this.groupBox13.Location = new System.Drawing.Point(12, 357);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(358, 482);
            this.groupBox13.TabIndex = 12;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Commands";
            // 
            // lbxCommands
            // 
            this.lbxCommands.DisplayMember = "Name";
            this.lbxCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxCommands.FormattingEnabled = true;
            this.lbxCommands.Location = new System.Drawing.Point(3, 55);
            this.lbxCommands.Name = "lbxCommands";
            this.lbxCommands.Size = new System.Drawing.Size(352, 424);
            this.lbxCommands.TabIndex = 1;
            this.lbxCommands.SelectedIndexChanged += new System.EventHandler(this.lbxCommands_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAddCommand,
            this.tsbtnDeleteCommand});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(352, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnAddCommand
            // 
            this.tsbtnAddCommand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnAddCommand.Image = global::APITester.Properties.Resources.GreenAdd_32;
            this.tsbtnAddCommand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAddCommand.Name = "tsbtnAddCommand";
            this.tsbtnAddCommand.Size = new System.Drawing.Size(36, 36);
            this.tsbtnAddCommand.Text = "toolStripButton1";
            this.tsbtnAddCommand.Click += new System.EventHandler(this.tsbtnAddCommand_Click);
            // 
            // tsbtnDeleteCommand
            // 
            this.tsbtnDeleteCommand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnDeleteCommand.Enabled = false;
            this.tsbtnDeleteCommand.Image = global::APITester.Properties.Resources.RedDelete_32;
            this.tsbtnDeleteCommand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDeleteCommand.Name = "tsbtnDeleteCommand";
            this.tsbtnDeleteCommand.Size = new System.Drawing.Size(36, 36);
            this.tsbtnDeleteCommand.Text = "toolStripButton2";
            this.tsbtnDeleteCommand.Click += new System.EventHandler(this.tsbtnDeleteCommand_Click);
            // 
            // LoadTestEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1591, 876);
            this.Controls.Add(this.groupBox13);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox24);
            this.Controls.Add(this.groupBox18);
            this.Controls.Add(this.groupBox17);
            this.Controls.Add(this.groupBox16);
            this.Controls.Add(this.groupBox15);
            this.Controls.Add(this.commandEditorControl1);
            this.Controls.Add(this.panel1);
            this.Name = "LoadTestEditor";
            this.Text = "LoadTestEditor";
            this.panel1.ResumeLayout(false);
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button tsbtnCancel;
        private System.Windows.Forms.Button btnOK;
        private CommandEditorControl commandEditorControl1;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.TextBox txtbLoginURL;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.TextBox txtbUserSecret;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.TextBox txtbUserId;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.TextBox txtbBaseURL;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.TextBox txtbTPA;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtbTBC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbTestDuration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbNumCalls;
        private System.Windows.Forms.RadioButton rbtnTime;
        private System.Windows.Forms.RadioButton rbtnNumberOfCalls;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.ListBox lbxCommands;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnAddCommand;
        private System.Windows.Forms.ToolStripButton tsbtnDeleteCommand;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtbEndLoad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbStartLoad;
        private System.Windows.Forms.TextBox txtbLoadIncrement;
        private System.Windows.Forms.RadioButton rbtnMultipleLoads;
    }
}