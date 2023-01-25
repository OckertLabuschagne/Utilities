using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEFI.UserControls
{
    public partial class UserInputControl : UserControl
    {
        private InputType _InputType = InputType.Derive;
        private bool _MultiLine = false;
        private object _Value;
        private Control _EditorControl;
        public UserInputControl()
        {
            InitializeComponent();
        }

        public override string Text { get => groupBox1.Text; set => groupBox1.Text = value; }
        public bool MultiLine { get; set; } = false;
        public bool SelectValue { get; set; } = false;
        public object Value { get => _Value; set => SetValue(value); }
        public bool HasButton { get; set; } = false;
        public string Format { get; set; } = "{0}";
        public string DisplayMember { get; set; }
        public string ButtonText { get; set; } = "...";
        public IEnumerable Items { get; set; }
        public char PasswordChar { get; set; } = '\0';
        public InputType InputType
        {
            get => _InputType;
            set
            {
                BuildUI(value);
            }
        }

        private void BuildUI(InputType value)
        {
            int controlIndex = 0;
            groupBox1.Controls.Clear();
            HasButton = HasButton | _InputType == InputType.Image | _InputType == InputType.Guid;
            if (HasButton)
            {
                Button button = new Button
                {
                    Dock = DockStyle.Right,
                    Text = ButtonText,
                    AutoSize = true
                };
                button.Click += Button_Click;
                groupBox1.Controls.Add(button);
            }
            _InputType = value;
            if (SelectValue)
            {
                ComboBox comboBox = new ComboBox
                {
                    Dock = DockStyle.Fill,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Visible = true,
                    DisplayMember = DisplayMember
                };
                comboBox.BringToFront();
                foreach (object item in Items)
                    comboBox.Items.Add(item);
                groupBox1.Controls.Add(comboBox);
                controlIndex = groupBox1.Controls.Count - 1;
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }
            else
            {
                switch (_InputType)
                {
                    case InputType.String:
                    case InputType.Decimal:
                    case InputType.Integer:
                        TextBox textbox = new TextBox
                        {
                            Dock = DockStyle.Fill,
                            Multiline = _MultiLine,
                            Text = _Value != null ? string.Format(Format, _Value) : string.Empty,
                            Visible = true
                        };
                        if (PasswordChar != '\0')
                            textbox.PasswordChar = PasswordChar;
                        textbox.BringToFront();
                        textbox.Leave += Textbox_Leave;
                        textbox.TextChanged += Textbox_TextChanged;
                        groupBox1.Controls.Add(textbox);
                        controlIndex = groupBox1.Controls.Count - 1;
                        break;
                    case InputType.Guid:
                        Label editor = new Label
                        {
                            Dock = DockStyle.Fill,
                            AutoSize = false,
                            Text = _Value != null ? string.Format(Format, _Value) : string.Empty,
                            Visible = true
                        };
                        editor.BringToFront();
                        groupBox1.Controls.Add(editor);
                        editor.TextChanged += Editor_TextChanged;
                        controlIndex = groupBox1.Controls.Count - 1;
                        break;
                    case InputType.Image:
                        Panel panel = new Panel
                        {
                            Dock = DockStyle.Fill,
                            BackgroundImageLayout = ImageLayout.Zoom
                        };
                        break;
                }
            }
            _EditorControl = groupBox1.Controls[controlIndex] as Control;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Value = (sender as ComboBox).SelectedItem;
            OnValueChanged(e);
        }

        private void Editor_TextChanged(object sender, EventArgs e)
        {
            Guid value;
            if (Guid.TryParse((sender as Label).Text, out value))
                _Value = value;
            else
                _Value = Guid.Empty;
        }

        public void SetValue(object value)
        {
            _Value = value;
            if (_Value == null)
                return;
            int intValue;
            decimal decimalValue;
            switch (_InputType)
            {
                case InputType.Derive:
                    Type valueType = value.GetType();
                    if (valueType == typeof(Image))
                        BuildUI(InputType.Image);
                    else if (valueType == typeof(Guid))
                        BuildUI(InputType.Guid);
                    else if (int.TryParse(value.ToString(), out intValue))
                        BuildUI(InputType.Integer);
                    else if (decimal.TryParse(value.ToString(), out decimalValue))
                        BuildUI(InputType.Integer);
                    else
                        BuildUI(InputType.String);
                    break;
                default:
                    if (_EditorControl == null)
                        BuildUI(_InputType);
                    break;
            }
            switch (_InputType)
            {
                case InputType.String:
                    (_EditorControl as TextBox).Text = value as string;
                    break;
                case InputType.Decimal:
                case InputType.Integer:
                    (_EditorControl as TextBox).Text = string.Format(Format, value);
                    break;
                case InputType.Guid:
                    (_EditorControl as Label).Text = value.ToString();
                    break;
                case InputType.Image:
                    (_EditorControl as Panel).BackgroundImage = value as Image;
                    break;
            }
        }

        public int GetInt()
        {
            int value;
            if (int.TryParse(_Value.ToString(), out value))
                return value;
            else
                throw new InvalidCastException($"{_Value} cannot be parsed as an integer");
        }

        public decimal GetDecimal()
        {
            Decimal value;
            if (decimal.TryParse(_Value.ToString(), out value))
                return value;
            else
                throw new InvalidCastException($"{_Value} cannot be parsed as a decimal");
        }

        public string GetString()
        {
            if (_Value is string)
                return _Value as string;
            else
                throw new InvalidCastException($"{_Value} is not a string value");
        }

        public Guid GetGuid()
        {
            if (_Value is Guid)
                return (Guid)_Value;
            else
                throw new InvalidCastException($"{_Value} is not a Guid value");
        }

        public Image GetImage()
        {
            if (_Value is Image)
                return _Value as Image;
            else
                throw new InvalidCastException($"The Value is not an image");
        }

        protected virtual void OnEditorLeave(EventArgs e)
        {
            EditorLeave?.Invoke(this, e);
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        protected virtual void OnButtonClicked(EventArgs e)
        {
            ButtonClicked?.Invoke(this, e);
        }

        private void Textbox_TextChanged(object sender, EventArgs e)
        {
            _Value = (sender as TextBox)?.Text;
            OnValueChanged(e);
        }

        private void Textbox_Leave(object sender, EventArgs e)
        {
            _Value = (sender as TextBox)?.Text;
            OnEditorLeave(EventArgs.Empty);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            switch(_InputType)
            {
                case InputType.Guid:
                    (_EditorControl as Label).Text = Guid.NewGuid().ToString();
                    break;
                case InputType.Image:
                    break;
            }

            OnButtonClicked(e);
        }

        public event EventHandler ValueChanged;
        public event EventHandler ButtonClicked;
        public event EventHandler EditorLeave;
    }

    public enum InputType
    {
        String,
        Integer,
        Decimal,
        Guid,
        Image,
        Derive
    }
}
