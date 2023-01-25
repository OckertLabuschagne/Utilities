using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Threading;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

using MigraDoc.DocumentObjectModel.IO;

using APITester.Models;
using APITester.Dialog;
using APITester.Properties;

using SEFI.Dialogs;
using s = SEFI.UserControls;
using APITester.Models.Commands;
namespace APITester
{
    public partial class Form1 : Form
    {
        string claimUrl = "http://localhost:5041/fias/claims",
            contractUrl = "http://localhost:5040/fias/contract",
            scsPermissionsUrl = "https://qa.purefi.co/qa-manual/api/scspermission",
            webLoginUrl = "https://qa.purefi.co/qa-manual/login/connect/token",
            tpa = "fias",
            selectedEnvironment = "Local",
            selectedGroup = "",
            connectionString,
            downloadDirectory,
            fileName,
            applicationName,
            logFilePath;
        string logFolder;
        DateTime? minDate = DateTime.Now.AddDays(-1);

        TPATestSuite _SelectedTPATestSuite;
        TPALoadTestSuite _SelectedTPALoadTest;
        LoginResponse loginResponse;
        Command _SelectedCommand;
        Sequence _SelectedSequence;
        Dictionary<string, Dictionary<string, List<Command>>> _Commands;
        Dictionary<string, Dictionary<string, TPATestSuite>> _TestSuites;
        Dictionary<string, Dictionary<string, TPALoadTestSuite>> _LoadTesting;
        Dictionary<string, (string, string)> _Users = new Dictionary<string, (string, string)>();
        List<double> _Durations;
        Dictionary<int, List<double>> _MultyDurations;
        List<JObject> _PerformanceLog = new List<JObject>();

