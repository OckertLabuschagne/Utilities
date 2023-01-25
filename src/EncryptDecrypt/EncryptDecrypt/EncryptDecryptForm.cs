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
using SEFI.Encryption;

namespace EncryptDecrypt
{
    public partial class EncryptDecryptForm : Form
    {
        private int intSaltLen = 5;
        private const string PWD_SUFFIX_NEW = "1F3n!%zy";
        private const int _encSalt = 509;
        private const int _encLength = 8;
        private static byte[] _IVBytes = new byte[] { 1, 3, 6, 23, 45, 16, 78, 20, 194, 78, 209, 39, 69, 74, 123, 43 };
        private const string _wexAddMessage = "You can add this TPA configuration";
        private const string _wexAddPressedMessage = "Update the TPA name and fields, then press the Commit button, or undo it";
        private const string _wexEditMessage = "You can edit, rename, copy or delete this TPA configuration";

        public EncryptDecryptForm()
        {
            InitializeComponent();
        }

        public  string Encrypt(string strStringToEncrypt)
        {
            if (strStringToEncrypt == null || strStringToEncrypt.Length == 0)
            {
                return "";
            }

            SymmetricAlgorithm objCryptoService = new TripleDESCryptoServiceProvider();
            objCryptoService.Mode = CipherMode.CBC;
            byte[] btToEncrypt = System.Text.ASCIIEncoding.ASCII.GetBytes(GenerateSeed2() + strStringToEncrypt + GenerateSeed2());

            objCryptoService.Key = GetLegalKey(objCryptoService);
            objCryptoService.IV = new byte[] { 0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9 };

            using (ICryptoTransform objTransform = objCryptoService.CreateEncryptor())
            using (System.IO.MemoryStream objMS = new System.IO.MemoryStream())
            {
                CryptoStream objCS = new CryptoStream(objMS, objTransform, CryptoStreamMode.Write);

                objCS.Write(btToEncrypt, 0, btToEncrypt.Length);
                objCS.FlushFinalBlock();

                byte[] btEncrypted = objMS.ToArray();

                return Convert.ToBase64String(btEncrypted, 0, btEncrypted.Length);
            }
        }
        private  string GenerateSeed2()
        {
            byte[] rndHlp = new byte[intSaltLen];

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(rndHlp);

            return System.Text.ASCIIEncoding.ASCII.GetString(rndHlp);
        }
        private static byte[] GetLegalKey(SymmetricAlgorithm objCryptoService)
        {
            string strKey = PWD_SUFFIX_NEW;
            // Adjust key if necessary, and return a valid key
            if (objCryptoService.LegalKeySizes.Length > 0)
            {
                // Key sizes in bits
                int intKeySize = strKey.Length * 8;
                int intMinSize = objCryptoService.LegalKeySizes[0].MinSize;
                int intMaxSize = objCryptoService.LegalKeySizes[0].MaxSize;
                int intSkipSize = objCryptoService.LegalKeySizes[0].SkipSize;

                if (intKeySize > intMaxSize)
                {
                    // Extract maximum size allowed
                    strKey = strKey.Substring(0, intMaxSize / 8);
                }
                else if (intKeySize < intMaxSize)
                {
                    // Set valid size
                    int intValidSize = (intKeySize <= intMinSize) ? intMinSize :
                        (intKeySize - intKeySize % intSkipSize) + intSkipSize;
                    if (intKeySize < intValidSize)
                    {
                        // Pad the key with asterisk to make up the size
                        strKey = strKey.PadRight(intValidSize / 8, '*');
                    }
                }
            }
            return System.Text.Encoding.ASCII.GetBytes(strKey);
        }
        public string Decrypt(string strStringToDecrypt)
        {
            if (strStringToDecrypt == null || strStringToDecrypt.Length == 0)
            {
                return "";
            }

            string strRet = "";
            try
            {
                SymmetricAlgorithm objCryptoService = new TripleDESCryptoServiceProvider();
                objCryptoService.Mode = CipherMode.CBC;
                byte[] btToDecrypt = Convert.FromBase64String(strStringToDecrypt);

                objCryptoService.Key = GetLegalKey(objCryptoService);
                objCryptoService.IV = new byte[] { 0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9 };

                using (ICryptoTransform objTransform = objCryptoService.CreateDecryptor())
                using (System.IO.MemoryStream objMS = new System.IO.MemoryStream(btToDecrypt, 0, btToDecrypt.Length))
                {

                    CryptoStream objCS = new CryptoStream(objMS, objTransform, CryptoStreamMode.Read);

                    // Get the result from the Crypto stream
                    System.IO.StreamReader objSR = new System.IO.StreamReader(objCS);
                    strRet = objSR.ReadToEnd();
                    return strRet.Substring(intSaltLen, strRet.Length - intSaltLen - intSaltLen);
                }
            }
            catch (Exception ex)
            {
            }
            return null;
            //try
            //{
            //    strRet = DecryptOld(strStringToDecrypt);
            //    if (strRet == null)
            //    {
            //        strRet = "";
            //    }
            //}
            //catch { }

            //if (strRet != "")
            //{
            //    return strRet;
            //}

            //try
            //{
            //    if (strRet == "")
            //    {
            //        strRet = DecryptRC4(strStringToDecrypt);
            //    }
            //    return strRet;
            //}
            //catch
            //{
            //    return strStringToDecrypt;
            //}
        }

