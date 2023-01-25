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
using SEFI.Dialogs;
namespace CodeGenerator.UI
{
    public partial class ClassFromDb : Form
    {

        string _ConnectionString;
        SqlConnection _Connection;
        DataTable _Columns;
        Dictionary<string, ColumnDefinition> _ColumnDefinitions;
        Dictionary<string, string> _Mappings;
        CodePrimitiveExpression nullExpression = new CodePrimitiveExpression(null);
        List<Dictionary<string, object>> _MockValues;
        IDataReader mockDataReader;
        string _EntityNamespace, _MappingNamespace, _ServicesNamespace, _MockDataNamespace, _UnitTestNamespace, _QueryNamespace;

        public ClassFromDb()
        {
            InitializeComponent();
            ApplySettings();
        }

        public void ApplySettings()
        {
            _Mappings = new Dictionary<string, string>();
            string[] mappings = Settings.Default.Substitutions.Split(',');
            foreach (string mapping in mappings)
            {
                if (string.IsNullOrEmpty(mapping))
                    continue;
                string[] parts = mapping.Split('=');
                _Mappings.Add(parts[0], parts[1]);
            }
            tstxtbNameExpression.Text = Settings.Default.ClassNameExpression;
            tstxtbNameSpace.Text = Settings.Default.Namespace;
            tstxtbNamespaceSuffix.Text = Settings.Default.NamespaceSuffix;
            SetNameSpaces();

            tstxtbEntityFilePath.Text = Settings.Default.EntityFolder;
            tstxtbMappingFilePath.Text = Settings.Default.InfrastructureServicesMappingFolder;
            tstxtbUntTestFilePath.Text = Settings.Default.UnitTestFolder;
            tstxtbQueryFilePath.Text = Settings.Default.InfrastructureServicesQueryFolder;
            tstxtbTestDataFilePath.Text = Settings.Default.TestDataFolder;
            tstxtbLookupServiceFilePath.Text = Settings.Default.InfrastructureServicesFolder;
            tstxtbDeleteServiceFilePath.Text = Settings.Default.InfrastructureServicesFolder;
            tstxtbSaveServiceFilePath.Text = Settings.Default.InfrastructureServicesFolder;
            tstxtbQueryUnitTestFolder.Text = Settings.Default.UnitTestFolder;
        }

        public string ConnectionString { set => SetConectionString(value); }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (_Connection?.State == ConnectionState.Open)
                _Connection.Close();
            if(_Connection != null)
                _Connection.Dispose();
        }

