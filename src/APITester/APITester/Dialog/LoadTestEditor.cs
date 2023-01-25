using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using APITester.Models;
namespace APITester.Dialog
{
    public partial class LoadTestEditor : Form
    {
        Command _SelectedCommand;
        TPALoadTestSuite _LoadTests;
        public LoadTestEditor()
        {
            InitializeComponent();
        }
        
        public TPALoadTestSuite LoadTests
        {
            get => _LoadTests;
            set
            {
                _LoadTests = value;
                PopulateUI();
            }
        }

        bool _EditName;

        private void lbxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_EditName)
            {
                tsbtnDeleteCommand.Enabled = lbxCommands.SelectedItem != null;
                _SelectedCommand = lbxCommands.SelectedItem as Command;
                commandEditorControl1.Command = _SelectedCommand;
            }
        }

        private void PopulateUI()
        {
            lbxCommands.Items.Clear();
            txtbTPA.Text = "";
            if(_LoadTests != null)
            {
                if (_LoadTests.Commands == null)
                    _LoadTests.Commands = new List<Command>();
                if (_LoadTests.Credentials == null)
                    _LoadTests.Credentials = new Credentials();
                foreach (Command command in _LoadTests.Commands)
                    lbxCommands.Items.Add(command);
                lbxCommands.SelectedIndex = lbxCommands.Items.Count - 1;
                txtbTPA.Text = _LoadTests.Name;
                txtbUserId.Text = _LoadTests.Credentials.UserId;
                txtbUserSecret.Text = _LoadTests.Credentials.Password;
                txtbBaseURL.Text = _LoadTests.BaseUrl;
                txtbLoginURL.Text = _LoadTests.LoginUrl;
                txtbNumCalls.Text = $"{_LoadTests.NumberOfCalls}";
                txtbTestDuration.Text = $"{_LoadTests.Duration}";
                txtbTBC.Text = $"{_LoadTests.TimeBetweenCalls}";
                txtbStartLoad.Text = $"{_LoadTests.StartLoad}";
                txtbEndLoad.Text = $"{_LoadTests.EndLoad}";
                txtbLoadIncrement.Text = $"{_LoadTests.LoadIncrement}";
                rbtnNumberOfCalls.Checked = _LoadTests.TestMode == TestMode.NumberOfCalls;
                rbtnTime.Checked = _LoadTests.TestMode == TestMode.Duration;
                rbtnMultipleLoads.Checked = _LoadTests.TestMode == TestMode.MultiLoad;
            }
            else
            {
                txtbTPA.Text = "";
                txtbUserId.Text = "";
                txtbUserSecret.Text = "";
                txtbBaseURL.Text = "";
                txtbLoginURL.Text = "";
                txtbNumCalls.Text = "";
                txtbTestDuration.Text ="";
                txtbTBC.Text = "";
                txtbStartLoad.Text = "";
                txtbEndLoad.Text = "";
                txtbLoadIncrement.Text = "";
            }
        }

        private void tsbtnAddCommand_Click(object sender, EventArgs e)
        {
            _SelectedCommand = new Command();
            commandEditorControl1.Command = _SelectedCommand;
            _LoadTests.Commands.Add(_SelectedCommand);
            lbxCommands.Items.Add(_SelectedCommand);
            lbxCommands.SelectedIndex = lbxCommands.Items.Count - 1;
        }

        private void tsbtnDeleteCommand_Click(object sender, EventArgs e)
        {
            _LoadTests.Commands.Remove(_SelectedCommand);
            lbxCommands.Items.Clear();
            foreach (Command command in _LoadTests.Commands)
                lbxCommands.Items.Add(command);
            lbxCommands.SelectedIndex = 0;
        }

        private void txtbTPA_Leave(object sender, EventArgs e)
        {
            _LoadTests.Name = txtbTPA.Text;
        }

        private void txtbBaseURL_Leave(object sender, EventArgs e)
        {
            _LoadTests.BaseUrl = txtbBaseURL.Text;

        }

        private void txtbLoginURL_Leave(object sender, EventArgs e)
        {
            _LoadTests.LoginUrl = txtbLoginURL.Text;
        }

        private void txtbUserId_Leave(object sender, EventArgs e)
        {
            if (_LoadTests.Credentials == null)
                _LoadTests.Credentials = new Credentials();
            _LoadTests.Credentials.UserId = txtbUserId.Text;
        }

        private void txtbUserSecret_Leave(object sender, EventArgs e)
        {
            if (_LoadTests.Credentials == null)
                _LoadTests.Credentials = new Credentials();
            _LoadTests.Credentials.Password = txtbUserSecret.Text;
        }

        private void txtbNumCalls_Leave(object sender, EventArgs e)
        {
            int intValue;
            if (int.TryParse(txtbNumCalls.Text, out intValue))
                _LoadTests.NumberOfCalls = intValue;
        }

        private void txtbTestDuration_Leave(object sender, EventArgs e)
        {
            int intValue;
            if (int.TryParse(txtbTestDuration.Text, out intValue))
                _LoadTests.Duration = intValue;
        }

        private void txtbTBC_Leave(object sender, EventArgs e)
        {
            int intValue;
            if (int.TryParse(txtbTBC.Text, out intValue))
                _LoadTests.TimeBetweenCalls = intValue;
        }

        private void rbtnNumberOfCalls_CheckedChanged(object sender, EventArgs e)
        {
            _LoadTests.TestMode = rbtnNumberOfCalls.Checked ? TestMode.NumberOfCalls : rbtnTime.Checked ? TestMode.Duration : TestMode.MultiLoad;
        }

        private void txtbLoadIncrement_Leave(object sender, EventArgs e)
        {
            int intValue;
            if (int.TryParse(txtbLoadIncrement.Text, out intValue))
                _LoadTests.LoadIncrement = intValue;
        }

        private void txtbEndLoad_Leave(object sender, EventArgs e)
        {
            int intValue;
            if (int.TryParse(txtbEndLoad.Text, out intValue))
                _LoadTests.EndLoad = intValue;
        }

        private void txtmStartLoad_Leave(object sender, EventArgs e)
        {
            int intValue;
            if (int.TryParse(txtbStartLoad.Text, out intValue))
                _LoadTests.StartLoad = intValue;

        }

        private void commandEditorControl1_NameChanged(object sender, EventArgs e)
        {
            _EditName = true;
            int current = lbxCommands.SelectedIndex;
            lbxCommands.Items.RemoveAt(current);
            lbxCommands.Items.Insert(current, _SelectedCommand);
            lbxCommands.SelectedIndex = lbxCommands.Items.Count - 1;
            _EditName = false;
        }
    }
}
