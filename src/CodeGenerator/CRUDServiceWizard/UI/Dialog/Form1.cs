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

using Newtonsoft.Json;


using CRUDServiceWizard.Project;

namespace CRUDServiceWizard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool _UnsavedFile = false;
        private string _ProjectFile;
        private CRUDServiceProject _Project;

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_UnsavedFile)
            {
                switch (MessageBox.Show("The project file has changes. Do you want to save it before you exit the program?", "Data Loss Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    case DialogResult.Cancel:
                        return;
                    case DialogResult.Yes:
                        SaveProject();
                        break;
                }
            }
            Application.Exit();
        }

        private void SaveProject()
        {
            if (string.IsNullOrEmpty(_ProjectFile))
            {
                SaveFileDialog dialog = new SaveFileDialog
                {
                    Title = "Project File",
                    Filter = "JSON File (*.json)|*.json"
                };
                if (dialog.ShowDialog() == DialogResult.Cancel)
                    return;
                _ProjectFile = dialog.FileName;
            }
            using (StreamWriter file = new StreamWriter(_ProjectFile, false))
            {
                file.Write(JsonConvert.SerializeObject(_Project));
                file.Flush();
                file.Close();
            }
        }
    }
}
