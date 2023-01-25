using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEFI.UserControls
{
    public partial class TextEditorControl : UserControl
    {
        public TextEditorControl()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public new string Text { get => fctxtbEditor.Text; set => fctxtbEditor.Text = value; }

        public FastColoredTextBoxNS.Language Language { get => fctxtbEditor.Language; set => fctxtbEditor.Language = value; }

        public bool ShowLineNumbers { get => fctxtbEditor.ShowLineNumbers; set => fctxtbEditor.ShowLineNumbers = value; }

        public DialogResult DialogResult { get; set; }

        private void OnClose(DialogResultEventArg e)
        {
            Close?.Invoke(this, e);
        }

        public event DialogResultEvemtHandler Close;
    }
}
