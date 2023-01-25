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
    public partial class ToolStripDropdownCheckedListBox : ToolStripDropDown
    {
        public ToolStripDropdownCheckedListBox()
        {
            Items.Add(new ToolStripControlHost(control));

            control.SelectedIndexChanged += new EventHandler(control_SelectedIndexChanged);
            control.ItemCheck += new ItemCheckEventHandler(control_ItemCheck);
        }

        void control_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.Close(ToolStripDropDownCloseReason.ItemClicked);
            OnCheckChanged(e);
        }

        void control_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectionChanged();
        }

        public CheckedListBox Selector
        {
            get { return this.control; }
        }

        private void control_SelectionCancelled(object sender, EventArgs e)
        {
            this.Close(ToolStripDropDownCloseReason.CloseCalled);
        }

        protected override void OnOpening(System.ComponentModel.CancelEventArgs e)
        {
            base.OnOpening(e);

            ToolStripProfessionalRenderer renderer = Renderer as ToolStripProfessionalRenderer;

            if (renderer != null)
                control.BackColor = renderer.ColorTable.ToolStripDropDownBackground;
        }

        protected override void OnOpened(EventArgs e)
        {
            base.OnOpened(e);
            control.Focus();
        }

        private CheckedListBox control = new CheckedListBox();

        public object SelectedItem { get { return Selector.SelectedItem; } set { this.Selector.SelectedItem = value; } }
        public int SelectedIndex { get { return Selector.SelectedIndex; } set { Selector.SelectedIndex = value; } }

        public void OnSelectionChanged()
        {
            if (SelectionChanged != null)
                SelectionChanged(this, new EventArgs());
        }

        public void OnCheckChanged(ItemCheckEventArgs e)
        {
            if (CheckChanged != null)
                CheckChanged(this, e);
        }

        [Category("Behavior")]
        public event ItemCheckEventHandler CheckChanged;

        [Category("Behavior")]
        public event EventHandler SelectionChanged;
    }
}
