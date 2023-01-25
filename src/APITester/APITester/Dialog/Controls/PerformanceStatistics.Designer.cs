
namespace APITester.Dialog.Controls
{
    partial class PerformanceStatistics
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFastest = new System.Windows.Forms.Label();
            this.lblSlowest = new System.Windows.Forms.Label();
            this.lblAverage = new System.Windows.Forms.Label();
            this.cmbxDetails = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbxMethods = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumberOfItems = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFastest);
            this.groupBox1.Controls.Add(this.lblSlowest);
            this.groupBox1.Controls.Add(this.lblAverage);
            this.groupBox1.Controls.Add(this.cmbxDetails);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbxMethods);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblNumberOfItems);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Level";
            // 
            // lblFastest
            // 
            this.lblFastest.AutoSize = true;
            this.lblFastest.Cursor = System.Windows.Forms.Cursors.Cross;
            this.lblFastest.Location = new System.Drawing.Point(473, 70);
            this.lblFastest.Name = "lblFastest";
            this.lblFastest.Size = new System.Drawing.Size(44, 13);
            this.lblFastest.TabIndex = 7;
            this.lblFastest.Text = "Fastest:";
            this.toolTip1.SetToolTip(this.lblFastest, "Double click to see detail");
            this.lblFastest.DoubleClick += new System.EventHandler(this.lblFastest_DoubleClick);
            // 
            // lblSlowest
            // 
            this.lblSlowest.AutoSize = true;
            this.lblSlowest.Cursor = System.Windows.Forms.Cursors.Cross;
            this.lblSlowest.Location = new System.Drawing.Point(306, 70);
            this.lblSlowest.Name = "lblSlowest";
            this.lblSlowest.Size = new System.Drawing.Size(47, 13);
            this.lblSlowest.TabIndex = 6;
            this.lblSlowest.Text = "Slowest:";
            this.toolTip1.SetToolTip(this.lblSlowest, "Double click to see detail");
            this.lblSlowest.DoubleClick += new System.EventHandler(this.lblSlowest_DoubleClick);
            // 
            // lblAverage
            // 
            this.lblAverage.AutoSize = true;
            this.lblAverage.Location = new System.Drawing.Point(114, 70);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(93, 13);
            this.lblAverage.TabIndex = 5;
            this.lblAverage.Text = "Average Duration:";
            // 
            // cmbxDetails
            // 
            this.cmbxDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxDetails.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxDetails.FormattingEnabled = true;
            this.cmbxDetails.Location = new System.Drawing.Point(58, 46);
            this.cmbxDetails.Name = "cmbxDetails";
            this.cmbxDetails.Size = new System.Drawing.Size(565, 21);
            this.cmbxDetails.TabIndex = 4;
            this.cmbxDetails.SelectedIndexChanged += new System.EventHandler(this.cmbxDetails_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Detail:";
            // 
            // cmbxMethods
            // 
            this.cmbxMethods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxMethods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxMethods.FormattingEnabled = true;
            this.cmbxMethods.Location = new System.Drawing.Point(58, 19);
            this.cmbxMethods.Name = "cmbxMethods";
            this.cmbxMethods.Size = new System.Drawing.Size(565, 21);
            this.cmbxMethods.Sorted = true;
            this.cmbxMethods.TabIndex = 2;
            this.cmbxMethods.SelectedIndexChanged += new System.EventHandler(this.cmbxMethods_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Method:";
            // 
            // lblNumberOfItems
            // 
            this.lblNumberOfItems.AutoSize = true;
            this.lblNumberOfItems.Location = new System.Drawing.Point(6, 70);
            this.lblNumberOfItems.Name = "lblNumberOfItems";
            this.lblNumberOfItems.Size = new System.Drawing.Size(48, 13);
            this.lblNumberOfItems.TabIndex = 0;
            this.lblNumberOfItems.Text = "0 Entries";
            // 
            // PerformanceStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "PerformanceStatistics";
            this.Size = new System.Drawing.Size(629, 94);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.ComboBox cmbxDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbxMethods;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumberOfItems;
        private System.Windows.Forms.Label lblFastest;
        private System.Windows.Forms.Label lblSlowest;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
