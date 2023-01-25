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
using System.Reflection;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;

using FastColoredTextBoxNS;

using Microsoft.CSharp;

using CodeGenerator.Properties;

using SEFI.Infrastructure.Common.DataUtilities;
namespace CodeGenerator.UI
{
    public partial class MockDb : Form
    {
        DataGridView _DGV;
        string _ConnectionString;
        SqlConnection _Connection;
        DataTable _Columns;
        Dictionary<string, string> _Mappings;

        public MockDb()
        {
            InitializeComponent();
            _Mappings = new Dictionary<string, string>();
            string[] mappings = Settings.Default.Substitutions.Split(',');
            foreach (string mapping in mappings)
            {
                if (string.IsNullOrEmpty(mapping))
                    return;
                string[] parts = mapping.Split('=');
                _Mappings.Add(parts[0], parts[1]);
            }
            tscmbxDbObjectType.SelectedIndex = 0;
            tstxtbNameExpression.Text = Settings.Default.ClassNameExpression;
            tstxtbNameSpace.Text = Settings.Default.Namespace;
        }

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
            chlbxTables.Items.Clear();
            DataTable schema = _Connection.GetSchema("Tables");
            foreach(DataRow row in schema.Rows)
            {
                if (tscmbxDbObjectType.SelectedIndex == 0)
                {
                    if (row.Field<string>("TABLE_TYPE") == "BASE TABLE")
                    {
                        if (!tsbtnFilter.Checked || string.IsNullOrEmpty(tstxtbFilter.Text))
                            chlbxTables.Items.Add(row.Field<string>("TABLE_NAME"));
                        else
                        {
                            string tableName = row.Field<string>("TABLE_NAME");
                            if (tableName.ToUpper().Contains(tstxtbFilter.Text.ToUpper()))
                                chlbxTables.Items.Add(tableName);
                        }
                    }
                }
                else
                {
                    if (row.Field<string>("TABLE_TYPE") == "VIEW")
                    {
                        if (!tsbtnFilter.Checked || string.IsNullOrEmpty(tstxtbFilter.Text))
                            chlbxTables.Items.Add(row.Field<string>("TABLE_NAME"));
                        else
                        {
                            string tableName = row.Field<string>("TABLE_NAME");
                            if (tableName.ToUpper().Contains(tstxtbFilter.Text.ToUpper()))
                                chlbxTables.Items.Add(tableName);
                        }
                    }
                }
            }
        }

        private void tsbtnFilter_Click(object sender, EventArgs e)
        {
            tsbtnFilter.Checked = !tsbtnFilter.Checked;
            FillTables();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (_Connection?.State == ConnectionState.Open)
                _Connection.Close();
            if(_Connection != null)
                _Connection.Dispose();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fctxtbMockDb.Text = "";
            //if(chlbxTables.SelectedIndex > -1)
            //{
            //    string className = "";
            //    Match match = Regex.Match(chlbxTables.SelectedItem as string, tstxtbNameExpression.Text);
            //    while(match.Success)
            //    {
            //        className += match.Value.Trim('_').Substring(0, 1).ToUpper() + match.Value.Trim('_').Substring(1);
            //        match = match.NextMatch();
            //    }
            //    tstxtbClassName.Text = className;
            //    tstxtbUntTestFileName.Text = Path.Combine(Settings.Default.UnitTestFolder, $"{tstxtbClassName.Text}MappingTests.cs");
            //    _Columns = _Connection.GetSchema("Columns", new[] { null, null, chlbxTables.SelectedItem as string });
            //    foreach (DataRow row in _Columns.Rows)
            //    {
            //        string fieldName = row.Field<string>("COLUMN_NAME");
            //        Type type = SQLServer.GetType(row.Field<string>("DATA_TYPE"));
            //        DbType dbType = SQLServer.GetDbType(row.Field<string>("DATA_TYPE"));
            //    }
            //}
        }

        private void tsbtnCreateCode_Click(object sender, EventArgs e)
        {
            CreateClass();
        }

