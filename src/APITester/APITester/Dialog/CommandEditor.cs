using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

using APITester.Models;
namespace APITester.Dialog
{
    public partial class CommandEditor : Form
    {
        Dictionary<string, List<Command>> _Commands;
        Command _SelectedCommand;
        TreeNode _SelectedNode;
        string _SelectedGroup, 
            _selectedKey;
        public CommandEditor()
        {
            InitializeComponent();
        }

        public Dictionary<string,List<Command>> Commands { get => _Commands; set => SetCommands(value); }

        public string SelectedEnvironment { get; set; }
        public string TPA { get; set; }

        private void SetCommands(Dictionary<string, List<Command>> value)
        {
            _Commands = value;
            tvCommands.Nodes.Clear();
            foreach(string group in _Commands.Keys)
            {
                TreeNode tnGroup = tvCommands.Nodes.Add(group);
                foreach(Command command in _Commands[group])
                {
                    tnGroup.Nodes.Add(new TreeNode { Text = command.Name, Tag = command });
                }
            }
        }

        private void PopulateUI()
        {
            commandEditorControl1.Enabled = _SelectedCommand != null;
            commandEditorControl1.Command = _SelectedCommand;
        }

        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            _SelectedCommand = new Command { 
                Name = "New Command",
                URL = $"{ConfigurationManager.AppSettings[SelectedEnvironment]}/api/claim/{ConfigurationManager.AppSettings["Version"]}/{TPA}/claims"
            };
            int inx =_SelectedNode.Nodes.Add(new TreeNode { Text = _SelectedCommand.Name, Tag = _SelectedCommand });
            tvCommands.SelectedNode = _SelectedNode.Nodes[inx];
            Commands[_SelectedGroup].Add(_SelectedCommand);
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            if(_SelectedNode.Parent == null)
            {
                if (MessageBox.Show("Data Loss Warning", $"You are about to delete the group {_SelectedNode.Text} and all {_SelectedNode.Nodes.Count} its commands.\nAre you sure you want to continue.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _Commands.Remove(_SelectedNode.Text);
                    tvCommands.Nodes.Remove(_SelectedNode);
                }
            }
            else 
            {
                if (MessageBox.Show("Data Loss Warning", $"You are about to delete {_SelectedNode.Nodes.Count}\nAre you sure you want to continue.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _Commands[_SelectedGroup].Remove(_SelectedCommand);
                    tvCommands.Nodes.Remove(_SelectedNode);
                }
            }
        }

        private void tvCommands_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _SelectedNode = e.Node;
            if (_SelectedNode.Parent != null)
            {
                _SelectedCommand = e.Node.Tag as Command;
                tsbtnDelete.Text = "Delete selected command";
                tsbtnAdd.Enabled = false;
                _SelectedGroup = e.Node.Parent.Text;
            }
            else
            {
                _SelectedCommand = null;
                tsbtnDelete.Text = "Delete selected grouo";
                tsbtnAdd.Enabled = true;
                _SelectedGroup = e.Node.Text;
            }
            PopulateUI();
        }

        private void tsbtnAddGroup_Click(object sender, EventArgs e)
        {
            InputDialog dialog = new InputDialog();
            if(dialog.Show("Group Name", "Please provide the group name", InputType.Text) == DialogResult.OK)
            {
                TreeNode node = tvCommands.Nodes.Add(dialog.InputText);
                tvCommands.SelectedNode = node;
                _SelectedGroup = dialog.InputText;
                _Commands.Add(_SelectedGroup, new List<Command>());
            }
        }
    }
}
