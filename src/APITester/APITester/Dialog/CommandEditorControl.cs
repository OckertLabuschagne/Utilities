using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using APITester.Models;
namespace APITester.Dialog
{
    public partial class CommandEditorControl : UserControl
    {
        Command _Command;
        string _selectedKey;
        public bool _Loading = false;
        public CommandEditorControl()
        {
            InitializeComponent();
        }

        public Command Command { get => _Command; set => SetCommand(value); }
        public bool CanGet { get => rbtnGet.Visible; set => rbtnGet.Visible = value; }
        public bool CanPost { get => rbtnPost.Visible; set => rbtnPost.Visible = value; }
        public bool CanPut { get => rbtnPut.Visible; set => rbtnPut.Visible = value; }
        public bool CanPatch { get => rbtnPatch.Visible; set => rbtnPatch.Visible = value; }

        public string GetRaw()
        {
            if (!string.IsNullOrEmpty(_Command.FilePath))
                return scsfIleUpload1.Json;
            return "";
        }
        private void SetCommand(Command value)
        {
            _Command = value;
            Enabled = _Command != null;
            PopulateUI();
        }

        public void ZoomIn()
        {
            scsfIleUpload1.ZoomIn();
            Font font = fctxtbRaw.Font;
            float size = font.Size + 1;

            fctxtbRaw.Font = new Font(font.FontFamily, size);
        }

        public void ZoomOut()
        {
            scsfIleUpload1.ZoomOut();
            Font font = fctxtbRaw.Font;
            float size = font.Size - 1;

            fctxtbRaw.Font = new Font(font.FontFamily, size);
        }

        private void PopulateUI()
        {
            _Loading = true;
            txtbName.Text = "";
            txtbURL.Text = "";
            fctxtbRaw.Text = "";
            groupBox1.Enabled = _Command != null;
            groupBox2.Enabled = _Command != null;
            groupBox3.Enabled = _Command != null;
            groupBox5.Enabled = _Command != null;
            dgvInput.Enabled = _Command != null;
            fctxtbRaw.Enabled = _Command != null;
            if (_Command != null)
            {
                txtbName.Text = _Command.Name;
                txtbURL.Text = _Command.URL;
                fctxtbRaw.Text = _Command.Raw;
                switch(_Command.Action)
                {
                    case ActionType.Get:
                        rbtnGet.Checked = true;
                        break;
                    case ActionType.Post:
                        rbtnPost.Checked = true;
                        break;
                    case ActionType.Put:
                        rbtnPut.Checked = true;
                        break;
                    case ActionType.Patch:
                        rbtnPatch.Checked = true;
                        break;
                }
                rbtnRaw.Checked = !string.IsNullOrEmpty(_Command.Raw);
                rbtnParameters.Checked = _Command.Parameters.Count() < 0;
                rbtnForm.Checked = _Command.Form.Count() > 0;
                rbtnSCSFileUpload.Checked = !string.IsNullOrEmpty(_Command.FilePath);
                scsfIleUpload1.UserId = _Command.UserId;
                scsfIleUpload1.FilePath = _Command.FilePath;
                scsfIleUpload1.Note = _Command.Note;
                SetDialog();
            }
            _Loading = false;
        }

        private void txtbName_TextChanged(object sender, EventArgs e)
        {
            if (!_Loading)
            {
                if (_Command != null)
                {
                    _Command.Name = txtbName.Text;
                }
                OnNameChanged(EventArgs.Empty);
            }
        }

        private void rbtnBody_CheckedChanged(object sender, EventArgs e)
        {
            SetDialog();
        }

        private void SetDialog()
        {
            dgvInput.Visible = rbtnForm.Checked || rbtnParameters.Checked;
            fctxtbRaw.Visible = rbtnRaw.Checked;
            scsfIleUpload1.Visible = rbtnSCSFileUpload.Checked;
        }

        private void rtbRaw_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            if (!_Loading)
                if (_Command != null)
                    _Command.Raw = fctxtbRaw.Text;
        }

        private void rbtnAction_CheckedChanged(object sender, EventArgs e)
        {
            if (_Command != null)
                _Command.Action = rbtnGet.Checked ? ActionType.Get : rbtnPost.Checked ? ActionType.Post : rbtnPut.Checked ? ActionType.Put : ActionType.Patch;
        }

        private void txtbURL_TextChanged(object sender, EventArgs e)
        {
            if (!_Loading)
                if (_Command != null)
                    _Command.URL = txtbURL.Text;
            OnURLChanged(new EventArgs());
        }

        private void dgvInput_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!_Loading)
            {
                if (rbtnForm.Checked)
                {
                    if (e.ColumnIndex == 0)
                    {
                        if (_selectedKey == null)
                        {
                            _selectedKey = dgvInput[e.ColumnIndex, e.RowIndex].Value as string;
                            _Command.Form.Add(_selectedKey, "");
                            dgvInput[1, e.RowIndex].ReadOnly = false;
                        }
                        else
                        {
                            string value = _Command.Form[_selectedKey];
                            _Command.Form.Remove(_selectedKey);
                            _selectedKey = dgvInput[e.ColumnIndex, e.RowIndex].Value as string;
                            _Command.Form.Add(_selectedKey, value);
                        }
                    }
                    else
                    {
                        _Command.Form[_selectedKey] = dgvInput[e.ColumnIndex, e.RowIndex].Value as string;
                    }
                }
                else
                {
                    if (e.ColumnIndex == 0)
                    {
                        if (_selectedKey == null)
                        {
                            _selectedKey = dgvInput[e.ColumnIndex, e.RowIndex].Value as string;
                            _Command.Parameters.Add(_selectedKey, "");
                            dgvInput[1, e.RowIndex].ReadOnly = false;
                        }
                        else
                        {
                            string value = _Command.Parameters[_selectedKey];
                            _Command.Parameters.Remove(_selectedKey);
                            _selectedKey = dgvInput[e.ColumnIndex, e.RowIndex].Value as string;
                            _Command.Parameters.Add(_selectedKey, value);
                        }
                    }
                    else
                    {
                        _Command.Parameters[_selectedKey] = dgvInput[e.ColumnIndex, e.RowIndex].Value as string;
                    }
                }
            }
        }

        private void dgvInput_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!_Loading)
            {
                if (dgvInput.Rows[e.RowIndex].IsNewRow)
                {
                    _selectedKey = null;
                    dgvInput[1, e.RowIndex].ReadOnly = true;
                }
                else
                {
                    _selectedKey = dgvInput[0, e.RowIndex].Value as string;
                }
            }
        }

        protected virtual void OnURLChanged(EventArgs e)
        {
            URLChanged?.Invoke(this, e);
        }

        protected virtual void OnNameChanged(EventArgs e)
        {
            NameChanged?.Invoke(this, e);
        }

        public event EventHandler URLChanged;
        public event EventHandler NameChanged;

        private void scsfIleUpload1_PropertyChanged(object sender, EventArgs e)
        {
            _Command.FilePath = scsfIleUpload1.FilePath;
            _Command.UserId = scsfIleUpload1.UserId;
            _Command.Note = scsfIleUpload1.Note;
        }
    }
}
