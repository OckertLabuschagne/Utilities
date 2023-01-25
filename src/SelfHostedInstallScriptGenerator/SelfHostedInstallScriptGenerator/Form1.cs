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
using System.IO;
using System.IO.Compression;

using SEFI.Dialogs;
namespace SelfHostedInstallScriptGenerator
{
    public partial class Form1 : Form
    {
        string _SourceRootFolder,
            _SqlDeployerPath,
            _DbUpgradePath,
            _DbReleaseFolder,
            _ReleaseFolder,
            _TargetFolder,
            _DbServer,
            _DbPort,
            _WhDdServer,
            _WhDbPort,
            _TPA;
        public Form1()
        {
            InitializeComponent();
            _SourceRootFolder = ConfigurationManager.AppSettings["SourcePath"];
            _TargetFolder = string.IsNullOrEmpty(Properties.Settings.Default.TargetFolder) ? _SourceRootFolder : Properties.Settings.Default.TargetFolder;
            _DbReleaseFolder = Properties.Settings.Default.DbReleasePath;
            _ReleaseFolder = Properties.Settings.Default.ReleasePath;
            _DbUpgradePath = Properties.Settings.Default.DbUpgradePart;
            _SqlDeployerPath = Properties.Settings.Default.SqlDeployerPath;
            _TPA = Properties.Settings.Default.TPA;
            _DbServer = Properties.Settings.Default.DbServer;

            tsslblSourceFolder.Text = _SourceRootFolder;
            tsslblTargetFolder.Text = _TargetFolder;
            tsslblReleaseFolder.Text = _ReleaseFolder;
            tsslblDbReleaseFolder.Text = _DbReleaseFolder;
            tstxtbTpa.Text = _TPA;
            tstxtbServer.Text = _DbServer;
            FillList();
        }

        private void lbxBatchFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtxtbCode.Text = "";
            if(lbxBatchFiles.SelectedItem != null)
            {
                if ((lbxBatchFiles.SelectedItem as string).Contains("Step1"))
                    rtxtbCode.Text = BuildStep1Batch();
                else if ((lbxBatchFiles.SelectedItem as string).Contains("Step2"))
                    rtxtbCode.Text = BuildStep2Batch();
                else if((lbxBatchFiles.SelectedItem as string).Contains("Step3"))
                    rtxtbCode.Text = BuildStep3Batch();
                else if ((lbxBatchFiles.SelectedItem as string).Contains("Auto_DB"))
                    rtxtbCode.Text = BuildAutoDBChange((lbxBatchFiles.SelectedItem as string).Replace($"{_SqlDeployerPath}\\{_DbUpgradePath}\\Deploy_Auto_DB_Changes_", "").Replace(".bat", ""));
                else if ((lbxBatchFiles.SelectedItem as string).Contains("Document_DB"))
                    rtxtbCode.Text = BuildDocumentDBChange((lbxBatchFiles.SelectedItem as string).Replace($"{_SqlDeployerPath}\\{_DbUpgradePath}\\Deploy_Document_DB_Changes_", "").Replace(".bat", ""));
                else if ((lbxBatchFiles.SelectedItem as string).Contains("Warehouse_DB"))
                    rtxtbCode.Text = BuildWarehouseDBChange((lbxBatchFiles.SelectedItem as string).Replace($"{_SqlDeployerPath}\\{_DbUpgradePath}\\Deploy_Warehouse_DB_Changes_", "").Replace(".bat", ""));
            }
        }

