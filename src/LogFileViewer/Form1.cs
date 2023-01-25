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
using System.Reflection;

using LogFileViewer.Properties;

using Newtonsoft.Json;

namespace LogFileViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string _path;
        string[] files;

        Dictionary<int, string> logLines;
        List<string> tpas;
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            switch(toolStripComboBox1.SelectedItem)
            {
                case "QA Manual":
                    files = Directory.GetFiles(Settings.Default.QALogsManual);
                    _path = Settings.Default.QALogsManual;
                    foreach (string file in files)
                        listBox1.Items.Add(Path.GetFileName(file));
                    break;
                case "QA Automation":
                    files = Directory.GetFiles(Settings.Default.QALogsAutomation);
                    _path = Settings.Default.QALogsAutomation;
                    foreach (string file in files)
                        listBox1.Items.Add(Path.GetFileName(file));
                    break;
                case "Production":
                    files = Directory.GetFiles(Settings.Default.ProductionClaim);
                    _path = Settings.Default.ProductionClaim;
                    foreach (string file in files)
                        listBox1.Items.Add(Path.GetFileName(file));
                    break;
                case "UAT":
                    files = Directory.GetFiles(Settings.Default.UATLogs);
                    _path = Settings.Default.UATLogs;
                    foreach (string file in files)
                        listBox1.Items.Add(Path.GetFileName(file));
                    break;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbxLogEntries.Items.Clear();
            lbxTPA.Items.Clear();
            logLines = new Dictionary<int, string>();
            tpas = new List<string>();
            if (listBox1.SelectedItem != null)
            {
                using (StreamReader file = new StreamReader(Path.Combine(_path, listBox1.SelectedItem as string)))
                {
                    string logLine;
                    while (!file.EndOfStream) 
                    {
                        string tpa;
                        logLine = file.ReadLine();
                        if(logLine.Contains("- https "))
                        {
                            string s = logLine.Substring(logLine.IndexOf("- https ") + 1).Substring(logLine.IndexOf('/') + 1);
                            s = s.Substring(s.IndexOf('/') + 1);
                            if (s.IndexOf('/') < 0)
                                continue;
                            tpa = s.Substring(0, s.IndexOf('/'));
                            if (!tpas.Contains(tpa))
                            {
                                tpas.Add(tpa);
                                lbxTPA.Items.Add(tpa);                            
                            }
                        }
                        if (logLine.Contains("{"))
                        {
                            if (logLine.Contains("\"RequestPath\":\"/migrate/api/claim/v1/"))
                            {
                                string s = logLine.Substring(logLine.IndexOf("\"RequestPath\":\"/migrate/api/claim/v1/"));
                                s = s.Substring(s.IndexOf("v1") + 3, 6);
                                tpa = s.Substring(0, s.IndexOf('/'));
                                if (!tpas.Contains(tpa))
                                {
                                    tpas.Add(tpa);
                                    lbxTPA.Items.Add(tpa);
                                }
                            }
                            lbxLogEntries.Items.Add(logLines.Count);
                            logLines.Add(logLines.Count, logLine.Substring(logLine.IndexOf('{')));
                        }
                    }
                }
            }
        }

        private void lbxLogEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            fctxtbRaw.Text = "";
            dataGridView1.Rows.Clear();
            if (lbxLogEntries.SelectedItem != null)
            {
                fctxtbRaw.Text = JsonPrettify(logLines[(int)lbxLogEntries.SelectedItem]);
                LogEntry entry = JsonConvert.DeserializeObject<LogEntry>(fctxtbRaw.Text.Replace("\"@t\":", "\"Time\":").Replace("\"@mt\":", "\"Method\":").Replace("\"@l\":", "\"Type\":").Replace("\"@x\":", "\"StackTrace\":"));
                PropertyInfo[] properties = typeof(LogEntry).GetProperties();
                foreach(PropertyInfo property in properties)
                {
                    object value = property.GetValue(entry, null);
                    dataGridView1.Rows.Add(property.Name, value);
                }
            }
        }


        public string JsonPrettify(string json)
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

        private void tsbtnFindTPA_Click(object sender, EventArgs e)
        {
            lbxTPA.Items.Clear();
            tpas = new List<string>();
            toolStripProgressBar1.Maximum = listBox1.Items.Count;
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Visible = true;
            toolStripStatusLabel1.Visible = true;
            foreach (string fileName in listBox1.Items)
            {
                toolStripProgressBar1.Value += 1;
                toolStripStatusLabel1.Text = $"Processing {toolStripProgressBar1.Value} of {toolStripProgressBar1.Maximum}";
                Application.DoEvents();
                using (StreamReader file = new StreamReader(Path.Combine(_path, fileName)))
                {
                    string logLine;
                    while (!file.EndOfStream)
                    {
                        string tpa;
                        logLine = file.ReadLine();
                        if (logLine.Contains("- https "))
                        {
                            string s = logLine.Substring(logLine.IndexOf("- https ") + 1).Substring(logLine.IndexOf('/') + 1);
                            s = s.Substring(s.IndexOf('/') + 1);
                            tpa = s.Substring(0, s.IndexOf('/'));
                            if (!tpas.Contains(tpa))
                            {
                                tpas.Add(tpa);
                            }
                        }
                        if (logLine.Contains("{"))
                        {
                            if (logLine.Contains("\"RequestPath\":\"/migrate/api/claim/v1/"))
                            {
                                string s = logLine.Substring(logLine.IndexOf("\"RequestPath\":\"/migrate/api/claim/v1/"));
                                s = s.Substring(s.IndexOf("v1") + 3, 6);
                                tpa = s.Substring(0, s.IndexOf('/'));
                                if (!tpas.Contains(tpa))
                                {
                                    tpas.Add(tpa);
                                }
                            }
                        }
                    }
                }
            }
            foreach (string tpa in tpas)
                lbxTPA.Items.Add(tpa);
            toolStripProgressBar1.Visible = false;
            toolStripStatusLabel1.Visible = true;
        }

        private void tsbtnFilter_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] filteredFiles = files.Where(f => f.Contains(tstxtbFilter.Text)).ToArray();
            foreach(string fileName in filteredFiles)
            {
                listBox1.Items.Add(Path.GetFileName(fileName));
            }
        }
    }
}