        private void CreateClass()
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace codeNamespace = new CodeNamespace(tstxtbNameSpace.Text);
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Tests.Mock"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Data"));
            foreach (string line in fctxtbAssemblies.Lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                codeNamespace.Imports.Add(new CodeNamespaceImport(line));
            }
            unit.Namespaces.Add(codeNamespace);
            CodeTypeDeclaration entity = new CodeTypeDeclaration
            {
                Name = tstxtbClassName.Text,
                IsClass = true,
                TypeAttributes = TypeAttributes.Public
            };
            entity.BaseTypes.Add("MockDBConnection");
            codeNamespace.Types.Add(entity);
            CodeTypeConstructor constrictor = new CodeTypeConstructor
            {
                Attributes = MemberAttributes.Public
            };
            entity.Members.Add(constrictor);
            foreach (string table in chlbxTables.CheckedItems)
            {
                CodeMethodInvokeExpression addTable = new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeThisReferenceExpression(), "AddTable"), new CodePrimitiveExpression(table));
                DataGridView dgvTable = tcData.TabPages[$"tp{table}"].Controls[0] as DataGridView;
                CodeMethodInvokeExpression addFieldParent = addTable;
                DataTable columns = _Connection.GetSchema("Columns", new[] { null, null, table });
                foreach (DataGridViewColumn column in dgvTable.Columns)
                {
                    DataRow[] rows = columns.Select($"COLUMN_NAME = '{column.HeaderText}'");
                    string typeString = rows[0].Field<string>("DATA_TYPE");
                    DbType dbType = SQLServer.GetDbType(typeString);
                    CodeMethodInvokeExpression addField = new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(addFieldParent, "AddField"), new CodePrimitiveExpression(column.HeaderText)
                        , new CodePropertyReferenceExpression(new CodeTypeReferenceExpression(typeof(DbType)), Enum.GetName(typeof(DbType), dbType)));
                    addFieldParent = addField;
                }
                if (dgvTable.Rows.Count > 1)
                {
                    foreach (DataGridViewRow row in dgvTable.Rows)
                    {
                        if(!row.IsNewRow)
                        {
                            List<CodeExpression> valueExpressions = new List<CodeExpression>();
                            foreach(DataGridViewCell cell in row.Cells)
                            {
                                string fieldName = dgvTable.Columns[cell.ColumnIndex].HeaderText;
                                Type valueType = dgvTable.Columns[cell.ColumnIndex].Tag as Type;
                                object value = cell.Value == null ? null : cell.Value == DBNull.Value ? null : cell.Value is Byte[] ? null : Convert.ChangeType(cell.Value, valueType);
                                if (value == null)
                                    valueExpressions.Add(new CodeObjectCreateExpression("KeyValuePair<string,object>", new CodePrimitiveExpression(fieldName), new CodePrimitiveExpression(value)));
                                else if (valueType.IsPrimitive)
                                    valueExpressions.Add(new CodeObjectCreateExpression("KeyValuePair<string,object>", new CodePrimitiveExpression(fieldName), new CodePrimitiveExpression(value)));
                                else
                                {
                                    if (valueType == typeof(DateTime))
                                        valueExpressions.Add(new CodeObjectCreateExpression("KeyValuePair<string,object>", new CodePrimitiveExpression(fieldName), new CodeSnippetExpression($"DateTime.Parse(\"{value}\")")));
                                    else if(valueType == typeof(Guid))
                                        valueExpressions.Add(new CodeObjectCreateExpression("KeyValuePair<string,object>", new CodePrimitiveExpression(fieldName), new CodeSnippetExpression($"Guid.Parse(\"{value}\")")));
                                    else if (valueType == typeof(string))
                                        valueExpressions.Add(new CodeObjectCreateExpression("KeyValuePair<string,object>", new CodePrimitiveExpression(fieldName), new CodePrimitiveExpression((value as string).Trim())));
                                }
                            }
                            CodeMethodInvokeExpression addData = new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(addFieldParent, "AddData"), valueExpressions.ToArray());
                            addFieldParent = addData;
                        }
                    }
                }
                constrictor.Statements.Add(addFieldParent);
            }
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            StringWriter stringWriter = new StringWriter();
            provider.GenerateCodeFromCompileUnit(unit, stringWriter, options);
            fctxtbMockDb.Text = Regex.Replace(Regex.Replace(Regex.Replace(stringWriter.ToString().Replace("System.Data.", ""), "\\).AddField", ")\r\n\t\t\t\t.AddField"), "\\).AddData", ")\r\n\t\t\t\t.AddData"), ", new", "\r\n\t\t\t\t\t, new");
        }

        private void tsbtnGetUnitTestFolder_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Title = "Select Mock Database File Name",
                Filter = "C-Sharp files {*.cs}|*.cs",
                FileName = tstxtbClassName.Text + "MappingTests.cs"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tstxtbUntTestFileName.Text = dialog.FileName;
                Settings.Default.UnitTestFolder = Path.GetDirectoryName(dialog.FileName);
                Settings.Default.Save();
            }
        }

        private void tsbtnSaveUnitTest_Click(object sender, EventArgs e)
        {
            SaveClass();
        }

        private void SaveClass()
        {
            if (string.IsNullOrEmpty(tstxtbUntTestFileName.Text))
            {
                SaveFileDialog dialog = new SaveFileDialog
                {
                    Title = "Select Mock Db File Name",
                    Filter = "C-Sharp files {*.cs}|*.cs"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    tstxtbUntTestFileName.Text = dialog.FileName;
                    Settings.Default.TestDataFolder = Path.GetDirectoryName(dialog.FileName);
                    Settings.Default.Save();
                }
                else
                {
                    MessageBox.Show("Missing Required Data", "Cannot save the file without a file name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            fctxtbMockDb.SaveToFile(tstxtbUntTestFileName.Text, Encoding.ASCII);
        }

        private void tscmbxDbObjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Connection != null)
                FillTables();
        }

        private void tstxtbNameExpression_Leave(object sender, EventArgs e)
        {
            Settings.Default.ClassNameExpression = tstxtbNameExpression.Text;
            Settings.Default.Save();
        }

        private void tstxtbClassName_Leave(object sender, EventArgs e)
        {
            tstxtbUntTestFileName.Text = Path.Combine(Settings.Default.TestDataFolder, $"{tstxtbClassName.Text}.cs");
            fctxtbMockDb.Text = "";
        }

        private void tstxtbFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tsbtnFilter.Checked = true;
                FillTables();
            }
        }

        private void tstxtbNameSpace_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.Namespace = tstxtbNameSpace.Text;
            Settings.Default.Save();
        }

        private void dgvFields_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            fctxtbMockDb.Text = "";
        }

        private void chlbxTables_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string tpName = $"tp{chlbxTables.Items[e.Index]}";

            if (e.NewValue == CheckState.Checked)
            {
                DataGridView dgv = new DataGridView
                {
                    Name = $"dgv{chlbxTables.Items[e.Index]}",
                    Dock = DockStyle.Fill
                };
                dgv.CellBeginEdit += Dgv_CellBeginEdit;
                dgv.CellEndEdit += Dgv_CellEndEdit;
                dgv.Controls.Add(new MonthCalendar
                {
                    Name = "mc",
                    Visible = false
                }); ;
                DataTable columns = _Connection.GetSchema("Columns", new[] { null, null, chlbxTables.SelectedItem as string });
                foreach (DataRow row in columns.Rows)
                {
                    string fieldName = row.Field<string>("COLUMN_NAME");
                    Type type = SQLServer.GetType(row.Field<string>("DATA_TYPE"));
                    DbType dbType = SQLServer.GetDbType(row.Field<string>("DATA_TYPE"));
                    DataGridViewColumn column;
                    switch (dbType)
                    {
                        case DbType.Boolean:
                            column = new DataGridViewCheckBoxColumn();
                            break;
                        default:
                            column = new DataGridViewTextBoxColumn();
                            break;
                    }
                    column.HeaderText = fieldName;
                    column.Tag = type;
                    dgv.Columns.Add(column);
                }

                TabPage page = new TabPage
                {
                    Name = tpName,
                    Text = $"{chlbxTables.Items[e.Index]}"
                };
                page.Controls.Add(dgv);
                tcData.TabPages.Add(page);
                tcData.SelectedTab = page;
                tsbtnAddData.Enabled = tcData.SelectedTab != null;
                _DGV = tcData.SelectedTab.Controls[0] as DataGridView;
            }
            else if ((e.CurrentValue == CheckState.Checked) && (e.NewValue == CheckState.Unchecked))
            {
                tcData.TabPages.RemoveByKey(tpName);
            }
        }

        private void Dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv.Columns[e.ColumnIndex].Tag as Type == typeof(DateTime))
            {
                foreach (Control control in dgv.Controls)
                    if (control is MonthCalendar)
                    {
                        dgv[e.ColumnIndex, e.RowIndex].Value = (control as MonthCalendar).SelectionStart;
                        control.Visible = false;
                        break;
                    }
            }
        }

        private void Dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv.Columns[e.ColumnIndex].Tag as Type == typeof(DateTime))
            {
                foreach (Control control in dgv.Controls)
                    if (control is MonthCalendar)
                    {
                        control.Location = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;
                        control.Visible = true;
                        control.Focus();
                        break;
                    }
            }
        }

        private void tsbtnAddData_Click(object sender, EventArgs e)
        {
            QueryDialog dialog = new QueryDialog
            {
                ConnectionString = _ConnectionString,
                StartPosition = FormStartPosition.CenterParent,
                TableName = tcData.SelectedTab.Text
            };
            dialog.ShowDialog();
            foreach (Dictionary<string, object> values in dialog.Values)
            {
                int rowIndex = _DGV.Rows.Add();
                foreach (DataGridViewColumn col in _DGV.Columns)
                {
                    _DGV[col.Index, rowIndex].Value = values[col.HeaderText];
                }
            }
        }

        private void tcData_SelectedIndexChanged(object sender, EventArgs e)
        {
            tsbtnAddData.Enabled = tcData.SelectedTab != null;
            _DGV = tcData.SelectedTab?.Controls[0] as DataGridView;
        }
    }
}
