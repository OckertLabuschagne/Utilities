using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeGenerator.UI
{
    public partial class QueryDialog : Form
    {
        public string ConnectionString { get => _ConnectionString; set => SetConnectionString(value); }
        public string TableName { get => _TableName; set => SetTableName(value); }
        public string Query { get => _Query; set => SetQuery(value); }

        string _ConnectionString,
            _Query,
            _TableName;
        SqlConnection _Connection;

        public QueryDialog()
        {
            InitializeComponent();
        }

        private void SetQuery(string query)
        {
            _Query = query;
            fctxtbQuery.Text = query;
        }

        private void SetTableName(string value)
        {
            _TableName = value;
            fctxtbQuery.Text = $"SELECT TOP 10 * FROM {_TableName}";
        }

        private void SetConnectionString(string value)
        {
            _ConnectionString = value;
            _Connection = new SqlConnection(_ConnectionString);
            tsslblDbName.Text = $"{_Connection.DataSource}.{_Connection.Database}";
        }

        public List<Dictionary<string,object>> Values
        {
            get
            {
                List<Dictionary<string, object>> retVal = new List<Dictionary<string, object>>();
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        Dictionary<string, object> values = new Dictionary<string, object>();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            values.Add(dgvData.Columns[i].HeaderText, row.Cells[i].Value);
                        }
                        retVal.Add(values);
                    }
                }
                return retVal;
            }
        }

        private void tsbtnExecute_Click(object sender, EventArgs e)
        {
            IDataReader reader = null;
            SqlCommand command = null;
            try
            {
                dgvData.Columns.Clear();
                _Connection = new SqlConnection(ConnectionString);
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
                   foreach(DataGridViewColumn column in dgvData.Columns)
                    {
                        int f = reader.GetOrdinal(column.HeaderText);
                        dgvData[column.Index, rowIndex].Value = reader.GetValue(f);
                    }
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
        }

        private void fctxtbQuery_Leave(object sender, EventArgs e)
        {
            _Query = fctxtbQuery.Text;
        }

        private void tsbtnConnect_Click(object sender, EventArgs e)
        {

        }

        private void fctxtbQuery_SizeChanged(object sender, EventArgs e)
        {
        }

        private void fctxtbQuery_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            tsbtnExecute.Enabled = !string.IsNullOrEmpty(fctxtbQuery.Text);
        }
    }
}
