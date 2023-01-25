using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

using FI.Models;
using APITester.Models.Extensions;
using APITester.Dialog.Controls;
namespace APITester.Dialog
{
    public partial class LogFileViewer : Form
    {
        Dictionary<string, Stack<PerformanceLog>> _PerformanceLogs = new Dictionary<string, Stack<PerformanceLog>>();
        Stack<TreeNode> _RootNodes = new Stack<TreeNode>();
        int _MaxLevel = 1;
        string _SelectedTPA = null;

        public LogFileViewer()
        {
            InitializeComponent();
        }

        private void tsbtnOpenLogFile_Click(object sender, EventArgs e)
        {
            //show open file dialog
            OpenFileDialog dialog = new OpenFileDialog { Filter = "Log file(*.json)|*.json|All files(*.*)|*.*", Title = "Open Log File"};
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _PerformanceLogs = new Dictionary<string, Stack<PerformanceLog>>();
                lbxLogEntries.Items.Clear();
                Text = $"Log Viewer ({Path.GetFileName(dialog.FileName)})";
                //Read the log into the stack
                using (FileStream stream = File.Open(dialog.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        tscmbxTPA.Items.Clear();
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            JObject json = JObject.Parse(line);
                            var time = json.SelectToken("@t");
                            lbxLogEntries.Items.Add((time, line));
                            var trace = json.SelectToken("@mt");
                            var actionId = json.SelectToken("ActionId");
                            if (trace != null)
                            {
                                if (trace.Value<string>()?.Contains("Method\":") ?? false)
                                {
                                    string jsonString = json.SelectToken("@mt").Value<string>();
                                    PerformanceLog log = JsonConvert.DeserializeObject<PerformanceLog>(jsonString);
                                    log.ActionId = actionId.Value<string>();
                                    if(log?.TPA != null)
                                    {
                                        _MaxLevel = log.Level > _MaxLevel ? log.Level : _MaxLevel;
                                        log.JsonObject = json;
                                        if (!_PerformanceLogs.ContainsKey(log.TPA.ToUpper()))
                                        {
                                            tscmbxTPA.Items.Add(log.TPA.ToUpper());
                                            _PerformanceLogs.Add(log.TPA.ToUpper(), new Stack<PerformanceLog>());
                                        }
                                    _PerformanceLogs[log.TPA.ToUpper()].Push(log);
                                    }
                                }
                            }
                        }
                        tscmbxLevel.Items.Clear();
                        for (int cnt = 1; cnt <= _MaxLevel; cnt++)
                            tscmbxLevel.Items.Add(cnt);
                        tscmbxLevel.SelectedIndex = tscmbxLevel.Items.Count - 1;
                        tscmbxTPA.SelectedIndex = 0;
                        FillPerformanceTree();
                    }
                }
            }
        }

        private void FillPerformanceTree()
        {
            tvPerformance.Nodes.Clear();
            foreach(string key in _PerformanceLogs.Keys)
            {
                TreeNode currentRoot = new TreeNode(key);
                tvPerformance.Nodes.Add(currentRoot);
                Queue<PerformanceLog> logQueue = new Queue<PerformanceLog>();
                Stack<TreeNode> nodes = BuildTree(currentRoot, _PerformanceLogs[key], logQueue);
                while (logQueue.Count > 0)
                    _PerformanceLogs[key].Push(logQueue.Dequeue());
                while (nodes.Count > 0)
                    currentRoot.Nodes.Add(nodes.Pop());
            }
        }

        public Stack<TreeNode> BuildTree(TreeNode root, Stack<PerformanceLog> logEntries, Queue<PerformanceLog> logQueue)
        {
            Stack<TreeNode> childNodes = new Stack<TreeNode>();
            if (logEntries == null)
                return null;
            PerformanceLog lastLog = null;
            TreeNode lastNode = null;
            while (logEntries.Count > 0)
            {
                if(lastLog != null  && logEntries.Peek().Level < lastLog.Level)
                {
                    return childNodes;
                }
                PerformanceLog log = logEntries.Pop();
                logQueue.Enqueue(log);
                TreeNode currentNode = new TreeNode
                {
                    Text = $"{log.Method} duration ({log.Duration:#0.00}ms)",
                    Tag = log
                };
                if (lastLog != null)
                {
                    if (log.Level == lastLog.Level) //Same level
                    {
                        childNodes.Push(currentNode);
                        lastLog = log;
                        lastNode = currentNode;
                    }
                    else if (log.Level > lastLog.Level) //Child;
                    {
                        BuildSubTree(currentNode, null,  logEntries, logQueue);
                        lastNode.Nodes.Add(currentNode);
                    }
                }
                else
                {
                    lastLog = log;
                    lastNode = currentNode;
                    childNodes.Push(currentNode);
                }
            }
            return childNodes;
        }

        public void BuildSubTree(TreeNode root, TreeNode lastNode, Stack<PerformanceLog> logEntries, Queue<PerformanceLog> logQueue)
        {
            Stack<TreeNode> childNodes = new Stack<TreeNode>();
            if (logEntries == null)
                return;
            PerformanceLog lastLog = null;
            while (logEntries.Count > 0)
            {
                if (lastLog != null && logEntries.Peek().Level < lastLog.Level)
                {
                    while (childNodes.Count > 0)
                        root.Nodes.Add(childNodes.Pop());
                    return;
                }
                PerformanceLog log = logEntries.Pop();
                logQueue.Enqueue(log);
                TreeNode currentNode = new TreeNode
                {
                    Text = $"{log.Method} duration ({log.Duration:#0.00}ms)",
                    Tag = log
                };
                if (lastLog != null)
                {
                    if (log.Level == lastLog.Level) //Same level
                    {
                        childNodes.Push(currentNode);
                        lastLog = log;
                        lastNode = currentNode;
                    }
                    else if (log.Level > lastLog.Level) //Child;
                    {
                        BuildSubTree(lastNode, currentNode, logEntries, logQueue);
                    }
                }
                else
                {
                    lastLog = log;
                    lastNode = currentNode;
                    childNodes.Push(currentNode);
                }
            }
            while (childNodes.Count > 0)
                root.Nodes.Add(childNodes.Pop());
        }

        private void tvPerformance_AfterSelect(object sender, TreeViewEventArgs e)
        {
            fcrtxtbLogView.Text = "";
            fctxtbStackTrace.Text = "";
            if (e.Node != null && e.Node.Tag != null)
            {
                fcrtxtbLogView.Text = (e.Node.Tag as PerformanceLog).JsonObject.ToString().JsonPrettify();
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
                fcrtxtbLogView.Text = jsonString.JsonPrettify();
                JObject json = JObject.Parse(jsonString);
                var stackTrace = json.SelectToken("@x");
                if (stackTrace != null)
                    fctxtbStackTrace.Text = stackTrace.ToString().Replace("\\r\\n", "\r\n");
            }
        }

        private void tscmbxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbxFilterdLogs.Items.Clear();
            if (tscmbxLevel.SelectedItem != null && _SelectedTPA != null)
            {
                int level = (int)tscmbxLevel.SelectedItem;
                PerformanceLog[] logs = _PerformanceLogs[_SelectedTPA].Where(i => i.Level <= level).ToArray();
                foreach (PerformanceLog log in logs)
                {
                    lbxFilterdLogs.Items.Add(log);
                }
                ShowStatistics(logs);
            }
        }

        private void tscmbxTPA_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbxFilterdLogs.Items.Clear();
            if (tscmbxTPA.SelectedItem != null)
            {
                _SelectedTPA = tscmbxTPA.SelectedItem as string;
                PerformanceLog[] logs = _PerformanceLogs[_SelectedTPA].ToArray();
                foreach (PerformanceLog log in logs)
                {
                    lbxFilterdLogs.Items.Add(log);
                }
                ShowStatistics(logs);
            }
        }

        private void lbxFilterdLogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            fcrtxtbLogView.Text = "";
            fctxtbStackTrace.Text = "";
            if (lbxFilterdLogs.SelectedItem != null)
            {
                fcrtxtbLogView.Text = (lbxFilterdLogs.SelectedItem as PerformanceLog).JsonObject.ToString().JsonPrettify();
            }
        }

        private void ShowStatistics(PerformanceLog[] logs)
        {
            tpStatistics.Controls.Clear();
            PerformanceLog[] subList = logs.Where(l => l.Level == 1).ToArray();
            if(subList.Any())
            {
                PerformanceStatistics stats = new PerformanceStatistics
                {
                    Level = 1,
                    Logs = subList
                };
                tpStatistics.Controls.Add(stats);
                stats.Dock = DockStyle.Top;
            }
            subList = logs.Where(l => l.Level == 2).ToArray();
            if (subList.Any())
            {
                PerformanceStatistics stats = new PerformanceStatistics
                {
                    Level = 2,
                    Logs = subList
                };
                tpStatistics.Controls.Add(stats);
                stats.Dock = DockStyle.Top;
            }
            subList = logs.Where(l => l.Level == 3).ToArray();
            if (subList.Any())
            {
                PerformanceStatistics stats = new PerformanceStatistics
                {
                    Level = 3,
                    Logs = subList
                };
                tpStatistics.Controls.Add(stats);
                stats.Dock = DockStyle.Top;
            }
            subList = logs.Where(l => l.Level == 4).ToArray();
            if (subList.Any())
            {
                PerformanceStatistics stats = new PerformanceStatistics
                {
                    Level = 4,
                    Logs = subList
                };
                tpStatistics.Controls.Add(stats);
                stats.Dock = DockStyle.Top;
            }
            subList = logs.Where(l => l.Level == 5).ToArray();
            if (subList.Any())
            {
                PerformanceStatistics stats = new PerformanceStatistics
                {
                    Level = 5,
                    Logs = subList
                };
                tpStatistics.Controls.Add(stats);
                stats.Dock = DockStyle.Top;
            }
        }
    }
}
