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

namespace APITester.Dialog.Controls
{
    public partial class SCSFIleUpload : UserControl
    {
        Attachment _attachment = new Attachment();
        public SCSFIleUpload()
        {
            InitializeComponent();
        }

        private void txtbUserId_Leave(object sender, EventArgs e)
        {
            _attachment.UserId = txtbUserId.Text;
            CreateJson();
            OnPropertyChanged();
        }

        public void ZoomIn()
        {
            Font font = fctxtbTextPreview.Font;
            float size = font.Size + 1;

            fctxtbTextPreview.Font = new Font(font.FontFamily, size);
            fctxtbJson.Font = new Font(font.FontFamily, size);
        }

        public void ZoomOut()
        {
            Font font = fctxtbTextPreview.Font;
            float size = font.Size - 1;

            fctxtbTextPreview.Font = new Font(font.FontFamily, size);
            fctxtbJson.Font = new Font(font.FontFamily, size);
        }

        private void txtbNote_Leave(object sender, EventArgs e)
        {
            _attachment.Notes = txtbNote.Text;
            CreateJson();
            OnPropertyChanged();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                _attachment.FileName = Path.GetFileName(dialog.FileName);
                byte[] fileContent = File.ReadAllBytes(dialog.FileName);
                SetFileUI(fileContent);
                _attachment.FileContent = Convert.ToBase64String(fileContent);
                lblFileName.Text = dialog.FileName;
            }
            CreateJson();
            OnPropertyChanged();
        }

        private void SetFileUI(byte[] fileContent)
        {
            gbPreview.Visible = false;
            pnlImage.Visible = false;
            fctxtbTextPreview.Visible = false;
            string extension = Path.GetExtension(_attachment.FileName);
            switch (extension)
            {
                case ".pdf":
                case ".doc":
                case ".docx":
                case ".pptx":
                case ".ppt":
                case ".xls":
                case ".xlsx":
                case ".zip":
                case ".rar":
                    break;
                case ".gif":
                case ".tif":
                case ".tiff":
                case ".bmp":
                case ".png":
                case ".rtf":
                case ".ico":
                case ".csv":
                case ".jpg":
                case ".jpeg":
                    gbPreview.Visible = true; ;
                    pnlImage.Visible = true;
                    pnlImage.BackgroundImage = Image.FromStream(new MemoryStream(fileContent));
                    break;
                case ".txt":
                case ".xml":
                case ".html":
                    gbPreview.Visible = true; ;
                    fctxtbTextPreview.Visible = true;
                    fctxtbTextPreview.Text = Encoding.Default.GetString(fileContent);
                    fctxtbTextPreview.Language = extension == ".html" ? FastColoredTextBoxNS.Language.HTML :
                         extension == ".xml" ? FastColoredTextBoxNS.Language.XML : FastColoredTextBoxNS.Language.Custom;
                    break;
            }
        }

        public string Json
        {
            get => fctxtbJson.Text; 
            set
            {
                fctxtbJson.Text = value;
                if (!string.IsNullOrEmpty(value))
                    _attachment = JsonConvert.DeserializeObject<Attachment>(value);
            }
        }

        public string UserId
        {
            get => txtbUserId.Text; 
            set
            {
                txtbUserId.Text = value;
                _attachment.UserId = txtbUserId.Text;
                CreateJson();
            }
        }
        public string Note
        {
            get => txtbNote.Text;
            set
            {
                txtbNote.Text = value;
                _attachment.Notes = txtbNote.Text;
                CreateJson();
            }
        }
        public string FilePath
        {
            get => lblFileName.Text; 
            set
            {
                lblFileName.Text = value;
                if (!string.IsNullOrEmpty(value))
                {
                    _attachment.FileName = Path.GetFileName(value);
                    byte[] fileContent = File.ReadAllBytes(value);
                    _attachment.FileContent = Convert.ToBase64String(fileContent);
                    SetFileUI(fileContent);
                }
                CreateJson();
            }
        }

        protected virtual void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, EventArgs.Empty);
        }

        private void CreateJson()
        {
            fctxtbJson.Text = JsonPrettify(JsonConvert.SerializeObject(_attachment));
        }

        public event EventHandler PropertyChanged;

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

    }
}
