using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace APITester.Dialog
{
    public partial class TextFileEditor : Form
    {
        public TextFileEditor()
        {
            InitializeComponent();
        }
        private bool _IsDirty;
        string _FileFilter;

        public string FileName { get => tslblFileName.Text; set => tslblFileName.Text = value; }
        public string FileFilter { get => _FileFilter; set => SetFileFilter(value); }

        public DialogResult Edit(string fileName, string fileFilter)
        {
            FileName = fileName;
            switch (Path.GetExtension(FileName))
            {
                case "json":
                    fcrtbText.Language = FastColoredTextBoxNS.Language.JS;
                    break;
                case "cs":
                    fcrtbText.Language = FastColoredTextBoxNS.Language.CSharp;
                    break;
                default:
                    fcrtbText.Language = FastColoredTextBoxNS.Language.Custom;
                    break;
            }
            FileFilter = fileFilter;
            Text = $"Text Editor ({FileName}";
            fcrtbText.OpenFile(FileName);
            _IsDirty = false;
            return ShowDialog();
        }

        private void SetFileFilter(string fileFilter)
        {
            _FileFilter = fileFilter;
        }

        private void tsbtnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = FileFilter
            };

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                FileName = dialog.FileName;
                fcrtbText.OpenFile(FileName);
                _IsDirty = false;
            }
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FileName))
                saveAsToolStripMenuItem_Click(sender, e);
            else
            {
                fcrtbText.SaveToFile(FileName, Encoding.ASCII);
                _IsDirty = false;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = FileFilter
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileName = dialog.FileName;
                fcrtbText.SaveToFile(FileName, Encoding.ASCII);
                _IsDirty = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while(_IsDirty)
            {
                switch(MessageBox.Show("The data in the editor has changed since the last save.\nDo you want to save the data now?", "Unsaved Data", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    case DialogResult.Cancel:
                        return;
                    case DialogResult.Yes:
                        tsbtnSave_Click(this, EventArgs.Empty);
                        break;
                }
            }
            Close();
        }

        private void fcrtbText_TextChanging(object sender, FastColoredTextBoxNS.TextChangingEventArgs e)
        {
            _IsDirty = true;
        }

        private void TextFileEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            while (_IsDirty)
            {
                switch (MessageBox.Show("The data in the editor has changed since the last save.\nDo you want to save the data now?", "Unsaved Data", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        return;
                    case DialogResult.Yes:
                        tsbtnSave_Click(this, EventArgs.Empty);
                        break;
                }
            }
        }
    }
}
