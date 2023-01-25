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
namespace APITester.Dialog
{
    public partial class LogEntryViewer : Form
    {
        public LogEntryViewer()
        {
            InitializeComponent();
        }

        public DialogResult ShowModal(PerformanceLog value)
        {
            LogEntryViewer dialog = new LogEntryViewer();
            if(value != null)
            {
                dialog.lblLevel.Text = $"Level: {value.Level}";
                dialog.lblTpa.Text = $"TPA: {value.TPA}";
                dialog.lblMethod.Text = $"Method: {value.Method}";
                dialog.lblDetail.Text = $"Detail: {value.Detail}";
                dialog.lblDuration.Text = $"Duration: {value.Duration}";
            }
            else
            {
                dialog.lblLevel.Text = "Level: ";
                dialog.lblTpa.Text = "TPA: ";
                dialog.lblMethod.Text = "Method:";
                dialog.lblDetail.Text = "Detail:";
                dialog.lblDuration.Text = "Duration:";
            }
            return dialog.ShowDialog();
        }
    }
}