        private void tsbtnSaveAll_Click(object sender, EventArgs e)
        {
            foreach(string file in lbxBatchFiles.Items)
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(_TargetFolder, _DbReleaseFolder, file)))
                {
                    if (file.Contains("Step1"))
                        writer.Write(BuildStep1Batch());
                    else if (file.Contains("Step2"))
                        writer.Write(BuildStep2Batch());
                    else if (file.Contains("Step3"))
                        writer.Write(BuildStep3Batch());
                    else if (file.Contains("Auto_DB"))
                        writer.Write(BuildAutoDBChange(file.Replace($"{_SqlDeployerPath}\\{_DbUpgradePath}\\Deploy_Auto_DB_Changes_", "").Replace(".bat", "")));
                    else if (file.Contains("Document_DB"))
                        writer.Write(BuildDocumentDBChange(file.Replace($"{_SqlDeployerPath}\\{_DbUpgradePath}\\Deploy_Document_DB_Changes_", "").Replace(".bat", "")));
                    else if (file.Contains("Warehouse_DB"))
                        writer.Write(BuildWarehouseDBChange(file.Replace($"{_SqlDeployerPath}\\{_DbUpgradePath}\\Deploy_Warehouse_DB_Changes_", "").Replace(".bat", "")));
                    writer.Flush();
                    writer.Close();
                }
            }
        }

        private void tsbtnCreateZip_Click(object sender, EventArgs e)
        {
            string zipFileFolder = Path.Combine(_TargetFolder, _ReleaseFolder, _DbReleaseFolder, "Builds\\Current\\Deployment\\Database");
            if (!Directory.Exists(zipFileFolder))
            {
                MessageBox.Show("No script files to zip", "No Files", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string autoScripts = Path.Combine(zipFileFolder, "Auto");
            if (!Directory.Exists(autoScripts))
            {
                MessageBox.Show("No script files to zip", "No Files", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string documentScripts = Path.Combine(zipFileFolder, "Document");
            if (!Directory.Exists(documentScripts))
            {
                MessageBox.Show("No script files to zip", "No Files", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (File.Exists(Path.Combine(zipFileFolder, $"{_TPA}_auto.zip")))
                File.Delete(Path.Combine(zipFileFolder, $"{_TPA}_auto.zip"));
            if (File.Exists(Path.Combine(zipFileFolder, $"{_TPA}_doc.zip")))
                File.Delete(Path.Combine(zipFileFolder, $"{_TPA}_doc.zip"));
            if (File.Exists(Path.Combine(zipFileFolder, $"{_TPA}_warehouse.zip")))
                File.Delete(Path.Combine(zipFileFolder, $"{_TPA}_warehouse.zip"));
            tspbGroups.Value = 1;
            tsslblGroup.Text = "1 of 3";
            string[] sqlFiles = Directory.GetFiles(autoScripts, "*.sql");
            if (sqlFiles != null && sqlFiles.Length > 0)
            {
                tspbFiles.Maximum = sqlFiles.Length;
                tsslblFiles.Text = $"1 of {sqlFiles.Length}";
                tspbFiles.Value = 1;
                using (ZipArchive archive = ZipFile.Open(Path.Combine(zipFileFolder, $"{_TPA}_auto.zip"), File.Exists(Path.Combine(zipFileFolder, $"{_TPA}_auto.zip")) ? ZipArchiveMode.Update : ZipArchiveMode.Create))
                {
                    for (int i = 0; i < sqlFiles.Length; i++)
                    {
                        archive.CreateEntryFromFile(sqlFiles[i], Path.GetFileName(sqlFiles[i]), CompressionLevel.Fastest);
                        tspbFiles.Value = i + 1;
                        tsslblFiles.Text = $"{tspbFiles.Value} of {sqlFiles.Length}";
                        Application.DoEvents();
                    }
                }
            }
            tspbGroups.Value = 2;
            tsslblGroup.Text = "2 of 3";
            sqlFiles = Directory.GetFiles(documentScripts, "*.sql"); ;
            if (sqlFiles != null && sqlFiles.Length > 0)
            {
                tspbFiles.Maximum = sqlFiles.Length;
                tsslblFiles.Text = $"1 of {sqlFiles.Length}";
                tspbFiles.Value = 1;
                using (ZipArchive archive = ZipFile.Open(Path.Combine(zipFileFolder, $"{_TPA}_doc.zip"), File.Exists(Path.Combine(zipFileFolder, $"{_TPA}_doc.zip")) ? ZipArchiveMode.Update : ZipArchiveMode.Create))
                {
                    for (int i = 0; i < sqlFiles.Length; i++)
                    {
                        archive.CreateEntryFromFile(sqlFiles[i], Path.GetFileName(sqlFiles[i]), CompressionLevel.Fastest);
                        tspbFiles.Value = i + 1;
                        Application.DoEvents();
                    }
                }
            }
            /*
            tspbGroups.Value = 3;
            tsslblGroup.Text = "3 of 3";
            sqlFiles = null;
            if (Directory.Exists(Path.Combine(_SourceRootFolder, build, "Warehouse Database")))
                sqlFiles = Directory.GetFiles(Path.Combine(_SourceRootFolder, build, "Warehouse Database"), "*.sql");
            else if (Directory.Exists(Path.Combine(_SourceRootFolder, build, "WarehouseDatabase")))
                sqlFiles = Directory.GetFiles(Path.Combine(_SourceRootFolder, build, "WarehouseDatabase"), "*.sql");
            if (sqlFiles != null && sqlFiles.Length > 0)
            {
                tspbFiles.Maximum = sqlFiles.Length;
                tsslblFiles.Text = $"1 of {sqlFiles.Length}";
                tspbFiles.Value = 1;
                using (ZipArchive archive = ZipFile.Open(Path.Combine(zipFileFolder, $"{_TPA}_warehouse.zip"), File.Exists(Path.Combine(zipFileFolder, $"{_TPA}_warehouse.zip")) ? ZipArchiveMode.Update : ZipArchiveMode.Create))
                {
                    for (int i = 0; i < sqlFiles.Length; i++)
                    {
                        archive.CreateEntryFromFile(sqlFiles[i], Path.GetFileName(sqlFiles[i]), CompressionLevel.Fastest);
                        tspbFiles.Value = i + 1;
                        Application.DoEvents();
                    }
                }
            }
            */
            if (tspbChecked.Value > tspbChecked.Maximum)
            {
                tspbChecked.Value++;
                tsslblChecked.Text = $"{tspbChecked.Value} of {clbBuilds.CheckedItems.Count}";
                Application.DoEvents();
            }
        }

        private void tsbtnCopy_Click(object sender, EventArgs e)
        {
            string zipFileFolder = Path.Combine(_TargetFolder, _ReleaseFolder, _DbReleaseFolder, "Builds\\Current\\Deployment\\Database");
            if (!Directory.Exists(zipFileFolder))
                Directory.CreateDirectory(zipFileFolder);
            string autoScripts = Path.Combine(zipFileFolder, "Auto");
            if (!Directory.Exists(autoScripts))
                Directory.CreateDirectory(autoScripts);
            string documentScripts = Path.Combine(zipFileFolder, "Document");
            if (!Directory.Exists(documentScripts))
                Directory.CreateDirectory(documentScripts);
            tsslblChecked.Text = $"1 of {clbBuilds.CheckedItems.Count}";
            tspbChecked.Maximum = clbBuilds.CheckedItems.Count;
            tspbChecked.Value = 1;
            foreach (string build in clbBuilds.CheckedItems)
            {
                tspbGroups.Value = 1;
                tsslblGroup.Text = "1 of 3";
                string[] subFolders = Directory.GetDirectories(Path.Combine(_SourceRootFolder, build));
                string[] sqlFiles = null;
                if (Directory.Exists(Path.Combine(_SourceRootFolder, build, "Auto Database")))
                    sqlFiles = Directory.GetFiles(Path.Combine(_SourceRootFolder, build, "Auto Database"), "*.sql");
                else if (Directory.Exists(Path.Combine(_SourceRootFolder, build, "AutoDatabase")))
                    sqlFiles = Directory.GetFiles(Path.Combine(_SourceRootFolder, build, "AutoDatabase"), "*.sql");
                if (sqlFiles != null && sqlFiles.Length > 0)
                {
                    tspbFiles.Maximum = sqlFiles.Length;
                    tsslblFiles.Text = $"1 of {sqlFiles.Length}";
                    tspbFiles.Value = 1;
                    for (int i = 0; i < sqlFiles.Length; i++)
                    {
                        if (!File.Exists(Path.Combine(autoScripts, Path.GetFileName(sqlFiles[i]))))
                            File.Copy(sqlFiles[i], Path.Combine(autoScripts, Path.GetFileName(sqlFiles[i])));
                        tspbFiles.Value = i + 1;
                        tsslblFiles.Text = $"{tspbFiles.Value} of {sqlFiles.Length}";
                        Application.DoEvents();
                    }
                }
                tspbGroups.Value = 2;
                tsslblGroup.Text = "2 of 3";
                sqlFiles = null;
                if (Directory.Exists(Path.Combine(_SourceRootFolder, build, "Document Database")))
                    sqlFiles = Directory.GetFiles(Path.Combine(_SourceRootFolder, build, "Document Database"), "*.sql");
                else if (Directory.Exists(Path.Combine(_SourceRootFolder, build, "DocumentDatabase")))
                    sqlFiles = Directory.GetFiles(Path.Combine(_SourceRootFolder, build, "DocumentDatabase"), "*.sql");
                if (sqlFiles != null && sqlFiles.Length > 0)
                {
                    tspbFiles.Maximum = sqlFiles.Length;
                    tsslblFiles.Text = $"1 of {sqlFiles.Length}";
                    tspbFiles.Value = 1;
                    for (int i = 0; i < sqlFiles.Length; i++)
                    {
                        if (!File.Exists(Path.Combine(documentScripts, Path.GetFileName(sqlFiles[i]))))
                            File.Copy(sqlFiles[i], Path.Combine(documentScripts, Path.GetFileName(sqlFiles[i])));
                        tspbFiles.Value = i + 1;
                        tsslblFiles.Text = $"{tspbFiles.Value} of {sqlFiles.Length}";
                        Application.DoEvents();
                    }
                }
                if (tspbChecked.Value < tspbChecked.Maximum)
                {
                    tspbChecked.Value++;
                    tsslblChecked.Text = $"{tspbChecked.Value} of {clbBuilds.CheckedItems.Count}";
                    Application.DoEvents();
                }
            }
        }

        private void clbBuilds_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                tsslblChecked.Text = $"0 of {clbBuilds.CheckedItems.Count + 1}";
            if (e.NewValue != CheckState.Checked)
                tsslblChecked.Text = $"0 of {clbBuilds.CheckedItems.Count - 1}";
        }


        private string BuildStep1Batch()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("@echo off");
            stringBuilder.AppendLine("echo Please press any key to trigger the sequential SQL upgrade");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("pause");
            stringBuilder.AppendLine("");
            foreach (string build in clbBuilds.CheckedItems)
            {
                string[] subFolders = Directory.GetDirectories(Path.Combine(_SourceRootFolder, build));
                if (subFolders.Contains(Path.Combine(_SourceRootFolder, build, "Auto Database")) || subFolders.Contains(Path.Combine(_SourceRootFolder, build, "AutoDatabase")))
                    stringBuilder.AppendLine($"start \"Parent Batch\" /wait \"%~dp0\\{_DbUpgradePath}\\Deploy_Auto_DB_Changes_{build}\"");
            }
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("pause");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("exit");
            return stringBuilder.ToString();
        }

        private string BuildStep2Batch()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("@echo off");
            stringBuilder.AppendLine("echo Please press any key to trigger the sequential SQL upgrade");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("pause");
            stringBuilder.AppendLine("");
            foreach (string build in clbBuilds.CheckedItems)
            {
                string[] subFolders = Directory.GetDirectories(Path.Combine(_SourceRootFolder, build));
                if (subFolders.Contains(Path.Combine(_SourceRootFolder, build, "Document Database")) || subFolders.Contains(Path.Combine(_SourceRootFolder, build, "DocumentDatabase")))
                    stringBuilder.AppendLine($"start \"Parent Batch\" /wait \"%~dp0\\{_DbUpgradePath}\\Deploy_Document_DB_Changes_{build}\"");
            }
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("pause");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("exit");
            return stringBuilder.ToString();
        }

        private string BuildStep3Batch()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("@echo off");
            stringBuilder.AppendLine("echo Please press any key to trigger the sequential SQL upgrade");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("pause");
            stringBuilder.AppendLine("");
            foreach (string build in clbBuilds.CheckedItems)
            {
                string[] subFolders = Directory.GetDirectories(Path.Combine(_SourceRootFolder, build));
                if (subFolders.Contains(Path.Combine(_SourceRootFolder, build, "Warehouse Database")) || subFolders.Contains(Path.Combine(_SourceRootFolder, build, "WarehouseDatabase")))
                    stringBuilder.AppendLine($"start \"Parent Batch\" /wait \"%~dp0\\{_DbUpgradePath}\\Deploy_Warehouse_DB_Changes_{build}\"");
            }
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("pause");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("exit");
            return stringBuilder.ToString();
        }

        private string BuildAutoDBChange(string build)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("@echo off");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("SET UtilityFile=%~dp0..\\Utility\\DeploySQLChanges.bat");
            string[] fileNames = null;
            if (Directory.Exists(Path.Combine(_SourceRootFolder, build, "Auto Database")))
                fileNames = Directory.GetFiles(Path.Combine(_SourceRootFolder, build, "Auto Database"), "*.zip");
            else if (Directory.Exists(Path.Combine(_SourceRootFolder, build, "AutoDatabase")))
                fileNames = Directory.GetFiles(Path.Combine(_SourceRootFolder, build, "AutoDatabase"), "*.zip");
            if (fileNames != null)
            {
                string fileName = Path.GetFileName(fileNames[0]);
                stringBuilder.AppendLine($"SET ZipFile=%~dp0..\\..\\..\\Builds\\Current\\Deployment\\Database\\{fileName}");
                stringBuilder.AppendLine($"SET SqlServer={_DbServer}{_DbPort}");
                stringBuilder.AppendLine("SET DatabasePrefix=scs_auto");
                stringBuilder.AppendLine("");
                stringBuilder.AppendLine($"START CMD /k CALL \"%UtilityFile%\" \"%ZipFile%\" \"%SqlServer%\" \"%DatabasePrefix%_{_TPA}\"");
                stringBuilder.AppendLine($"START CMD /k CALL \"%UtilityFile%\" \"%ZipFile%\" \"%SqlServer%\" \"%DatabasePrefix%_master_{_TPA}\"");
                stringBuilder.AppendLine("");
                stringBuilder.AppendLine("PAUSE");
                return stringBuilder.ToString();
            }
            else return "";
        }

        private string BuildDocumentDBChange(string build)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("@echo off");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("SET UtilityFile=%~dp0..\\Utility\\DeploySQLChanges.bat");
            stringBuilder.AppendLine($"SET ZipFile=%~dp0..\\..\\..\\Builds\\Current\\Deployment\\Database\\{build}.doc.zip");
            stringBuilder.AppendLine($"SET SqlServer={_DbServer}{_DbPort}");
            stringBuilder.AppendLine("SET DatabasePrefix=scs_auto_document");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine($"START CMD /k CALL \"%UtilityFile% \" \"%ZipFile% \" \" %SqlServer% \" \"%DatabasePrefix%_{_TPA}\"");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("PAUSE");
            return stringBuilder.ToString();
        }

        private string BuildWarehouseDBChange(string build)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("@echo off");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("SET UtilityFile=%~dp0..\\Utility\\DeploySQLChanges.bat");
            stringBuilder.AppendLine($"SET ZipFile=%~dp0..\\..\\..\\Builds\\Current\\Deployment\\Database\\{build}.w.zip");
            stringBuilder.AppendLine($"SET SqlServer={_WhDdServer}{_WhDbPort}");
            stringBuilder.AppendLine("SET DatabasePrefix=scs_warehouse");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine($"START CMD /k CALL \"%UtilityFile%\" \"%ZipFile%\" \"%SqlServer%\" \"%DatabasePrefix%_{_TPA}\"");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("PAUSE");
            return stringBuilder.ToString();
        }

        private void FillList()
        {
            string[] builds = Directory.GetDirectories(_SourceRootFolder);
            clbBuilds.Items.Clear();
            foreach (string build in builds)
            {
                clbBuilds.Items.Add(build.Replace($"{_SourceRootFolder}\\", ""));
            }
        }

        private void tstxtbTpa_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.TPA = tstxtbTpa.Text;
            Properties.Settings.Default.Save();
        }

        private void tstxtbServer_Leave(object sender, EventArgs e)
        {
            _DbServer = tstxtbServer.Text;
            Properties.Settings.Default.DbServer = _DbServer;
            Properties.Settings.Default.Save();
        }

        private void tsslblTargetFolder_DoubleClick(object sender, EventArgs e)
        {
        }

        private void tsbtnSelectTargetFolder_Click(object sender, EventArgs e)
        {
            MultiValueInputDialog dialog = new MultiValueInputDialog();
            if (dialog.ShowDialog(new Field
            {
                Caption = "Target Folder",
                InputType = SEFI.UserControls.InputType.Folder,
                ButtonText = "Select",
                Value = _TargetFolder
            },
            new Field
            {
                Caption = "Release Folder",
                InputType = SEFI.UserControls.InputType.Folder,
                ButtonText = "Select",
                Value = Path.Combine(_TargetFolder, _ReleaseFolder)
            },
            new Field
            {
                Caption = "Database Release Folder",
                InputType = SEFI.UserControls.InputType.Folder,
                ButtonText = "Select",
                Value = Path.Combine(_TargetFolder, _ReleaseFolder, _DbReleaseFolder)
            }) == DialogResult.OK)
            {
                _TargetFolder = dialog.Fields[0].Value as string;
                _ReleaseFolder = (dialog.Fields[1].Value as string).Replace($"{_TargetFolder}\\", "");
                _DbReleaseFolder = string.IsNullOrEmpty(_ReleaseFolder) ? (dialog.Fields[2].Value as string).Replace($"{_TargetFolder}\\", "") : (dialog.Fields[2].Value as string).Replace($"{_TargetFolder}\\", "").Replace($"{_ReleaseFolder}\\","");

                tsslblTargetFolder.Text = _TargetFolder;
                tsslblReleaseFolder.Text = _ReleaseFolder;
                tsslblDbReleaseFolder.Text = _DbReleaseFolder;

                Properties.Settings.Default.TargetFolder = _TargetFolder;
                Properties.Settings.Default.ReleasePath = _ReleaseFolder;
                Properties.Settings.Default.DbReleasePath = _DbReleaseFolder;
                Properties.Settings.Default.Save();
            }
        }

        private void tsbtnBuildDatabaseBatchFiles_Click(object sender, EventArgs e)
        {
            lbxBatchFiles.Items.Clear();
            lbxBatchFiles.Items.Add($"{_SqlDeployerPath}\\Step1_Upgrade_Auto.bat");
            lbxBatchFiles.Items.Add($"{_SqlDeployerPath}\\Step2_Upgrade_Document.bat");
            lbxBatchFiles.Items.Add($"{_SqlDeployerPath}\\Step3_Upgrade_Warehouse.bat");
            foreach (string build in clbBuilds.CheckedItems)
            {
                string[] subFolders = Directory.GetDirectories(Path.Combine(_SourceRootFolder, build));
                if (subFolders.Contains(Path.Combine(_SourceRootFolder, build, "Auto Database")) || subFolders.Contains(Path.Combine(_SourceRootFolder, build, "AutoDatabase")))
                    lbxBatchFiles.Items.Add($"{_SqlDeployerPath}\\{_DbUpgradePath}\\Deploy_Auto_DB_Changes_{build}.bat");
                if (subFolders.Contains(Path.Combine(_SourceRootFolder, build, "Document Database")) || subFolders.Contains(Path.Combine(_SourceRootFolder, build, "DocumentDatabase")))
                    lbxBatchFiles.Items.Add($"{_SqlDeployerPath}\\{_DbUpgradePath}\\Deploy_Document_DB_Changes_{build}.bat");
                if (subFolders.Contains(Path.Combine(_SourceRootFolder, build, "Warehouse Database")) || subFolders.Contains(Path.Combine(_SourceRootFolder, build, "WarehouseDatabase")))
                    lbxBatchFiles.Items.Add($"{_SqlDeployerPath}\\{_DbUpgradePath}\\Deploy_Warehouse_DB_Changes_{build}.bat");
            }
        }
    }
}
