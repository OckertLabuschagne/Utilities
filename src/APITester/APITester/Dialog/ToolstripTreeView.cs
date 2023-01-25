using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APITester.Dialog
{
    public partial class ToolstripTreeView : ToolStripControlHost
    {
        public ToolstripTreeView()
            : base(new TreeViewCombo())
        {
            TreeView.AfterSelect += Control_AfterSelect;
            TreeView.Height = 200;
        }

        private void Control_AfterSelect(object sender, TreeViewEventArgs e)
        {
            OnAfterSelect(e);
        }

        public TreeViewCombo TreeView { get => base.Control as TreeViewCombo; }

        public TreeNode SelectedNode { get => TreeView.SelectedNode; set => TreeView.SelectedNode = value; }
        public TreeNodeCollection Nodes { get => TreeView.Nodes; }

        protected virtual void OnAfterSelect(TreeViewEventArgs e)
        {
            AfterSelect?.Invoke(this, e);
        }

        [Category("Behavior")]
        public event TreeViewEventHandler AfterSelect;
    }
}
