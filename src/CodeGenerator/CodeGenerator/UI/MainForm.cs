using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using SEFI.Dialogs;
using CodeGenerator.UI;
using CodeGenerator.Properties;
namespace CodeGenerator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void codeFromDatabaseTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassFromDb dialog = new ClassFromDb
            {
                MdiParent = this,
                ConnectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString,
                WindowState = FormWindowState.Maximized
            };
            dialog.Show();
        }

        private void tsbtnMockDatabase_Click(object sender, EventArgs e)
        {
            MockDb dialog = new MockDb
            {
                MdiParent = this,
                ConnectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString,
                WindowState = FormWindowState.Maximized
            };
            dialog.Show();
        }

        private void toolStripButton1tsbtnEditSettings_Click(object sender, EventArgs e)
        {
            MultiValueInputDialog dialog = new MultiValueInputDialog
            {
                Text = "Application Settings",
                Icon = Resources.ConfigureWrench,
                StartPosition = FormStartPosition.CenterParent
            };
            dialog.FieldRaisedEvent += Dialog_FieldRaisedEvent;
            dialog.Fields.Add(new Field
            {
                Caption = "Substitutions",
                InputType = SEFI.UserControls.InputType.String,
                Value = Settings.Default.Substitutions
            });
            dialog.Fields.Add(new Field
            {
                Caption = "ClassNameExpression",
                InputType = SEFI.UserControls.InputType.String,
                Value = Settings.Default.ClassNameExpression
            });
            dialog.Fields.Add(new Field
            {
                Caption = "Namespace",
                InputType = SEFI.UserControls.InputType.String,
                Value = Settings.Default.Namespace
            });
            dialog.Fields.Add(new Field
            {
                Caption = "NamespaceSuffix",
                InputType = SEFI.UserControls.InputType.String,
                Value = Settings.Default.NamespaceSuffix
            });
            dialog.Fields.Add(new Field
            {
                Caption = "GitRepositoryFolder",
                InputType = SEFI.UserControls.InputType.String,
                Value = Settings.Default.GitRepositoryFolder,
                HasButton = true,
                ButtonText = "Select Folder"
            });
            dialog.Fields.Add(new Field
            {
                Caption = "EntityFolder",
                InputType = SEFI.UserControls.InputType.String,
                Value = Settings.Default.EntityFolder,
                HasButton = true,
                ButtonText = "Select Folder"
            });
            dialog.Fields.Add(new Field
            {
                Caption = "InfrastructureServicesMappingFolder",
                InputType = SEFI.UserControls.InputType.String,
                Value = Settings.Default.InfrastructureServicesMappingFolder,
                HasButton = true,
                ButtonText = "Select Folder"
            });
            dialog.Fields.Add(new Field
            {
                Caption = "UnitTestFolder",
                InputType = SEFI.UserControls.InputType.String,
                Value = Settings.Default.UnitTestFolder,
                HasButton = true,
                ButtonText = "Select Folder"
            });
            dialog.Fields.Add(new Field
            {
                Caption = "TestDataFolder",
                InputType = SEFI.UserControls.InputType.String,
                Value = Settings.Default.TestDataFolder,
                HasButton = true,
                ButtonText = "Select Folder"
            });
            dialog.Fields.Add(new Field
            {
                Caption = "InfrastructureServicesFolder",
                InputType = SEFI.UserControls.InputType.String,
                Value = Settings.Default.InfrastructureServicesFolder,
                HasButton = true,
                ButtonText = "Select Folder"
            });
            dialog.Fields.Add(new Field
            {
                Caption = "InfrastructureServiceUnitTestFolder",
                InputType = SEFI.UserControls.InputType.String,
                Value = Settings.Default.InfrastructureServiceUnitTestFolder,
                HasButton = true,
                ButtonText = "Select Folder"
            });
            dialog.Fields.Add(new Field
            {
                Caption = "InfrastructureServicesProjectFolder",
                InputType = SEFI.UserControls.InputType.String,
                Value = Settings.Default.InfrastructureServicesProjectFolder,
                HasButton = true,
                ButtonText = "Select Folder"
            });
            dialog.Fields.Add(new Field
            {
                Caption = "InfrastructureServicesQueryFolder",
                InputType = SEFI.UserControls.InputType.String,
                Value = Settings.Default.InfrastructureServicesQueryFolder,
                HasButton = true,
                ButtonText = "Select Folder"
            });
            dialog.Fields.Add(new Field
            {
                Caption = "InfrastructureServicesInterfacesFolder",
                InputType = SEFI.UserControls.InputType.String,
                Value = Settings.Default.InfrastructureServicesInterfacesFolder,
                HasButton = true,
                ButtonText = "Select Folder"
            });
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (Field field in dialog.Fields)
                {
                    if (field.Caption.Contains("Folder") && !string.IsNullOrEmpty(Settings.Default.GitRepositoryFolder) && field.Caption != "GitRepositoryFolder")
                    {
                        Settings.Default[field.Caption] = (field.Value as string).Replace(Settings.Default.GitRepositoryFolder, "");
                    }
                    else
                        Settings.Default[field.Caption] = field.Value;
                }
                Settings.Default.Save();
            }
            if (ActiveMdiChild is ClassFromDb)
                (ActiveMdiChild as ClassFromDb).ApplySettings();
        }

        private void Dialog_FieldRaisedEvent(object sender, FieldEventArgs e)
        {
            if(e.Field.Caption.Contains("Folder"))
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.SelectedPath = Settings.Default.GitRepositoryFolder ?? null;
                dialog.SelectedPath = e.Field.Value as string;
                if (dialog.ShowDialog() == DialogResult.OK)
                    e.Field.Value = dialog.SelectedPath;
            }
        }

        private void tsbtnDACGenerator_Click(object sender, EventArgs e)
        {
            DataAccessBuilder dialog = new DataAccessBuilder 
            {
                MdiParent = this,
                ConnectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString,
                WindowState = FormWindowState.Maximized,
            };
            dialog.Show();

        }

        private void tsbtnClassFromAssembly_Click(object sender, EventArgs e)
        {
            TestObjectForClass dialog = new TestObjectForClass
            {
                MdiParent = this,
                ConnectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString,
                WindowState = FormWindowState.Maximized,
            };
            dialog.Show();
        }
    }
}
