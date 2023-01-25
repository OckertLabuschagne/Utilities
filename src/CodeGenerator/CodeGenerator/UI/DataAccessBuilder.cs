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

using CodeGenerator.Properties;
namespace CodeGenerator.UI
{
    public partial class DataAccessBuilder : Form
    {
        public DataAccessBuilder()
        {
            InitializeComponent();
            _Tables = new Dictionary<string, TableDefinition>();
            string[] mappings = Settings.Default.Substitutions.Split(',');
            foreach (string mapping in mappings)
            {
                if (string.IsNullOrEmpty(mapping))
                    continue;
                string[] parts = mapping.Split('=');
                _Mappings.Add(parts[0], parts[1]);
            }


        }

        Dictionary<string, string> _Mappings = new Dictionary<string, string>();
        Dictionary<string, TableDefinition> _Tables;
        TableDefinition _SelectedTable = null;
        SqlConnection _Connection;
        string _ConnectionString;

        public string ConnectionString { set => SetConectionString(value); }

        private void SetConectionString(string value)
        {
            _ConnectionString = value;
            _Connection = new SqlConnection(value);
            tslblConnection.Text = $"{_Connection.DataSource}.{_Connection.Database}";
            _Connection.Open();
            FillTables();
        }

        private void FillTables()
        {
            DataTable schema;
            if (tscmbxDbObjectType.SelectedItem as string == "Procedures")
            {
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
                        clbxTables.Items.Add(name);
                    }
                }
            }
            /*
            else if (tscmbxDbObjectType.SelectedItem as string == "Custom SQL")
            {
                using (SqlCommand command = _Connection.CreateCommand())
                {
                    command.CommandText = fctxtbCustomQuery.Text;
                    IDataReader reader = command.ExecuteReader();
                    schema = reader.GetSchemaTable();
                    dgvFields.Rows.Clear();
                    _ColumnDefinitions = new Dictionary<string, ColumnDefinition>();
                    foreach (DataRow row in schema.Rows)
                    {
                        _ColumnDefinitions.Add(row.Field<string>("ColumnName")
                            , new ColumnDefinition
                            {
                                Type = (Type)row["DataType"],
                                DbType = SQLServer.GetDbType((Type)row["DataType"]),
                                Length = row[8] != DBNull.Value ? row.Field<int>("FiledSize") : 0
                            });
                        string fieldName = row.Field<string>("ColumnName");
                        DbType dbType = SQLServer.GetDbType((Type)row["DataType"]);
                        dgvFields.Rows.Add(false, fieldName, GetPropertyName(fieldName, dbType), false, false);
                    }
                    tstxtbEntityFilePath.Text = Settings.Default.EntityFolder;
                    tstxtbMappingFilePath.Text = Settings.Default.InfrastructureServicesMappingFolder;
                    tstxtbUntTestFilePath.Text = Settings.Default.UnitTestFolder;
                    tstxtbTestDataFilePath.Text = Settings.Default.TestDataFolder;
                    tstxtbPostSQLSnippet.Text = Settings.Default.PostSQLSnippet;
                    tstxtbQueryFilePath.Text = Settings.Default.InfrastructureServicesQueryFolder;
                    SetNameSpaces();
                }
            }
            */
            else
            {
                schema = _Connection.GetSchema("Tables");
                FillTablesFromSchema(schema);
            }
        }

        private void FillTablesFromSchema(DataTable schema)
        {
            foreach (DataRow row in schema.Rows)
            {
                if (tscmbxDbObjectType.SelectedIndex == 0)
                {
                    if (row.Field<string>("TABLE_TYPE") == "BASE TABLE")
                    {
                        if (!tsbtnFilter.Checked || string.IsNullOrEmpty(tstxtbFilter.Text))
                            clbxTables.Items.Add(row.Field<string>("TABLE_NAME"));
                        else
                        {
                            string tableName = row.Field<string>("TABLE_NAME");
                            if (tableName.ToUpper().Contains(tstxtbFilter.Text.ToUpper()))
                                clbxTables.Items.Add(tableName);
                        }
                    }
                }
                else
                {
                    if (row.Field<string>("TABLE_TYPE") == "VIEW")
                    {
                        if (!tsbtnFilter.Checked || string.IsNullOrEmpty(tstxtbFilter.Text))
                            clbxTables.Items.Add(row.Field<string>("TABLE_NAME"));
                        else
                        {
                            string tableName = row.Field<string>("TABLE_NAME");
                            if (tableName.ToUpper().Contains(tstxtbFilter.Text.ToUpper()))
                                clbxTables.Items.Add(tableName);
                        }
                    }
                }
            }
        }

        private void tscmbxDbObjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tsbtnFilter.Enabled = true;
            tstxtbFilter.Enabled = true;
            if (_Connection != null)
            {
                FillTables();
            }
        }

        private void tscmbxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            fctxtbCode.Text = "";
            gbTestData.Visible = false;
            if (_SelectedTable != null)
            {
                switch (tscmbxClass.SelectedItem as string)
                {
                    case "Entity":
                        fctxtbCode.Text = _SelectedTable.CreateEntity();
                        break;
                    case "Mapping":
                        fctxtbCode.Text = _SelectedTable.CreateMapping();
                        break;
                    case "Query":
                        fctxtbCode.Text = _SelectedTable.CreateQueryClass();
                        break;
                    case "Lookup Service":
                        fctxtbCode.Text = _SelectedTable.CreateLookupServiceClass();
                        break;
                    case "Save Service":
                        break;
                    case "Delete Service":
                        break;
                    case "Test Data Reader":
                        gbTestData.Visible = true;
                        break;
                    case "Test Object Factory":
                        gbTestData.Visible = true;
                        break;
                    case "Mapping Unit Tests":
                        break;
                    case "Query Unit Tests":
                        break;
                }
            }
        }

        private void clbxTables_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string tableName = clbxTables.Items[e.Index] as string;
            if (e.NewValue == CheckState.Checked)
            {
                if (!_Tables.ContainsKey(tableName))
                {
                    if (e.Index == clbxTables.SelectedIndex)
                        _Tables.Add(tableName, _SelectedTable);
                    else
                    {
                        TableDefinition selectedTable = new TableDefinition();
                        selectedTable.DeriveFromTable(_Connection.GetSchema("Columns", new[] { null, null, clbxTables.SelectedItem as string }));
                        _Tables.Add(tableName, selectedTable);
                    }
                }
            }
            else if (_Tables.ContainsKey(tableName))
                _Tables.Remove(tableName);
        }

        private void clbxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tableName = clbxTables.SelectedItem as string;
            if (_Tables.ContainsKey(tableName))
                _SelectedTable = _Tables[tableName];
            else
            {
                //Create a table definition
                _SelectedTable = new TableDefinition();
                _SelectedTable.DeriveFromTable(_Connection.GetSchema("Columns", new[] { null, null, clbxTables.SelectedItem as string }));
            }
            _SelectedTable.FillDataGridView(dgvFields, _Mappings);
        }

        private void dgvFields_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ColumnDefinition column = _SelectedTable.Fields[dgvFields[1, e.RowIndex].Value as string];
            switch (e.ColumnIndex)
            {
                case 0:
                    column.Included = (bool)dgvFields[e.ColumnIndex, e.RowIndex].Value;
                    break;
                case 2:
                    column.FieldName = dgvFields[e.ColumnIndex, e.RowIndex].Value as string;
                    break;
                case 3:
                    column.IsFilterField = (bool)dgvFields[e.ColumnIndex, e.RowIndex].Value;
                    break;
                case 4:
                    column.IsKeyField = (bool)dgvFields[e.ColumnIndex, e.RowIndex].Value;
                    break;
            }
        }

        private void tsbtnExecute_Click(object sender, EventArgs e)
        {
            IDataReader reader = null;
            List<Dictionary<string, object>> mockValues = new List<Dictionary<string, object>>();
            SqlCommand command = null;
            try
            {
                dgvData.Columns.Clear();
                _Connection = new SqlConnection(_ConnectionString);
                command = _Connection.CreateCommand();

                _Connection.Open();
                command.CommandText = fctxtbQuery.Text;
                command.CommandType = CommandType.Text;
                reader = command.ExecuteReader();

                for (int f = 0; f < reader.FieldCount; f++)
                {
                    dgvData.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = reader.GetName(f)
                    });
                }

                while (reader.Read())
                {
                    int rowIndex = dgvData.Rows.Add();
                    Dictionary<string, object> rowData = new Dictionary<string, object>();

                    foreach (DataGridViewColumn column in dgvData.Columns)
                    {
                        int f = reader.GetOrdinal(column.HeaderText);
                        object value = reader.GetValue(f);
                        dgvData[column.Index, rowIndex].Value = value;
                        rowData.Add(column.HeaderText, value);
                    }
                    mockValues.Add(rowData);
                }
            }
            catch (Exception excp)
            {
                MessageBox.Show($"There was an error trying to execute the query. Error: {excp}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                reader?.Dispose();
                command?.Dispose();
                if (_Connection != null)
                {
                    if (_Connection.State == ConnectionState.Open)
                        _Connection.Close();
                    _Connection.Dispose();
                }
            }

            if (_SelectedTable != null)
            {
                switch (tscmbxClass.SelectedItem as string)
                {
                    case "Test Data Reader":
                        _SelectedTable.MockValues = mockValues;
                        fctxtbCode.Text = _SelectedTable.CreateMockDataReader();
                        break;
                    case "Test Object Factory":
                        _SelectedTable.MockValues = mockValues;
                        fctxtbCode.Text = _SelectedTable.CreateTestDataClasses();
                        break;
                }
            }
        }

        private void tsbtnConnect_Click(object sender, EventArgs e)
        {

        }

        private void fctxtbQuery_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            tsbtnExecute.Enabled = !string.IsNullOrEmpty(fctxtbQuery.Text);
        }
    }
}
