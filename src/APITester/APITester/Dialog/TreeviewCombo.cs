using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;

namespace APITester.Dialog
{
    [SecurityPermissionAttribute(
            SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    public partial class TreeViewCombo : ComboBox
    {
        ToolStripControlHost treeViewHost;
        ToolStripDropDown dropDown;
        public TreeViewCombo()
        {
            TreeView treeView = new TreeView();
            treeView.PathSeparator = ".";
            treeView.AfterSelect += TreeView_AfterSelect;
            treeView.BorderStyle = BorderStyle.None;
            treeViewHost = new ToolStripControlHost(treeView);
            dropDown = new ToolStripDropDown();
            dropDown.Items.Add(treeViewHost);
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            OnAfterSelect(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            TreeView.Width = Width;
        }

        public TreeView TreeView
        {
            get { return treeViewHost.Control as TreeView; }
        }

        public TreeNode SelectedNode { get => TreeView.SelectedNode; set => TreeView.SelectedNode = value; }

        public TreeNodeCollection Nodes { get => TreeView.Nodes; }

        private void ShowDropDown()
        {
            if (dropDown != null)
            {
                treeViewHost.Width = DropDownWidth;
                treeViewHost.Height = DropDownHeight;
                dropDown.Show(this, 0, this.Height);
            }
        }

        private const int WM_USER = 0x0400,
                          WM_REFLECT = WM_USER + 0x1C00,
                          WM_COMMAND = 0x0111,
                          CBN_DROPDOWN = 7;

        public static int HIWORD(int n)
        {
            return (n >> 16) & 0xffff;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (WM_REFLECT + WM_COMMAND))
            {
                if (HIWORD((int)m.WParam) == CBN_DROPDOWN)
                {
                    ShowDropDown();
                    return;
                }
            }
            base.WndProc(ref m);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dropDown != null)
                {
                    dropDown.Dispose();
                    dropDown = null;
                }
            }
            base.Dispose(disposing);
        }

        protected virtual void OnAfterSelect(TreeViewEventArgs e)
        {
            AfterSelect?.Invoke(this, e);
            Text = TreeView.SelectedNode.FullPath;
            dropDown.Hide();
        }


        [Category("Behavior")]
        public event TreeViewEventHandler AfterSelect;
    }
}
