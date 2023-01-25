using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEFI.Dialogs
{
    public partial class MultiValueInputDialog : Form
    {
        public MultiValueInputDialog()
        {
            InitializeComponent();
            Fields = new Fields();
            Fields.FieldAdded += Fields_FieldAdded;
            Fields.FieldDeleted += Fields_FieldDeleted;
            Fields.FieldValueChanged += Fields_FieldValueChanged;
        }

        private void Fields_FieldValueChanged(object sender, FieldEventArgs e)
        {
            foreach (UserControls.UserInputControl control in pnlEditor.Controls)
            {
                if (control.Tag == e.Field)
                {
                    control.Value = e.Field.Value;
                    break;
                }
            }
        }

        public Fields Fields { get; protected set; }

        private void Fields_FieldDeleted(object sender, FieldEventArgs e)
        {
            BuildUI();
        }

        private void Fields_FieldAdded(object sender, FieldEventArgs e)
        {
            BuildUI();
        }

        public void BuildUI()
        {
            pnlEditor.Controls.Clear();
            Height = 80;
            foreach(Field field in Fields)
            {
                UserControls.UserInputControl control = new UserControls.UserInputControl
                {
                    Text = field.Caption,
                    MultiLine = field.MultiLine,
                    SelectValue = field.SelectValue,
                    Items = field.Items,
                    Format = field.Format,
                    PasswordChar = field.PasswordChar,
                    HasButton = field.HasButton,
                    ButtonText = field.ButtonText,
                    Value = field.Value,
                    Tag = field,
                    Dock = DockStyle.Top,
                    Height = field.Height,
                    DisplayMember = field.DisplayMember,
                    InputType = field.InputType
                };
                control.ValueChanged += Control_ValueChanged;
                control.ButtonClicked += Control_ButtonClicked;
                pnlEditor.Controls.Add(control);
                control.BringToFront();
                Height += control.Height;
            }
        }


        public DialogResult ShowDialog(params Field[] fields)
        {
            Fields.AddRange(fields);
            BuildUI();
            return base.ShowDialog();
        }

        private void Control_ButtonClicked(object sender, EventArgs e)
        {
            UserControls.UserInputControl editor = sender as UserControls.UserInputControl;

            FieldRaisedEvent?.Invoke(sender, new FieldEventArgs { Field = Fields[Fields.IndexOf(editor.Tag as Field)] });
        }

        private void Control_ValueChanged(object sender, EventArgs e)
        {
            UserControls.UserInputControl editor = sender as UserControls.UserInputControl;
            Fields[Fields.IndexOf(editor.Tag as Field)].Value = editor.Value;
        }

        public event FieldEventHandler FieldRaisedEvent;
    }

    public class Field
    {
        object _Value;
        public Field(object value = null)
        {
            Height = 45;
            Caption = "Value";
            MultiLine = false;
            SelectValue = false;
            Items = null;
            Format = "{0}";
            PasswordChar = '\0';
            HasButton = false;
            ButtonText = null;
            InputType = UserControls.InputType.Derive;
            Value = value;
        }

        public UserControls.InputType InputType { get; set; }
        public string Caption { get; set; }
        public object Value { get => _Value; set => SetValue(value); }
        public int Height { get; set; }
        public bool MultiLine { get; set; }
        public bool SelectValue { get; set; }
        public IEnumerable Items { get; set; }
        public string Format { get; set; }
        public char PasswordChar { get; set; }
        public bool HasButton { get; set; }
        public string ButtonText { get; set; }
        public string DisplayMember { get; set; }
        public string Filter { get; set; } = "*.*";

        private void SetValue(object value)
        {
            _Value = value;
            OnValueChanged();
        }

        protected virtual void OnValueChanged()
        {
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler ValueChanged;
    }

    public class Fields : List<Field>
    {

        public new void Add(Field item)
        {
            base.Add(item);
            item.ValueChanged += Item_ValueChanged;
            OnFieldAdded(item);
        }

        private void Item_ValueChanged(object sender, EventArgs e)
        {
            OnFieldValueChanged(sender as Field);
        }

        public new void Remove(Field field)
        {
            base.Remove(field);
            OnFieldDeleted(field);
        }

        public new void RemoveAt(int index)
        {
            Field item = base[index];
            base.RemoveAt(index);
            OnFieldDeleted(item);
        }

        protected virtual void OnFieldAdded(Field field)
        {
            FieldAdded?.Invoke(this, new FieldEventArgs { Field = field });
        }

        protected virtual void OnFieldDeleted(Field field)
        {
            FieldDeleted?.Invoke(this, new FieldEventArgs { Field = field });
        }

        protected virtual void OnFieldValueChanged(Field field)
        {
            FieldValueChanged?.Invoke(this, new FieldEventArgs { Field = field });
        }

        public event FieldEventHandler FieldAdded;
        public event FieldEventHandler FieldDeleted;
        public event FieldEventHandler FieldValueChanged;
    }

    public class FieldEventArgs
    {
        public Field Field { get; set; }
    }

    public class CallBackEventArgs
    {
        Func<Field,bool> Function;
    }

    public delegate void FieldEventHandler(object sender, FieldEventArgs e);
    public delegate void CallBackEventHandler(object sender, CallBackEventArgs e);
}
