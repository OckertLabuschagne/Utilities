using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeGenerator.UI
{
    public partial class TestDataClassGenerator : Form
    {
        string _ConnectionString;
        SqlConnection _Connection;

        public TestDataClassGenerator()
        {
            InitializeComponent();
        }

        private void tstxtbFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tsbtnFilter.Checked = true;
                FillTables();
            }
        }

        private void FillTables()
        {
            listBox1.Items.Clear();
            DataTable schema;
            if (tscmbxDbObjectType.SelectedItem as string == "Procedures")
            {
                tsbtnEditQuery.Enabled = false;
                string sql = "SELECT  name FROM sys.objects WHERE type = 'P'";
                using (SqlCommand command = _Connection.CreateCommand())
                {
                    command.CommandText = sql;
                    IDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        if (tsbtnFilter.Checked && !string.IsNullOrEmpty(tstxtbFilter.Text) && !name.Contains(tstxtbFilter.Text))
                            continue;
                        listBox1.Items.Add(name);
                    }
                }
            }
            else
            {
                tsbtnEditQuery.Enabled = true;
                schema = _Connection.GetSchema("Tables");
                foreach (DataRow row in schema.Rows)
                {
                    if (tscmbxDbObjectType.SelectedIndex == 0)
                    {
                        if (row.Field<string>("TABLE_TYPE") == "BASE TABLE")
                        {
                            if (!tsbtnFilter.Checked || string.IsNullOrEmpty(tstxtbFilter.Text))
                                listBox1.Items.Add(row.Field<string>("TABLE_NAME"));
                            else
                            {
                                string tableName = row.Field<string>("TABLE_NAME");
                                if (tableName.ToUpper().Contains(tstxtbFilter.Text.ToUpper()))
                                    listBox1.Items.Add(tableName);
                            }
                        }
                    }
                    else
                    {
                        if (row.Field<string>("TABLE_TYPE") == "VIEW")
                        {
                            if (!tsbtnFilter.Checked || string.IsNullOrEmpty(tstxtbFilter.Text))
                                listBox1.Items.Add(row.Field<string>("TABLE_NAME"));
                            else
                            {
                                string tableName = row.Field<string>("TABLE_NAME");
                                if (tableName.ToUpper().Contains(tstxtbFilter.Text.ToUpper()))
                                    listBox1.Items.Add(tableName);
                            }
                        }
                    }
                }
            }
        }
    }
}