        private void BtnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbDecrypted.Text))
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                txtbEncrypted.Text = Encrypt(txtbDecrypted.Text);
        }

        private void BtnDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbEncrypted.Text))
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                txtbDecrypted.Text = Decrypt(txtbEncrypted.Text);
        }

        private void BtnEncryptId_Click(object sender, EventArgs e)
        {
            txtbEncryptedId.Text = KeyGenerator.EncryptKey((int?)int.Parse(txtbDecryptedId.Text));
        }

        private void BtnEncryptWex_Click(object sender, EventArgs e)
        {
            txtbEncryptedWex.Text = EncryptData(35, txtbDecryptedWex.Text);
        }

        private void BtnDecryptId_Click(object sender, EventArgs e)
        {
            txtbDecryptedId.Text = $"{KeyGenerator.DecryptKey(txtbEncryptedId.Text)}";
        }

        private bool DisplayEditButtons
        {
            set
            {
                DisplayCommitButton = false;
                txtbAppSettingsFile.Enabled = true;
                btnOpenFile.Enabled = true;
                cmbxTpa.Enabled = true;

                if (value)
                {
                    if (cmbxTpa.SelectedIndex >= 0 && cmbxTpa.Text.Equals(cmbxTpa.SelectedItem))
                    {
                        btnWexEdit.Text = "Edit";
                        btnWexRename.Text = "Rename";
                        btnWexCopy.Text = "Copy";
                        btnWexDelete.Text = "Delete";
                        btnWexEdit.Enabled = true;
                        btnWexRename.Enabled = true;
                        btnWexCopy.Enabled = true;
                        btnWexDelete.Enabled = true;
                        btnWexEdit.Show();
                        btnWexRename.Show();
                        btnWexCopy.Show();
                        btnWexDelete.Show();
                    }
                    else
                    {
                        btnWexAdd.Text = "Add";
                        btnWexAdd.Show();
                    }
                }
                else
                {
                    btnWexAdd.Hide();
                    btnWexEdit.Hide();
                    btnWexRename.Hide();
                    btnWexCopy.Hide();
                    btnWexDelete.Hide();
                    DisplayRenameCopy = false;
                }
            }
        } 

        private void BtnDecryptWex_Click(object sender, EventArgs e)
        {
            txtbDecryptedWex.Text = DecryptData(35, txtbEncryptedWex.Text);
        }

        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            var openFileDialogForm = new OpenFileDialog
            {
                Filter = "Text Document(*.json)|*.json"
            };
            if (Directory.Exists(txtbAppSettingsFile.Text))
            {
                openFileDialogForm.InitialDirectory = txtbAppSettingsFile.Text;
            }
            else if (File.Exists(txtbAppSettingsFile.Text))
            {
                openFileDialogForm.InitialDirectory = Directory.GetParent(txtbAppSettingsFile.Text).FullName;
            }
            openFileDialogForm.ShowDialog();
            var filePath = openFileDialogForm.FileName;
            DisplayEditButtons = false;
            cmbxTpa.Enabled = false;
            EnableFields = false;
            GetTpas(filePath);
            txtbAppSettingsFile.Text = openFileDialogForm.FileName;            
        }

        private void GetTpas(string filePath, WexOperations operation = WexOperations.Edit)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader file = File.OpenText(filePath))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject json = (JObject)JToken.ReadFrom(reader);
                    var tpas = new SortedSet<string>();
                    var wex = json.SelectToken("WrightExpress");
                    if (wex != null)
                    {
                        foreach (var child in wex.Children())
                        {
                            var property = child as JProperty;
                            if (property != null)
                            {
                                var parts = property.Name.Split(':');
                                if (parts.Length == 3)
                                    if (!string.IsNullOrWhiteSpace(parts[0]))
                                        if (!tpas.Contains(parts[0]))
                                            tpas.Add(parts[0]);
                            }
                        }
                    }
                    cmbxTpa.Items.Clear();
                    foreach (var tpa in tpas)
                        cmbxTpa.Items.Add(tpa);

                    cmbxTpa.Enabled = true;
                    cmbxTpa.SelectedIndex = cmbxTpa.Items.IndexOf(cmbxTpa.Text);
                    GetWexValues(operation: operation);
                }
            }
        }

        private void BtnWexAdd_Click(object sender, EventArgs e)
        {
            if (btnWexAdd.Text.Equals("Undo"))
            {
                lblWexConfirmMsg.Hide();
                btnWexAdd.Text = "Add";
                EnableFields = false;
                DisplayCommitButton = false;
                lblWexMessage.ForeColor = Color.DarkBlue;
                lblWexMessage.Text = _wexAddMessage;
            }
            else
            {
                lblWexStatusMsg.Hide();
                btnWexAdd.Text = "Undo";
                txtbAppSettingsFile.Enabled = false;
                btnOpenFile.Enabled = false;
                EnableFields = true;
                DisplayCommitButton = true;
                lblWexMessage.ForeColor = Color.DarkBlue;
                lblWexMessage.Text = _wexAddPressedMessage;
                txtbLoginId.Select();
            }
        }

        private void BtnWexEdit_Click(object sender, EventArgs e)
        {
            if (btnWexEdit.Text.Equals("Undo"))
            {
                btnWexEdit.Text = "Edit";
                lblWexConfirmMsg.Hide();
                GetWexValues();
            }
            else
            {
                lblWexStatusMsg.Hide();
                btnWexEdit.Text = "Undo";
                btnWexRename.Enabled = false;
                btnWexCopy.Enabled = false;
                btnWexDelete.Enabled = false;
                txtbAppSettingsFile.Enabled = false;
                btnOpenFile.Enabled = false;
                cmbxTpa.Enabled = false;
                EnableFields = true;
                DisplayCommitButton = true;
                btnWexCommit.Enabled = true;
                lblWexMessage.ForeColor = Color.DarkBlue;
                lblWexMessage.Text = "Update the fields, then press the Commit button, or undo it";
                txtbLoginId.Select();
            }
        }

        private bool DisplayRenameCopy
        {
            set
            {
                if (value)
                {
                    lblWexRenameCopy.Show();
                    txtbWexNewTpa.Show();
                    EnableFields = true;
                }
                else
                {
                    btnWexRename.Text = "Rename";
                    btnWexCopy.Text = "Copy";
                    lblWexRenameCopy.Hide();
                    txtbWexNewTpa.Hide();
                }
            }
        }

        private bool DisplayCommitButton
        {
            set
            {
                if (value)
                {
                    btnWexCommit.Show();
                    btnWexCommit.Text = "Commit";
                }
                else
                    btnWexCommit.Hide();
            }
        }

        private void BtnWexRename_Click(object sender, EventArgs e)
        {
            if (btnWexRename.Text.Equals("Undo"))
            {
                DisplayRenameCopy = false;
                lblWexNewTpaMsg.Hide();
                lblWexConfirmMsg.Hide();
                GetWexValues();
            }
            else
            {
                lblWexStatusMsg.Hide();
                btnWexRename.Text = "Undo";
                lblWexRenameCopy.Text = "Rename to:";
                btnWexCommit.Text = "Commit";
                txtbWexNewTpa.Text = "";
                lblWexNewTpaMsg.Show();
                txtbWexNewTpa.Enabled = true;
                btnWexEdit.Enabled = false;
                btnWexCopy.Enabled = false;
                btnWexDelete.Enabled = false;
                txtbAppSettingsFile.Enabled = false;
                btnOpenFile.Enabled = false;
                cmbxTpa.Enabled = false;
                DisplayRenameCopy = true;
                DisplayCommitButton = true;
                lblWexMessage.ForeColor = Color.DarkBlue;
                lblWexMessage.Text = _wexAddPressedMessage;
                txtbWexNewTpa.Select();
            }
        }
        private void BtnWexCopy_Click(object sender, EventArgs e)
        {
            if (btnWexCopy.Text.Equals("Undo"))
            {
                DisplayRenameCopy = false;
                lblWexNewTpaMsg.Hide();
                lblWexConfirmMsg.Hide();
                GetWexValues();
            }
            else
            {
                lblWexStatusMsg.Hide();
                btnWexCopy.Text = "Undo";
                lblWexRenameCopy.Text = "Copy to:";
                txtbWexNewTpa.Text = "";
                lblWexNewTpaMsg.Show();
                txtbWexNewTpa.Enabled = true;
                btnWexEdit.Enabled = false;
                btnWexRename.Enabled = false;
                btnWexDelete.Enabled = false;
                txtbAppSettingsFile.Enabled = false;
                btnOpenFile.Enabled = false;
                cmbxTpa.Enabled = false;
                DisplayRenameCopy = true;
                DisplayCommitButton = true;
                lblWexMessage.ForeColor = Color.DarkBlue;
                lblWexMessage.Text = _wexAddPressedMessage;
                txtbWexNewTpa.Select();
            }
        }

        private void BtnWexDelete_Click(object sender, EventArgs e)
        {
            if (btnWexDelete.Text.Equals("Undo"))
            {
                DisplayRenameCopy = false;
                GetWexValues();
            }
            else
            {
                lblWexStatusMsg.Hide();
                btnWexDelete.Text = "Undo";
                btnWexEdit.Enabled = false;
                btnWexRename.Enabled = false;
                btnWexCopy.Enabled = false;
                txtbAppSettingsFile.Enabled = false;
                btnOpenFile.Enabled = false;
                cmbxTpa.Enabled = false;
                DisplayCommitButton = true;
                btnWexCommit.Enabled = true;
                lblWexMessage.ForeColor = Color.DarkBlue;
                lblWexMessage.Text = "Press the Commit button to delete, or undo it";
            }
        }

        private void BtnWexCommit_Click(object sender, EventArgs e)
        {
            WexOperations op;

            if (btnWexAdd.Visible && btnWexAdd.Text == "Undo")
                op = WexOperations.Add;
            else if (btnWexEdit.Visible && btnWexEdit.Text == "Undo")
                op = WexOperations.Edit;
            else if (btnWexRename.Visible && btnWexRename.Text == "Undo")
                op = WexOperations.Rename;
            else if (btnWexCopy.Visible && btnWexCopy.Text == "Undo")
                op = WexOperations.Copy;
            else if (btnWexDelete.Visible && btnWexDelete.Text == "Undo")
                op = WexOperations.Delete;
            else
                return;

            var filePath = txtbAppSettingsFile.Text;
            if (File.Exists(filePath))
            {
                JObject json = null;
                using (StreamReader file = File.OpenText(filePath))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    json = (JObject)JToken.ReadFrom(reader);
                    var tpas = new SortedSet<string>();
                    var wex = json.SelectToken("WrightExpress");
                    var overallState = WexUpdateStates.Success;
                    var states = new WexUpdateStates[5];

                    if (wex != null)
                    {
                        states[0] = SetProperty(wex, cmbxTpa.Text, Templates.LoginId, txtbLoginId.Text, op, txtbWexNewTpa.Text);
                        states[1] = SetProperty(wex, cmbxTpa.Text, Templates.UserName, txtbUserName.Text, op, txtbWexNewTpa.Text);
                        states[2] = SetProperty(wex, cmbxTpa.Text, Templates.Password, txtbPassword.Text, op, txtbWexNewTpa.Text);
                        states[3] = SetProperty(wex, cmbxTpa.Text, Templates.BankNumber, txtbBankNumber.Text, op, txtbWexNewTpa.Text);
                        states[4] = SetProperty(wex, cmbxTpa.Text, Templates.CompanyNumber, txtbCompanyNumber.Text, op, txtbWexNewTpa.Text);

                        foreach (var state in states)
                            if (state > overallState)
                                overallState = state;

                        if (btnWexCommit.Text == "Commit")
                            switch (overallState)
                            {
                                case WexUpdateStates.Missing:
                                    btnWexCommit.Text = "Confirm";
                                    lblWexConfirmMsg.Text = "One or more field\nsettings were missing.\n\nPress Confirm to commit";
                                    lblWexConfirmMsg.Show();
                                    EnableFields = false;
                                    return;

                                case WexUpdateStates.Overlay:
                                    btnWexCommit.Text = "Confirm";
                                    lblWexConfirmMsg.Text = "This will overlay one\nor more settings.\n\nPress Confirm to commit";
                                    lblWexConfirmMsg.Show();
                                    txtbWexNewTpa.Enabled = false;
                                    EnableFields = false;
                                    return;
                            }

                        btnWexCommit.Text = "Commit";
                        lblWexConfirmMsg.Hide();
                    }
                }

                string output = JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filePath, output);

                switch (op)
                {
                    case WexOperations.Add:
                    case WexOperations.Copy:
                        lblWexMessage.Text = _wexEditMessage;
                        GetTpas(txtbAppSettingsFile.Text, operation: op);
                        break;

                    case WexOperations.Rename:
                    case WexOperations.Delete:
                        lblWexMessage.Text = _wexAddMessage;
                        GetTpas(txtbAppSettingsFile.Text, operation: op);
                        break;

                    default:
                        lblWexMessage.Text = _wexEditMessage;
                        break;
                }

                lblTpaMsg.Hide();
                DisplayEditButtons = true;
                EnableFields = false;

                switch (op)
                {
                    case WexOperations.Add:
                        lblWexStatusMsg.Text = "Added";
                        lblWexStatusMsg.Show();
                        break;
                    case WexOperations.Edit:
                        lblWexStatusMsg.Text = "Updated";
                        lblWexStatusMsg.Show();
                        break;
                    case WexOperations.Copy:
                        lblWexStatusMsg.Text = "Copied";
                        lblWexStatusMsg.Show();
                        break;
                    case WexOperations.Rename:
                        lblWexStatusMsg.Text = "Renamed";
                        lblWexStatusMsg.Show();
                        break;
                    case WexOperations.Delete:
                        lblWexStatusMsg.Text = "Deleted";
                        lblWexStatusMsg.Show();
                        break;
                }

            }
        }

        private enum WexOperations: int
        {
            Add = 0,
            Edit = 1,
            Rename = 2,
            Copy = 3,
            Delete = 4
        }

        private bool EnableCommitButton
        {
            get
            {
                var enabled = true;
                enabled &= !lblLoginIdMsg.Visible;
                enabled &= !lblUserNameMsg.Visible;
                enabled &= !lblPasswordMsg.Visible;
                enabled &= !lblBankNumberMsg.Visible;
                enabled &= !lblCompanyNumberMsg.Visible;
                
                if (enabled)
                    lblWexFieldMsg.Hide();
                else
                    lblWexFieldMsg.Show();
                
                enabled &= !lblTpaMsg.Visible;
                enabled &= !lblWexNewTpaMsg.Visible;
                btnWexCommit.Enabled = enabled;
                return enabled;
            }
        }

        private void ToggleWexFieldMsg(TextBox txtb, Label lbl)
        {
            if (EnableFields && string.IsNullOrWhiteSpace(txtb.Text))
                lbl.Show();
            else
                lbl.Hide();

            var enabled = EnableCommitButton;
        }

        private bool EnableFields
        {
            get { return txtbLoginId.Enabled; }
            set
            {
                txtbLoginId.Enabled = value;
                txtbUserName.Enabled = value;
                txtbPassword.Enabled = value;
                txtbBankNumber.Enabled = value;
                txtbCompanyNumber.Enabled = value;

                ToggleWexFieldMsg(txtbLoginId, lblLoginIdMsg);
                ToggleWexFieldMsg(txtbUserName, lblUserNameMsg);
                ToggleWexFieldMsg(txtbPassword, lblPasswordMsg);
                ToggleWexFieldMsg(txtbBankNumber, lblBankNumberMsg);
                ToggleWexFieldMsg(txtbCompanyNumber, lblCompanyNumberMsg);

                if (!value) 
                {
                    txtbAppSettingsFile.Enabled = true;
                    btnOpenFile.Enabled = true;
                    cmbxTpa.Enabled = true;
                }
            }
        }

        private bool cmbxTpa_keyhandled = false;
        private bool cmbxTpa_keyChar = false;
        private bool cmbxTpa_control = false;

        private void CmbxTpa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbxTpa_keyhandled)
            {
                cmbxTpa.SelectedText += char.ToUpper(e.KeyChar);
                cmbxTpa_keyhandled = false;
                e.Handled = true;
            }
            else if (cmbxTpa_keyChar)
            {
                cmbxTpa.SelectedText += char.ToUpper(e.KeyChar);
                cmbxTpa_keyhandled = false;
                e.Handled = true;
            }
            else if (!cmbxTpa_control || e.KeyChar == '\r')
            {
                e.Handled = true;
            }
        }

        private void CmbxTpa_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbxTpa.Text))
            {
                cmbxTpa.Text = "";
                lblTpaMsg.Show();
            }
            else
                lblTpaMsg.Hide();

            var enabled = EnableCommitButton;
        }

        private void CmbxTpa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblWexStatusMsg.Hide();
                cmbxTpa.SelectedIndex = cmbxTpa.Items.IndexOf(cmbxTpa.Text);
                GetWexValues();
            }
            else if (!e.Shift && e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
                cmbxTpa_keyhandled = true;

            cmbxTpa_control = false;
            if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
                cmbxTpa_keyChar = true;

            else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
                cmbxTpa_keyChar = true;

            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                cmbxTpa_keyChar = true;

            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Decimal:
                    case Keys.Divide:
                    case Keys.OemBackslash:
                    case Keys.OemPipe:
                    case Keys.OemMinus:
                    case Keys.Oemplus:
                    case Keys.Oemcomma:
                    case Keys.OemQuestion:
                    case Keys.Oemtilde:
                    case Keys.OemPeriod:
                    case Keys.OemOpenBrackets:
                    case Keys.OemCloseBrackets:
                        cmbxTpa_keyChar = true;
                        break;

                    case Keys.LShiftKey:
                    case Keys.ShiftKey:
                    case Keys.Back:
                    case Keys.Enter:
                    case Keys.CapsLock:
                    case Keys.Alt:
                    case Keys.Control:
                    case Keys.Escape:
                    case Keys.Left:
                    case Keys.Cancel:
                        cmbxTpa_control = true;
                        cmbxTpa_keyChar = false;
                        break;

                    default:
                        cmbxTpa_keyChar = false;
                        break;
                }
            }
        }

        private void TxtbLoginId_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleWexFieldMsg(txtbLoginId, lblLoginIdMsg);
        }
        private void TxtbUserName_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleWexFieldMsg(txtbUserName, lblUserNameMsg);
        }
        private void TxtbPassword_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleWexFieldMsg(txtbPassword, lblPasswordMsg);
        }
        private void TxtbBankNumber_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleWexFieldMsg(txtbBankNumber, lblBankNumberMsg);
        }

        private void TxtbCompanyNumber_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleWexFieldMsg(txtbCompanyNumber, lblCompanyNumberMsg);
        }

        private bool txtbWexNewTpa_keyhandled = false;
        private bool txtbWexNewTpa_keyChar = false;
        private bool txtbWexNewTpa_control = false;

        private void TxtbWexNewTpa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtbWexNewTpa_keyhandled)
            {
                txtbWexNewTpa.SelectedText += char.ToUpper(e.KeyChar);
                txtbWexNewTpa_keyhandled = false;
                e.Handled = true;
            }
            else if (txtbWexNewTpa_keyChar)
            {
                txtbWexNewTpa.SelectedText += char.ToUpper(e.KeyChar);
                txtbWexNewTpa_keyhandled = false;
                e.Handled = true;
            }
            else if (!txtbWexNewTpa_control || e.KeyChar == '\r')
            {
                e.Handled = true;
            }
        }

        private void TxtbWexNewTpa_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbWexNewTpa.Text))
            {
                txtbWexNewTpa.Text = "";
                lblWexNewTpaMsg.Show();
            }
            else
                lblWexNewTpaMsg.Hide();

            var enabled = EnableCommitButton;
        }

        private void TxtbWexNewTpa_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.Enter)
            {
                var enable = EnableCommitButton;
            }
            else if (!e.Shift && e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
                txtbWexNewTpa_keyhandled = true;

            cmbxTpa_control = false;
            if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
                txtbWexNewTpa_keyChar = true;

            else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
                txtbWexNewTpa_keyChar = true;

            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                txtbWexNewTpa_keyChar = true;

            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Decimal:
                    case Keys.Divide:
                    case Keys.OemBackslash:
                    case Keys.OemPipe:
                    case Keys.OemMinus:
                    case Keys.Oemplus:
                    case Keys.Oemcomma:
                    case Keys.OemQuestion:
                    case Keys.Oemtilde:
                    case Keys.OemPeriod:
                    case Keys.OemOpenBrackets:
                    case Keys.OemCloseBrackets:
                        txtbWexNewTpa_keyChar = true;
                        break;

                    case Keys.LShiftKey:
                    case Keys.ShiftKey:
                    case Keys.Back:
                    case Keys.Enter:
                    case Keys.CapsLock:
                    case Keys.Alt:
                    case Keys.Control:
                    case Keys.Escape:
                    case Keys.Left:
                    case Keys.Cancel:
                        txtbWexNewTpa_control = true;
                        txtbWexNewTpa_keyChar = false;
                        break;

                    default:
                        txtbWexNewTpa_keyChar = false;
                        break;
                }
            }
        }

        private struct Templates
        {
            internal static string LoginId = "{0}::LoginId";
            internal static string UserName = "{0}::UserName";
            internal static string Password = "{0}::Password";
            internal static string BankNumber = "{0}::BankNumber";
            internal static string CompanyNumber = "{0}::CompanyNumber";
        }

        private string ParseProperty(JToken wex, string tpa, string template)
        {
            var arg = string.Format(template, tpa);
            var element = wex.SelectToken(arg);           
            if (element == null)
                return "";

            var value = element.ToString();
            return DecryptData(35, value);
        }

        private enum WexUpdateStates : int
        {
            Success = 0,
            Missing = 1,
            Overlay = 2
        }

        private WexUpdateStates SetProperty(JToken wex, string tpa, string template, string value, WexOperations op, string target = null)
        {
            var state = WexUpdateStates.Success;
            var arg = string.Format(template, tpa);
            var element = wex.SelectToken(arg);

            switch (op)
            {
                case WexOperations.Add:
                    if (element != null)
                        state = WexUpdateStates.Overlay;

                    wex[arg] = EncryptData(35, value);
                    return state;

                case WexOperations.Edit:
                    if (element == null)
                        state = WexUpdateStates.Missing;

                    wex[arg] = EncryptData(35, value);
                    return state;

                case WexOperations.Rename:
                    WexDelete(element, ref state);
                    WexCopy(wex, template, target, value, ref state);
                    return state;

                case WexOperations.Copy:
                    WexCopy(wex, template, target, value, ref state);
                    return state;

                case WexOperations.Delete:
                    WexDelete(element, ref state);
                    return state;
            }

            return state;
        }

        private void WexDelete(JToken element, ref WexUpdateStates state)
        {
            if (element == null)
                state = WexUpdateStates.Missing;
            else
                (element.Parent as JProperty).Remove();
        }

        private void WexCopy(JToken wex, string template, string target, string value, ref WexUpdateStates state)
        {
            var arg = string.Format(template, target);
            var element = wex.SelectToken(arg);

            if (element != null)
                state = WexUpdateStates.Overlay;

            wex[arg] = EncryptData(35, value);
        }

        private void CmbxTpa_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblWexStatusMsg.Hide();
            GetWexValues();
        }

        private void GetWexValues(WexOperations operation = WexOperations.Edit)
        {
            DisplayEditButtons = false;
            EnableFields = false;

            if (cmbxTpa.SelectedIndex < 0)
            {
                switch (operation)
                {
                    case WexOperations.Delete:
                    case WexOperations.Rename:
                        break;

                    default:
                        txtbLoginId.Text = "";
                        txtbUserName.Text = "";
                        txtbPassword.Text = "";
                        txtbBankNumber.Text = "";
                        txtbCompanyNumber.Text = "";
                        break;
                }
                lblWexMessage.Text = _wexAddMessage;

                if (string.IsNullOrWhiteSpace(cmbxTpa.Text))
                    lblTpaMsg.Show();

                DisplayEditButtons = true;
            }
            else
            {
                var filePath = txtbAppSettingsFile.Text;

                if (File.Exists(filePath))
                {
                    using (StreamReader file = File.OpenText(filePath))
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        JObject json = (JObject)JToken.ReadFrom(reader);
                        var tpas = new SortedSet<string>();
                        var wex = json.SelectToken("WrightExpress");
                        if (wex != null)
                        {
                            switch (operation)
                            {
                                case WexOperations.Rename:
                                case WexOperations.Delete:
                                    break;
                                default:
                                    txtbLoginId.Text = ParseProperty(wex, cmbxTpa.SelectedItem as string, Templates.LoginId);
                                    txtbUserName.Text = ParseProperty(wex, cmbxTpa.SelectedItem as string, Templates.UserName);
                                    txtbPassword.Text = ParseProperty(wex, cmbxTpa.SelectedItem as string, Templates.Password);
                                    txtbBankNumber.Text = ParseProperty(wex, cmbxTpa.SelectedItem as string, Templates.BankNumber);
                                    txtbCompanyNumber.Text = ParseProperty(wex, cmbxTpa.SelectedItem as string, Templates.CompanyNumber);
                                    break;
                            }
                            lblWexMessage.Text = _wexEditMessage;
                            DisplayEditButtons = true;
                            lblTpaMsg.Hide();
                        }
                    }
                }
            }
        }

        public static string EncryptKey(int salt, int length, params int[] values)
        {
            Random rnd = new Random(salt);
            int offset = rnd.Next(0, 10);
            string seperator = $"{(char)rnd.Next(33, 48)}";

            string toEncrypt = "";
            List<string> valStrings = new List<string>();
            foreach (int val in values)
            {
                string valstring = $"{val + offset:X}";
                while (valstring.Length < 4)
                    valstring += (char)rnd.Next(71, 91);
                valStrings.Add(valstring);
            }
            toEncrypt = string.Join(seperator, valStrings.ToArray());
            while (toEncrypt.Length < length)
            {
                toEncrypt += (char)rnd.Next(71, 91);
            }
            return toEncrypt;
        }

        public static void DecryptKey(int salt, string encryptedKey, out int[] values)
        {
            List<int> vals = new List<int>();
            Random rnd = new Random(salt);
            int offset = rnd.Next(0, 10);
            char seperator = (char)rnd.Next(33, 48);
            string[] parts = encryptedKey.Split(seperator);
            int val;
            foreach (string part in parts)
            {
                string intString = part;
                for (int i = 71; i < 91; i++)
                    intString = intString.Replace($"{(char)i}", "");
                if (int.TryParse(intString, NumberStyles.HexNumber, new CultureInfo("en-US"), out val))
                    vals.Add(val - offset);
            }
            values = vals.ToArray();
        }
        private static int _timeByteLength = 5;
        public static string EncryptData(int length, string value)
        {
            if (value.Length > length)
                throw new Exception("Value length is greater than configured length");

            var bytes = Encoding.ASCII.GetBytes(value.PadRight(length + _timeByteLength + 1));
            var jlen = _IVBytes.Length;
            byte rollOver = 0;

            var epochBytes = GetEpochTime();

            for (int i = 0; i < _timeByteLength; i++)
                bytes[length + i] = epochBytes[i];

            var updated = Encoding.ASCII.GetString(bytes);

            for (int n = 0; n < length + _timeByteLength; n++)
                for (int i = 0; i < length + _timeByteLength; i++)
                    for (int j = 0; j < jlen; j += 2)
                        EorAddRollLeft(ref bytes[i], j, ref rollOver);

            bytes[length + _timeByteLength] = rollOver;
            return Convert.ToBase64String(bytes);
        }

        private static byte[] GetEpochTime()
        {
            DateTime now = DateTime.Now;
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var tsEpoch = now - epoch;
            var seconds = (long)tsEpoch.TotalSeconds;
            return BitConverter.GetBytes(seconds);
        }

        private static void EorAddRollLeft(ref byte byt, int j, ref byte rollOver)
        {
            byt = (byte)(byt ^ _IVBytes[j]);
            if (j + 1 < _IVBytes.Length)
                if (byt + _IVBytes[j + 1] > 255)
                    byt = (byte)(byt + _IVBytes[j + 1] - 256);
                else
                    byt = (byte)(byt + _IVBytes[j + 1]);

            if (byt * 2 > 255)
            {
                byt = (byte)(byt * 2 + rollOver - 256);
                rollOver = 1;
            }
            else
            {
                byt = (byte)(byt * 2 + rollOver);
                rollOver = 0;
            }
        }

        public static string DecryptData(int length, string value)
        {
            byte[] data;

            try
            {
                data = Convert.FromBase64String(value);
            }
            catch
            {
                // it means this string is not really encrypted nor is it base64 format
                return value;
            }

            if (data.Length != length + _timeByteLength + 1)
                return value; // it means this string is not really encrypted

            byte rollOver = data[length + _timeByteLength];
            var bytes = new byte[length + _timeByteLength];
            Array.Copy(data, bytes, length + _timeByteLength);

            for (int n = 0; n < length + _timeByteLength; n++)
                for (int i = length + _timeByteLength - 1; i >= 0; i--)
                    for (int j = _IVBytes.Length - 1; j >= 1; j -= 2)
                        RollRightSubtractEor(ref bytes[i], j, ref rollOver);

            return Encoding.ASCII.GetString(bytes).Substring(0, length).Trim();
        }

        private static void RollRightSubtractEor(ref byte byt, int j, ref byte rollOver)
        {
            byte previousRollOver = (byte)(byt & 1);
            byt = (byte)(byt / 2 + rollOver * 128);
            rollOver = previousRollOver;

            if (byt - _IVBytes[j] < 0)
                byt = (byte)(byt - _IVBytes[j] + 256);
            else
                byt = (byte)(byt - _IVBytes[j]);

            if (j - 1 >= 0)
                byt = (byte)(byt ^ _IVBytes[j - 1]);
        }

        private void btn_Encrypt_Click(object sender, EventArgs e)
        {
            txtEncryptedString.Text = EncryptData(int.Parse(txtStrLen.Text), txtDecryptedString.Text);
        }

        private void btn_Decrypt_Click(object sender, EventArgs e)
        {
            txtDecryptedString.Text = DecryptData(int.Parse(txtStrLen.Text), txtEncryptedString.Text);
        }

        private void btnToBase64_Click(object sender, EventArgs e)
        {
            fctxtbBase64.Text = Convert.ToBase64String(Encoding.UTF8.GetBytes(fctxtbPlain.Text));
        }

        private void btnFromBase64_Click(object sender, EventArgs e)
        {
            fctxtbPlain.Text = Encoding.UTF8.GetString(Convert.FromBase64String(fctxtbBase64.Text));
        }
    }
}