        List<Sequence> _Sequences;
        Step _SelectedStep;
        byte[] rawResponse;
        bool selectionChanging;
        List<Task<(bool, object)>> ActiveTasks;
        int errorCount = 0, maxTasks = 0, logRows = 1000, logPage = 0;
        StringBuilder errorLog = new StringBuilder();
        bool _SuppressEvents = false;
        (string, string) _User;
        public Form1()
        {
            InitializeComponent();

            commandEditorControl1.CanGet = true;
            commandEditorControl1.CanPost = true;
            commandEditorControl1.CanPut = true;
            commandEditorControl1.CanPatch = true;
            commandEditorControl2.CanGet = true;
            commandEditorControl2.CanPost = true;
            commandEditorControl2.CanPut = true;
            commandEditorControl2.CanPatch = true;
            cePerformance.CanGet = true;
            cePerformance.CanPost = true;
            cePerformance.CanPut = true;
            cePerformance.CanPatch = true;
            tscmbxCommand.ComboBox.DisplayMember = "Name";
            tscmbxSequences.ComboBox.DisplayMember = "Name";
            tsmiEnvironment.DropDownItems.Clear();
            tsmiEnvironment.DropDownItems.Add(tsmiLocal);
            string[] environments = ConfigurationManager.AppSettings["Environments"].Split(',');
            selectedEnvironment = Settings.Default.Environemt;
            if (selectedEnvironment == "Local")
                tsmiLocal.Checked = true;
            foreach (string env in environments)
            {
                ToolStripMenuItem mi = new ToolStripMenuItem
                {
                    Name = $"tsmi{env.Replace(" ", "").Replace("-", "")}",
                    Size = new Size(338, 40),
                    Text = env,
                    Checked = selectedEnvironment == env
                };
                mi.Click += new EventHandler(localToolStripMenuItem_Click);
                tsmiEnvironment.DropDownItems.Add(mi);
            }
            tsslblEnvironment.Text = selectedEnvironment;
            if (!string.IsNullOrEmpty(selectedEnvironment))
                SetURLs();
            if (File.Exists(Path.Combine(Application.StartupPath, "Commands.json")))
            {
                //Load the commands
                using (StreamReader commandFile = new StreamReader(Path.Combine(Application.StartupPath, "Commands.json")))
                    _Commands = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<Command>>>>(commandFile.ReadToEnd());
                if (_Commands == null)
                    _Commands = new Dictionary<string, Dictionary<string, List<Command>>>();
                FillCommands();
                tstxtbFolder.Text = Settings.Default.Path;
                connectionString = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;
                tscmbxAPi.SelectedItem = Settings.Default.API;
                switch (Settings.Default.Action)
                {
                    case "Put":
                        rbtnPut.Checked = true;
                        break;
                    case "Post":
                        rbtnPost.Checked = true;
                        break;
                    case "Get":
                        rbtnGet.Checked = true;
                        break;
                }
            }
            string usersString = Settings.Default.Users;
            string[] TPAUsers = usersString.Split(';');
            foreach (string TPAUser in TPAUsers)
            {
                string[] parts = TPAUser.Split(',');
                _Users.Add(parts[0], (parts[1], parts[2]));
            }
            if (File.Exists(Path.Combine(Application.StartupPath, "Sequences.json")))
            {
                using (StreamReader sequenceFile = new StreamReader(Path.Combine(Application.StartupPath, "Sequences.json")))
                    _Sequences = JsonConvert.DeserializeObject<List<Sequence>>(sequenceFile.ReadToEnd());
                if (_Sequences == null)
                    _Sequences = new List<Sequence>();
                tscmbxSequences.Items.Clear();
                foreach (Sequence seq in _Sequences)
                    tscmbxSequences.Items.Add(seq);
            }
            else if (_Sequences == null)
                _Sequences = new List<Sequence>();

            if (File.Exists(Path.Combine(Application.StartupPath, "TestSuits.json")))
            {
                using (StreamReader sequenceFile = new StreamReader(Path.Combine(Application.StartupPath, "TestSuits.json")))
                    _TestSuites = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, TPATestSuite>>>(sequenceFile.ReadToEnd());
                if (_TestSuites == null)
                    _TestSuites = new Dictionary<string, Dictionary<string, TPATestSuite>>();
                SetTestSuites();
            }

            if (File.Exists(Path.Combine(Application.StartupPath, "LoadTests.json")))
            {
                using (StreamReader sequenceFile = new StreamReader(Path.Combine(Application.StartupPath, "LoadTests.json")))
                    _LoadTesting = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, TPALoadTestSuite>>>(sequenceFile.ReadToEnd());
                if (_LoadTesting == null)
                    _LoadTesting = new Dictionary<string, Dictionary<string, TPALoadTestSuite>>();
                SetLoadTests();
            }

            if (string.IsNullOrEmpty(Settings.Default.DownloadDirectory))
            {
                downloadDirectory = Path.Combine(Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)), "Downloads");
                Settings.Default.DownloadDirectory = downloadDirectory;
                Settings.Default.Save();
            }
            downloadDirectory = Settings.Default.DownloadDirectory;
            tslblDownloadFolder.Text = downloadDirectory;
            tstxtbTPA.Text = Settings.Default.SelectedTPA;
            tpa = Settings.Default.SelectedTPA;
            if (_Users.ContainsKey(tpa.ToUpper()))
            {
                _User = _Users[tpa.ToUpper()];
                tsslblUserId.Text = _User.Item1;
            }
            else
            {
                _User = default;
                tsslblUserId.Text = "";
            }
            tstxtbNumberOfIterations.Text = $"{Settings.Default.NumberOfTestRuns}";
            tslblMinDate.Text = $"After {minDate:yyy-MM-dd}";
            tsbtnRefresh_Click(tsbtnRefresh, EventArgs.Empty);
            tstxtbPageSize.Text = $"{logRows}";
        }

        private void SetLoadTests()
        {
            tscmbxTPA.Items.Clear();
            var testSuite = _LoadTesting.Where(s => s.Key == selectedEnvironment);
            var _TestSuite = testSuite.Any() ? testSuite.FirstOrDefault().Value : null;
            if (_TestSuite != null)
                foreach (string key in _TestSuite.Keys)
                    tscmbxTPA.Items.Add(key);
        }

        private void SetTestSuites()
        {
            tscmbxSequences.Items.Clear();
            if (_TestSuites != null)
            {
                var testSuite = _TestSuites.Where(s => s.Key == selectedEnvironment);
                var _TestSuite = testSuite.Any() ? testSuite.FirstOrDefault().Value : null;
                if (_TestSuite != null)
                    foreach (string key in _TestSuite.Keys)
                        cmbxTPA.Items.Add(key);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbtnGetToken_Click(object sender, EventArgs e)
        {
            rtbResults.Text = "";
            Application.DoEvents();
            rtbResults.Text = GetToken();
        }

        private void tsbtnExecuteCommand_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            tsslblExecuting.Visible = true;
            rtbResults.Text = "";
            Application.DoEvents();
            if (loginResponse == null || !loginResponse.IsTokenurrent)
                GetToken();
            switch (_SelectedCommand.Action)
            {
                case ActionType.Get:
                    rtbResults.Visible = false;
                    documentPreview1.Visible = false;
                    var response = Get(_SelectedCommand.URL, _SelectedCommand.Parameters.ToList(), loginResponse.access_token);
                    switch (response.Item1)
                    {
                        case "application/json":
                        case "text/plain":
                            rtbResults.Visible = true;
                            rtbResults.Text = JsonPrettify(response.Item2 as string);
                            break;
                        case "application/pdf":
                            MemoryStream stream = new MemoryStream(response.Item2 as byte[]);
                            //PdfDocument document = PdfDocument.
                            //documentPreview1.Document = DdlReader.. (stream);
                            documentPreview1.Visible = true;
                            break;
                    }
                    break;
                case ActionType.Post:
                    rtbResults.Text = JsonPrettify(Post(_SelectedCommand));
                    break;
                case ActionType.Put:
                    rtbResults.Text = JsonPrettify(Put(_SelectedCommand.URL, parameters: _SelectedCommand.Parameters, bearerToken: loginResponse.access_token, body: _SelectedCommand.Form, textBody: _SelectedCommand.Raw, contentType: "application/json"));
                    break;
                case ActionType.Patch:
                    rtbResults.Text = JsonPrettify(Patch(_SelectedCommand.URL, parameters: _SelectedCommand.Parameters, bearerToken: loginResponse.access_token, body: _SelectedCommand.Form, textBody: _SelectedCommand.Raw, contentType: "application/json"));
                    break;
            }
            Cursor = Cursors.Default;
            tsslblExecuting.Visible = false;
        }

        private void tsbtnConfigureCommands_Click(object sender, EventArgs e)
        {
            if (!_Commands.ContainsKey(selectedEnvironment))
                _Commands.Add(selectedEnvironment, new Dictionary<string, List<Command>>());
            CommandEditor dialog = new CommandEditor
            {
                Text = $"Command Editor ({selectedEnvironment})",
                Commands = _Commands[selectedEnvironment],
                TPA = tpa,
                SelectedEnvironment = selectedEnvironment
            };
            dialog.ShowDialog();
            using (StreamWriter writer = new StreamWriter(Path.Combine(Application.StartupPath, "Commands.json")))
            {
                writer.Write(JsonConvert.SerializeObject(_Commands));
                writer.Flush();
                writer.Close();
            }
            FillCommands();
        }

        private void localToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _User = default;
            if (_Users.ContainsKey(tpa.ToUpper()))
            {
                _User = _Users[tpa.ToUpper()];
                tsslblUserId.Text = _User.Item1;
            }
            else
            {
                _User = default;
                tsslblUserId.Text = "";
            }
            tvLogFiles.Nodes.Clear();
            foreach (ToolStripMenuItem item in tsmiEnvironment.DropDownItems)
                item.Checked = false;
            ToolStripMenuItem mi = sender as ToolStripMenuItem;
            selectedEnvironment = mi.Text;
            mi.Checked = true;
            SetURLs();
            tsslblEnvironment.Text = mi.Text;
            Settings.Default.Environemt = selectedEnvironment;
            Settings.Default.Save();
            FillCommands();
            SetTestSuites();
            SetLoadTests();
            lbxLogEntries.Items.Clear();
            tvPerformance.Nodes.Clear();
        }

        private void SetURLs()
        {
            if (selectedEnvironment == "Local")
            {
                claimUrl = ConfigurationManager.AppSettings["LocalHostClaimURL"];
                contractUrl = ConfigurationManager.AppSettings["LocalHostContractURL"];
                webLoginUrl = ConfigurationManager.AppSettings["LocalWebLoginURL"];
                connectionString = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;
            }
            else
            {
                claimUrl = $"{ConfigurationManager.AppSettings[selectedEnvironment]}/api/{ConfigurationManager.AppSettings["Version"]}/{tpa}/claims";
                contractUrl = $"{ConfigurationManager.AppSettings[selectedEnvironment]}/api/{ConfigurationManager.AppSettings["Version"]}/{tpa}/contract";
                scsPermissionsUrl = $"{ConfigurationManager.AppSettings[selectedEnvironment]}/api/scspermissions";
                webLoginUrl = $"{ConfigurationManager.AppSettings[selectedEnvironment]}/login/connect/token";
                connectionString = ConfigurationManager.ConnectionStrings[selectedEnvironment]?.ConnectionString;
            }
        }

        private void FillCommands()
        {
            tvCommands.Nodes.Clear();
            if (_Commands?.ContainsKey(selectedEnvironment) ?? false)
            {
                foreach (string group in _Commands[selectedEnvironment].Keys)
                {
                    TreeNode node = tvCommands.Nodes.Add(group);
                    foreach (Command command in _Commands[selectedEnvironment][group])
                    {
                        int inx = node.Nodes.Add(new TreeNode { Text = command.Name, Tag = command });
                        if (_SelectedCommand != null && command.Name == _SelectedCommand.Name)
                            node.Nodes[inx].EnsureVisible();
                    }
                }
            }
        }

        public string GetToken()
        {
            if (_User != default)
            {
                List<KeyValuePair<string, string>> body = new List<KeyValuePair<string, string>>();
                body.Add(new KeyValuePair<string, string>("client_id", _User.Item1));
                body.Add(new KeyValuePair<string, string>("client_secret", _User.Item2));
                body.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
                body.Add(new KeyValuePair<string, string>("scope", "Claim Contract ScsPermission"));
                string response = Post(webLoginUrl, body: body, contentType: "application/x-www-form-urlencoded");
                if (response.StartsWith("<"))
                {
                    loginResponse = null;
                    tsslblToken.Text = "Failed";
                    tsslblToken.BackColor = Color.Red;
                    return response;
                }
                loginResponse = JsonConvert.DeserializeObject<LoginResponse>(response);
                loginResponse.Date = DateTime.Now;
                tsslblToken.Text = loginResponse.access_token != null ? "Aquired" : "Not aquired";
                tsslblToken.BackColor = loginResponse.access_token != null ? Color.Green : Color.Red;
                return loginResponse.access_token;
            }
            MessageBox.Show($"There is no user for {tpa}", "Missing Infomation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tsslblToken.Text = "No User";
            tsslblToken.BackColor = Color.Red;
            return "";
        }

        private void tsbtnSelectGolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                SelectedPath = tstxtbFolder.Text
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tstxtbFolder.Text = dialog.SelectedPath;
                Settings.Default.Path = dialog.SelectedPath;
                Settings.Default.Save();
            }
        }

        private void tstxtbFolder_TextChanged(object sender, EventArgs e)
        {
            lbxFiles.Items.Clear();
            if (!string.IsNullOrEmpty(tstxtbFolder.Text))
            {
                //Get the json files from the folder.
                string[] files = Directory.GetFiles(tstxtbFolder.Text, "*.json");
                foreach (string file in files)
                {
                    lbxFiles.Items.Add(Path.GetFileName(file));
                }
            }
        }

        private void lbxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader(Path.Combine(tstxtbFolder.Text, lbxFiles.SelectedItem as string)))
            {
                var requestJson = JsonConvert.DeserializeObject(reader.ReadToEnd());
                Newtonsoft.Json.Linq.JToken firstChild = (requestJson as Newtonsoft.Json.Linq.JObject).First;
                string path = firstChild.Path;
                while (!path.Contains("Request"))
                {
                    firstChild = firstChild.First;
                    path = firstChild.Path;
                };
                fctxtbRaw.Text = JsonPrettify(firstChild.First.ToString());
            }
            fctxtbResult.Text = "";
        }

        private void tscmbxAPi_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtbURL.Text = tscmbxAPi.SelectedItem as string == "Claim" ? $"{claimUrl}/{Settings.Default.URLParameter}" : $"{contractUrl}/{Settings.Default.URLParameter}";
            Settings.Default.API = tscmbxAPi.SelectedItem as string;
            Settings.Default.Save();
        }

        private void rbtnPut_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPost.Checked)
            {
                tsbtnExecute.Text = "Post payload";// :  ? "Put payload" : "Get";
                Settings.Default.Action = "Post";
            }
            else if (rbtnPut.Checked)
            {
                tsbtnExecute.Text = "Put payload";
                Settings.Default.Action = "Put";
            }
            else if (rbtnGet.Checked)
            {
                tsbtnExecute.Text = "Get payload";
                Settings.Default.Action = "Get";
            }
            Settings.Default.Save();
        }

        private void tsbtnExecute_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            tsslblExecuting.Visible = true;
            fctxtbResult.Text = "";
            Application.DoEvents();
            if (loginResponse == null || !loginResponse.IsTokenurrent)
                GetToken();
            Command command = new Command
            {
                Action = rbtnPost.Checked ? ActionType.Post : ActionType.Put,
                Raw = fctxtbRaw.Text,
                URL = txtbURL.Text,
            };
            if (rbtnPost.Checked)
                fctxtbResult.Text = JsonPrettify(Post(command));
            else if (rbtnPut.Checked)
                fctxtbResult.Text = JsonPrettify(Put(command));
            //else 
            //    fctxtbResult.Text = JsonPrettify(Get(command));
            Cursor = Cursors.Default;
            tsslblExecuting.Visible = false;
        }

        private void tsbtnQueryData_Click(object sender, EventArgs e)
        {
            string[] parts = txtbURL.Text.Split('/');

            DatabaseForm dialog = new DatabaseForm
            {
                ConnectionString = connectionString,
                Parameter = $"{tscmbxAPi.SelectedItem} number",
                ParameterValue = parts.Last(),
                StartPosition = FormStartPosition.CenterParent
            };
            dialog.ShowDialog();
        }

        private void tsbtnZoomIn_Click(object sender, EventArgs e)
        {
            Font font = fctxtbResult.Font;
            float size = font.Size + 1;
            fctxtbResult.Font = new Font(font.FontFamily, size);
            fctxtbRaw.Font = new Font(font.FontFamily, size);
            rtbResults.Font = new Font(font.FontFamily, size);
            commandEditorControl1.ZoomIn();
        }

        private void tsbtnZoomOut_Click(object sender, EventArgs e)
        {
            Font font = fctxtbResult.Font;
            float size = font.Size - 1;
            fctxtbResult.Font = new Font(font.FontFamily, size);
            fctxtbRaw.Font = new Font(font.FontFamily, size);
            rtbResults.Font = new Font(font.FontFamily, size);
            commandEditorControl1.ZoomOut();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Font font = rtbResults.Font;
            float size = font.Size + 1;
            rtbResults.Font = new Font(font.FontFamily, size);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Font font = rtbResults.Font;
            float size = font.Size + 1;
            rtbResults.Font = new Font(font.FontFamily, size);
        }

        private void txtbURL_TextChanged(object sender, EventArgs e)
        {
            string[] parts = txtbURL.Text.Split('/');
            Settings.Default.URLParameter = parts.Last();
        }

        private void tvCommands_AfterSelect(object sender, TreeViewEventArgs e)
        {
            rtbResults.Visible = false;
            documentPreview1.Visible = false;
            pnlImage.Visible = false;
            selectionChanging = true;
            tslblCommandName.Text = "";
            tsslblMessage.Text = "";
            tsslblResultCode.Text = "";
            tscmbxVerbs.SelectedIndex = -1;
            tstxtbURL.Text = "";
            tcCommand.SelectedTab = tpCommandConfig;
            rtbResults.Text = "";
            _SelectedCommand = e.Node.Tag as Command;
            commandEditorControl1.Command = _SelectedCommand;
            tsbtnRun.Enabled = _SelectedCommand != null;
            addNewCommandToolStripMenuItem.Enabled = e.Node != null;
            deleteSelectedCommandToolStripMenuItem.Enabled = _SelectedCommand != null;
            cloneSelectedCommandToolStripMenuItem.Enabled = _SelectedCommand != null; ;
            if (_SelectedCommand != null)
            {
                tslblCommandName.Text = _SelectedCommand.Name;
                tstxtbURL.Text = _SelectedCommand.URL;
                tscmbxVerbs.SelectedItem = _SelectedCommand.Action == ActionType.Get ? "GET" :
                    _SelectedCommand.Action == ActionType.Post ? "POST" :
                    "PUT";
                if (!string.IsNullOrEmpty(_SelectedCommand.FilePath))
                    _SelectedCommand.Raw = commandEditorControl1.GetRaw();
            }
            selectionChanging = false;
            tslblFileName.Text = "";
            tsbtnViewFile.Enabled = false;
        }

        private void tsbtnRun_Click(object sender, EventArgs e)
        {
            tcCommand.SelectedTab = tpResponse;
            tsslblResultCode.Text = "";
            tsslblMessage.Text = "";
            Cursor = Cursors.WaitCursor;
            tsslblExecuting.Visible = true;
            rtbResults.Text = "";
            Application.DoEvents();
            if (loginResponse == null || !loginResponse.IsTokenurrent)
                GetToken();
            var results = RunCommand(_SelectedCommand);
            switch (_SelectedCommand.Action)
            {
                case ActionType.Get:
                    rtbResults.Visible = false;
                    documentPreview1.Visible = false;
                    pnlImage.Visible = false;
                    tsbtnViewAsImage.Enabled = false;
                    if (!string.IsNullOrEmpty(results.Item1))
                    {
                        rtbResults.Visible = true;
                        rtbResults.Text = results.Item1;
                    }
                    if (results.Item2 is MemoryStream)
                    {
                        MemoryStream memoryStream = results.Item2 as MemoryStream;
                        //documentPreview1.LoadFromStream(memoryStream);
                        documentPreview1.Visible = true;
                        if (!Directory.Exists(Settings.Default.OutputFolder))
                            Directory.CreateDirectory(Settings.Default.OutputFolder);
                        PdfDocument doc = PdfReader.Open(memoryStream);
                        doc.Save(Path.Combine(Settings.Default.OutputFolder, "Output.pdf"));

                    }
                    if (results.Item2 is string)
                    {
                        string path = results.Item2 as string;
                        if (path.ToLower().Contains("doc"))
                        {
                            tslblFileName.Text = path;
                            tsbtnViewFile.Enabled = true;
                            applicationName = "winword.exe";
                        }
                        else if (path.ToLower().Contains("xls"))
                        {
                            tslblFileName.Text = path;
                            tsbtnViewFile.Enabled = true;
                            applicationName = "winword.exe";
                        }
                        else
                        {
                            tsbtnViewAsImage.Enabled = true;
                        }
                    }
                    if (results.Item2 is Image)
                    {
                        pnlImage.Visible = true;
                        pnlImage.BackgroundImage = results.Item2 as Image;
                    }
                    break;
                case ActionType.Post:
                case ActionType.Put:
                case ActionType.Patch:
                    rtbResults.Visible = true;
                    rtbResults.Text = results.Item1;
                    break;
            }
            Cursor = Cursors.Default;
            tsslblExecuting.Visible = false;
        }

        private (string, object) RunCommand(Command command)
        {
            switch (command.Action)
            {
                case ActionType.Get:
                    var response = Get(command.URL, command.Parameters.ToList(), loginResponse.access_token);
                    switch (response.Item1)
                    {
                        case "application/json":
                            return (JsonPrettify(response.Item2 as string), null);
                        case "text/plain":
                        case "text/richtext":
                            return (Encoding.Default.GetString(rawResponse), response.Item1);
                        case "application/pdf":
                            MemoryStream stream = new MemoryStream(rawResponse);
                            return ("", stream);
                        case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                            if (!string.IsNullOrEmpty(fileName))
                            {
                                using (FileStream file = new FileStream(Path.Combine(downloadDirectory, fileName), FileMode.OpenOrCreate))
                                {
                                    file.Write(response.Item2 as byte[], 0, rawResponse.Length);
                                }
                            }
                            return ("Click the button to view the file", Path.Combine(downloadDirectory, fileName));
                        case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet":
                            if (!string.IsNullOrEmpty(fileName))
                            {
                                using (FileStream file = new FileStream(Path.Combine(downloadDirectory, fileName), FileMode.OpenOrCreate))
                                {
                                    file.Write(response.Item2 as byte[], 0, rawResponse.Length);
                                }
                            }
                            return ("Click the button to view the file", Path.Combine(downloadDirectory, fileName));
                        case "image/gif":
                        case "image /tif":
                        case "image/tiff":
                        case "image/bmp":
                        case "image/png":
                        case "image/jpeg":
                        case "image/pjpg":
                            Image img = null;
                            try
                            {
                                using (MemoryStream imageStream = new MemoryStream(rawResponse))
                                    img = Image.FromStream(imageStream);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("The data does not represent an image.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                pnlImage.Visible = false;
                                rtbResults.Visible = true;
                            }
                            return ("", img);
                    }
                    break;
                case ActionType.Post:
                    return (JsonPrettify(Post(command)), null);
                case ActionType.Put:
                    return (JsonPrettify(Put(command.URL, parameters: command.Parameters, bearerToken: loginResponse.access_token, body: command.Form, textBody: command.Raw, contentType: "application/json")), null);
                case ActionType.Patch:
                    return (JsonPrettify(Patch(command.URL, parameters: command.Parameters, bearerToken: loginResponse.access_token, body: command.Form, textBody: command.Raw, contentType: "application/json")), null);
            }
            return ("", null);
        }

        private void deleteSelectedCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvCommands.SelectedNode;
            while (selectedNode.Parent != null)
                selectedNode = selectedNode.Parent;
            selectedGroup = selectedNode.Text;
            _Commands[selectedEnvironment][selectedGroup].Remove(_SelectedCommand);
            FillCommands();
        }

        private void addNewCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvCommands.SelectedNode;
            while (selectedNode.Parent != null)
                selectedNode = selectedNode.Parent;
            selectedGroup = selectedNode.Text;
            tcCommand.SelectedTab = tpCommandConfig;
            _SelectedCommand = new Command();
            _SelectedCommand.URL = ConfigurationManager.AppSettings[selectedEnvironment == "Local" ? "LocalHostClaimURL" : selectedEnvironment];
            commandEditorControl1.Command = _SelectedCommand;
            _Commands[selectedEnvironment][selectedGroup].Add(_SelectedCommand);
        }

        private void cloneSelectedCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvCommands.SelectedNode;
            while (selectedNode.Parent != null)
                selectedNode = selectedNode.Parent;
            selectedGroup = selectedNode.Text;
            tcCommand.SelectedTab = tpCommandConfig;
            _SelectedCommand = _SelectedCommand.Clone();
            commandEditorControl1.Command = _SelectedCommand;
            _Commands[selectedEnvironment][selectedGroup].Add(_SelectedCommand);
        }

        private void commandEditorControl1_URLChanged(object sender, EventArgs e)
        {
            if (!selectionChanging)
                tstxtbURL.Text = _SelectedCommand.URL;
        }

        private void tstxtbURL_TextChanged(object sender, EventArgs e)
        {
            if (!selectionChanging)
                _SelectedCommand.URL = tstxtbURL.Text;
        }

        private void tsbtnSaveCommand_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(Application.StartupPath, "Commands.json")))
            {
                writer.Write(JsonConvert.SerializeObject(_Commands));
                writer.Flush();
                writer.Close();
            }
            FillCommands();
        }

        private void tsslblDownloadDirectory_DoubleClick(object sender, EventArgs e)
        {
        }

        private void tstxtbTPA_Leave(object sender, EventArgs e)
        {
            tpa = tstxtbTPA.Text;
            if (_Users.ContainsKey(tpa.ToUpper()))
            {
                _User = _Users[tpa.ToUpper()];
                tsslblUserId.Text = _User.Item1;
            }
            else
            {
                _User = default;
                tsslblUserId.Text = "";
            }
            Settings.Default.Save();
        }

        private void tsbtnViewAsImage_Click(object sender, EventArgs e)
        {
            pnlImage.Visible = true;
            rtbResults.Visible = false;
            documentPreview1.Visible = false;
            try
            {
                using (MemoryStream imageStream = new MemoryStream(rawResponse))
                    pnlImage.BackgroundImage = Image.FromStream(imageStream);
            }
            catch (Exception)
            {
                MessageBox.Show("The data does not represent an image.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pnlImage.Visible = false;
                rtbResults.Visible = true;
            }
        }

        private void tsbtnStartTest_Click(object sender, EventArgs e)
        {
            tsslblProgress.Visible = true;
            tspbProgress.Visible = true;
            tspbProgress.Value = 0;
            chart1.Series[0].Points.Clear();
            fctxtbLog.Text = "";
            errorCount = 0;
            maxTasks = 0;
            lblAverageDuration.Text = "Average duration 0 ms";
            ActiveTasks = new List<Task<(bool, object)>>();
            _Durations = new List<double>();

            int numTasks = 0;
            DateTime startTime = DateTime.Now;
            //get the test parameters
            int timeBetweenCalls;
            if (!int.TryParse(txtbTBC.Text, out timeBetweenCalls))
            {
                //throw an error
            }
            if (rbtnTime.Checked)
            {
                double duration;
                if (double.TryParse(txtbTestDuration.Text, out duration))
                {
                    while (startTime.AddHours(duration) < DateTime.Now)
                    {
                        numTasks++;
                        //make a call
                        if (loginResponse == null || !loginResponse.IsTokenurrent)
                            GetToken();
                        Task<(bool, object)> task = GetAsync(txtbTestURL.Text, bearerToken: loginResponse.access_token);
                        ActiveTasks.Add(task);
                        //Wait for time between cals
                        DateTime st = DateTime.Now;
                        while (DateTime.Now.Subtract(st).TotalMilliseconds < timeBetweenCalls)
                        {
                            Application.DoEvents();
                        }
                        CheckTasks(startTime, numTasks);
                    }
                }
                else
                {
                    //throw an error
                }
                while (ActiveTasks.Count > 0)
                    CheckTasks(startTime, numTasks);
                fctxtbLog.Text = errorLog.ToString();
            }
            else if (rbtnNumberOfCalls.Checked)
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chart1.Series[0].Name = "Number of calls per 100 ms";
                int numberOfCalls;
                if (int.TryParse(txtbNumCalls.Text, out numberOfCalls))
                {
                    tspbProgress.Maximum = numberOfCalls;
                    for (int i = 0; i < numberOfCalls; i++)
                    {
                        //make a call
                        if (loginResponse == null || !loginResponse.IsTokenurrent)
                            GetToken();
                        Task<(bool, object)> task = GetAsync(txtbTestURL.Text, bearerToken: loginResponse.access_token);
                        ActiveTasks.Add(task);
                        //Wait for time between cals
                        DateTime st = DateTime.Now;
                        while (DateTime.Now.Subtract(st).TotalMilliseconds < timeBetweenCalls)
                        {
                            Application.DoEvents();
                        }
                        numTasks = i + 1;
                        tspbProgress.Value = i;
                        tsslblProgress.Text = $"{i + 1} of {numberOfCalls}";
                        CheckTasks(startTime, numTasks);
                    }
                }
                while (ActiveTasks.Count > 0)
                    CheckTasks(startTime, numTasks);
                fctxtbLog.Text = errorLog.ToString();
                //draw a distribution chart
                Dictionary<int, int> distributions = new Dictionary<int, int>();
                double total = 0;
                foreach (double duration in _Durations)
                {
                    total += duration;
                    int dur = (int)duration / 100;
                    if (distributions.ContainsKey(dur))
                    {
                        distributions[dur]++;
                    }
                    else
                    {
                        distributions.Add(dur, 1);
                    }
                }
                lblAverageDuration.Text = $"Average duration {total / _Durations.Count:#0.00} ms";
                foreach (int key in distributions.Keys)
                    chart1.Series[0].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(key * 100, distributions[key]));
            }
            else if (rbtnMultipleLoads.Checked)
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series[0].BorderWidth = 5;
                chart1.Series[0].Name = "Average duration per calls per second";
                _MultyDurations = new Dictionary<int, List<double>>();
                int numberOfCalls;
                if (int.TryParse(txtbNumCalls.Text, out numberOfCalls))
                {
                    tspbProgress.Maximum = numberOfCalls;

                    int tbc = 1000 / _SelectedTPALoadTest.StartLoad;
                    int numLoads = (_SelectedTPALoadTest.EndLoad - _SelectedTPALoadTest.StartLoad) / _SelectedTPALoadTest.LoadIncrement + 1;
                    int loadTestNumber = 0;
                    while (tbc >= 1000 / _SelectedTPALoadTest.EndLoad)
                    {
                        tspbProgress.Value = 0;
                        tsslblProgress.Text = $"Load test {loadTestNumber} of {numLoads}. Call 0 of {numberOfCalls}";
                        _Durations = new List<double>();
                        _MultyDurations.Add(_SelectedTPALoadTest.StartLoad + (loadTestNumber * _SelectedTPALoadTest.LoadIncrement), _Durations);
                        loadTestNumber++;
                        for (int i = 0; i < numberOfCalls; i++)
                        {
                            //make a call
                            if (loginResponse == null || !loginResponse.IsTokenurrent)
                                GetToken();
                            Task<(bool, object)> task = GetAsync(txtbTestURL.Text, bearerToken: loginResponse.access_token);
                            ActiveTasks.Add(task);
                            //Wait for time between cals
                            DateTime st = DateTime.Now;
                            while (DateTime.Now.Subtract(st).TotalMilliseconds < tbc)
                            {
                                Application.DoEvents();
                            }
                            tspbProgress.Value = i;
                            tsslblProgress.Text = $"Load test {loadTestNumber} of {numLoads}. Call {i} of {numberOfCalls}";
                            Application.DoEvents();
                        }
                        while (ActiveTasks.Count > 0)
                            CheckTasks(startTime, numTasks);
                        tbc = 1000 / (_SelectedTPALoadTest.StartLoad + (loadTestNumber * _SelectedTPALoadTest.LoadIncrement));
                    }
                }
                fctxtbLog.Text = errorLog.ToString();
                //calcuate the average of each load tesr run
                foreach (int key in _MultyDurations.Keys)
                {
                    double total = 0;
                    foreach (int duration in _MultyDurations[key])
                    {
                        total += duration;
                    }
                    double avarage = total / _MultyDurations[key].Count;
                    chart1.Series[0].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(key, avarage));
                }
            }
            tsslblProgress.Visible = false;
            tspbProgress.Visible = false;
        }

        private void CheckTasks(DateTime startTime, int cnt)
        {
            for (int i = 0; i < ActiveTasks.Count; i++)
            {
                if (ActiveTasks[i].IsCompleted)
                {
                    if (!ActiveTasks[i].Result.Item1)
                    {
                        errorCount++;
                        if (ActiveTasks[i].Result.Item2 != null)
                            errorLog.AppendLine((ActiveTasks[i].Result.Item2 as HttpResponseMessage).ReasonPhrase);
                    }
                    ActiveTasks.RemoveAt(i--);
                }
            }
            maxTasks = maxTasks < ActiveTasks.Count ? ActiveTasks.Count : maxTasks;
            lblActiveTasks.Text = $"Number of active tasks = {ActiveTasks.Count}";
            lblNumCallsMade.Text = $"Number of calls made ={cnt}";
            TimeSpan duration = DateTime.Now.Subtract(startTime);
            lblDudation.Text = $"Running form {duration}";
            lblErrors.Text = $"Number of errors ={errorCount}";
            lblMaxTasks.Text = $"Maximum number of concurrent tasks ={maxTasks}";
            Application.DoEvents();
        }

        private void lbxSequence_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_SuppressEvents)
                return;
            _SelectedStep = lbxSequence.SelectedItem as Step;
            commandEditorControl2.Command = _SelectedStep?.Command;
            tsbtnDeleteStep.Enabled = _SelectedStep != null;
        }

        private void tscmbxSequences_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbxSequence.Items.Clear();
            _SelectedSequence = tscmbxSequences.SelectedItem as Sequence;
            tsbtnDeleteSequence.Enabled = _SelectedSequence != null;
            tsbtnAddStep.Enabled = _SelectedSequence != null;
            tsbtnStartSequence.Enabled = _SelectedSequence != null;
            if (_SelectedSequence != null)
            {
                foreach (Step step in _SelectedSequence.Steps)
                    lbxSequence.Items.Add(step);
            }
        }

        private void tsbtnAddSequence_Click(object sender, EventArgs e)
        {
            //Add a new sequence
            InputDialog dialog = new InputDialog { ShowActionButton = false };
            if (dialog.Show("Sequence", "Sequence Name", InputType.Text) == DialogResult.OK)
            {
                Sequence sequence = new Sequence
                {
                    Name = dialog.InputText,
                    Steps = new List<Step>()
                };
                _Sequences.Add(sequence);
                tscmbxSequences.Items.Add(sequence);
                tscmbxSequences.SelectedItem = sequence;
            }
        }

        private void tsbtnDeleteSequence_Click(object sender, EventArgs e)
        {
            //Delete selected sequence
            _Sequences.Remove(_SelectedSequence);
        }

        private void tsbtnAddStep_Click(object sender, EventArgs e)
        {
            //Add a new step
            Step newStep = new Step
            {
                Ordinal = _SelectedSequence.Steps.Count,
                Command = new Command
                {
                    URL = claimUrl
                }
            };
            _SelectedSequence.Steps.Add(newStep);
            lbxSequence.Items.Add(newStep);
            lbxSequence.SelectedItem = newStep;
        }

        private void tsbtnDeleteStep_Click(object sender, EventArgs e)
        {
            //Delete selected step
            _SelectedSequence.Steps.Remove(_SelectedStep);
        }

        private void tsbtnSequenceZoomIn_Click(object sender, EventArgs e)
        {
            commandEditorControl2.ZoomIn();
        }

        private void tsbtnSequenceZoomOut_Click(object sender, EventArgs e)
        {
            commandEditorControl2.ZoomOut();
        }

        private void tsbtnStartSequence_Click(object sender, EventArgs e)
        {
            dgvSequenceResults.Rows.Clear();
            if (loginResponse == null || !loginResponse.IsTokenurrent)
                GetToken();
            //Run the sequence
            foreach (Step step in _SelectedSequence.Steps)
            {
                DateTime startTime = DateTime.Now;
                var result = RunCommand(step.Command);
                TimeSpan duration = DateTime.Now.Subtract(startTime);
                int rowIndex = dgvSequenceResults.Rows.Add(step.Name, duration, result.Item1);
                dgvSequenceResults.Rows[rowIndex].Tag = result.Item2;
            }
        }

        private void tsbtnSequenceSave_Click(object sender, EventArgs e)
        {
            //Save the sequences
            using (StreamWriter commandFile = new StreamWriter(Path.Combine(Application.StartupPath, "Sequences.json")))
            {
                commandFile.Write(JsonConvert.SerializeObject(_Sequences));
            }
        }

        private void commandEditorControl2_NameChanged(object sender, EventArgs e)
        {
            _SuppressEvents = true;
            int index = lbxSequence.SelectedIndex;
            lbxSequence.Items.RemoveAt(index);
            lbxSequence.Items.Insert(index, _SelectedStep);
            lbxSequence.SelectedIndex = index;
            _SuppressEvents = false;
        }

        private void dgvSequenceResults_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // display the result in a window
        }

        private void tsbtnUserCredentials_Click(object sender, EventArgs e)
        {
            //get the user credentials
            MultiValueInputDialog dialog = new MultiValueInputDialog
            {
                Text = "Get User Credentials"
            };
            dialog.Fields.AddRange(
                new[]
                {
                    new Field
                    {
                        Caption = "User Id",
                        InputType = s.InputType.String,
                        Value = _User != default ?  _User.Item1 : ""
                    },
                    new Field
                    {
                        Caption = "User Secret",
                        InputType = s.InputType.String,
                        Value =  _User != default ? _User.Item2 : "",
                        PasswordChar = '*'
                    }
                });
            dialog.BuildUI();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _User = (dialog.Fields.Where(f => f.Caption == "User Id").FirstOrDefault().Value as string, dialog.Fields.Where(f => f.Caption == "User Secret").FirstOrDefault().Value as string);
                tsslblUserId.Text = _User.Item1;
                _Users[tpa] = _User;
                SetUsers();
            }
        }

        private void SetUsers()
        {
            StringBuilder usersString = new StringBuilder();
            bool isFirst = true;
            foreach (string key in _Users.Keys)
            {
                if (isFirst)
                    isFirst = false;
                else
                    usersString.Append(";");
                usersString.Append($"{key},{_Users[key].Item1},{_Users[key].Item2}");
            }
            Settings.Default.Users = usersString.ToString();
            Settings.Default.Save();
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            //Load the files
            switch (selectedEnvironment)
            {
                case "Local":
                    logFolder = Path.Combine(ConfigurationManager.AppSettings["LocalLogFolder"], "FI.Claim");
                    break;
                case "QA-Manual":
                    logFolder = Path.Combine(ConfigurationManager.AppSettings["QALogFolder"], "qa-manual", "FI.Claim");
                    break;
                case "QA-Automation":
                    logFolder = Path.Combine(ConfigurationManager.AppSettings["QALogFolder"], "qa-automation", "FI.Claim");
                    break;
                case "Release-Manual":
                    logFolder = Path.Combine(ConfigurationManager.AppSettings["ReleaseLogFolder"], "release-manual", "FI.Claim");
                    break;
                case "Release-Automation":
                    logFolder = Path.Combine(ConfigurationManager.AppSettings["ReleaseLogFolder"], "Release-automation", "FI.Claim");
                    break;
                case "UAT":
                    logFolder = Path.Combine(ConfigurationManager.AppSettings["UATLogFolder"], "FI.Claim");
                    break;
            }
            FillLogFiles();
        }

        private void FillLogFiles()
        {
            tvLogFiles.Nodes.Clear();
            if (Directory.Exists(logFolder))
            {
                string[] logFiles = Directory.GetFiles(logFolder, "*.json");
                foreach (string logFile in logFiles)
                {
                    string logFileName = Path.GetFileNameWithoutExtension(logFile);
                    string[] nameParts = logFileName.Split('$');
                    if (nameParts.Length == 4)
                    {
                        if (!logFileName.Contains("_payload"))
                        {
                            DateTime fileDate;
                            if (DateTime.TryParse($"{nameParts[3].Substring(0, 4)}-{nameParts[3].Substring(4, 2)}-{nameParts[3].Substring(6, 2)}", out fileDate))
                            {
                                if (fileDate > minDate)
                                {
                                    string date = $"{fileDate.Date:yyyy-MM-dd}";
                                    TreeNode dateNode;
                                    if (!tvLogFiles.Nodes.ContainsKey(date))
                                    {
                                        dateNode = tvLogFiles.Nodes.Add(date, date);
                                    }
                                    else
                                    {
                                        dateNode = tvLogFiles.Nodes[date];
                                    }
                                    TreeNode fileNode = new TreeNode
                                    {
                                        Text = logFileName,
                                        Tag = logFile
                                    };
                                    dateNode.Nodes.Add(fileNode);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void lbxLogFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbxLogEntries.Items.Clear();
            if (tvLogFiles.SelectedNode != null)
            {
                using (FileStream stream = File.Open(Path.Combine(logFolder, tvLogFiles.SelectedNode.Tag as string), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            JObject json = JObject.Parse(line);
                            var time = json.SelectToken("@t");
                            lbxLogEntries.Items.Add((time, line));
                        }
                    }
                }
            }
        }

        private void lbxLogEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            fcrtxtbLogView.Text = "";
            fctxtbStackTrace.Text = "";
            if (lbxLogEntries.SelectedItem != null)
            {
                var logEntry = lbxLogEntries.SelectedItem;
                string jsonString = (((JToken, string))logEntry).Item2;
                fcrtxtbLogView.Text = JsonPrettify(jsonString);
                JObject json = JObject.Parse(jsonString);
                var stackTrace = json.SelectToken("@x");
                if (stackTrace != null)
                    fctxtbStackTrace.Text = stackTrace.ToString().Replace("\\r\\n", "\r\n");
            }
            else
                fctxtbLog.Text = "";
        }

        private void tsbtnAddTPA_Click(object sender, EventArgs e)
        {
            InputDialog dialog = new InputDialog();
            if (dialog.Show("TPA Code") == DialogResult.OK)
            {
                if (_TestSuites == null) _TestSuites = new Dictionary<string, Dictionary<string, TPATestSuite>>();
                {
                    _SelectedTPATestSuite = new TPATestSuite { Name = dialog.InputText };
                    Dictionary<string, TPATestSuite> testSuite = new Dictionary<string, TPATestSuite>();
                }
                Dictionary<string, TPATestSuite> environmentSuites = _TestSuites.Where(s => s.Key == selectedEnvironment).FirstOrDefault().Value;
                if (environmentSuites == null)
                {
                    environmentSuites = new Dictionary<string, TPATestSuite>();
                    _TestSuites.Add(selectedEnvironment, environmentSuites);
                }
                if (!environmentSuites.ContainsKey(dialog.InputText))
                    environmentSuites.Add(dialog.InputText, _SelectedTPATestSuite);
                if (selectedEnvironment != "Other")
                {
                    _SelectedTPATestSuite.BaseUrl = $"{ConfigurationManager.AppSettings[selectedEnvironment]}/api/{ConfigurationManager.AppSettings["Version"]}";
                    _SelectedTPATestSuite.LoginUrl = $"{ConfigurationManager.AppSettings[selectedEnvironment]}/login/connect/token";
                }
                int index = cmbxTPA.Items.Add(dialog.InputText);
                cmbxTPA.SelectedIndex = index;
                PopulateTestSuite();
            }
        }

        private void PopulateTestSuite()
        {
            txtbBaseURL.Text = _SelectedTPATestSuite.BaseUrl;
            txtbUserId.Text = _SelectedTPATestSuite.Credentials?.UserId;
            txtbUserSecret.Text = _SelectedTPATestSuite.Credentials?.Password;
            txtbLoginURL.Text = _SelectedTPATestSuite.LoginUrl;
        }

        private void tsbtnSavePerformnceCommands_Click(object sender, EventArgs e)
        {
            //Save the test suites
            using (StreamWriter writer = new StreamWriter(Path.Combine(Application.StartupPath, "TestSuits.json")))
            {
                writer.Write(JsonConvert.SerializeObject(_TestSuites));
                writer.Flush();
                writer.Close();
            }
        }

        private void rbtnGetAllClaims_CheckedChanged(object sender, EventArgs e)
        {
            fctxtbIncomingPayload.Text = "";
            tabControl3.SelectedIndex = 0;
            _SelectedCommand = null;
            if (rbtnGetAllClaims.Checked)
            {
                if (_SelectedTPATestSuite.Commands == null)
                {
                    _SelectedTPATestSuite.Commands = new List<Command>();
                    _SelectedCommand = new GetAllClaims(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name);
                    _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
                }
                _SelectedCommand = _SelectedTPATestSuite.Commands.Where(f => f.Name == "Get All Claims").FirstOrDefault();
                if (_SelectedCommand == null)
                {
                    _SelectedCommand = new GetAllClaims(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name);
                    _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
                }
            }
            cePerformance.Command = _SelectedCommand;
            tsbtnRunPerformanceCommand.Enabled = _SelectedCommand != null;
        }

        private void rbtnGetSingleClaim_CheckedChanged(object sender, EventArgs e)
        {
            fctxtbIncomingPayload.Text = "";
            tabControl3.SelectedIndex = 0;
            _SelectedCommand = null;
            if (rbtnGetSingleClaim.Checked)
            {
                if (_SelectedTPATestSuite.Commands == null)
                {
                    _SelectedTPATestSuite.Commands = new List<Command>();
                }
                _SelectedCommand = _SelectedTPATestSuite.Commands.Where(f => f.Name == "Get Single Claim").FirstOrDefault();
                if (_SelectedCommand == null)
                {
                    InputDialog dialog = new InputDialog();
                    string claimNumber = "{cliam number}";
                    if (dialog.Show("Claim Number", "Please Provide the claim number") == DialogResult.OK)
                        claimNumber = dialog.InputText;
                    _SelectedCommand = new GetSingleClaim(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name, claimNumber);
                    _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
                }
            }
            cePerformance.Command = _SelectedCommand;
            tsbtnRunPerformanceCommand.Enabled = _SelectedCommand != null;
        }

        private void rbtnGetDocument_CheckedChanged(object sender, EventArgs e)
        {
            fctxtbIncomingPayload.Text = "";
            tabControl3.SelectedIndex = 0;
            _SelectedCommand = null;
            if (rbtnGetDocument.Checked)
            {
                if (_SelectedTPATestSuite.Commands == null)
                {
                    _SelectedTPATestSuite.Commands = new List<Command>();
                }
                _SelectedCommand = _SelectedTPATestSuite.Commands.Where(f => f.Name == "Get Incoming Document").FirstOrDefault();
                if (_SelectedCommand == null)
                {
                    InputDialog dialog = new InputDialog();
                    string documentIdentifier = "{Identifier}";
                    if (dialog.Show("Incoming Document", "Please provide the incoming document Identifier") == DialogResult.OK)
                        documentIdentifier = dialog.InputText;
                    _SelectedCommand = new GetIncomingDocument(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name, documentIdentifier);
                    _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
                }
            }
            cePerformance.Command = _SelectedCommand;
            tsbtnRunPerformanceCommand.Enabled = _SelectedCommand != null;
        }

        private void rbtnGetOutgoingDocument_CheckedChanged(object sender, EventArgs e)
        {
            fctxtbIncomingPayload.Text = "";
            tabControl3.SelectedIndex = 0;
            _SelectedCommand = null;
            if (rbtnGetOutgoingDocument.Checked)
            {
                if (_SelectedTPATestSuite.Commands == null)
                {
                    _SelectedTPATestSuite.Commands = new List<Command>();
                }
                _SelectedCommand = _SelectedTPATestSuite.Commands.Where(f => f.Name == "Get Outgoing Document").FirstOrDefault();
                if (_SelectedCommand == null)
                {
                    InputDialog dialog = new InputDialog();
                    string documentIdentifier = "{Identifier}";
                    if (dialog.Show("Outgoing Document", "Please provide the outgoing document Identifier") == DialogResult.OK)
                        documentIdentifier = dialog.InputText;
                    _SelectedCommand = new GetOutgoingDocument(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name, documentIdentifier);
                    _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
                }
            }
            cePerformance.Command = _SelectedCommand;
            tsbtnRunPerformanceCommand.Enabled = _SelectedCommand != null;
        }

        private void rbtnGetClaimDocuments_CheckedChanged(object sender, EventArgs e)
        {
            fctxtbIncomingPayload.Text = "";
            tabControl3.SelectedIndex = 0;
            _SelectedCommand = null;
            if (rbtnGetClaimDocuments.Checked)
            {
                if (_SelectedTPATestSuite.Commands == null)
                {
                    _SelectedTPATestSuite.Commands = new List<Command>();
                }
                _SelectedCommand = _SelectedTPATestSuite.Commands.Where(f => f.Name == "Get Claim Documents").FirstOrDefault();
                if (_SelectedCommand == null)
                {
                    InputDialog dialog = new InputDialog();
                    string claimNumber = "{cliam number}";
                    if (dialog.Show("Claim Number", "Please Provide the claim number") == DialogResult.OK)
                        claimNumber = dialog.InputText;
                    _SelectedCommand = new GetClaimDocuments(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name, claimNumber);
                    _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
                }
            }
            cePerformance.Command = _SelectedCommand;
            tsbtnRunPerformanceCommand.Enabled = _SelectedCommand != null;
        }

        private void rbtnGetClaimPayees_CheckedChanged(object sender, EventArgs e)
        {
            fctxtbIncomingPayload.Text = "";
            tabControl3.SelectedIndex = 0;
            _SelectedCommand = null;
            if (rbtnGetClaimPayees.Checked)
            {
                if (_SelectedTPATestSuite.Commands == null)
                {
                    _SelectedTPATestSuite.Commands = new List<Command>();
                }
                _SelectedCommand = _SelectedTPATestSuite.Commands.Where(f => f.Name == "Get Payees").FirstOrDefault();
                if (_SelectedCommand == null)
                {
                    InputDialog dialog = new InputDialog();
                    string claimNumber = "{cliam number}";
                    if (dialog.Show("Claim Number", "Please Provide the claim number") == DialogResult.OK)
                        claimNumber = dialog.InputText;
                    _SelectedCommand = new GetPayees(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name, claimNumber);
                    _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
                }
            }
            cePerformance.Command = _SelectedCommand;
            tsbtnRunPerformanceCommand.Enabled = _SelectedCommand != null;
        }

        private void rbtnGetInspectionPartners_CheckedChanged(object sender, EventArgs e)
        {
            fctxtbIncomingPayload.Text = "";
            tabControl3.SelectedIndex = 0;
            _SelectedCommand = null;
            if (rbtnGetInspectionPartners.Checked)
            {
                if (_SelectedTPATestSuite.Commands == null)
                {
                    _SelectedTPATestSuite.Commands = new List<Command>();
                }
                _SelectedCommand = _SelectedTPATestSuite.Commands.Where(f => f.Name == "Get Outgoing Document").FirstOrDefault();
                if (_SelectedCommand == null)
                {
                    _SelectedCommand = new GetInspectionPartners(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name);
                    _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
                }
            }
            cePerformance.Command = _SelectedCommand;
            tsbtnRunPerformanceCommand.Enabled = _SelectedCommand != null;
        }

        private void rbtnGetInspectionRequests_CheckedChanged(object sender, EventArgs e)
        {
            fctxtbIncomingPayload.Text = "";
            tabControl3.SelectedIndex = 0;
            _SelectedCommand = null;
            if (rbtnGetInspectionRequests.Checked)
            {
                if (_SelectedTPATestSuite.Commands == null)
                {
                    _SelectedTPATestSuite.Commands = new List<Command>();
                }
                _SelectedCommand = _SelectedTPATestSuite.Commands.Where(f => f.Name == "Get Inspections").FirstOrDefault();
                if (_SelectedCommand == null)
                {
                    InputDialog dialog = new InputDialog();
                    string claimNumber = "{cliam number}";
                    if (dialog.Show("Claim Number", "Please Provide the claim number") == DialogResult.OK)
                        claimNumber = dialog.InputText;
                    _SelectedCommand = new GetInspectionRequests(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name, claimNumber);
                    _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
                }
            }
            cePerformance.Command = _SelectedCommand;
            tsbtnRunPerformanceCommand.Enabled = _SelectedCommand != null;
        }

        private void rbtnGetInspectionHistory_CheckedChanged(object sender, EventArgs e)
        {
            fctxtbIncomingPayload.Text = "";
            tabControl3.SelectedIndex = 0;
            _SelectedCommand = null;
            if (rbtnGetInspectionHistory.Checked)
            {
                if (_SelectedTPATestSuite.Commands == null)
                {
                    _SelectedTPATestSuite.Commands = new List<Command>();
                }
                _SelectedCommand = _SelectedTPATestSuite.Commands.Where(f => f.Name == "Get Inspection History").FirstOrDefault();
                if (_SelectedCommand == null)
                {
                    InputDialog dialog = new InputDialog();
                    string claimNumber = "{cliam number}";
                    if (dialog.Show("Claim Number", "Please Provide the claim number") == DialogResult.OK)
                        claimNumber = dialog.InputText;
                    _SelectedCommand = new GetInspectionHistory(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name, claimNumber);
                    _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
                }
            }
            cePerformance.Command = _SelectedCommand;
            tsbtnRunPerformanceCommand.Enabled = _SelectedCommand != null;
        }

        private void rbtnGetCreditCard_CheckedChanged(object sender, EventArgs e)
        {
            fctxtbIncomingPayload.Text = "";
            tabControl3.SelectedIndex = 0;
            _SelectedCommand = null;
            //if (rbtnGetOutgoingDocument.Checked)
            //{
            //    if (_SelectedTPATestSuite.Commands == null)
            //    {
            //        _SelectedTPATestSuite.Commands = new List<Command>();
            //        _SelectedCommand = new GetOutgoingDocument(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name);
            //        _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
            //    }
            //    _SelectedCommand = _SelectedTPATestSuite.Commands.Where(f => f.Name == "Get Outgoing Document").FirstOrDefault();
            //    if (_SelectedCommand == null)
            //    {
            //        _SelectedCommand = new GetOutgoingDocument(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name);
            //        _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
            //    }
            //}
            cePerformance.Command = _SelectedCommand;
            tsbtnRunPerformanceCommand.Enabled = _SelectedCommand != null;
        }

        private void rbtnCreateClaim_CheckedChanged(object sender, EventArgs e)
        {
            fctxtbIncomingPayload.Text = "";
            tabControl3.SelectedIndex = 0;
            _SelectedCommand = null;
            if (rbtnCreateClaim.Checked)
            {
                if (_SelectedTPATestSuite.Commands == null)
                {
                    _SelectedTPATestSuite.Commands = new List<Command>();
                    _SelectedCommand = new CreateClaim(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name);
                    _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
                }
                _SelectedCommand = _SelectedTPATestSuite.Commands.Where(f => f.Name == "Create Claim").FirstOrDefault();
                if (_SelectedCommand == null)
                {
                    _SelectedCommand = new CreateClaim(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name);
                    _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
                }
                rbtnChangePayload.Checked = _SelectedCommand.JsonPayload != null;
            }
            cePerformance.Command = _SelectedCommand;
            tsbtnRunPerformanceCommand.Enabled = _SelectedCommand != null;
        }

        private void rbtnCreateInspectionRequest_CheckedChanged(object sender, EventArgs e)
        {
            fctxtbIncomingPayload.Text = "";
            tabControl3.SelectedIndex = 0;
            _SelectedCommand = null;
            //if (rbtnGetOutgoingDocument.Checked)
            //{
            //    if (_SelectedTPATestSuite.Commands == null)
            //    {
            //        _SelectedTPATestSuite.Commands = new List<Command>();
            //        _SelectedCommand = new GetOutgoingDocument(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name);
            //        _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
            //    }
            //    _SelectedCommand = _SelectedTPATestSuite.Commands.Where(f => f.Name == "Get Outgoing Document").FirstOrDefault();
            //    if (_SelectedCommand == null)
            //    {
            //        _SelectedCommand = new GetOutgoingDocument(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name);
            //        _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
            //    }
            //}
            cePerformance.Command = _SelectedCommand;
            tsbtnRunPerformanceCommand.Enabled = _SelectedCommand != null;
        }

        private void rbtnAttachDocument_CheckedChanged(object sender, EventArgs e)
        {
            fctxtbIncomingPayload.Text = "";
            tabControl3.SelectedIndex = 0;
            _SelectedCommand = null;
            //if (rbtnGetOutgoingDocument.Checked)
            //{
            //    if (_SelectedTPATestSuite.Commands == null)
            //    {
            //        _SelectedTPATestSuite.Commands = new List<Command>();
            //        _SelectedCommand = new GetOutgoingDocument(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name);
            //        _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
            //    }
            //    _SelectedCommand = _SelectedTPATestSuite.Commands.Where(f => f.Name == "Get Outgoing Document").FirstOrDefault();
            //    if (_SelectedCommand == null)
            //    {
            //        _SelectedCommand = new GetOutgoingDocument(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name);
            //        _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
            //    }
            //}
            cePerformance.Command = _SelectedCommand;
            tsbtnRunPerformanceCommand.Enabled = _SelectedCommand != null;
        }

        private void rbtnUpdateClaim_CheckedChanged(object sender, EventArgs e)
        {
            fctxtbIncomingPayload.Text = "";
            tabControl3.SelectedIndex = 0;
            _SelectedCommand = null;
            //if (rbtnGetOutgoingDocument.Checked)
            //{
            //    if (_SelectedTPATestSuite.Commands == null)
            //    {
            //        _SelectedTPATestSuite.Commands = new List<Command>();
            //        _SelectedCommand = new GetOutgoingDocument(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name);
            //        _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
            //    }
            //    _SelectedCommand = _SelectedTPATestSuite.Commands.Where(f => f.Name == "Get Outgoing Document").FirstOrDefault();
            //    if (_SelectedCommand == null)
            //    {
            //        _SelectedCommand = new GetOutgoingDocument(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name);
            //        _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
            //    }
            //}
            cePerformance.Command = _SelectedCommand;
            tsbtnRunPerformanceCommand.Enabled = _SelectedCommand != null;
        }

        private void rbtnCreatePayments_CheckedChanged(object sender, EventArgs e)
        {
            fctxtbIncomingPayload.Text = "";
            tabControl3.SelectedIndex = 0;
            _SelectedCommand = null;
            //if (rbtnGetOutgoingDocument.Checked)
            //{
            //    if (_SelectedTPATestSuite.Commands == null)
            //    {
            //        _SelectedTPATestSuite.Commands = new List<Command>();
            //        _SelectedCommand = new GetOutgoingDocument(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name);
            //        _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
            //    }
            //    _SelectedCommand = _SelectedTPATestSuite.Commands.Where(f => f.Name == "Get Outgoing Document").FirstOrDefault();
            //    if (_SelectedCommand == null)
            //    {
            //        _SelectedCommand = new GetOutgoingDocument(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name);
            //        _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
            //    }
            //}
            cePerformance.Command = _SelectedCommand;
            tsbtnRunPerformanceCommand.Enabled = _SelectedCommand != null;
        }

        private void rbtnDeleteDocument_CheckedChanged(object sender, EventArgs e)
        {
            fctxtbIncomingPayload.Text = "";
            tabControl3.SelectedIndex = 0;
            _SelectedCommand = null;
            //if (rbtnGetOutgoingDocument.Checked)
            //{
            //    if (_SelectedTPATestSuite.Commands == null)
            //    {
            //        _SelectedTPATestSuite.Commands = new List<Command>();
            //        _SelectedCommand = new GetOutgoingDocument(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name);
            //        _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
            //    }
            //    _SelectedCommand = _SelectedTPATestSuite.Commands.Where(f => f.Name == "Get Outgoing Document").FirstOrDefault();
            //    if (_SelectedCommand == null)
            //    {
            //        _SelectedCommand = new GetOutgoingDocument(_SelectedTPATestSuite.BaseUrl, _SelectedTPATestSuite.Name);
            //        _SelectedTPATestSuite.Commands.Add(_SelectedCommand);
            //    }
            //}
            cePerformance.Command = _SelectedCommand;
            tsbtnRunPerformanceCommand.Enabled = _SelectedCommand != null;
        }

        private void txtbBaseURL_Leave(object sender, EventArgs e)
        {
            _SelectedTPATestSuite.BaseUrl = txtbBaseURL.Text;
        }

        private void txtbUserId_Leave(object sender, EventArgs e)
        {
            if (_SelectedTPATestSuite.Credentials == null)
                _SelectedTPATestSuite.Credentials = new Credentials();
            _SelectedTPATestSuite.Credentials.UserId = txtbUserId.Text;
        }

        private void txtbUserSecret_Leave(object sender, EventArgs e)
        {
            if (_SelectedTPATestSuite.Credentials == null)
                _SelectedTPATestSuite.Credentials = new Credentials();
            _SelectedTPATestSuite.Credentials.Password = txtbUserSecret.Text;
        }

        private void cmbxTPA_SelectedIndexChanged(object sender, EventArgs e)
        {
            rbtnAttachDocument.Checked = false;
            rbtnCreateClaim.Checked = false;
            rbtnCreateInspectionRequest.Checked = false;
            rbtnCreatePayments.Checked = false;
            rbtnDeleteDocument.Checked = false;
            rbtnGetAllClaims.Checked = false;
            rbtnGetClaimDocuments.Checked = false;
            rbtnGetClaimPayees.Checked = false;
            rbtnGetCreditCard.Checked = false;
            rbtnGetDocument.Checked = false;
            rbtnGetInspectionHistory.Checked = false;
            rbtnGetInspectionPartners.Checked = false;
            rbtnGetInspectionRequests.Checked = false;
            rbtnGetOutgoingDocument.Checked = false;
            rbtnGetSingleClaim.Checked = false;
            fctxtbIncomingPayload.Text = "";
            tabControl3.SelectedIndex = 0;
            _User = default;
            loginResponse = null;
            tsslblToken.Text = "Not aquired";
            tsslblToken.BackColor = Color.Red;
            if (cmbxTPA.SelectedItem != null)
            {
                var envivironmentSuite = _TestSuites.Where(s => s.Key == selectedEnvironment).FirstOrDefault().Value;
                if (envivironmentSuite == null)
                {
                    envivironmentSuite = new Dictionary<string, TPATestSuite>();
                    _TestSuites.Add(selectedEnvironment, envivironmentSuite);
                }
                var suits = envivironmentSuite.Where(s => s.Key == cmbxTPA.SelectedItem as string);
                KeyValuePair<string, TPATestSuite> suit;
                if (!suits.Any())
                {
                    _SelectedTPATestSuite = new TPATestSuite();
                    _SelectedTPATestSuite.BaseUrl = $"{ConfigurationManager.AppSettings[selectedEnvironment]}/api/{ConfigurationManager.AppSettings["Version"]}";
                    _SelectedTPATestSuite.LoginUrl = $"{ConfigurationManager.AppSettings[selectedEnvironment]}/login/connect/token";
                    envivironmentSuite.Add(cmbxTPA.SelectedItem as string, _SelectedTPATestSuite);
                }
                else
                    _SelectedTPATestSuite = suits.FirstOrDefault().Value;
                _User = (_SelectedTPATestSuite.Credentials?.UserId, _SelectedTPATestSuite.Credentials?.Password);
                txtbBaseURL.Text = _SelectedTPATestSuite.BaseUrl;
                txtbUserId.Text = _User.Item1;
                txtbUserSecret.Text = _User.Item2;
                txtbLoginURL.Text = _SelectedTPATestSuite.LoginUrl;
            }
            webLoginUrl = _SelectedTPATestSuite.LoginUrl;
            tsbtnRunPerformanceCommand.Enabled = false;
            fctxtbIncomingPayload.Text = "";
            gbEndpoints.Enabled = cmbxTPA.SelectedItem != null;
        }

        private void tsbtnRunPerformanceCommand_Click(object sender, EventArgs e)
        {
            chart2.Series[0].Points.Clear();
            tsslblProgress.Visible = true;
            tspbProgress.Visible = true;
            txtbAverageDuration.Text = "";
            txtbIncommingPayloadSize.Text = "";
            txtbOutgoingPayloadSize.Text = "";
            List<TimeSpan> durations = new List<TimeSpan>();
            //Execute the selected command.
            tsslblResultCode.Text = "";
            tsslblMessage.Text = "";
            Cursor = Cursors.WaitCursor;
            tsslblExecuting.Visible = true;
            Application.DoEvents();
            if (loginResponse == null || !loginResponse.IsTokenurrent)
                GetToken();
            int numIterations;
            if (int.TryParse(tstxtbNumberOfIterations.Text, out numIterations))
            {
                tsslblProgress.Text = $"0 of {numIterations}";
                tspbProgress.Value = 0;
                Application.DoEvents();
                (string, object) results = ("", null);// = RunCommand(_SelectedCommand);
                tspbProgress.Maximum = numIterations;
                for (int i = -1; i < numIterations; i++)
                {
                    tsslblProgress.Text = $"{i + 1} of {numIterations}";
                    tspbProgress.Value = i + 1;
                    Application.DoEvents();
                    DateTime start = DateTime.Now;
                    switch (_SelectedCommand.Action)
                    {
                        case ActionType.Get:
                            results = Get(_SelectedCommand.URL, _SelectedCommand.Parameters.ToList(), loginResponse.access_token);
                            if (tsslblResultCode.Text != "200")
                                break;
                            break;
                        case ActionType.Post:
                            results = (Post(_SelectedCommand), null);
                            fctxtbIncomingPayload.Text = results.Item1;
                            if (_SelectedCommand.Name == "Create Claim")
                            {
                                if (_SelectedCommand.JsonPayload != null)
                                {
                                    string claimNumber = _SelectedCommand.JsonPayload.GetPropertyValue("ClaimNumber") as string;
                                    string commandText = Resources.DeleteClaim.Replace("{ClaimNumber}", claimNumber);
                                    RunDatabaseScript(commandText);
                                }
                            }
                            break;
                        case ActionType.Put:
                            results = (Put(_SelectedCommand.URL, parameters: _SelectedCommand.Parameters, bearerToken: loginResponse.access_token, body: _SelectedCommand.Form, textBody: _SelectedCommand.Raw, contentType: "application/json"), null);
                            break;
                        case ActionType.Patch:
                            results = (Patch(_SelectedCommand.URL, parameters: _SelectedCommand.Parameters, bearerToken: loginResponse.access_token, body: _SelectedCommand.Form, textBody: _SelectedCommand.Raw, contentType: "application/json"), null);
                            break;
                    }
                    TimeSpan duration = DateTime.Now.Subtract(start);
                    if (i >= 0)
                        durations.Add(duration);
                }
                double total = 0;
                foreach (TimeSpan duration in durations)
                {
                    total += duration.TotalMilliseconds;
                }
                FillDistributionChart(durations);
                txtbAverageDuration.Text = $"{total / numIterations}";
                txtbIncommingPayloadSize.Text = results.Item2 != null ? results.Item2 is string ? $"{(results.Item2 as string).Length}" : "" : $"{results.Item1.Length}";
                txtbOutgoingPayloadSize.Text = $"{_SelectedCommand.PayloadSize}";
                if (results.Item2 != null)
                    fctxtbIncomingPayload.Text = JsonPrettify(results.Item2 as string);
                tsslblProgress.Visible = false;
                tspbProgress.Visible = false;
            }
            //switch (_SelectedCommand.Action)
            //{
            //    case ActionType.Get:
            //        if (!string.IsNullOrEmpty(results.Item1))
            //        {
            //            rtbResults.Visible = true;
            //            rtbResults.Text = results.Item1;
            //        }
            //        if (results.Item2 is MemoryStream)
            //        {
            //            MemoryStream memoryStream = results.Item2 as MemoryStream;
            //            documentPreview1.Visible = true;
            //        }
            //        if (results.Item2 is string)
            //        {
            //            string path = results.Item2 as string;
            //            if (path.ToLower().Contains("doc"))
            //            {
            //                tslblFileName.Text = path;
            //                tsbtnViewFile.Enabled = true;
            //                applicationName = "winword.exe";
            //            }
            //            else if (path.ToLower().Contains("xls"))
            //            {
            //                tslblFileName.Text = path;
            //                tsbtnViewFile.Enabled = true;
            //                applicationName = "winword.exe";
            //            }
            //            else
            //            {
            //                tsbtnViewAsImage.Enabled = true;
            //            }
            //        }
            //        if (results.Item2 is Image)
            //        {
            //            pnlImage.Visible = true;
            //            pnlImage.BackgroundImage = results.Item2 as Image;
            //        }
            //        break;
            //    case ActionType.Post:
            //    case ActionType.Put:
            //    case ActionType.Patch:
            //        rtbResults.Visible = true;
            //        rtbResults.Text = results.Item1;
            //        break;
            //}
            Cursor = Cursors.Default;
            tsslblExecuting.Visible = false;
        }

        private void FillDistributionChart(List<TimeSpan> durations)
        {
            double min = durations.Min(d => d.TotalMilliseconds);
            double max = durations.Max(d => d.TotalMilliseconds);
            double span = (max - min) / 20;
            List<int> buckets = new List<int>();
            for (int i = 0; i < 20; i++)
                buckets.Add(0);
            foreach (TimeSpan duration in durations)
            {
                int bucket = (int)((duration.TotalMilliseconds - min) / span);
                buckets[bucket >= buckets.Count? 19 : bucket]++;
            }
            for(int bucket = 0; bucket < buckets.Count; bucket++)
                chart2.Series[0].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint { XValue = (bucket * span) + min, YValues = new double[] { (double)buckets[bucket] } });
        } 

        private void tsbtnOpenLogFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "Open Log File",
                Filter = "JSON Log File(*.json)|*.json"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _PerformanceLog.Clear();
                lbxLogEntries.Items.Clear();
                using (FileStream stream = File.Open(dialog.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            JObject json = JObject.Parse(line);
                            var time = json.SelectToken("@t");
                            lbxLogEntries.Items.Add((time, line));
                            var trace = json.SelectToken("@mt");
                            if (trace != null)
                            {
                                if (trace.Value<string>()?.Contains("Duration") ?? false)
                                {
                                    _PerformanceLog.Add(json);
                                }
                            }
                        }
                        FillPerformanceTree();
                    }
                }
            }
        }

        private void tstxtbNumberOfIterations_Leave(object sender, EventArgs e)
        {
            int numRuns;
            if (int.TryParse(tstxtbNumberOfIterations.Text, out numRuns))
            {
                Settings.Default.NumberOfTestRuns = numRuns;
                Settings.Default.Save();
            }
        }

        private void txtbLoginURL_Leave(object sender, EventArgs e)
        {
            _SelectedTPATestSuite.LoginUrl = txtbLoginURL.Text;
        }

        private void tsbtnFilterLog_Click(object sender, EventArgs e)
        {
            MultiValueInputDialog dialog = new MultiValueInputDialog { Text = "Select date" };
            dialog.Fields.Add(new Field
            {
                Caption = "Dates after",
                Value = minDate,
                InputType = s.InputType.Date
            });
            dialog.BuildUI();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                minDate = (DateTime)dialog.Fields.Where(f => f.Caption == "Dates after").FirstOrDefault()?.Value;
                tslblMinDate.Text = $"After {minDate:yyy-MM-dd}";
                FillLogFiles();
            }
        }

        private void tvLogFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lbxLogEntries.Items.Clear();
            fcrtxtbLogView.Text = "";
            fctxtbStackTrace.Text = "";
            if (tvLogFiles.SelectedNode != null && tvLogFiles.SelectedNode.Tag != null)
            {
                logFilePath = Path.Combine(logFolder, tvLogFiles.SelectedNode.Tag as string);
                LoadLog();
            }
            FillPerformanceTree();
        }

        private int LoadLog()
        {
            int row = 0;
            using (FileStream stream = File.Open(logFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    if (logPage > 0)
                    {
                        while (!reader.EndOfStream && row < logPage + logRows)
                        {
                            row++;
                            string line = reader.ReadLine();
                        }
                    }
                    row = 0;
                    while (!reader.EndOfStream && row < logRows)
                    {
                        row++;
                        string line = reader.ReadLine();
                        JObject json = JObject.Parse(line);
                        var time = json.SelectToken("@t");
                        lbxLogEntries.Items.Add((time, line));
                        var trace = json.SelectToken("@mt");
                        if (trace != null)
                        {
                            if (trace.Value<string>()?.Contains("Duration") ?? false)
                            {
                                _PerformanceLog.Add(json);
                            }
                        }
                    }
                    tsbtnLoadNextPage.Enabled = !reader.EndOfStream;
                }
            }

            return row;
        }

        private void FillPerformanceTree()
        {
            tvPerformance.Nodes.Clear();
            string parentId = null;
            string name = null;
            string duration = "";
            TreeNode currentRoot = null;
            JObject jsonTag = null;
           foreach (JObject json in _PerformanceLog)
            {
                string pId = json.SelectToken("ActionName").Value<string>();
                if (pId != parentId)
                {
                    if (currentRoot != null)
                    {
                        currentRoot.Text = $"{name} ({duration})";
                        currentRoot.Tag = jsonTag;
                        tvPerformance.Nodes.Add(currentRoot);
                        currentRoot = new TreeNode();
                    }
                    else
                    {
                        currentRoot = new TreeNode();
                    }
                    name = json.SelectToken("@mt").Value<string>();
                    duration = name.Substring(name.IndexOf("Duration") + 10);
                    name = name.Substring(0, name.IndexOf("Duration"));
                    parentId = pId;
                    jsonTag = json;
                }
                else
                {
                    currentRoot.Nodes.Add(new TreeNode { Text = $"{name} ({duration})", Tag = jsonTag });
                    name = json.SelectToken("@mt").Value<string>();
                    duration = name.Substring(name.IndexOf("Duration") + 10);
                    name = name.Substring(0, name.IndexOf("Duration"));
                    jsonTag = json;
                }
            }
            if (currentRoot != null)
            {
                tvPerformance.Nodes.Add(currentRoot);
                currentRoot.Text = $"{name} ({duration})";
                currentRoot.Tag = jsonTag;
            }
        }

        private void tscmbxTPA_SelectedIndexChanged(object sender, EventArgs e)
        {
            tscmbxCommand.Items.Clear();
            _User = default;
            loginResponse = null;
            tsslblToken.Text = "Not aquired";
            tsslblToken.BackColor = Color.Red;
            if (tscmbxTPA.SelectedItem != null)
            {
                tsbtnEditLoadTests.Enabled = true;
                var environmentSuite = _LoadTesting.Where(s => s.Key == selectedEnvironment).FirstOrDefault().Value;
                var suit = environmentSuite.Where(s => s.Key == tscmbxTPA.SelectedItem as string).FirstOrDefault();
                _SelectedTPALoadTest = suit.Value;
                //Set the user
                _User = (_SelectedTPALoadTest?.Credentials?.UserId, _SelectedTPALoadTest?.Credentials?.Password);
                tsslblUserId.Text = _User.Item1;
                //Load the available commands
                if (_SelectedTPALoadTest?.Commands != null)
                {
                    foreach (Command command in _SelectedTPALoadTest.Commands)
                        tscmbxCommand.Items.Add(command);
                    txtbUserId.Text = _SelectedTPALoadTest.Credentials.UserId;
                    txtbUserSecret.Text = _SelectedTPALoadTest.Credentials.Password;
                    txtbBaseURL.Text = _SelectedTPALoadTest.BaseUrl;
                    txtbLoginURL.Text = _SelectedTPALoadTest.LoginUrl;
                    txtbNumCalls.Text = $"{_SelectedTPALoadTest.NumberOfCalls}";
                    txtbTestDuration.Text = $"{_SelectedTPALoadTest.Duration}";
                    txtbTBC.Text = $"{_SelectedTPALoadTest.TimeBetweenCalls}";
                    txtbStartLoad.Text = $"{_SelectedTPALoadTest.StartLoad}";
                    txtbEndLoad.Text = $"{_SelectedTPALoadTest.EndLoad}";
                    txtbLoadIncrement.Text = $"{_SelectedTPALoadTest.LoadIncrement}";
                    rbtnNumberOfCalls.Checked = _SelectedTPALoadTest.TestMode == TestMode.NumberOfCalls;
                    rbtnTime.Checked = _SelectedTPALoadTest.TestMode == TestMode.Duration;
                    rbtnMultipleLoads.Checked = _SelectedTPALoadTest.TestMode == TestMode.MultiLoad;
                }
            }
        }

        private void tscmbxCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            _SelectedCommand = tscmbxCommand.SelectedItem as Command;
            txtbTestURL.Text = _SelectedCommand?.URL;
            tsbtnStartTest.Enabled = _SelectedCommand != null;
        }

        private void tsbtnAddPerformanceTest_Click(object sender, EventArgs e)
        {
            //show editor
            LoadTestEditor dialog = new LoadTestEditor
            {
                Text = "Add new TPA",
                LoadTests = new TPALoadTestSuite
                {
                    BaseUrl = $"{ConfigurationManager.AppSettings[selectedEnvironment]}/api/{ConfigurationManager.AppSettings["Version"]}",
                    LoginUrl = $"{ConfigurationManager.AppSettings[selectedEnvironment]}/login/connect/token"
                },
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (_LoadTesting == null)
                    _LoadTesting = new Dictionary<string, Dictionary<string, TPALoadTestSuite>>();
                if (_LoadTesting.ContainsKey(dialog.LoadTests.Name))
                {
                    MessageBox.Show("TPA already exist", "User Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _SelectedTPALoadTest = dialog.LoadTests;
                    tscmbxTPA.Items.Add(_SelectedTPALoadTest.Name);
                    if (_LoadTesting == null)
                        _LoadTesting = new Dictionary<string, Dictionary<string, TPALoadTestSuite>>();
                    var environmentSuite = _LoadTesting.Where(s => s.Key == selectedEnvironment).FirstOrDefault().Value;
                    if (environmentSuite == null)
                    {
                        environmentSuite = new Dictionary<string, TPALoadTestSuite>();
                        _LoadTesting.Add(selectedEnvironment, environmentSuite);
                    }
                    environmentSuite.Add(_SelectedTPALoadTest.Name, _SelectedTPALoadTest);
                    tscmbxTPA.SelectedIndex = tscmbxTPA.Items.Count - 1;
                }
            }
        }

        private void tsbtnSaveLoadTests_Click(object sender, EventArgs e)
        {
            //Save load test suites
            using (StreamWriter writer = new StreamWriter(Path.Combine(Application.StartupPath, "LoadTests.json")))
            {
                writer.Write(JsonConvert.SerializeObject(_LoadTesting));
                writer.Flush();
                writer.Close();
            }
        }

        private void tsbtnLoadPreviousPage_Click(object sender, EventArgs e)
        {
            if (logPage > 0)
                logPage--;
            tsbtnLoadPreviousPage.Enabled = logPage > 0;
            tsbtnLoadNextPage.Enabled = true;
            LoadLog();
        }

        private void tstxtbPageSize_Leave(object sender, EventArgs e)
        {
            int.TryParse(tstxtbPageSize.Text, out logRows);
            LoadLog();
        }

        private void rbtnChangePayload_CheckedChanged(object sender, EventArgs e)
        {
            dgvChange.Rows.Clear();
            gbSamplePayloads.Enabled = rbtnChangePayload.Checked;
            dgvChange.Enabled = rbtnChangePayload.Checked;
            if (rbtnChangePayload.Checked)
            {
                if (_SelectedCommand.JsonPayload == null)
                {
                    JObject json = JObject.Parse(_SelectedCommand.Raw);
                    _SelectedCommand.JsonPayload = new JsonPayload(json);
                }
                foreach (JsonPayloadProperty property in _SelectedCommand.JsonPayload.Properties)
                {
                    AddRow(property, "");
                }
            }
            else
            {
                fctxtbSamplePayload.Text = "";
                _SelectedCommand.JsonPayload = null;
            }
        }

        private void AddRow(JsonPayloadProperty property, string path)
        {
            if (property.Value is JsonPayload)
            {
                path = string.IsNullOrEmpty(path) ? $"{property.Name}" : $"{path}.{property.Name}";
                foreach (JsonPayloadProperty prop in (property.Value as JsonPayload).Properties)
                    AddRow(prop, path);
            }
            if (property.Value is Array)
            {
                foreach (var val in property.Value as Array)
                {
                    path = string.IsNullOrEmpty(path) ? $"{property.Name}" : $"{path}.{property.Name}";
                    foreach (JsonPayloadProperty prop in (val as JsonPayload).Properties)
                        AddRow(prop, path);
                }
            }
            else
            {
                string name = string.IsNullOrEmpty(path) ? property.Name : $"{path}.{property.Name}";
                int rowIndex = dgvChange.Rows.Add(name, property.Value, property.Increment, property.ValueFormat, property.IncrementValue);
                dgvChange.Rows[rowIndex].Tag = property;
            }
        }

        private void dgvChange_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            JsonPayloadProperty property = dgvChange.Rows[e.RowIndex].Tag as JsonPayloadProperty;
            switch(e.ColumnIndex)
            {
                case 2:
                    property.Increment = (bool)dgvChange[e.ColumnIndex, e.RowIndex].Value;
                    break;
                case 3:
                    property.ValueFormat = dgvChange[e.ColumnIndex, e.RowIndex].Value as string;
                    break;
                case 4:
                    property.IncrementValue = int.Parse(dgvChange[e.ColumnIndex, e.RowIndex].Value as string);
                    break;
            }
        }

        private void tsbtnNextPayload_Click(object sender, EventArgs e)
        {
            _SelectedCommand.JsonPayload.NextValue();
            fctxtbSamplePayload.Text = JsonPrettify( _SelectedCommand.JsonPayload.ToString());
        }

        private void rbtnDeleteClaim_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtnDeleteClaim.Checked)
            {
                fctxtbSQLCommand.Text = Resources.DeleteClaim;
                tsbtnRunSQLCommand.Enabled = ConfigurationManager.ConnectionStrings[selectedEnvironment] != null && !string.IsNullOrEmpty(fctxtbSQLCommand.Text);
            }
        }

        private void tsbtnRunSQLCommand_Click(object sender, EventArgs e)
        {
            string commandTest = fctxtbSQLCommand.Text;
            RunDatabaseScript(commandTest);
            MessageBox.Show("SQL Command execution completed.", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RunDatabaseScript(string commandTest)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[selectedEnvironment].ConnectionString))
            {
                connection.Open();
                if (commandTest.Contains("\nGO"))
                {
                    StringBuilder commandText = new StringBuilder();
                    MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(commandTest));
                    StreamReader reader = new StreamReader(stream);
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (line.ToUpper() != "GO")
                            commandText.AppendLine(line);
                        else
                        {
                            using (SqlCommand command = connection.CreateCommand())
                            {
                                try
                                {
                                    command.CommandText = commandText.ToString();
                                    command.CommandType = CommandType.Text;
                                    command.ExecuteNonQuery();
                                }
                                catch (Exception excp)
                                {
                                    MessageBox.Show($"SQL Command execution failed.\n{excp.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            commandText = new StringBuilder();
                        }
                    }
                    if (commandText.Length > 0)
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            try
                            {
                                command.CommandText = commandText.ToString();
                                command.CommandType = CommandType.Text;
                                command.ExecuteNonQuery();
                            }
                            catch (Exception excp)
                            {
                                MessageBox.Show($"SQL Command execution failed.\n{excp.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        commandText = new StringBuilder();
                    }
                }
                else
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        try
                        {
                            command.CommandText = commandTest;
                            command.CommandType = CommandType.Text;
                            command.ExecuteNonQuery();
                        }
                        catch (Exception excp)
                        {
                            MessageBox.Show($"SQL Command execution failed.\n{excp.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
            }
        }

        private void tsbtnOpenLogViewer_Click(object sender, EventArgs e)
        {
            LogFileViewer dialog = new LogFileViewer();
            dialog.ShowDialog();
        }

        private void tsbtnLoadNextPage_Click(object sender, EventArgs e)
        {
            logPage++;
            tsbtnLoadPreviousPage.Enabled = true;
            LoadLog();
        }

        private void tsbtnEditLoadTests_Click(object sender, EventArgs e)
        {
            LoadTestEditor dialog = new LoadTestEditor
            {
                Text = "Add new TPA",
                LoadTests = _SelectedTPALoadTest
            };
            dialog.ShowDialog();
        }

        private void tvPerformance_AfterSelect(object sender, TreeViewEventArgs e)
        {
            fcrtxtbLogView.Text = "";
            fctxtbStackTrace.Text = "";
            if (e.Node != null)
            {
                if(e.Node.Tag != null)
                {
                    JObject json = e.Node.Tag as JObject;
                    fcrtxtbLogView.Text = json.ToString();
                }
            }
        }

        private void tsbtnGetDownloadFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = downloadDirectory;
            if (dialog.ShowDialog() == DialogResult.OK)
                downloadDirectory = dialog.SelectedPath;
            tslblDownloadFolder.Text = downloadDirectory;
            Settings.Default.DownloadDirectory = downloadDirectory;
            Settings.Default.Save();
        }

        private void tsbtnViewFile_Click(object sender, EventArgs e)
        {
            using (Process process = Process.Start(applicationName, $"\"{tslblFileName.Text}\""))
                process.WaitForExit();
        }

        private void tstxtbURL_Leave(object sender, EventArgs e)
        {
            _SelectedCommand.URL = tstxtbURL.Text;
        }

        private string Post(Command command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            if (string.IsNullOrEmpty(command.URL))
                throw new ArgumentNullException(nameof(command.URL));
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.access_token);
                HttpContent content = null;
                if(command.JsonPayload != null)
                {
                    command.JsonPayload.NextValue();
                    content = new StringContent(command.JsonPayload.ToString());
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                }
                else if (!string.IsNullOrEmpty(command.Raw))
                {
                    content = new StringContent(command.Raw);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                }
                else if (command.Form != null)
                {
                    content = new FormUrlEncodedContent(command.Form.ToList());
                    content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
                }
                string url = command.URL;
                if (command.Parameters != null)
                {
                    bool isFirst = true;
                    foreach (KeyValuePair<string, string> pair in command.Parameters)
                    {
                        if (isFirst)
                        {
                            url += "?";
                            isFirst = false;
                        }
                        else
                            url += "&";
                        url += $"{pair.Key}={pair.Value}";
                    }
                }
                try
                {
                    using (var response = client.PostAsync(new Uri(url), content))
                    {
                        tsslblResultCode.Text = $"{(int)response.Result.StatusCode}";
                        tsslblResultCode.ForeColor = response.Result.IsSuccessStatusCode ? Color.Green : Color.Red;
                        tsslblMessage.ForeColor = response.Result.IsSuccessStatusCode ? Color.Green : Color.Red;
                        tsslblMessage.Text = response?.Result.ReasonPhrase;
                        var responseContent = response.Result.Content.ReadAsStringAsync();
                        responseContent.Wait();
                        return responseContent.Result;
                    }
                }
                catch (Exception excp)
                {
                    MessageBox.Show($"{excp}", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return null;
            }
        }

        private string Put(Command command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            if (string.IsNullOrEmpty(command.URL))
                throw new ArgumentNullException(nameof(command.URL));
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.access_token);
                HttpContent content = null;
                if (!string.IsNullOrEmpty(command.Raw))
                {
                    content = new StringContent(command.Raw);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                }
                else if (command.Form != null)
                {
                    content = new FormUrlEncodedContent(command.Form.ToList());
                    content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
                }
                string url = command.URL;
                if (command.Parameters != null)
                {
                    bool isFirst = true;
                    foreach (KeyValuePair<string, string> pair in command.Parameters)
                    {
                        if (isFirst)
                        {
                            url += "?";
                            isFirst = false;
                        }
                        else
                            url += "&";
                        url += $"{pair.Key}={pair.Value}";
                    }
                }
                try
                {
                    using (var response = client.PutAsync(new Uri(url), content))
                    {
                        tsslblResultCode.Text = $"{(int)response.Result.StatusCode}";
                        tsslblResultCode.ForeColor = response.Result.IsSuccessStatusCode ? Color.Green : Color.Red;
                        tsslblMessage.ForeColor = response.Result.IsSuccessStatusCode ? Color.Green : Color.Red;
                        tsslblMessage.Text = response?.Result.ReasonPhrase;
                        var responseContent = response.Result.Content.ReadAsStringAsync();
                        responseContent.Wait();
                        return responseContent.Result;
                    }
                }
                catch (Exception excp)
                {
                    MessageBox.Show($"{excp}", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return null;
            }
        }

        private string Post(string url, List<KeyValuePair<string, string>> parameters = null, IEnumerable<KeyValuePair<string, string>> body = null, string bearerToken = null, string contentType = "text/plain")
        {
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(bearerToken))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                HttpContent content = null;
                if (body != null)
                {
                    content = new FormUrlEncodedContent(body);
                    content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                }
                if (parameters != null)
                {
                    bool isFirst = true;
                    foreach (KeyValuePair<string, string> pair in parameters)
                    {
                        if (isFirst)
                        {
                            url += "?";
                            isFirst = false;
                        }
                        else
                            url += "&";
                        url += $"{pair.Key}={pair.Value}";
                    }
                }
                try
                {
                    using (var response = client.PostAsync(new Uri(url), content))
                    {
                        tsslblResultCode.Text = $"{(int)response.Result.StatusCode}";
                        tsslblResultCode.ForeColor = response.Result.IsSuccessStatusCode ? Color.Green : Color.Red;
                        tsslblMessage.ForeColor = response.Result.IsSuccessStatusCode ? Color.Green : Color.Red;
                        tsslblMessage.Text = response?.Result.ReasonPhrase;
                        var responseContent = response.Result.Content.ReadAsStringAsync();
                        responseContent.Wait();
                        return responseContent.Result;
                    }
                }
                catch (Exception excp)
                {
                    MessageBox.Show($"{excp}", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return null;
            }
        }

        private string Put(string url, IEnumerable<KeyValuePair<string, string>> parameters = null, IEnumerable<KeyValuePair<string, string>> body = null, string textBody = null, string bearerToken = null, string contentType = "text/plain")
        {
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(bearerToken))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                HttpContent content = null;
                if (!string.IsNullOrEmpty(textBody))
                {
                    content = new StringContent(textBody);
                    content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                }
                if (body.Count() > 0)
                {
                    content = new FormUrlEncodedContent(body);
                    content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                }
                if (parameters.Count() > 0)
                {
                    bool isFirst = true;
                    foreach (KeyValuePair<string, string> pair in parameters)
                    {
                        if (isFirst)
                        {
                            url += "?";
                            isFirst = false;
                        }
                        else
                            url += "&";
                        url += $"{pair.Key}={pair.Value}";
                    }
                }
                try
                {
                    using (var response = client.PutAsync(new Uri(url), content))
                    {
                        tsslblResultCode.Text = $"{(int)response.Result.StatusCode}";
                        tsslblResultCode.ForeColor = response.Result.IsSuccessStatusCode ? Color.Green : Color.Red;
                        tsslblMessage.ForeColor = response.Result.IsSuccessStatusCode ? Color.Green : Color.Red;
                        tsslblMessage.Text = response?.Result.ReasonPhrase;
                        var responseContent = response.Result.Content.ReadAsStringAsync();
                        responseContent.Wait();
                        return responseContent.Result;
                    }
                }
                catch (Exception excp)
                {
                    MessageBox.Show($"{excp}", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return null;
            }
        }

        private string Patch(string url, IEnumerable<KeyValuePair<string, string>> parameters = null, IEnumerable<KeyValuePair<string, string>> body = null, string textBody = null, string bearerToken = null, string contentType = "text/plain")
        {
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(bearerToken))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                HttpContent content = null;
                if (!string.IsNullOrEmpty(textBody))
                {
                    content = new StringContent(textBody);
                    content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                }
                if (body.Count() > 0)
                {
                    content = new FormUrlEncodedContent(body);
                    content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                }
                if (parameters.Count() > 0)
                {
                    bool isFirst = true;
                    foreach (KeyValuePair<string, string> pair in parameters)
                    {
                        if (isFirst)
                        {
                            url += "?";
                            isFirst = false;
                        }
                        else
                            url += "&";
                        url += $"{pair.Key}={pair.Value}";
                    }
                }
                try
                {
                    using (var response = client.PatchAsync(url, content))
                    {
                        tsslblResultCode.Text = $"{(int)response.Result.StatusCode}";
                        tsslblResultCode.ForeColor = response.Result.IsSuccessStatusCode ? Color.Green : Color.Red;
                        tsslblMessage.ForeColor = response.Result.IsSuccessStatusCode ? Color.Green : Color.Red;
                        tsslblMessage.Text = response?.Result.ReasonPhrase;
                        var responseContent = response.Result.Content.ReadAsStringAsync();
                        responseContent.Wait();
                        return responseContent.Result;
                    }
                }
                catch (Exception excp)
                {
                    MessageBox.Show($"{excp}", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return null;
            }
        }

        private (string, object) Get(string url, List<KeyValuePair<string, string>> parameters = null, string bearerToken = null)
        {
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(bearerToken))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

                if (parameters != null)
                {
                    bool isFirst = true;
                    foreach (KeyValuePair<string, string> pair in parameters)
                    {
                        if (isFirst)
                        {
                            url += "?";
                            isFirst = false;
                        }
                        else
                            url += "&";
                        url += $"{pair.Key}={pair.Value}";
                    }
                }
                try
                {
                    using (var response = client.GetAsync(new Uri(url)))
                    {
                        tsslblResultCode.Text = $"{(int)response.Result.StatusCode}";
                        tsslblResultCode.ForeColor = response.Result.IsSuccessStatusCode ? Color.Green : Color.Red;
                        tsslblMessage.ForeColor = response.Result.IsSuccessStatusCode ? Color.Green : Color.Red;
                        tsslblMessage.Text = response?.Result.ReasonPhrase;
                        string mediaType = response.Result.Content.Headers.ContentType?.MediaType;
                        fileName = response.Result.Content.Headers.ContentDisposition?.FileName.Trim('"');
                        var responseRawContent = response.Result.Content.ReadAsByteArrayAsync();
                        responseRawContent.Wait();
                        rawResponse = responseRawContent.Result;

                        switch (mediaType)
                        {
                            case "text/csv":
                            case "application/json":
                            case "text/xml":
                            case "text/html":
                                var responseTextContent = response.Result.Content.ReadAsStringAsync();
                                responseTextContent.Wait();
                                return (mediaType, responseTextContent.Result);
                            default:
                                var responseContent = response.Result.Content.ReadAsByteArrayAsync();
                                responseContent.Wait();
                                rawResponse = responseContent.Result;
                                return (mediaType, responseContent.Result);
                        }
                    }
                }
                catch (Exception excp)
                {
                    MessageBox.Show($"{excp}", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return ("", null);
            }
        }

        private async Task<(bool, object)> GetAsync(string url, List<KeyValuePair<string, string>> parameters = null, string bearerToken = null)
        {
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(bearerToken))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

                if (parameters != null)
                {
                    bool isFirst = true;
                    foreach (KeyValuePair<string, string> pair in parameters)
                    {
                        if (isFirst)
                        {
                            url += "?";
                            isFirst = false;
                        }
                        else
                            url += "&";
                        url += $"{pair.Key}={pair.Value}";
                    }
                }
                try
                {
                    DateTime startTime = DateTime.Now;
                    var response = await client.GetAsync(new Uri(url));
                    if (_Durations != null)
                        _Durations.Add(DateTime.Now.Subtract(startTime).TotalMilliseconds);
                    return (response.IsSuccessStatusCode, response);
                }
                catch (Exception excp)
                {
                    MessageBox.Show($"{excp}", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return (false, null);
            }
        }

        public string JsonPrettify(string json)
        {
            try
            {
                if (string.IsNullOrEmpty(json))
                    return null;
                using (var stringReader = new StringReader(json))
                using (var stringWriter = new StringWriter())
                {
                    var jsonReader = new JsonTextReader(stringReader);
                    var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
                    jsonWriter.WriteToken(jsonReader);
                    return stringWriter.ToString();
                }
            }
            catch (Exception excp)
            {
                return "";
            }
        }
    }
}