        private void tsbtnFilter_Click(object sender, EventArgs e)
        {
            tsbtnFilter.Checked = !tsbtnFilter.Checked;
            FillTables();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tschkbxCheckAll.Checked = false;
            fctxtbEntity.Text = "";
            fctxtbMapping.Text = "";
            fctxtbUnitTest.Text = "";
            fctxtbMockDataReader.Text = "";
            tstxtbQuery.Text = "";
            _MockValues = null;
            if (listBox1.SelectedIndex > -1)
            {
                string className = "";
                _ColumnDefinitions = new Dictionary<string, ColumnDefinition>();
                if (tscmbxDbObjectType.SelectedItem as string == "Procedures")
                {
                    Dictionary<string, object> values = new Dictionary<string, object>();
                    MultiValueInputDialog dialog = new MultiValueInputDialog();
                    Dictionary<string, DbType> parameters = SQLServer.GetSPParameters(_Connection, listBox1.SelectedItem as string);
                    if (parameters.Any())
                    {
                        foreach (string paramName in parameters.Keys)
                        {
                            dialog.Fields.Add(new Field
                            {
                                Caption = paramName,
                                InputType = SEFI.UserControls.InputType.String,
                                Height = 45
                            });
                        }
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            foreach (Field field in dialog.Fields)
                                values.Add(field.Caption, field.Value);
                        }
                        else
                            return;
                    }
                    //execute the stored procedure
                    _Columns = SQLServer.GetSPSchema(_Connection, listBox1.SelectedItem as string, values, out mockDataReader);
                    foreach (DataRow row in _Columns.Rows)
                    {
                        _ColumnDefinitions.Add(row.Field<string>("ColumnName")
                            , new ColumnDefinition
                            {
                                Type = SQLServer.GetType(row.Field<string>("DataTypeName")),
                                DbType = SQLServer.GetDbType(row.Field<string>("DataTypeName")),
                                Length = row.Field<int>("ColumnSize")
                            });
                        string fieldName = row.Field<string>("ColumnName");
                        DbType dbType = SQLServer.GetDbType(row.Field<string>("DataTypeName"));
                        dgvFields.Rows.Add(false, fieldName, GetPropertyName(fieldName, dbType), false, false);
                        tstxtbQuery.Text = $"SELECT TOP 5 * FROM ({fctxtbCustomQuery.Text})";
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(tstxtbNameExpression.Text))
                    {
                        Match match = Regex.Match(listBox1.SelectedItem as string, tstxtbNameExpression.Text);
                        while (match.Success)
                        {
                            className += match.Value.Trim('_').Substring(0, 1).ToUpper() + match.Value.Trim('_').Substring(1);
                            match = match.NextMatch();
                        }
                    }
                    _Columns = _Connection.GetSchema("Columns", new[] { null, null, listBox1.SelectedItem as string });
                    FillFields(_Columns);
                    tstxtbQuery.Text = $"SELECT TOP 5 * FROM {listBox1.SelectedItem}";
                }
                tstxtbClassName.Text = className;
                tstxtbEntityFilePath.Text = Settings.Default.EntityFolder;
                tstxtbMappingFilePath.Text = Settings.Default.InfrastructureServicesMappingFolder;
                tstxtbUntTestFilePath.Text = Settings.Default.UnitTestFolder;
                tstxtbTestDataFilePath.Text = Settings.Default.TestDataFolder;
                tstxtbPostSQLSnippet.Text = Settings.Default.PostSQLSnippet;
                tstxtbQueryFilePath.Text = Settings.Default.InfrastructureServicesQueryFolder;
            }
            SetNameSpaces();
        }

        private void FillFields(DataTable resultSchema)
        {
            dgvFields.Rows.Clear();
            foreach (DataRow row in resultSchema.Rows)
            {
                _ColumnDefinitions.Add(row.Field<string>("COLUMN_NAME")
                    , new ColumnDefinition
                    {
                        Type = SQLServer.GetType(row.Field<string>("DATA_TYPE")),
                        DbType = SQLServer.GetDbType(row.Field<string>("DATA_TYPE")),
                        Length = row[8] != DBNull.Value ? row.Field<int>("CHARACTER_MAXIMUM_LENGTH") : 0
                    });
                string fieldName = row.Field<string>("COLUMN_NAME");
                DbType dbType = SQLServer.GetDbType(row.Field<string>("DATA_TYPE"));
                dgvFields.Rows.Add(false, fieldName, GetPropertyName(fieldName, dbType), false, false);
            }
        }

        private void tsbtnCreateCode_Click(object sender, EventArgs e)
        {
            CreateEntity();
            CreateMapping();
            CreateUnitTest();
            CreateMockDataReader();
            CreateLookupServiceInterface();
            CreateLookupServiceClass();
            CreateSaveServiceInterface();
            CreateSaveServiceClass();
            CreateDeleteServiceInterface();
            CreateDeleteServiceClass();
            CreateQueryClass();
            SetNameSpaces();
        }

        private string GetPropertyName(string fieldName, DbType dataType)
        {
            if (_Mappings.ContainsKey(fieldName))
                return _Mappings[fieldName];
            string retVal = fieldName;
            if(tschkbxRemoveTypePrefix.Checked)
            {
                switch(dataType)
                {
                    case DbType.Int16:
                    case DbType.Int32:
                    case DbType.Int64:
                    case DbType.Byte:
                        retVal = retVal.StartsWith("bt") ? retVal.Substring(2) :  retVal.TrimStart('i','n');
                        break;
                    case DbType.AnsiString:
                    case DbType.AnsiStringFixedLength:
                    case DbType.String:
                    case DbType.StringFixedLength:
                        retVal = retVal.Substring(1);
                        break;
                    case DbType.Date:
                    case DbType.DateTime:
                    case DbType.DateTime2:
                        retVal = retVal.TrimStart('d', 't');
                        break;
                    case DbType.Currency:
                    case DbType.Decimal:
                        retVal = retVal.TrimStart('c');
                        break;
                    case DbType.Boolean:
                        retVal = retVal.Substring(2);
                        break;
                    case DbType.VarNumeric:
                        retVal = retVal.TrimStart('n');
                        break;
                }
            }
            if (string.IsNullOrEmpty(retVal))
                return retVal;
            string[] parts = retVal.Split('_');
            retVal = "";
            foreach (string part in parts)
                retVal += part.Substring(0, 1).ToUpper() + part.Substring(1);
            return retVal;
        }

        private void tschkbxCheckAll_CheckChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvFields.Rows)
            {
                row.Cells[0].Value = tschkbxCheckAll.Checked;
            }
        }

        private void tsbtnGetEntityFileName_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog { Description = "Select Entity Folder", SelectedPath = tstxtbEntityFilePath.Text };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tstxtbEntityFilePath.Text = dialog.SelectedPath;
                Settings.Default.EntityFolder = dialog.SelectedPath;
                Settings.Default.Save();
            }
        }

        private void tsbtnGetMappingFileName_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog { Description = "Select Mapping Folder",  SelectedPath = tstxtbMappingFilePath.Text };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tstxtbMappingFilePath.Text = dialog.SelectedPath;
                Settings.Default.InfrastructureServicesMappingFolder = dialog.SelectedPath;
                Settings.Default.Save();
            }
        }

        private void tsbtnGetUnitTestFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog { Description = "Select Unit Test Folder", SelectedPath = tstxtbUntTestFilePath.Text };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tstxtbUntTestFilePath.Text = dialog.SelectedPath;
                Settings.Default.UnitTestFolder = dialog.SelectedPath;
                Settings.Default.Save();
            }
        }

        private void tsbtnSelectQueryFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog { Description = "Select Query Folder", SelectedPath = tstxtbQueryFilePath.Text };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tstxtbQueryFilePath.Text = dialog.SelectedPath;
                Settings.Default.InfrastructureServicesQueryFolder = dialog.SelectedPath;
                Settings.Default.Save();
            }
        }

        private void tsbtnSelectMockDataFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog { Description = "Select Query Folder", SelectedPath = tstxtbTestDataFilePath.Text };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tstxtbTestDataFilePath.Text = dialog.SelectedPath;
                Settings.Default.TestDataFolder = dialog.SelectedPath;
                Settings.Default.Save();
            }
        }

        private void tsbtnSelectLookupFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog { Description = "Select Services Folder", SelectedPath = tstxtbLookupServiceFilePath.Text };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tstxtbLookupServiceFilePath.Text = dialog.SelectedPath;
                tstxtbDeleteServiceFilePath.Text = dialog.SelectedPath;
                tstxtbSaveServiceFilePath.Text = dialog.SelectedPath;
                Settings.Default.InfrastructureServicesQueryFolder = dialog.SelectedPath;
                Settings.Default.Save();
            }
        }

        private void tsbtnSelectQueryUnitTestFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog { Description = "Select Query Unit Test Folder", SelectedPath = tstxtbLookupServiceFilePath.Text };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tstxtbQueryUnitTestFolder.Text = dialog.SelectedPath;
                Settings.Default.QueryUnitTestFolder = dialog.SelectedPath;
                Settings.Default.Save();
            }
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            SaveEntity();
            SaveMapping();
        }

        private void tsbtnSaveMapping_Click(object sender, EventArgs e)
        {
            SaveMapping();
        }
       
        private void tsbtnSaveUnitTest_Click(object sender, EventArgs e)
        {
            SaveUnitTest();
        }

        private void tsbtnSaveEntity_Click(object sender, EventArgs e)
        {
            SaveEntity();
        }

        private void tsbtnSaveQueryFile_Click(object sender, EventArgs e)
        {
            SaveMockData();
        }

        private void tsbtnSubstitude_Click(object sender, EventArgs e)
        {
            NameMapping dialog = new NameMapping
            {
                Mappings = _Mappings
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder mapping = new StringBuilder();
                bool isFirst = true;
                _Mappings = dialog.Mappings;
                foreach (string key in _Mappings.Keys)
                {
                    if (isFirst)
                        isFirst = false;
                    else mapping.Append(',');
                    mapping.Append($"{key}={_Mappings[key]}");
                }
                Settings.Default.Substitutions = mapping.ToString();
                Settings.Default.Save();
            }
        }

        private void tscmbxDbObjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tsbtnFilter.Enabled = true;
            tstxtbFilter.Enabled = true;
            listBox1.Visible = true;
            fctxtbCustomQuery.Visible = false;
            if (_Connection != null)
            {
                if (tscmbxDbObjectType.SelectedItem as string == "Custom SQL")
                {
                    tsbtnFilter.Enabled = false;
                    tstxtbFilter.Enabled = false;
                    listBox1.Visible = false;
                    fctxtbCustomQuery.Visible = true;
                    QueryDialog dialog = new QueryDialog
                    {
                        Text = "Enter Custom SQL",
                        ConnectionString = _Connection.ConnectionString,
                        Query = fctxtbCustomQuery.Text
                    };
                    if (dialog.ShowDialog() == DialogResult.OK)
                        fctxtbCustomQuery.Text = dialog.Query;
                }
                FillTables();
            }
        }

        private void tstxtbNameExpression_Leave(object sender, EventArgs e)
        {
            Settings.Default.ClassNameExpression = tstxtbNameExpression.Text;
            Settings.Default.Save();
        }

        private void tstxtbClassName_Leave(object sender, EventArgs e)
        {
            //tstxtbEntityFilePath.Text = Path.Combine(Settings.Default.EntityFolder, tstxtbClassName.Text + ".cs");
            //tstxtbMappingFilePath.Text = Path.Combine(Settings.Default.MappingFolder, $"{tstxtbClassName.Text}Mapping.cs");
            //tstxtbUntTestFilePath.Text = Path.Combine(Settings.Default.UnitTestFolder, $"{tstxtbClassName.Text}MappingTests.cs");
            //toolstipMockData.Text = Path.Combine(Settings.Default.QueryFolder, $"{tstxtbClassName.Text}Query.cs");
            //fctxtbEntity.Text = "";
            //fctxtbUnitTest.Text = "";
            //fctxtbMapping.Text = "";
        }

        private void tstxtbFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tsbtnFilter.Checked = true;
                FillTables();
            }
        }

        private void tstxtbNamespaceSuffix_Leave(object sender, EventArgs e)
        {
            Settings.Default.NamespaceSuffix = tstxtbNamespaceSuffix.Text;
            Settings.Default.Save();
            SetNameSpaces();
        }

        private void tstxtbNameSpace_Leave(object sender, EventArgs e)
        {
            Settings.Default.Namespace = tstxtbNameSpace.Text;
            Settings.Default.Save();
            SetNameSpaces();
        }

        private void SetNameSpaces()
        {
            if (string.IsNullOrEmpty(Settings.Default.NamespaceSuffix))
            {
                _EntityNamespace = $"{Settings.Default.InfrastructureNamespace}.Entities";
                _MappingNamespace = $"{Settings.Default.Namespace}.Mappings";
                _ServicesNamespace = $"{Settings.Default.Namespace}.Services";
                _MockDataNamespace = $"{Settings.Default.Namespace}.Tests.MockData";
                _UnitTestNamespace = $"{Settings.Default.Namespace}.Tests.UnitTests";
                _QueryNamespace = $"{Settings.Default.Namespace}.Queries";
            }
            else
            {
                _EntityNamespace = $"{Settings.Default.InfrastructureNamespace}.Entities.{Settings.Default.NamespaceSuffix}";
                _MappingNamespace = $"{Settings.Default.Namespace}.Mappings.{Settings.Default.NamespaceSuffix}";
                _ServicesNamespace = $"{Settings.Default.Namespace}.Services.{Settings.Default.NamespaceSuffix}";
                _MockDataNamespace = $"{Settings.Default.Namespace}.Tests.{Settings.Default.NamespaceSuffix}.MockData";
                _UnitTestNamespace = $"{Settings.Default.Namespace}.Tests.{Settings.Default.NamespaceSuffix}.UnitTests";
                _QueryNamespace = $"{Settings.Default.Namespace}.Queries.{Settings.Default.NamespaceSuffix}";
            }
        }

        private void dgvFields_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            fctxtbEntity.Text = "";
            fctxtbUnitTest.Text = "";
            fctxtbMapping.Text = "";
        }

        private void ClassFromDb_Load(object sender, EventArgs e)
        {
            tscmbxDbObjectType.SelectedIndex = 0;
            tstxtbNameExpression.Text = Settings.Default.ClassNameExpression;
        }

        private void tsbtnEditQuery_Click(object sender, EventArgs e)
        {
            QueryDialog dialog = new QueryDialog
            {
                Query = $"{tstxtbQuery.Text}\n{tstxtbPostSQLSnippet.Text}",
                ConnectionString = _ConnectionString
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tstxtbQuery.Text = dialog.Query;
                _MockValues = dialog.Values;
                CreateMockDataReader();
            }
        }

        private void tstxtbQueryFilePath_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.InfrastructureServicesQueryFolder = Path.GetDirectoryName(tstxtbTestDataFilePath.Text);
            Settings.Default.Save();
        }

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
            listBox1.Items.Clear();
            DataTable schema;
            if (tscmbxDbObjectType.SelectedItem as string == "Procedures")
            {
                tsbtnEditQuery.Enabled = false;
                tstxtbQuery.Enabled = false;
                string sql = "SELECT  name FROM sys.objects WHERE type = 'P'";
                using (SqlCommand command = _Connection.CreateCommand())
                {
                    command.CommandText = sql;
                    IDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        string name = reader.GetString(0);
                        if (tsbtnFilter.Checked && !string.IsNullOrEmpty(tstxtbFilter.Text) && !name.Contains(tstxtbFilter.Text))
                            continue;
                        listBox1.Items.Add(name);
                    }
                }
            }
            else if(tscmbxDbObjectType.SelectedItem as string == "Custom SQL")
            {
                tschkbxCheckAll.Checked = false;
                fctxtbEntity.Text = "";
                fctxtbMapping.Text = "";
                fctxtbUnitTest.Text = "";
                fctxtbMockDataReader.Text = "";
                tstxtbQuery.Text = "";
                _MockValues = null;
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
            else
            {
                tsbtnEditQuery.Enabled = true;
                tstxtbQuery.Enabled = true;
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

        private void CreateUnitTest()
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace codeNamespace = new CodeNamespace(_UnitTestNamespace);
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Data"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Linq"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("Xunit"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Mappings"));
            codeNamespace.Imports.Add(new CodeNamespaceImport(_MockDataNamespace));
            codeNamespace.Imports.Add(new CodeNamespaceImport(_MappingNamespace));
            codeNamespace.Imports.Add(new CodeNamespaceImport(_EntityNamespace));
            foreach(string line in fctxtbAssemblies.Lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                codeNamespace.Imports.Add(new CodeNamespaceImport(line));
            }
            unit.Namespaces.Add(codeNamespace);
            CodeTypeDeclaration testClass = new CodeTypeDeclaration
            {
                Name = $"{tstxtbClassName.Text}MappingsTests",
                IsClass = true,
                TypeAttributes = TypeAttributes.Public,
            };
            CodeMemberMethod test = new CodeMemberMethod
            {
                Attributes = MemberAttributes.Public,                
                ReturnType = new CodeTypeReference(),
                Name = $"Test{tstxtbClassName.Text}Mapping"
            };
            test.CustomAttributes.Add(new CodeAttributeDeclaration("Fact"));
            testClass.Members.Add(test);
            CodeVariableDeclarationStatement objectPropertyMap = new CodeVariableDeclarationStatement(new CodeTypeReference($"{tstxtbClassName.Text}Mapping"), "objectPropertyMap");
            test.Statements.Add(objectPropertyMap);
            CodeVariableReferenceExpression objectPropertyMapRef = new CodeVariableReferenceExpression("objectPropertyMap");
            test.Statements.Add(new CodeAssignStatement(objectPropertyMapRef, new CodeObjectCreateExpression($"{tstxtbClassName.Text}Mapping", new CodeExpression[] { })));
            CodeVariableDeclarationStatement actual = new CodeVariableDeclarationStatement(new CodeTypeReference("PropertyMap"), "actual");
            test.Statements.Add(actual);
            CodeVariableReferenceExpression actualRef = new CodeVariableReferenceExpression("actual");
            CodeMethodReferenceExpression assertEqual = new CodeMethodReferenceExpression(new CodePropertyReferenceExpression(new CodeBaseReferenceExpression(), "Assert"), "Equal");
            foreach (DataGridViewRow row in dgvFields.Rows)
            {
                if ((bool)row.Cells[0].Value)
                {
                    ColumnDefinition column = _ColumnDefinitions[row.Cells[1].Value as string];
                    if (column!= null)
                    {
                        string fieldName = row.Cells[1].Value as string;
                        DbType dbType = column.DbType;
                        string propertyName = row.Cells[2].Value as string;

                        CodeMethodInvokeExpression where = new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodePropertyReferenceExpression(objectPropertyMapRef, "PropertyMaps"), "Where"), new CodeSnippetExpression($"m => m.PropertyName == \"{propertyName}\""));
                        CodeMethodInvokeExpression firstOrDefault = new CodeMethodInvokeExpression(where, "FirstOrDefault", new CodeExpression[] { });
                        test.Statements.Add(new CodeAssignStatement(actualRef, firstOrDefault));

                        test.Statements.Add(new CodeMethodInvokeExpression(assertEqual, new CodePrimitiveExpression(propertyName), new CodePropertyReferenceExpression(actualRef, "PropertyName")));
                        test.Statements.Add(new CodeMethodInvokeExpression(assertEqual, new CodePropertyReferenceExpression(new CodeTypeReferenceExpression(typeof(DbType)), Enum.GetName(typeof(DbType), dbType)), new CodePropertyReferenceExpression(actualRef, "DbType")));
                        test.Statements.Add(new CodeMethodInvokeExpression(assertEqual, new CodePrimitiveExpression(fieldName), new CodePropertyReferenceExpression(actualRef, "FieldName")));
                        switch (dbType)
                        {
                            case DbType.String:
                            case DbType.StringFixedLength:
                            case DbType.AnsiString:
                            case DbType.AnsiStringFixedLength:
                                int length = column.Length;
                                test.Statements.Add(new CodeMethodInvokeExpression(assertEqual, new CodePrimitiveExpression(length), new CodePropertyReferenceExpression(actualRef, "FieldLength")));
                                break;
                        }
                    }
                }
            }

             test = new CodeMemberMethod
            {
                Attributes = MemberAttributes.Public,
                ReturnType = new CodeTypeReference(),
                Name = $"Test{tstxtbClassName.Text}Create"
            };
            test.CustomAttributes.Add(new CodeAttributeDeclaration("Fact"));
            testClass.Members.Add(test);

            CodeVariableDeclarationStatement mockData = new CodeVariableDeclarationStatement(new CodeTypeReference($"{tstxtbClassName.Text}MockDatareader"), "reader");
            test.Statements.Add(mockData);
            codeNamespace.Types.Add(testClass);

            test.Statements.Add(objectPropertyMap);
            test.Statements.Add(new CodeAssignStatement(objectPropertyMapRef, new CodeObjectCreateExpression($"{tstxtbClassName.Text}Mapping", new CodeExpression[] { })));

            CodeVariableReferenceExpression readerRef = new CodeVariableReferenceExpression("reader");
            test.Statements.Add(new CodeAssignStatement(readerRef, new CodeObjectCreateExpression($"{tstxtbClassName.Text}MockDatareader", new CodeExpression[] { })));
            test.Statements.Add(new CodeMethodInvokeExpression(readerRef, "Read", new CodeExpression[] { }));

            actual = new CodeVariableDeclarationStatement(new CodeTypeReference($"{tstxtbClassName.Text}"), "actual");
            test.Statements.Add(actual);
            test.Statements.Add(new CodeAssignStatement(actualRef, new CodeSnippetExpression($"ObjectFactory.CreateObject<{tstxtbClassName.Text}>(reader,objectPropertyMap.PropertyMaps)")));
            CodeMethodReferenceExpression assertNotNull = new CodeMethodReferenceExpression(new CodePropertyReferenceExpression(new CodeBaseReferenceExpression(), "Assert"), "NotNull");
            test.Statements.Add(new CodeMethodInvokeExpression(assertNotNull, actualRef));
            test.Statements.Add(new CodeSnippetExpression("object expected"));
            CodeVariableReferenceExpression expectedRef = new CodeVariableReferenceExpression("expected");
            CodeAssignStatement setExpected;
            foreach (DataGridViewRow row in dgvFields.Rows)
            {
                if ((bool)row.Cells[0].Value)
                {
                    ColumnDefinition column = _ColumnDefinitions[row.Cells[1].Value as string];
                    if (column != null)
                    { 
                        string fieldName = row.Cells[1].Value as string;
                        Type type = column.Type;
                        DbType dbType = column.DbType;
                        string propertyName = row.Cells[2].Value as string;

                        setExpected = new CodeAssignStatement(expectedRef, new CodeMethodInvokeExpression(readerRef, "GetValue", new CodeMethodInvokeExpression(readerRef, "GetOrdinal", new CodePrimitiveExpression($"{fieldName}"))));
                        test.Statements.Add(setExpected);
                        test.Statements.Add(new CodeMethodInvokeExpression(assertEqual, expectedRef, new CodePropertyReferenceExpression(actualRef, propertyName)));
                    }
                }
            }


            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            StringWriter stringWriter = new StringWriter();
            provider.GenerateCodeFromCompileUnit(unit, stringWriter, options);
            fctxtbUnitTest.Text = stringWriter.ToString().Replace("[Fact()].", "[Fact]")
                .Replace("base.", "")
                .Replace("System.Data.", "");
        }

        private void CreateMapping()
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace codeNamespace = new CodeNamespace(_MappingNamespace);
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Data"));
            codeNamespace.Imports.Add(new CodeNamespaceImport(_EntityNamespace));
            foreach (string line in fctxtbAssemblies.Lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                codeNamespace.Imports.Add(new CodeNamespaceImport(line));
            }
            unit.Namespaces.Add(codeNamespace);

            CodeTypeDeclaration mapping = new CodeTypeDeclaration
            {
                Name = $"{tstxtbClassName.Text}Mapping",
                IsClass = true,
                TypeAttributes = TypeAttributes.Public,
            };
            mapping.BaseTypes.Add(new CodeTypeReference($"ObjectPropertyMap<{tstxtbClassName.Text}>"));
            codeNamespace.Types.Add(mapping);
            CodeConstructor constructor = new CodeConstructor
            {
                Attributes = MemberAttributes.Public
            };
            CodeAssignStatement setdatabaseObject = new CodeAssignStatement(new CodePropertyReferenceExpression(new CodeBaseReferenceExpression(), "DatabaseObject"), new CodePrimitiveExpression(listBox1.SelectedItem as string));
            constructor.Statements.Add(setdatabaseObject);
            if (tscmbxDbObjectType.SelectedItem as string == "Procedures")
            {
                CodeAssignStatement setStoredProcedure = new CodeAssignStatement(new CodePropertyReferenceExpression(new CodeBaseReferenceExpression(), "IsStoredProcedure"), new CodePrimitiveExpression(true));
                constructor.Statements.Add(setStoredProcedure);
            }
            foreach (DataGridViewRow row in dgvFields.Rows)
            {
                if ((bool)row.Cells[0].Value)
                {
                    ColumnDefinition column = _ColumnDefinitions[row.Cells[1].Value as string];
                    CodeMethodInvokeExpression isKeyField;
                    if (column != null)
                    {
                        string fieldName = row.Cells[1].Value as string;
                        DbType dbType = column.DbType;
                        string propertyName = row.Cells[2].Value as string;
                        CodeMethodInvokeExpression statement = new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeBaseReferenceExpression(), "Property"), new CodeSnippetExpression($"p => p.{row.Cells[2].Value as string}"));
                        CodeMethodInvokeExpression hasField = new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(statement, "HasFieldName"), new CodePrimitiveExpression(fieldName));
                        CodeMethodInvokeExpression hasDbType = new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(hasField, "HasDbType")
                            , new CodePropertyReferenceExpression(new CodeTypeReferenceExpression(typeof(DbType)), Enum.GetName(typeof(DbType), dbType)));
                        switch (dbType)
                        {
                            case DbType.String:
                            case DbType.StringFixedLength:
                            case DbType.AnsiString:
                            case DbType.AnsiStringFixedLength:
                                int length = column.Length;
                                CodeMethodInvokeExpression hasLength = new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(hasDbType, "HasLength"), new CodePrimitiveExpression(length));
                                if ((bool)row.Cells[4].Value)
                                {
                                    isKeyField = new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(hasLength, "IsMemberOfKeyField"), new CodePrimitiveExpression(true));
                                    constructor.Statements.Add(new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(isKeyField, "MustTrimString"), new CodePrimitiveExpression(true)));
                                }
                                else
                                    constructor.Statements.Add(new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(hasLength, "MustTrimString"), new CodePrimitiveExpression(true)));
                                break;
                            default:
                                if ((bool)row.Cells[4].Value)
                                {
                                    isKeyField = new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(hasDbType, "IsMemberOfKeyField"), new CodePrimitiveExpression(true));
                                    constructor.Statements.Add(isKeyField);
                                }
                                else
                                    constructor.Statements.Add(hasDbType);
                                break;
                        }
                    }
                }
            }
            mapping.Members.Add(constructor);
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            StringWriter stringWriter = new StringWriter();
            provider.GenerateCodeFromCompileUnit(unit, stringWriter, options);
            fctxtbMapping.Text = stringWriter.ToString().Replace("base.", "")
                .Replace("System.Data.","");
        }

        private void CreateEntity()
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace codeNamespace = new CodeNamespace(_EntityNamespace);
            codeNamespace.Imports.Add(new CodeNamespaceImport("System"));
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
            codeNamespace.Types.Add(entity);
            foreach (DataGridViewRow row in dgvFields.Rows)
            {
                if ((bool)row.Cells[0].Value)
                {
                    ColumnDefinition column = _ColumnDefinitions[row.Cells[1].Value as string];
                    if (column != null)
                    {
                        Type type = column.Type;
                        string typeName = type == typeof(string) ? "string" : $"{type.Name}?";
                        CodeMemberProperty property = new CodeMemberProperty
                        {
                            Name = row.Cells[2].Value as string,
                            Type = new CodeTypeReference(typeName),
                            HasGet = true,
                            HasSet = true,
                            Attributes = MemberAttributes.Public
                        };
                        entity.Members.Add(property);
                    }
                }
            }
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            StringWriter stringWriter = new StringWriter();
            provider.GenerateCodeFromCompileUnit(unit, stringWriter, options);
            string pattern = "\r\n *{\r\n *get\r\n *\\{\r\n *\\}\r\n *set\r\n *\\{\r\n *\\}\r\n *}\r\n *";
            fctxtbEntity.Text = Regex.Replace(stringWriter.ToString(), pattern, "{ get; set; }")
                .Replace("System.DateTime", "DateTime")
                .Replace("@string", "string")
                .Replace("Int32", "int")
                .Replace("Decimal", "decimal")
                .Replace("Boolean", "bool");
            //fctxtbEntity.Text = stringWriter.ToString();
        }

        private void CreateLookupServiceInterface()
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace codeNamespace = new CodeNamespace(_ServicesNamespace);
            codeNamespace.Imports.Add(new CodeNamespaceImport(_EntityNamespace));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Data"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Threading"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Threading.Tasks"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Services"));
            codeNamespace.Imports.Add(new CodeNamespaceImport(_QueryNamespace));
            foreach (string line in fctxtbAssemblies.Lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                codeNamespace.Imports.Add(new CodeNamespaceImport(line));
            }
            unit.Namespaces.Add(codeNamespace);

            //Declare the interface
            CodeTypeDeclaration typeDeclaration = new CodeTypeDeclaration
            {
                Name = $"I{tstxtbClassName.Text}LookupService",
                TypeAttributes = TypeAttributes.Public,
                IsInterface = true,
            };
            typeDeclaration.BaseTypes.Add(new CodeTypeReference("IDatabaseLookupService"));
            codeNamespace.Types.Add(typeDeclaration);
            CodeParameterDeclarationExpression query = new CodeParameterDeclarationExpression(new CodeTypeReference($"{tstxtbClassName.Text}Query"), "query");
            CodeParameterDeclarationExpression token = new CodeParameterDeclarationExpression(new CodeTypeReference("CancellationToken"), "token");
            CodeParameterDeclarationExpression connection = new CodeParameterDeclarationExpression
            {
                Name = "connection",
                Type = new CodeTypeReference("IDbConnection"),
            };
            //Add the lookup method
            CodeMemberMethod lookupAsync = new CodeMemberMethod
            {
                Name = "LookupAsync",
                ReturnType = new CodeTypeReference($"Task<List<{tstxtbClassName.Text}>>"),
            };

            lookupAsync.Parameters.Add(query);
            lookupAsync.Parameters.Add(token);
            lookupAsync.Parameters.Add(connection);
            typeDeclaration.Members.Add(lookupAsync);

            //Add the lookup method
            CodeMemberMethod lookup = new CodeMemberMethod
            {
                Name = "Lookup",
                ReturnType = new CodeTypeReference($"List<{tstxtbClassName.Text}>"),
            };

            lookup.Parameters.Add(query);
            lookup.Parameters.Add(connection);
            typeDeclaration.Members.Add(lookup);

            //Add the get method
            CodeMemberMethod getAsync = new CodeMemberMethod
            {
                Name = "GetAsync",
                ReturnType = new CodeTypeReference($"Task<{tstxtbClassName.Text}>"),
            };

            getAsync.Parameters.Add(query);
            getAsync.Parameters.Add(token);
            getAsync.Parameters.Add(connection);
            typeDeclaration.Members.Add(getAsync);

            //Add the get method
            CodeMemberMethod get = new CodeMemberMethod
            {
                Name = "Get",
                ReturnType = new CodeTypeReference($"{tstxtbClassName.Text}"),
            };

            get.Parameters.Add(query);
            get.Parameters.Add(connection);
            typeDeclaration.Members.Add(get);

            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            StringWriter stringWriter = new StringWriter();
            provider.GenerateCodeFromCompileUnit(unit, stringWriter, options);
            fctxtbLookupServiceInterface.Text = stringWriter.ToString();
        }

        private void CreateLookupServiceClass()
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace codeNamespace = new CodeNamespace(_ServicesNamespace);
            codeNamespace.Imports.Add(new CodeNamespaceImport(_EntityNamespace));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Data"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Threading"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Threading.Tasks"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Services"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Queries"));
            foreach (string line in fctxtbAssemblies.Lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                codeNamespace.Imports.Add(new CodeNamespaceImport(line));
            }
            unit.Namespaces.Add(codeNamespace);

            //Declare the interface
            CodeTypeDeclaration typeDeclaration = new CodeTypeDeclaration
            {
                Name = $"{tstxtbClassName.Text}LookupService",
                IsClass = true,
                TypeAttributes = TypeAttributes.Public
            };
            typeDeclaration.BaseTypes.Add($"DatabaseLookupService");
            typeDeclaration.BaseTypes.Add($"I{tstxtbClassName.Text}LookupService");

            //Add the class to the namespace
            codeNamespace.Types.Add(typeDeclaration);

            //Add the methods to implemtn the interface
            CodeParameterDeclarationExpression query = new CodeParameterDeclarationExpression(new CodeTypeReference($"{tstxtbClassName.Text}Query"), "query");
            CodeParameterDeclarationExpression token = new CodeParameterDeclarationExpression(new CodeTypeReference("CancellationToken"), "token");
            CodeParameterDeclarationExpression connection = new CodeParameterDeclarationExpression(new CodeTypeReference("IDbConnection"), "connection");
            //Create references to the parameters
            CodeArgumentReferenceExpression queryRefference = new CodeArgumentReferenceExpression("query");
            CodeArgumentReferenceExpression connectionRefference = new CodeArgumentReferenceExpression("connection");
            CodeArgumentReferenceExpression tokenRefference = new CodeArgumentReferenceExpression("token");

            CodeTypeReference taskListValuesType = new CodeTypeReference($"async Task<List<{tstxtbClassName.Text}>>");
            CodeTypeReference mappingType = new CodeTypeReference($"{tstxtbClassName.Text}Mapping");

            CodeObjectCreateExpression mappingCreate = new CodeObjectCreateExpression($"{tstxtbClassName.Text}Mapping");
            //Add the lookup method
            CodeMemberMethod lookupAsync = new CodeMemberMethod
            {
                Name = "LookupAsync",
                ReturnType = taskListValuesType,
                Attributes = MemberAttributes.Public
            };
            
            //Add the parameters to the method signature
            lookupAsync.Parameters.Add(query);
            lookupAsync.Parameters.Add(token);
            lookupAsync.Parameters.Add(connection);

            //Return value
            CodeSnippetStatement lookupAsyncReturnStatement = new CodeSnippetStatement($"\t\t\treturn await base.LookupAsync(query, new {tstxtbClassName.Text}Mapping(), token, connection);");

            lookupAsync.Statements.Add(lookupAsyncReturnStatement);

            //Add the method to the class
            typeDeclaration.Members.Add(lookupAsync);

            CodeMemberMethod lookup = new CodeMemberMethod
            {
                Name = "Lookup",
                ReturnType = new CodeTypeReference($"List<{tstxtbClassName.Text}>"),
                Attributes = MemberAttributes.Public
            };

            //Add the parameters to the method signature
            lookup.Parameters.Add(query);
            lookup.Parameters.Add(connection);

            //Return value
            CodeMethodReturnStatement lookupReturnStatement = new CodeMethodReturnStatement(new CodeMethodInvokeExpression(new CodeBaseReferenceExpression()
                , "Lookup"
                , queryRefference
                , mappingCreate
                , connection));

            lookup.Statements.Add(lookupReturnStatement);
            //Add the method to the class
            typeDeclaration.Members.Add(lookup);

            //Add the get method
            CodeMemberMethod getAsync = new CodeMemberMethod
            {
                Name = "GetAsync",
                ReturnType = new CodeTypeReference($"async Task<{tstxtbClassName.Text}>"),
                Attributes = MemberAttributes.Public
            };

            getAsync.Parameters.Add(query);
             getAsync.Parameters.Add(token);
           getAsync.Parameters.Add(connection);

            CodeSnippetStatement getAsyncReturnStatement = new CodeSnippetStatement($"\t\t\treturn await base.GetAsync(query, new {tstxtbClassName.Text}Mapping(), token, connection);");

            getAsync.Statements.Add(getAsyncReturnStatement);

            typeDeclaration.Members.Add(getAsync);

            //Add the get method
            CodeMemberMethod get = new CodeMemberMethod
            {
                Name = "Get",
                ReturnType = new CodeTypeReference($"{tstxtbClassName.Text}"),
                Attributes = MemberAttributes.Public
            };

            get.Parameters.Add(query);
            get.Parameters.Add(connection);

            //Return value
            CodeMethodReturnStatement getReturnStatement = new CodeMethodReturnStatement(new CodeMethodInvokeExpression(new CodeBaseReferenceExpression()
                , "Get"
                , queryRefference
                , mappingCreate
                , connection));

            get.Statements.Add(getReturnStatement);

            typeDeclaration.Members.Add(get);

            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            StringWriter stringWriter = new StringWriter();
            provider.GenerateCodeFromCompileUnit(unit, stringWriter, options);
            fctxtbLookupServiceClass.Text = stringWriter.ToString();
        }

        private void CreateSaveServiceInterface()
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace codeNamespace = new CodeNamespace(_MappingNamespace);
            codeNamespace.Imports.Add(new CodeNamespaceImport(_EntityNamespace));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Data"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Threading"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Threading.Tasks"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Services"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Models"));
            foreach (string line in fctxtbAssemblies.Lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                codeNamespace.Imports.Add(new CodeNamespaceImport(line));
            }
            unit.Namespaces.Add(codeNamespace);

            //Declare the interface
            CodeTypeDeclaration typeDeclaration = new CodeTypeDeclaration
            {
                Name = $"I{tstxtbClassName.Text}SaveService",
                TypeAttributes = TypeAttributes.Public,
                IsInterface = true,
            };
            typeDeclaration.BaseTypes.Add(new CodeTypeReference("IDatabaseSaveService"));
            codeNamespace.Types.Add(typeDeclaration);
            CodeParameterDeclarationExpression value = new CodeParameterDeclarationExpression(new CodeTypeReference(tstxtbClassName.Text), "value");
            CodeParameterDeclarationExpression token = new CodeParameterDeclarationExpression(new CodeTypeReference("CancellationToken"), "token");
            CodeParameterDeclarationExpression connection = new CodeParameterDeclarationExpression
            {
                Name = "connection",
                Type = new CodeTypeReference("IDbConnection"),
            };
            //Add the save async method
            CodeMemberMethod saveAsync = new CodeMemberMethod
            {
                Name = "SaveAsync",
                ReturnType = new CodeTypeReference($"Task<Response>"),
            };

            saveAsync.Parameters.Add(value);
            saveAsync.Parameters.Add(connection);
            saveAsync.Parameters.Add(token);
            typeDeclaration.Members.Add(saveAsync);

            //Add the save  method
            CodeMemberMethod save = new CodeMemberMethod
            {
                Name = "Save",
                ReturnType = new CodeTypeReference($"Response"),
            };

            save.Parameters.Add(value);
            save.Parameters.Add(connection);
            typeDeclaration.Members.Add(save);

            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            StringWriter stringWriter = new StringWriter();
            provider.GenerateCodeFromCompileUnit(unit, stringWriter, options);
            fctxtbSaveServiceInterface.Text = stringWriter.ToString();
        }

        private void CreateSaveServiceClass()
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace codeNamespace = new CodeNamespace(_ServicesNamespace);
            codeNamespace.Imports.Add(new CodeNamespaceImport(_EntityNamespace));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Data"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Threading"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Threading.Tasks"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Services"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Models"));
            foreach (string line in fctxtbAssemblies.Lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                codeNamespace.Imports.Add(new CodeNamespaceImport(line));
            }
            unit.Namespaces.Add(codeNamespace);

            //Declare the interface
            CodeTypeDeclaration typeDeclaration = new CodeTypeDeclaration
            {
                Name = $"{tstxtbClassName.Text}SaveService",
                IsClass = true,
                TypeAttributes = TypeAttributes.Public
            };
            typeDeclaration.BaseTypes.Add($"DatabaseSaveService");
            typeDeclaration.BaseTypes.Add($"I{tstxtbClassName.Text}SaveService");

            //Add the class to the namespace
            codeNamespace.Types.Add(typeDeclaration);

            //Add the methods to implemtn the interface
            CodeParameterDeclarationExpression value = new CodeParameterDeclarationExpression(new CodeTypeReference(tstxtbClassName.Text), "value");
            CodeParameterDeclarationExpression token = new CodeParameterDeclarationExpression(new CodeTypeReference("CancellationToken"), "token");
            CodeParameterDeclarationExpression connection = new CodeParameterDeclarationExpression(new CodeTypeReference("IDbConnection"), "connection");

            //Create references to the parameters
            CodeArgumentReferenceExpression valueRefference = new CodeArgumentReferenceExpression("value");
            CodeArgumentReferenceExpression tokenRefference = new CodeArgumentReferenceExpression("token");
            CodeArgumentReferenceExpression connectionRefference = new CodeArgumentReferenceExpression("connection");

            CodeTypeReference taskListValuesType = new CodeTypeReference($"async Task<Response>");

            CodeObjectCreateExpression mappingCreate = new CodeObjectCreateExpression($"{tstxtbClassName.Text}Mapping");
            //Add the save async method
            CodeMemberMethod saveAsync = new CodeMemberMethod
            {
                Name = "SaveAsync",
                ReturnType = taskListValuesType,
                Attributes = MemberAttributes.Public
            };

            //Add the parameters to the method signature
            saveAsync.Parameters.Add(value);
            saveAsync.Parameters.Add(connection);
            saveAsync.Parameters.Add(token);

            //Return value
            CodeSnippetStatement saveAsyncReturnStatement = new CodeSnippetStatement($"\t\treturn await base.SaveAsync(value, new {tstxtbClassName.Text}Mapping(), connection, token)");

            saveAsync.Statements.Add(saveAsyncReturnStatement);

            //Add the method to the class
            typeDeclaration.Members.Add(saveAsync);

            CodeMemberMethod save = new CodeMemberMethod
            {
                Name = "Save",
                ReturnType = new CodeTypeReference($"Response>"),
                Attributes = MemberAttributes.Public
            };

            //Add the parameters to the method signature
            save.Parameters.Add(value);
            save.Parameters.Add(connection);

            //Return value
            CodeMethodReturnStatement lookupReturnStatement = new CodeMethodReturnStatement(new CodeMethodInvokeExpression(new CodeBaseReferenceExpression()
                , "Save"
                , valueRefference
                , mappingCreate
                , connectionRefference));

            save.Statements.Add(lookupReturnStatement);
            //Add the method to the class
            typeDeclaration.Members.Add(save);

            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            StringWriter stringWriter = new StringWriter();
            provider.GenerateCodeFromCompileUnit(unit, stringWriter, options);
            fctxtbSaveService.Text = stringWriter.ToString();
        }

        private void CreateDeleteServiceInterface()
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace codeNamespace = new CodeNamespace(_MappingNamespace);
            codeNamespace.Imports.Add(new CodeNamespaceImport(_EntityNamespace));
            codeNamespace.Imports.Add(new CodeNamespaceImport(_QueryNamespace));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Data"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Threading"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Threading.Tasks"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Services"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Queries"));
            foreach (string line in fctxtbAssemblies.Lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                codeNamespace.Imports.Add(new CodeNamespaceImport(line));
            }
            unit.Namespaces.Add(codeNamespace);

            //Declare the interface
            CodeTypeDeclaration typeDeclaration = new CodeTypeDeclaration
            {
                Name = $"I{tstxtbClassName.Text}DeleteService",
                TypeAttributes = TypeAttributes.Public,
                IsInterface = true,
            };
            typeDeclaration.BaseTypes.Add(new CodeTypeReference("IDatabaseDeleteService"));
            codeNamespace.Types.Add(typeDeclaration);
            CodeParameterDeclarationExpression query = new CodeParameterDeclarationExpression(new CodeTypeReference($"{tstxtbClassName.Text}Query"), "query");
            CodeParameterDeclarationExpression value = new CodeParameterDeclarationExpression(new CodeTypeReference(tstxtbClassName.Text), "value");
            CodeParameterDeclarationExpression token = new CodeParameterDeclarationExpression(new CodeTypeReference("CancellationToken"), "token");
            CodeParameterDeclarationExpression connection = new CodeParameterDeclarationExpression
            {
                Name = "connection",
                Type = new CodeTypeReference("IDbConnection"),
            };
            //Add the delete async method
            CodeMemberMethod deleteAsync = new CodeMemberMethod
            {
                Name = "DeleteAsync",
                ReturnType = new CodeTypeReference($"Task<Response>"),
            };

            deleteAsync.Parameters.Add(value);
            deleteAsync.Parameters.Add(connection);
            deleteAsync.Parameters.Add(token);
            deleteAsync.Parameters.Add(query);
            deleteAsync.Comments.Add(new CodeCommentStatement("todo-Add defaut value to make the query parameter optional. \"query = null\""));

            typeDeclaration.Members.Add(deleteAsync);

            //Add the save  method
            CodeMemberMethod delete = new CodeMemberMethod
            {
                Name = "Delete",
                ReturnType = new CodeTypeReference($"Response"),
            };

            delete.Parameters.Add(value);
            delete.Parameters.Add(connection);
            delete.Parameters.Add(query);
            delete.Comments.Add(new CodeCommentStatement("todo- Add defaut value to make the query parameter optional. \"query = null\""));

            typeDeclaration.Members.Add(delete);

            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            StringWriter stringWriter = new StringWriter();
            provider.GenerateCodeFromCompileUnit(unit, stringWriter, options);
            fctxtbDeleteServiceInterface.Text = stringWriter.ToString();
        }

        private void CreateDeleteServiceClass()
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace codeNamespace = new CodeNamespace(_ServicesNamespace);
            codeNamespace.Imports.Add(new CodeNamespaceImport(_EntityNamespace));
            codeNamespace.Imports.Add(new CodeNamespaceImport(_QueryNamespace));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Data"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Threading"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Threading.Tasks"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Services"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Queries"));
            foreach (string line in fctxtbAssemblies.Lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                codeNamespace.Imports.Add(new CodeNamespaceImport(line));
            }
            unit.Namespaces.Add(codeNamespace);

            //Declare the interface
            CodeTypeDeclaration typeDeclaration = new CodeTypeDeclaration
            {
                Name = $"{tstxtbClassName.Text}DeleteService",
                IsClass = true,
                TypeAttributes = TypeAttributes.Public
            };
            typeDeclaration.BaseTypes.Add($"DatabaseDeleteService");
            typeDeclaration.BaseTypes.Add($"I{tstxtbClassName.Text}DeleteService");

            //Add the class to the namespace
            codeNamespace.Types.Add(typeDeclaration);

            //Add the methods to implemtn the interface
            CodeParameterDeclarationExpression query = new CodeParameterDeclarationExpression(new CodeTypeReference($"{tstxtbClassName.Text}Query"), "query");
            CodeParameterDeclarationExpression value = new CodeParameterDeclarationExpression(new CodeTypeReference(tstxtbClassName.Text), "value");
            CodeParameterDeclarationExpression token = new CodeParameterDeclarationExpression(new CodeTypeReference("CancellationToken"), "token");
            CodeParameterDeclarationExpression connection = new CodeParameterDeclarationExpression(new CodeTypeReference("IDbConnection"), "connection");

            //Create references to the parameters
            CodeArgumentReferenceExpression queryRefference = new CodeArgumentReferenceExpression("query");
            CodeArgumentReferenceExpression valueRefference = new CodeArgumentReferenceExpression("value");
            CodeArgumentReferenceExpression tokenRefference = new CodeArgumentReferenceExpression("token");
            CodeArgumentReferenceExpression connectionRefference = new CodeArgumentReferenceExpression("connection");

            CodeTypeReference taskListValuesType = new CodeTypeReference($"async Task<Response>");

            CodeObjectCreateExpression mappingCreate = new CodeObjectCreateExpression($"{tstxtbClassName.Text}Mapping");
            //Add the save async method
            CodeMemberMethod deleteAsync = new CodeMemberMethod
            {
                Name = "DeleteAsync",
                ReturnType = taskListValuesType,
                Attributes = MemberAttributes.Public
            };

            //Add the parameters to the method signature
            deleteAsync.Parameters.Add(value);
            deleteAsync.Parameters.Add(connection);
            deleteAsync.Parameters.Add(token);
            deleteAsync.Parameters.Add(query);
            deleteAsync.Comments.Add(new CodeCommentStatement("todo-Add defaut value to make the query parameter optional. \"query = null\""));

            //Return value
            CodeSnippetStatement saveAsyncReturnStatement = new CodeSnippetStatement($"\t\treturn await base.DeleteAsync(value, new {tstxtbClassName.Text}Mapping(), connection, token, query)");

            deleteAsync.Statements.Add(saveAsyncReturnStatement);

            //Add the method to the class
            typeDeclaration.Members.Add(deleteAsync);

            CodeMemberMethod delete = new CodeMemberMethod
            {
                Name = "Delete",
                ReturnType = new CodeTypeReference($"Response>"),
                Attributes = MemberAttributes.Public
            };

            //Add the parameters to the method signature
            delete.Parameters.Add(value);
            delete.Parameters.Add(connection);
            delete.Parameters.Add(query);
            delete.Comments.Add(new CodeCommentStatement("todo-Add defaut value to make the query parameter optional. \"query = null\""));

            //Return value
            CodeMethodReturnStatement lookupReturnStatement = new CodeMethodReturnStatement(new CodeMethodInvokeExpression(new CodeBaseReferenceExpression()
                , "Delete"
                , valueRefference
                , mappingCreate
                , connectionRefference
                , queryRefference));

            delete.Statements.Add(lookupReturnStatement);
            //Add the method to the class
            typeDeclaration.Members.Add(delete);

            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            StringWriter stringWriter = new StringWriter();
            provider.GenerateCodeFromCompileUnit(unit, stringWriter, options);
            fctxtbDeleteServiceClass.Text = stringWriter.ToString();
        }

        private void CreateQueryClass()
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace codeNamespace = new CodeNamespace(_QueryNamespace);
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Data"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Queries"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Infrastructure"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Infrastructure.Interfaces"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Infrastructure.Enums"));
            foreach (string line in fctxtbAssemblies.Lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                codeNamespace.Imports.Add(new CodeNamespaceImport(line));
            }
            unit.Namespaces.Add(codeNamespace);

            //Declare the type
            CodeTypeDeclaration typeDeclaration = new CodeTypeDeclaration
            {
                Name = $"{tstxtbClassName.Text}Query",
                TypeAttributes = TypeAttributes.Public
            };
            typeDeclaration.BaseTypes.Add(new CodeTypeReference("IQuery"));
            codeNamespace.Types.Add(typeDeclaration);

            //Add properties for all the fields marked as query fields
            foreach(DataGridViewRow row in dgvFields.Rows)
            {
                if((bool)row.Cells[3].Value)
                {
                    // add a property to the class
                    ColumnDefinition column = _ColumnDefinitions[row.Cells[1].Value as string];
                    if (column != null)
                    {
                        Type type = column.Type;
                        string typeName = type == typeof(string) ? "string" : $"{type.Name}?";
                        CodeMemberProperty property = new CodeMemberProperty
                        {
                            Name = row.Cells[2].Value as string,
                            Type = new CodeTypeReference(typeName),
                            HasGet = true,
                            HasSet = true,
                            Attributes = MemberAttributes.Public
                        };
                        typeDeclaration.Members.Add(property);
                    }
                }
            }

            //Add the filters property
            CodeMemberProperty filterProperty = new CodeMemberProperty
            {
                Name = "Filters",
                Type = new CodeTypeReference("Filters"),
                HasGet = true,
                HasSet = false,
                Attributes = MemberAttributes.Public
            };
            typeDeclaration.Members.Add(filterProperty);

            //Add the BuildFilter method
            CodeMemberMethod buildFilter = new CodeMemberMethod
            {
                Name = "BuildFilters",
                ReturnType = new CodeTypeReference($"Filters"),
                Attributes = MemberAttributes.Private
            };

            CodeMethodReferenceExpression builfFiltersRef = new CodeMethodReferenceExpression(new CodeThisReferenceExpression(), "BuildFilters");

            filterProperty.GetStatements.Add(new CodeMethodReturnStatement(new CodeMethodInvokeExpression(builfFiltersRef)));
            typeDeclaration.Members.Add(buildFilter);

            //Create statements to add and instantiate the returnValue of type Filter to the method
            CodeVariableDeclarationStatement returnValue = new CodeVariableDeclarationStatement("Filters", "returnValue");
            CodeVariableReferenceExpression returnValueRef = new CodeVariableReferenceExpression("returnValue");
            CodeAssignStatement innitiateReturnValue = new CodeAssignStatement(returnValueRef, new CodeObjectCreateExpression("Filters"));

            //Add the statements
            buildFilter.Statements.Add(returnValue);
            buildFilter.Statements.Add(innitiateReturnValue);

            //Create the return statement
            CodeMethodReturnStatement returnStatement = new CodeMethodReturnStatement(returnValueRef);
            CodePropertyReferenceExpression filterListRef = new CodePropertyReferenceExpression(returnValueRef, "FilterList");

            //Add filter for all the fields marked as query fields
            foreach (DataGridViewRow row in dgvFields.Rows)
            {
                if ((bool)row.Cells[3].Value)
                {
                    // add a property to the class
                    ColumnDefinition column = _ColumnDefinitions[row.Cells[1].Value as string];
                    if (column != null)
                    {
                        CodePropertyReferenceExpression propertyReference = new CodePropertyReferenceExpression(new CodeThisReferenceExpression(), row.Cells[2].Value as string);
                        CodeBinaryOperatorExpression isnullExpression = new CodeBinaryOperatorExpression(propertyReference, CodeBinaryOperatorType.IdentityInequality, new CodePrimitiveExpression(null));
                        CodeConditionStatement ifStatement = new CodeConditionStatement
                        {
                            Condition = isnullExpression
                        };
                        CodeVariableDeclarationStatement filter = new CodeVariableDeclarationStatement("Filter", "filter");
                        CodeVariableReferenceExpression filterRef = new CodeVariableReferenceExpression("filter");
                        CodeObjectCreateExpression createFilterExpression = new CodeObjectCreateExpression("Filter");
                        CodeAssignStatement setFilter = new CodeAssignStatement(filterRef, createFilterExpression);

                        CodePropertyReferenceExpression nameRef = new CodePropertyReferenceExpression(filterRef, "Name");
                        CodeAssignStatement setName = new CodeAssignStatement(nameRef, new CodePrimitiveExpression($"By {row.Cells[2].Value}"));

                        CodePropertyReferenceExpression propertyNameRef = new CodePropertyReferenceExpression(filterRef, "PropertyName");
                        CodeAssignStatement setPropertyName = new CodeAssignStatement(propertyNameRef, new CodePrimitiveExpression(row.Cells[2].Value));

                        CodePropertyReferenceExpression fieldNameRef = new CodePropertyReferenceExpression(filterRef, "FieldName");
                        CodeAssignStatement setFieldName = new CodeAssignStatement(fieldNameRef, new CodePrimitiveExpression(row.Cells[1].Value));

                        CodePropertyReferenceExpression operatorRef = new CodePropertyReferenceExpression(filterRef, "Operator");
                        CodeAssignStatement setOperatore = new CodeAssignStatement(operatorRef, new CodeFieldReferenceExpression(new CodeTypeReferenceExpression("ComparisonOperator"), "Equal"));

                        CodeVariableDeclarationStatement value = new CodeVariableDeclarationStatement("ValueObject", "filterValue");
                        CodeVariableReferenceExpression valueRef = new CodeVariableReferenceExpression("filterValue");
                        CodeObjectCreateExpression createValueExpression = new CodeObjectCreateExpression("ValueObject");

                        CodeAssignStatement setValue = new CodeAssignStatement(valueRef, createValueExpression);
                        CodePropertyReferenceExpression valueValueRef = new CodePropertyReferenceExpression(valueRef, "Value");

                        CodeAssignStatement setValueValue = new CodeAssignStatement(valueValueRef, propertyReference);

                        CodePropertyReferenceExpression filterValueRef = new CodePropertyReferenceExpression(filterRef, "Value");

                        CodeAssignStatement setValueProperty = new CodeAssignStatement(filterValueRef, valueRef);

                        ifStatement.TrueStatements.AddRange(new CodeStatement[]
                        {
                            filter,
                            setFilter,
                            value,
                            setValue,
                            setValueValue,
                            setName,
                            setPropertyName,
                            setFieldName,
                            setOperatore,
                            setValueProperty,
                        });

                        CodeMethodInvokeExpression addFilterExpression = new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(filterListRef
                            , "Add")
                            , new CodeObjectCreateExpression("KeyValuePair<SEFI.Interfaces.IFilter, LogicOperator>", filterRef, new CodeSnippetExpression("LogicOperator.Empty")));
                        ifStatement.TrueStatements.Add(addFilterExpression);
                        buildFilter.Statements.Add(ifStatement);
                    }
                }
            }

            buildFilter.Statements.Add(returnStatement);

            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            StringWriter stringWriter = new StringWriter();
            provider.GenerateCodeFromCompileUnit(unit, stringWriter, options);
            fctxtbQuery.Text = stringWriter.ToString();
            string pattern = "\r\n *{\r\n *get\r\n *\\{\r\n *\\}\r\n *set\r\n *\\{\r\n *\\}\r\n *}\r\n *";
            fctxtbQuery.Text = Regex.Replace(stringWriter.ToString(), pattern, "{ get; set; }")
                .Replace("System.DateTime", "DateTime")
                .Replace("@string", "string")
                .Replace("Int32", "int")
                .Replace("Decimal", "decimal")
                .Replace("Boolean", "bool");
        }

        private void CreateMockDataReader()
        {
            fctxtbMockDataReader.Text = "";
            if (_MockValues == null)
            {
                SqlConnection Connection = new SqlConnection(_ConnectionString);
                SqlCommand command = null;
                _MockValues = new List<Dictionary<string, object>>();
                try
                {
                    if (tscmbxDbObjectType.SelectedItem as string == "Custom SQL")
                    {
                        command = _Connection.CreateCommand();
                        Connection.Open();
                        command.CommandText = fctxtbCustomQuery.Text;
                        command.CommandType = CommandType.Text;
                        mockDataReader = command.ExecuteReader();
                    }
                    else if (tscmbxDbObjectType.SelectedItem as string != "Procedures")
                    {
                        command = _Connection.CreateCommand();
                        Connection.Open();
                        command.CommandText = tstxtbQuery.Text;
                        command.CommandType = CommandType.Text;
                        mockDataReader = command.ExecuteReader();
                    }
                   
                    if (mockDataReader != null)
                    {
                        while (mockDataReader.Read())
                        {
                            Dictionary<string, object> rowData = new Dictionary<string, object>();
                            for (int i = 0; i < mockDataReader.FieldCount; i++)
                            {
                                string column = mockDataReader.GetName(i);
                                rowData.Add(column, mockDataReader.GetValue(i));
                            }
                            _MockValues.Add(rowData);
                        }
                    }
                }
                catch (Exception excp)
                {
                    MessageBox.Show($"There was an error trying to execute the query. Error: {excp}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    mockDataReader?.Dispose();
                    command?.Dispose();
                    if (Connection != null)
                    {
                        if (Connection.State == ConnectionState.Open)
                            Connection.Close();
                        Connection.Dispose();
                    }
                }
            }
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace codeNamespace = new CodeNamespace(_MockDataNamespace);
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.DataUtilities"));
            foreach (string line in fctxtbAssemblies.Lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                codeNamespace.Imports.Add(new CodeNamespaceImport(line));
            }
            unit.Namespaces.Add(codeNamespace);
            CodeTypeDeclaration typeDeclaration = new CodeTypeDeclaration
            {
                Name = $"{tstxtbClassName.Text}MockDatareader",
                IsClass = true,
                TypeAttributes = TypeAttributes.Public,
            };
            typeDeclaration.BaseTypes.Add(new CodeTypeReference("MemoryDataReader"));
            codeNamespace.Types.Add(typeDeclaration);

            CodeConstructor constructor = new CodeConstructor
            {
                Attributes = MemberAttributes.Public
            };

            int row = 0;
            foreach(Dictionary<string, object> values in _MockValues)
            {
                foreach(KeyValuePair<string, object> value in values)
                {
                    CodeObjectCreateExpression valueExpression = null;
                    if(value.Value == null)
                        valueExpression = new CodeObjectCreateExpression("KeyValuePair<string, object>", new CodePrimitiveExpression(value.Key), new CodePrimitiveExpression(null));
                    else if (value.Value == DBNull.Value)
                        valueExpression = new CodeObjectCreateExpression("KeyValuePair<string, object>", new CodePrimitiveExpression(value.Key), new CodePrimitiveExpression(null));
                    else if (value.Value.GetType().IsPrimitive)
                        valueExpression = new CodeObjectCreateExpression("KeyValuePair<string, object>", new CodePrimitiveExpression(value.Key), new CodePrimitiveExpression(value.Value));
                    else if (value.Value.GetType() == typeof(DateTime))
                        valueExpression = new CodeObjectCreateExpression("KeyValuePair<string, object>", new CodePrimitiveExpression(value.Key), new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(value.Value.GetType()), "Parse", new CodePrimitiveExpression(((DateTime)value.Value).ToString("yyyy-MM-ddTHH:mm:ss.fff"))));
                    else if (value.Value.GetType() == typeof(Guid))
                        valueExpression = new CodeObjectCreateExpression("KeyValuePair<string, object>", new CodePrimitiveExpression(value.Key), new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(value.Value.GetType()), "Parse", new CodePrimitiveExpression($"{value.Value}")));
                    else if (value.Value.GetType() == typeof(string))
                        valueExpression = new CodeObjectCreateExpression("KeyValuePair<string, object>", new CodePrimitiveExpression(value.Key), new CodePrimitiveExpression((value.Value as string).Trim()));
                    else if (value.Value.GetType() == typeof(byte[]))
                        valueExpression = new CodeObjectCreateExpression("KeyValuePair<string, object>", new CodePrimitiveExpression(value.Key), new CodePrimitiveExpression(null));
                    else
                        valueExpression = new CodeObjectCreateExpression("KeyValuePair<string, object>", new CodePrimitiveExpression(value.Key), new CodePrimitiveExpression(value.Value));
                    CodeMethodInvokeExpression addValue = new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), "AddValues", new CodePrimitiveExpression(row), valueExpression);
                    constructor.Statements.Add(addValue);
                }
                row++;
            }

            typeDeclaration.Members.Add(constructor);

            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            StringWriter stringWriter = new StringWriter();
            provider.GenerateCodeFromCompileUnit(unit, stringWriter, options);
            fctxtbMockDataReader.Text = stringWriter.ToString();
        }

        private void tsbtnSaveQuery_Click(object sender, EventArgs e)
        {
            SaveQuery();
        }

        private void tsbtnSaveLookupService_Click(object sender, EventArgs e)
        {
            SaveLookupService();
        }

        private void tsbtnSaveSaveService_Click(object sender, EventArgs e)
        {
            SaveSaveService();
        }

        private void tsbtnSaveDeleteService_Click(object sender, EventArgs e)
        {
            SaveDeleteService();
        }

        private void tsbtnSaveQueryUnitTest_Click(object sender, EventArgs e)
        {
            SaveQueryUnitTest();
        }

        private void SaveEntity()
        {
            if (string.IsNullOrEmpty(tstxtbEntityFilePath.Text))
            {
                MessageBox.Show("Please select the folder where the file needs to be saved", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string path = Path.Combine(Settings.Default.EntityFolder, $"{tstxtbClassName.Text}.cs");
            fctxtbEntity.SaveToFile(path, Encoding.ASCII);
            MessageBox.Show($"{path} has been saved", "File Saved", MessageBoxButtons.OK);
        }

        private void SaveMapping()
        {
            if (string.IsNullOrEmpty(tstxtbMappingFilePath.Text))
            {
                MessageBox.Show("Please select the folder where the file needs to be saved", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string path;
            if(string.IsNullOrEmpty(Settings.Default.GitRepositoryFolder))
                path = Path.Combine(Settings.Default.InfrastructureServicesMappingFolder, $"{tstxtbClassName.Text}Mapping.cs");
            else
                path = $"{Settings.Default.GitRepositoryFolder}\\{Settings.Default.InfrastructureServicesMappingFolder.Replace(Settings.Default.GitRepositoryFolder, "")}\\{tstxtbClassName.Text}Mapping.cs";
            fctxtbMapping.SaveToFile(path, Encoding.ASCII);
            MessageBox.Show($"{path} has been saved", "File Saved", MessageBoxButtons.OK);
        }

        private void SaveUnitTest()
        {
            if (string.IsNullOrEmpty(tstxtbUntTestFilePath.Text))
            {
                MessageBox.Show("Please select the folder where the file needs to be saved", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string path;
            if (string.IsNullOrEmpty(Settings.Default.GitRepositoryFolder))
                path = Path.Combine(Settings.Default.UnitTestFolder, $"{tstxtbClassName.Text}MappingsTests.cs");
            else
                path = $"{Settings.Default.GitRepositoryFolder}{Settings.Default.UnitTestFolder.Replace(Settings.Default.GitRepositoryFolder, "")}\\{tstxtbClassName.Text}MappingsTests.cs";
            fctxtbUnitTest.SaveToFile(path, Encoding.ASCII);
            MessageBox.Show($"{path} has been saved", "File Saved", MessageBoxButtons.OK);
        }

        private void SaveMockData()
        {
            if (string.IsNullOrEmpty(tstxtbTestDataFilePath.Text))
            {
                MessageBox.Show("Please select the folder where the file needs to be saved", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string path;
            if(string.IsNullOrEmpty(Settings.Default.GitRepositoryFolder))
                path = Path.Combine(Settings.Default.TestDataFolder, $"{tstxtbClassName.Text}MockDataReader.cs");
            else
                path = $"{Settings.Default.GitRepositoryFolder}\\{Settings.Default.TestDataFolder.Replace(Settings.Default.GitRepositoryFolder, "")}\\{tstxtbClassName.Text}MockDataReader.cs";
            fctxtbMockDataReader.SaveToFile(path, Encoding.ASCII);
            MessageBox.Show($"{path} has been saved", "File Saved", MessageBoxButtons.OK);
        }

        private void SaveLookupService()
        {
            if (string.IsNullOrEmpty(Settings.Default.InfrastructureServicesFolder) || string.IsNullOrEmpty(Settings.Default.InfrastructureServicesInterfacesFolder))
            {
                MessageBox.Show("Please select the folder where the file needs to be saved", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string path;
            if (string.IsNullOrEmpty(Settings.Default.GitRepositoryFolder))
                path = Path.Combine(Settings.Default.InfrastructureServicesFolder, $"{tstxtbClassName.Text}LookupService.cs");
            else
                path = $"{Settings.Default.GitRepositoryFolder}{Settings.Default.InfrastructureServicesFolder.Replace(Settings.Default.GitRepositoryFolder, "")}\\{tstxtbClassName.Text}LookupService.cs";
            fctxtbLookupServiceClass.SaveToFile(path, Encoding.ASCII);

            if (string.IsNullOrEmpty(Settings.Default.GitRepositoryFolder))
                path = Path.Combine(Settings.Default.InfrastructureServicesInterfacesFolder, $"I{tstxtbClassName.Text}LookupService.cs");
            else
                path = $"{Settings.Default.GitRepositoryFolder}\\{Settings.Default.InfrastructureServicesInterfacesFolder.Replace(Settings.Default.GitRepositoryFolder, "")}\\I{tstxtbClassName.Text}LookupService.cs";
            fctxtbLookupServiceInterface.SaveToFile(path, Encoding.ASCII);
            MessageBox.Show($"{path} has been saved", "File Saved", MessageBoxButtons.OK);
        }

        private void SaveSaveService()
        {
            if (string.IsNullOrEmpty(Settings.Default.InfrastructureServicesFolder) || string.IsNullOrEmpty(Settings.Default.InfrastructureServicesInterfacesFolder))
            {
                MessageBox.Show("Please select the folder where the file needs to be saved", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(Settings.Default.GitRepositoryFolder))
            {
                MessageBox.Show("Please configure the GIT Repository folder.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string path;
                if (string.IsNullOrEmpty(Settings.Default.GitRepositoryFolder))
                    path = Path.Combine(Settings.Default.InfrastructureServicesFolder, $"{tstxtbClassName.Text}SaveService.cs");
                else
                    path = $"{Settings.Default.GitRepositoryFolder}{Settings.Default.InfrastructureServicesFolder.Replace(Settings.Default.GitRepositoryFolder, "")}\\{tstxtbClassName.Text}SaveService.cs";
                fctxtbSaveService.SaveToFile(path, Encoding.ASCII);

                if (string.IsNullOrEmpty(Settings.Default.GitRepositoryFolder))
                    path = Path.Combine(Settings.Default.InfrastructureServicesInterfacesFolder, $"I{tstxtbClassName.Text}SaveService.cs");
                else
                    path = $"{Settings.Default.GitRepositoryFolder}\\{Settings.Default.InfrastructureServicesInterfacesFolder.Replace(Settings.Default.GitRepositoryFolder, "")}\\I{tstxtbClassName.Text}SaveService.cs";
                fctxtbSaveServiceInterface.SaveToFile(path, Encoding.ASCII);
                MessageBox.Show($"{path} has been saved", "File Saved", MessageBoxButtons.OK);
            }
        }

        private void SaveDeleteService()
        {
            if (string.IsNullOrEmpty(Settings.Default.InfrastructureServicesFolder) || string.IsNullOrEmpty(Settings.Default.InfrastructureServicesInterfacesFolder))
            {
                MessageBox.Show("Please select the folder where the file needs to be saved", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(Settings.Default.GitRepositoryFolder))
            {
                MessageBox.Show("Please configure the GIT Repository folder.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(Settings.Default.GitRepositoryFolder))
            {
                string path;
                if (string.IsNullOrEmpty(Settings.Default.GitRepositoryFolder))
                    path = Path.Combine(Settings.Default.InfrastructureServicesFolder, $"{tstxtbClassName.Text}DeleteService.cs");
                else
                    path = $"{Settings.Default.GitRepositoryFolder}{Settings.Default.InfrastructureServicesFolder.Replace(Settings.Default.GitRepositoryFolder, "")}\\{tstxtbClassName.Text}DeleteService.cs";
                fctxtbDeleteServiceClass.SaveToFile(path, Encoding.ASCII);

                if (string.IsNullOrEmpty(Settings.Default.GitRepositoryFolder))
                    path = Path.Combine(Settings.Default.InfrastructureServicesInterfacesFolder, $"I{tstxtbClassName.Text}DeleteService.cs");
                else
                    path = $"{Settings.Default.GitRepositoryFolder}\\{Settings.Default.InfrastructureServicesInterfacesFolder.Replace(Settings.Default.GitRepositoryFolder, "")}\\I{tstxtbClassName.Text}DeleteService.cs";
                fctxtbDeleteServiceInterface.SaveToFile(path, Encoding.ASCII);
                MessageBox.Show($"{path} has been saved", "File Saved", MessageBoxButtons.OK);
            }
        }

        private void SaveQueryUnitTest()
        {

        }

        private void SaveQuery()
        {
            if (string.IsNullOrEmpty(tstxtbQueryFilePath.Text))
            {
                MessageBox.Show("Please select the folder where the file needs to be saved", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string path;
            if (string.IsNullOrEmpty(Settings.Default.GitRepositoryFolder))
                path = Path.Combine(Settings.Default.InfrastructureServicesQueryFolder, $"{tstxtbClassName.Text}Query.cs");
            else
                path = $"{Settings.Default.GitRepositoryFolder}\\{Settings.Default.InfrastructureServicesQueryFolder.Replace(Settings.Default.GitRepositoryFolder, "")}\\{tstxtbClassName.Text}Query.cs";
            fctxtbQuery.SaveToFile(path, Encoding.ASCII);
            MessageBox.Show($"{path} has been saved", "File Saved", MessageBoxButtons.OK);
        }

        private void tstxtbPostSQLSnippet_Leave(object sender, EventArgs e)
        {
            Settings.Default.PostSQLSnippet = tstxtbPostSQLSnippet.Text;
            Settings.Default.Save();
        }

        private void openConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //let the user select the connection string
            MultiValueInputDialog dialog = new MultiValueInputDialog();
            Field inputField = new Field
            {
                Caption = "Connection",
                SelectValue = true,
                Items = ConfigurationManager.ConnectionStrings,
                DisplayMember = "name",
                InputType = SEFI.UserControls.InputType.String
            };
            dialog.Fields.Add(inputField);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //set the connection string
                ConnectionString = (dialog.Fields[0].Value as ConnectionStringSettings).ConnectionString;
            }
        }
    }
}
