namespace CodeGenerator
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.functionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeFromDatabaseTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mockDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnCodeFromTable = new System.Windows.Forms.ToolStripButton();
            this.tsbtnMockDatabase = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1tsbtnEditSettings = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDACGenerator = new System.Windows.Forms.ToolStripButton();
            this.tsbtnClassFromAssembly = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.functionToolStripMenuItem,
            this.windowsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.windowsToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1108, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // functionToolStripMenuItem
            // 
            this.functionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.codeFromDatabaseTableToolStripMenuItem,
            this.mockDatabaseToolStripMenuItem});
            this.functionToolStripMenuItem.Name = "functionToolStripMenuItem";
            this.functionToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.functionToolStripMenuItem.Text = "&Function";
            // 
            // codeFromDatabaseTableToolStripMenuItem
            // 
            this.codeFromDatabaseTableToolStripMenuItem.Name = "codeFromDatabaseTableToolStripMenuItem";
            this.codeFromDatabaseTableToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.codeFromDatabaseTableToolStripMenuItem.Text = "&Code From Database Table";
            this.codeFromDatabaseTableToolStripMenuItem.Click += new System.EventHandler(this.codeFromDatabaseTableToolStripMenuItem_Click);
            // 
            // mockDatabaseToolStripMenuItem
            // 
            this.mockDatabaseToolStripMenuItem.Name = "mockDatabaseToolStripMenuItem";
            this.mockDatabaseToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.mockDatabaseToolStripMenuItem.Text = "&Mock Database";
            this.mockDatabaseToolStripMenuItem.Click += new System.EventHandler(this.tsbtnMockDatabase_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.windowsToolStripMenuItem.Text = "&Windows";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnCodeFromTable,
            this.tsbtnMockDatabase,
            this.toolStripButton1tsbtnEditSettings,
            this.tsbtnDACGenerator,
            this.tsbtnClassFromAssembly});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1108, 39);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnCodeFromTable
            // 
            this.tsbtnCodeFromTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnCodeFromTable.Image = global::CodeGenerator.Properties.Resources.DatabaseGear_32;
            this.tsbtnCodeFromTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCodeFromTable.Name = "tsbtnCodeFromTable";
            this.tsbtnCodeFromTable.Size = new System.Drawing.Size(36, 36);
            this.tsbtnCodeFromTable.Text = "Create code from database table";
            this.tsbtnCodeFromTable.Click += new System.EventHandler(this.codeFromDatabaseTableToolStripMenuItem_Click);
            // 
            // tsbtnMockDatabase
            // 
            this.tsbtnMockDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnMockDatabase.Image = global::CodeGenerator.Properties.Resources.DatabaseSilver_32;
            this.tsbtnMockDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnMockDatabase.Name = "tsbtnMockDatabase";
            this.tsbtnMockDatabase.Size = new System.Drawing.Size(36, 36);
            this.tsbtnMockDatabase.Text = "Create mock database";
            this.tsbtnMockDatabase.Click += new System.EventHandler(this.tsbtnMockDatabase_Click);
            // 
            // toolStripButton1tsbtnEditSettings
            // 
            this.toolStripButton1tsbtnEditSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1tsbtnEditSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1tsbtnEditSettings.Image = global::CodeGenerator.Properties.Resources.ConfigureWrench_32;
            this.toolStripButton1tsbtnEditSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1tsbtnEditSettings.Name = "toolStripButton1tsbtnEditSettings";
            this.toolStripButton1tsbtnEditSettings.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton1tsbtnEditSettings.Text = "Edit settings";
            this.toolStripButton1tsbtnEditSettings.Click += new System.EventHandler(this.toolStripButton1tsbtnEditSettings_Click);
            // 
            // tsbtnDACGenerator
            // 
            this.tsbtnDACGenerator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnDACGenerator.Image = global::CodeGenerator.Properties.Resources.RunDatabaseScript_32;
            this.tsbtnDACGenerator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDACGenerator.Name = "tsbtnDACGenerator";
            this.tsbtnDACGenerator.Size = new System.Drawing.Size(36, 36);
            this.tsbtnDACGenerator.Text = "Create data access classes.";
            this.tsbtnDACGenerator.Click += new System.EventHandler(this.tsbtnDACGenerator_Click);
            // 
            // tsbtnClassFromAssembly
            // 
            this.tsbtnClassFromAssembly.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnClassFromAssembly.Image = global::CodeGenerator.Properties.Resources.DLL_32;
            this.tsbtnClassFromAssembly.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClassFromAssembly.Name = "tsbtnClassFromAssembly";
            this.tsbtnClassFromAssembly.Size = new System.Drawing.Size(36, 36);
            this.tsbtnClassFromAssembly.Text = "Create code from assembly";
            this.tsbtnClassFromAssembly.Click += new System.EventHandler(this.tsbtnClassFromAssembly_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip1.Location = new System.Drawing.Point(0, 678);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1108, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 700);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Code Generator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnCodeFromTable;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem functionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeFromDatabaseTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbtnMockDatabase;
        private System.Windows.Forms.ToolStripMenuItem mockDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1tsbtnEditSettings;
        private System.Windows.Forms.ToolStripButton tsbtnDACGenerator;
        private System.Windows.Forms.ToolStripButton tsbtnClassFromAssembly;
    }
}

