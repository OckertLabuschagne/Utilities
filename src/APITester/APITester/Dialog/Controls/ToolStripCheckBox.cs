using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SEFI.UserControls
{
    public partial class ToolStripCheckBox : ToolStripControlHost
    {
        public ToolStripCheckBox()
            : base(new CheckBox())
        {
            CheckBox.CheckedChanged += Control_CheckedChanged;
        }

        private void Control_CheckedChanged(object sender, EventArgs e)
        {
            OnCheckChanged(e);
        }

        [Category("Appearance")]
        public override string Text { get => CheckBox.Text; set => CheckBox.Text = value; }
        [Category("Appearance")]
        public bool Checked { get => CheckBox.Checked; set => CheckBox.Checked = value; }

        public CheckBox CheckBox
        {
            get { return base.Control as CheckBox; }
        }

        public void OnCheckChanged(EventArgs e)
        {
            CheckChanged?.Invoke(this, e);
        }

        [Category("Behavior")]
        public event EventHandler CheckChanged;
    }
}
