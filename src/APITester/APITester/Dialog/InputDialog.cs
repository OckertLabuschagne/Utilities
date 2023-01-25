using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APITester.Dialog
{
    public partial class InputDialog : Form
    {
        InputType _InputType;
        public InputDialog()
        {
            InitializeComponent();
        }

        public DialogResult Show(string text = "Input Dialog", string prompt = "Please provide value", InputType inputType = InputType.Text, IEnumerable<object> items = null, Icon icon = null)
        {
            Text = text;
            Prompt = prompt;
            InputType = inputType;
            Items = items;btnAction.Visible = false;
            if (icon != null)
                Icon = icon;
            return ShowDialog();
        }

        public string Prompt { get => lblPrompt.Text; set => lblPrompt.Text = value; }

        public InputType InputType
        {
            get { return _InputType; }
            set
            {
                _InputType = value;
                cmbxInput.Visible = false;
                txtbInput.Visible = false;
                switch (_InputType)
                {
                    case InputType.Text:
                        txtbInput.Visible = true;
                        break;
                    case InputType.Select:
                        cmbxInput.Visible = true;
                        break;
                }
            }
        }

        public IEnumerable<object> Items
        {
            set
            {
                cmbxInput.Items.Clear();
                if (value != null)
                    cmbxInput.Items.AddRange(value.ToArray());
            }
        }

        public object SelectedItem { get => cmbxInput.SelectedItem; set => cmbxInput.SelectedItem = value; }

        public string InputText { get => txtbInput.Text; set => txtbInput.Text = value; }

        public string DisplayMember { get => cmbxInput.DisplayMember; set => cmbxInput.DisplayMember = value; }

        public bool  ShowActionButton { get => btnAction.Visible; set => btnAction.Visible = value; }

        public string ActionButtonText { get => btnAction.Text; set => btnAction.Text = value; }

        private void BtnAction_Click(object sender, EventArgs e)
        {
            ActionButtonPressed?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler ActionButtonPressed;
    }

    public enum InputType
    {
        Text,
        Select
    }
}
