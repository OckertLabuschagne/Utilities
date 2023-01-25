using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Newtonsoft.Json;

using APITester.Models;
namespace APITester.Dialog
{
    public partial class DatabaseForm : Form
    {
        Dictionary<string, SQLCommadGroup> _Groups;
        SQLCommadGroup _SelectedGroup;
        public DatabaseForm()
        {
            InitializeComponent();
            using (StreamReader commandFile = new StreamReader(Path.Combine(Application.StartupPath, "Queries.json")))
            {
                string jsonText = commandFile.ReadToEnd();
                _Groups = JsonConvert.DeserializeObject<Dictionary<string, SQLCommadGroup>>(jsonText);
            }
            tscmbxCommandGroups.ComboBox.DisplayMember = "Name";
            foreach (SQLCommadGroup group in _Groups.Values)
            {
                tscmbxCommandGroups.Items.Add(group);
            }
        }

        public string Parameter { get => tslblParameter.Text; set => tslblParameter.Text = value; }
        public string ParameterValue { get => tslblParameterValue.Text; set => tslblParameterValue.Text = value; }
        public string ConnectionString { get; set; }
        private void tsbtnExecute_Click(object sender, EventArgs e)
        {
            gbResults.Controls.Clear();
            foreach (SQLCommand sql in clbCommands.CheckedItems)
            {
                if (sql.CommandType ==  SQLCommandType.Query)
                {
                    //Add a group box for the command
                    GroupBox groupBox = new GroupBox
                    {
                        Text = sql.Name,
                        Height = 200,
                        Dock = DockStyle.Top,
                        Visible = true
                    };
                    DataGridView dataGridView = new DataGridView
                    {
                        Visible = true,
                        AllowUserToAddRows = false,
                        ReadOnly = true
                    };
                    //add datagrid for the command
                    groupBox.Controls.Add(dataGridView);
                    dataGridView.Dock = DockStyle.Fill;
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();
                        //execute the query for the command
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = string.Format(sql.SQL, ParameterValue);
                            using (IDataReader reader = command.ExecuteReader())
                                //Fill the datagrid with the data
                                FillData(dataGridView, reader);
                        }
                    }
                    gbResults.Controls.Add(groupBox);
                    groupBox.BringToFront();
                }
            }
        }

        private void tscmbxCommandGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbCommands.Items.Clear();
            _SelectedGroup = tscmbxCommandGroups.SelectedItem as SQLCommadGroup;
            if(_SelectedGroup != null)
            {
                foreach (SQLCommand sql in _SelectedGroup.Commands)
                    clbCommands.Items.Add(sql);
            }
        }

        private void FillData(DataGridView control, IDataReader reader)
        {
            control.Columns.Clear();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                string fieldName = reader.GetName(i);
                control.Columns.Add($"col_{fieldName}", fieldName);
            }
            while (reader.Read())
            {
                int rowIndex = control.Rows.Add();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    control[i, rowIndex].Value = reader.GetValue(i);
                }
            }
        }

        private void tsbtnEditSQL_Click(object sender, EventArgs e)
        {
            TextFileEditor dialog = new TextFileEditor();
            dialog.Edit(Path.Combine(Application.StartupPath, "Queries.json"), "json");
        }

        private void cbxCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            for(int i = 0; i < clbCommands.Items.Count; i++)
            {
                clbCommands.SetItemChecked(i, cbxCheckAll.Checked);
            }
        }
    }
}
