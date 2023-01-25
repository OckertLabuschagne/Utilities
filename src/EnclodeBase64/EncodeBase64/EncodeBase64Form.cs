using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Security;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;

namespace EnableBase64
{
    public partial class EnableBase64Form : Form
    {

        public void SelectOutput(string fileName)
        {
            txtbOutputFile.Text = fileName + ".base64";
        }

        public void Encode(string fileName)
        {
            if (!File.Exists(fileName))
                return;

            if (txtbOutputFile.Text == txtbInputFile.Text)
                return;

            FileStream fs;

            try
            {

                using (new FileStream(txtbOutputFile.Text, FileMode.Append, FileAccess.Write));

                if (File.Exists(txtbOutputFile.Text))
                    File.Delete(txtbOutputFile.Text);

                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            try
            {
                var previewerIsEmpty = true;
                prgbEncoding.Minimum = 0;
                prgbEncoding.Maximum = 100;
                prgbEncoding.Value = 0;

                var fileSize = fs.Length;
                var progressSize = 0L;
                var buffer = new byte[10239];
                var bytesRead = fs.Read(buffer, 0, buffer.Length);

                while (bytesRead > 0)
                {
                    byte[] secondaryBuffer = new byte[buffer.Length];
                    int secondaryBufferBytesRead = bytesRead;
                    Array.Copy(buffer, secondaryBuffer, buffer.Length);
                    bool isFinalChunk = false;
                    Array.Clear(buffer, 0, buffer.Length);
                    bytesRead = fs.Read(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        isFinalChunk = true;
                        buffer = new byte[secondaryBufferBytesRead];
                        Array.Copy(secondaryBuffer, buffer, buffer.Length);
                    }

                    String base64String = Convert.ToBase64String(isFinalChunk ? buffer : secondaryBuffer);
                    if (previewerIsEmpty)
                    {
                        previewerIsEmpty = false;
                        txtbEnableBase64File.Text = base64String;
                    }
                    File.AppendAllText(txtbOutputFile.Text, base64String);
                    progressSize += bytesRead;

                    prgbEncoding.Value = (int)(100 * ((double)progressSize / (double)fileSize));
                    Application.DoEvents();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            finally
            {
                prgbEncoding.Value = 100;
                fs.Dispose();
            }
        }

        public EnableBase64Form()
        {
            InitializeComponent();
        }
        private void BtnOpenInputFile_Click(object sender, EventArgs e)
        {
            var openFileDialogForm = new OpenFileDialog
            {
            };
            if (Directory.Exists(txtbInputFile.Text))
            {
                openFileDialogForm.InitialDirectory = txtbInputFile.Text;
            }
            else if (File.Exists(txtbInputFile.Text) || Directory.Exists(txtbInputFile.Text))
            {
                openFileDialogForm.InitialDirectory = Directory.GetParent(txtbInputFile.Text).FullName;
            }
            openFileDialogForm.ShowDialog();

            if (!string.IsNullOrWhiteSpace(openFileDialogForm.FileName))
            {
                txtbInputFile.Text = openFileDialogForm.FileName;
                SelectOutput(openFileDialogForm.FileName);
            }
        }

        private void BtnOpenOutputFile_Click(object sender, EventArgs e)
        {
            var openFileDialogForm = new OpenFileDialog
            {
            };
            if (Directory.Exists(txtbOutputFile.Text))
            {
                openFileDialogForm.InitialDirectory = txtbOutputFile.Text;
            }
            else if (File.Exists(txtbOutputFile.Text) || Directory.Exists(txtbOutputFile.Text))
            {
                openFileDialogForm.InitialDirectory = Directory.GetParent(txtbOutputFile.Text).FullName;
            }
            openFileDialogForm.ShowDialog();

            if (!string.IsNullOrWhiteSpace(openFileDialogForm.FileName))
                txtbOutputFile.Text = openFileDialogForm.FileName;
        }

        private void BtnEncode_Click(object sender, EventArgs e)
        {
            Encode(txtbInputFile.Text);
        }

        private void EnableBase64Form_Load(object sender, EventArgs e)
        {

        }
    }
}
