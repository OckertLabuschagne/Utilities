using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FI.Models;
namespace APITester.Dialog.Controls
{
    public partial class PerformanceStatistics : UserControl
    {
        public PerformanceStatistics()
        {
            InitializeComponent();
        }

        PerformanceLog[] _Logs;
        PerformanceLog[] _FilteredLogs;

        public int Level { set => groupBox1.Text = $"Level ({value})"; }

        public PerformanceLog[] Logs
        {
            set
            {
                _Logs = value;
                cmbxMethods.Items.Clear();
                cmbxMethods.Items.Add("All");
                foreach (PerformanceLog log in _Logs)
                {
                    if (!cmbxMethods.Items.Contains(log.Method))
                        cmbxMethods.Items.Add(log.Method);
                }
                cmbxMethods.SelectedIndex = cmbxMethods.Items.Count > 0 ? 0 : -1;
                cmbxDetails.Items.Clear();
                cmbxDetails.Items.Add("All");
                foreach (PerformanceLog log in _Logs)
                {
                    if (!cmbxDetails.Items.Contains(log.Detail))
                        cmbxDetails.Items.Add(log.Detail);
                }
                cmbxDetails.SelectedIndex = cmbxDetails.Items.Count > 0 ? 0 : -1;
                ShowStatistics(_Logs);
            }
        }

        private void ShowStatistics(PerformanceLog[] logs)
        {
            if (logs.Length > 0)
            {
                double average = logs.Average(l => l.Duration);
                double max = logs.Max(l => l.Duration);
                double min = logs.Min(l => l.Duration);
                lblSlowest.Tag = logs.Where(l => l.Duration == max).FirstOrDefault();
                lblFastest.Tag = logs.Where(l => l.Duration == min).FirstOrDefault();
                lblFastest.Text = $"Fastest: {min:#0.0}ms";
                lblSlowest.Text = $"Slowest: {max:#0.0}ms";
                lblAverage.Text = $"Average Duration: {average:#0.0}ms";
                lblNumberOfItems.Text = $"{logs.Length} entries";
            }
            else
            {
                lblFastest.Text = "Fastest: 0.0ms";
                lblSlowest.Text = "Slowest: 0.0ms";
                lblAverage.Text = "Average Duration: 0.0ms";
                lblNumberOfItems.Text = "0 entries";
            }
        }

        private void SelectLogs(string selectedMethod, string selectedDetail)
        {
            if (selectedMethod != null && selectedMethod != "All")
            {
                if (selectedDetail != null && selectedDetail != "All")
                    _FilteredLogs = _Logs.Where(l => l.Method == selectedMethod && l.Detail == selectedDetail).ToArray();
                else
                    _FilteredLogs = _Logs.Where(l => l.Method == selectedMethod).ToArray();
            }
            else
            {
                if (selectedDetail != null && selectedDetail != "All")
                    _FilteredLogs = _Logs.Where(l => l.Detail == selectedDetail).ToArray();
                else
                    _FilteredLogs = _Logs;
            }
            ShowStatistics(_FilteredLogs);
        }

        private void lblSlowest_DoubleClick(object sender, EventArgs e)
        {
            LogEntryViewer dialog = new LogEntryViewer();
            dialog.ShowModal(lblSlowest.Tag as PerformanceLog);
        }

        private void lblFastest_DoubleClick(object sender, EventArgs e)
        {
            LogEntryViewer dialog = new LogEntryViewer();
            dialog.ShowModal(lblFastest.Tag as PerformanceLog);
        }

        private void cmbxMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMethod = cmbxMethods.SelectedItem as string;
            string selectedDetail = cmbxDetails.SelectedItem as string;
            SelectLogs(selectedMethod, selectedDetail);
        }

        private void cmbxDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMethod = cmbxMethods.SelectedItem as string;
            string selectedDetail = cmbxDetails.SelectedItem as string;
            SelectLogs(selectedMethod, selectedDetail);
        }
    }
}
