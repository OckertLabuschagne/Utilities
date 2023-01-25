using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Reflection;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Configuration;

using CodeGenerator.Properties;
using SEFI.Infrastructure.Common.DataUtilities;
namespace CodeGenerator
{
    public class TableDefinition
    {
        public TableDefinition()
        {
            Fields = new Dictionary<string, ColumnDefinition>();
            _TypePrefixes = new Dictionary<DbType, string>();
            string[] typePrefixes = Settings.Default.TypePrefixes.Split(';');
            foreach(string prefix in typePrefixes)
            {
                string[] parts = prefix.Split('=');
                DbType type = (DbType)Enum.Parse(typeof(DbType), parts[0]);
                _TypePrefixes.Add(type, parts[1]);
            }
            _NameExpression = Settings.Default.ClassNameExpression;
        }

        public string ClassName { get; set; }
        public string TableName { get; set; }
        public Dictionary<string, ColumnDefinition> Fields { get; protected set; }

        public bool RemoveTypePrefix { get; set; } = true;

        public List<Dictionary<string, object>> MockValues { get; set; }

        string _NameExpression;
        Dictionary<DbType, string> _TypePrefixes;
        Dictionary<string, string> _Mappings;
        public void DeriveFromTable(DataTable schema)
        {
            Fields.Clear();
            string tableName = schema.Rows[0].Field<string>("TABLE_NAME");
            if (!string.IsNullOrEmpty(_NameExpression))
            {
                Match match = Regex.Match(tableName as string, _NameExpression);
                while (match.Success)
                {
                    ClassName += match.Value.Trim('_').Substring(0, 1).ToUpper() + match.Value.Trim('_').Substring(1);
                    match = match.NextMatch();
                }
            }
            foreach (DataRow row in schema.Rows)
            {
                Fields.Add(row.Field<string>("COLUMN_NAME")
                    , new ColumnDefinition
                    {
                        Type = SQLServer.GetType(row.Field<string>("DATA_TYPE")),
                        DbType = SQLServer.GetDbType(row.Field<string>("DATA_TYPE")),
                        Length = row[8] != DBNull.Value ? row.Field<int>("CHARACTER_MAXIMUM_LENGTH") : 0,
                        Included = true
                    });
            }
        }

        public void DeriveFromReader(DataTable schema)
        {

        }

        public void FillDataGridView(DataGridView dataGridView, Dictionary<string, string> Mappings)
        {
            _Mappings = Mappings;
            dataGridView.Rows.Clear();
            foreach(string field in Fields.Keys)
            {
                ColumnDefinition column = Fields[field];
                string propertyName = GetPropertyName(field, column.DbType);
                dataGridView.Rows.Add(column.Included, field, propertyName, column.IsFilterField, column.IsKeyField);
            }
        }

        public  string CreateEntity()
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace codeNamespace = new CodeNamespace(Settings.Default.InfrastructureEntityNamespace);
            codeNamespace.Imports.Add(new CodeNamespaceImport("System"));
            unit.Namespaces.Add(codeNamespace);
            CodeTypeDeclaration entity = new CodeTypeDeclaration
            {
                Name = ClassName,
                IsClass = true,
                TypeAttributes = TypeAttributes.Public
            };
            codeNamespace.Types.Add(entity);
            foreach (string field in Fields.Keys)
            {
                ColumnDefinition columnDefinition = Fields[field];
                if (columnDefinition.Included)
                {
                    if (columnDefinition != null)
                    {
                        Type type = columnDefinition.Type;
                        string typeName = type == typeof(string) ? "string" : $"{type.Name}?";
                        CodeMemberProperty property = new CodeMemberProperty
                        {
                            Name = field,
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
            return Regex.Replace(stringWriter.ToString(), pattern, "{ get; set; }")
                .Replace("System.DateTime", "DateTime")
                .Replace("@string", "string")
                .Replace("Int32", "int")
                .Replace("Decimal", "decimal")
                .Replace("Boolean", "bool");
        }

        public  string CreateMapping()
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace codeNamespace = new CodeNamespace(Settings.Default.MappingNamespace);
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Data"));
            codeNamespace.Imports.Add(new CodeNamespaceImport(Settings.Default.InfrastructureEntityNamespace));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Infrastructure.Mappings"));
            unit.Namespaces.Add(codeNamespace);

            CodeTypeDeclaration mapping = new CodeTypeDeclaration
            {
                Name = $"{ClassName}Mapping",
                IsClass = true,
                TypeAttributes = TypeAttributes.Public,
            };
            mapping.BaseTypes.Add(new CodeTypeReference($"ObjectPropertyMap<{ClassName}>"));
            codeNamespace.Types.Add(mapping);
            CodeConstructor constructor = new CodeConstructor
            {
                Attributes = MemberAttributes.Public
            };
            CodeAssignStatement setdatabaseObject = new CodeAssignStatement(new CodePropertyReferenceExpression(new CodeBaseReferenceExpression(), "DatabaseObject"), new CodePrimitiveExpression(TableName));
            constructor.Statements.Add(setdatabaseObject);
            foreach (string field in Fields.Keys)
            {
                ColumnDefinition column = Fields[field];
                if (column.Included)
                {
                    CodeMethodInvokeExpression isKeyField;
                    if (column != null)
                    {
                        DbType dbType = column.DbType;
                        string fieldName = column.FieldName?? GetPropertyName(field, column.DbType);
                        CodeMethodInvokeExpression statement = new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeBaseReferenceExpression(), "Property"), new CodeSnippetExpression($"p => p.{fieldName}"));
                        CodeMethodInvokeExpression hasField = new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(statement, "HasFieldName"), new CodePrimitiveExpression(field));
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
                                if (column.IsKeyField)
                                {
                                    isKeyField = new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(hasLength, "IsMemberOfKeyField"), new CodePrimitiveExpression(true));
                                    constructor.Statements.Add(new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(isKeyField, "MustTrimString"), new CodePrimitiveExpression(true)));
                                }
                                else
                                    constructor.Statements.Add(new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(hasLength, "MustTrimString"), new CodePrimitiveExpression(true)));
                                break;
                            default:
                                if (column.IsKeyField)
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
            return stringWriter.ToString().Replace("base.", "")
                .Replace("System.Data.", "");
        }

        public string CreateQueryClass()
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace codeNamespace = new CodeNamespace(Settings.Default.QueryNamespace);
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Data"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Queries"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("i=FI.Infrastructure"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Infrastructure.Interfaces"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Infrastructure.Enums"));
            unit.Namespaces.Add(codeNamespace);

            //Declare the type
            CodeTypeDeclaration typeDeclaration = new CodeTypeDeclaration
            {
                Name = $"{ClassName}Query",
                TypeAttributes = TypeAttributes.Public
            };
            typeDeclaration.BaseTypes.Add(new CodeTypeReference("IQuery"));
            codeNamespace.Types.Add(typeDeclaration);

            //Add properties for all the fields marked as query fields
            foreach (string field in Fields.Keys)
            {
                ColumnDefinition column = Fields[field];
                if (column.IsFilterField)
                {
                    // add a property to the class
                    if (column != null)
                    {
                        Type type = column.Type;
                        string typeName = type == typeof(string) ? "string" : $"{type.Name}?";
                        CodeMemberProperty property = new CodeMemberProperty
                        {
                            Name = column.FieldName ?? GetPropertyName(field, column.DbType),
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
                Type = new CodeTypeReference("i.Filters"),
                HasGet = true,
                HasSet = false,
                Attributes = MemberAttributes.Public
            };
            typeDeclaration.Members.Add(filterProperty);

            //Add the BuildFilter method
            CodeMemberMethod buildFilter = new CodeMemberMethod
            {
                Name = "BuildFilters",
                ReturnType = new CodeTypeReference($"i.Filters"),
                Attributes = MemberAttributes.Private
            };

            CodeMethodReferenceExpression builfFiltersRef = new CodeMethodReferenceExpression(new CodeThisReferenceExpression(), "BuildFilters");

            filterProperty.GetStatements.Add(new CodeMethodReturnStatement(new CodeMethodInvokeExpression(builfFiltersRef)));
            typeDeclaration.Members.Add(buildFilter);

            //Create statements to add and instantiate the returnValue of type Filter to the method
            CodeVariableDeclarationStatement returnValue = new CodeVariableDeclarationStatement("i.Filters", "returnValue");
            CodeVariableReferenceExpression returnValueRef = new CodeVariableReferenceExpression("returnValue");
            CodeAssignStatement innitiateReturnValue = new CodeAssignStatement(returnValueRef, new CodeObjectCreateExpression("i.Filters"));

            //Add the statements
            buildFilter.Statements.Add(returnValue);
            buildFilter.Statements.Add(innitiateReturnValue);

            //Create the return statement
            CodeMethodReturnStatement returnStatement = new CodeMethodReturnStatement(returnValueRef);
            CodePropertyReferenceExpression filterListRef = new CodePropertyReferenceExpression(returnValueRef, "i.FilterList");

            //Add filter for all the fields marked as query fields
            foreach (string field in Fields.Keys)
            {
                ColumnDefinition column = Fields[field];
                if (column.IsFilterField)
                {
                    if (column != null)
                    {
                        string propertyName = column.FieldName ?? GetPropertyName(field, column.DbType);
                        CodePropertyReferenceExpression propertyReference = new CodePropertyReferenceExpression(new CodeThisReferenceExpression(), propertyName);
                        CodeBinaryOperatorExpression isnullExpression = new CodeBinaryOperatorExpression(propertyReference, CodeBinaryOperatorType.IdentityInequality, new CodePrimitiveExpression(null));
                        CodeConditionStatement ifStatement = new CodeConditionStatement
                        {
                            Condition = isnullExpression
                        };
                        CodeVariableDeclarationStatement filter = new CodeVariableDeclarationStatement("i.Filter", "filter");
                        CodeVariableReferenceExpression filterRef = new CodeVariableReferenceExpression("filter");
                        CodeObjectCreateExpression createFilterExpression = new CodeObjectCreateExpression("i.Filter");
                        CodeAssignStatement setFilter = new CodeAssignStatement(filterRef, createFilterExpression);

                        CodePropertyReferenceExpression nameRef = new CodePropertyReferenceExpression(filterRef, "Name");
                        CodeAssignStatement setName = new CodeAssignStatement(nameRef, new CodePrimitiveExpression($"By {propertyName}"));

                        CodePropertyReferenceExpression propertyNameRef = new CodePropertyReferenceExpression(filterRef, "PropertyName");
                        CodeAssignStatement setPropertyName = new CodeAssignStatement(propertyNameRef, new CodePrimitiveExpression(propertyName));

                        CodePropertyReferenceExpression fieldNameRef = new CodePropertyReferenceExpression(filterRef, "FieldName");
                        CodeAssignStatement setFieldName = new CodeAssignStatement(fieldNameRef, new CodePrimitiveExpression(field));

                        CodePropertyReferenceExpression operatorRef = new CodePropertyReferenceExpression(filterRef, "Operator");
                        CodeAssignStatement setOperatore = new CodeAssignStatement(operatorRef, new CodeFieldReferenceExpression(new CodeTypeReferenceExpression("ComparisonOperator"), "Equal"));

                        CodeVariableDeclarationStatement value = new CodeVariableDeclarationStatement("i.ValueObject", "filterValue");
                        CodeVariableReferenceExpression valueRef = new CodeVariableReferenceExpression("filterValue");
                        CodeObjectCreateExpression createValueExpression = new CodeObjectCreateExpression("i.ValueObject");

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
            string pattern = "\r\n *{\r\n *get\r\n *\\{\r\n *\\}\r\n *set\r\n *\\{\r\n *\\}\r\n *}\r\n *";
            return Regex.Replace(stringWriter.ToString(), pattern, "{ get; set; }")
                .Replace("System.DateTime", "DateTime")
                .Replace("@string", "string")
                .Replace("Int32", "int")
                .Replace("Decimal", "decimal")
                .Replace("Boolean", "bool");
        }

        public string CreateLookupServiceClass()
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace codeNamespace = new CodeNamespace(Settings.Default.ServicesNamespace);
            codeNamespace.Imports.Add(new CodeNamespaceImport(Settings.Default.InfrastructureEntityNamespace));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Threading"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Threading.Tasks"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("Microsoft.Extensions.Configuration"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Packages.Security.Context"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Services"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Queries"));
            unit.Namespaces.Add(codeNamespace);

            //Declare the interface
            CodeTypeDeclaration typeDeclaration = new CodeTypeDeclaration
            {
                Name = $"{ClassName}LookupService",
                IsClass = true,
                TypeAttributes = TypeAttributes.Public
            };
            typeDeclaration.BaseTypes.Add($"DatabaseLookupService");
            typeDeclaration.BaseTypes.Add($"I{ClassName}LookupService");

            //Add the class to the namespace
            codeNamespace.Types.Add(typeDeclaration);

            //Add the methods to implement the interface
            CodeParameterDeclarationExpression query = new CodeParameterDeclarationExpression(new CodeTypeReference($"{ClassName}Query"), "query");
            CodeParameterDeclarationExpression token = new CodeParameterDeclarationExpression(new CodeTypeReference("CancellationToken"), "token");
            CodeParameterDeclarationExpression connection = new CodeParameterDeclarationExpression(new CodeTypeReference("IDbConnection"), "connection");
            CodeParameterDeclarationExpression cache = new CodeParameterDeclarationExpression(new CodeTypeReference("Dictionary<string,T>"), "cache");
            //Create references to the parameters
            CodeArgumentReferenceExpression queryRefference = new CodeArgumentReferenceExpression("query");
            CodeArgumentReferenceExpression connectionRefference = new CodeArgumentReferenceExpression("connection");
            CodeArgumentReferenceExpression tokenRefference = new CodeArgumentReferenceExpression("token");

            CodeTypeReference taskListValuesType = new CodeTypeReference($"async Task<List<{ClassName}>>");
            CodeTypeReference mappingType = new CodeTypeReference($"{ClassName}Mapping");

            CodeObjectCreateExpression mappingCreate = new CodeObjectCreateExpression($"{ClassName}Mapping");
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
            CodeSnippetStatement lookupAsyncReturnStatement = new CodeSnippetStatement($"\t\t\treturn await base.LookupAsync(query, new {ClassName}Mapping(), token, connection);");

            lookupAsync.Statements.Add(lookupAsyncReturnStatement);

            //Add the method to the class
            typeDeclaration.Members.Add(lookupAsync);

            CodeMemberMethod lookup = new CodeMemberMethod
            {
                Name = "Lookup",
                ReturnType = new CodeTypeReference($"List<{ClassName}>"),
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
                ReturnType = new CodeTypeReference($"async Task<{ClassName}>"),
                Attributes = MemberAttributes.Public
            };

            getAsync.Parameters.Add(query);
            getAsync.Parameters.Add(token);
            getAsync.Parameters.Add(connection);

            CodeSnippetStatement getAsyncReturnStatement = new CodeSnippetStatement($"\t\t\treturn await base.GetAsync(query, new {ClassName}Mapping(), token, connection);");

            getAsync.Statements.Add(getAsyncReturnStatement);

            typeDeclaration.Members.Add(getAsync);

            //Add the get method
            CodeMemberMethod get = new CodeMemberMethod
            {
                Name = "Get",
                ReturnType = new CodeTypeReference($"{ClassName}"),
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

            //Add the override abstract get method
            CodeMemberMethod getAsyncT = new CodeMemberMethod
            {
                Name = "GetAsync",
                ReturnType = new CodeTypeReference($"async Task<T>"),
                Attributes = MemberAttributes.Public | MemberAttributes.Override
            };

            getAsyncT.Parameters.Add(query);
            getAsyncT.Parameters.Add(token);
            getAsyncT.Parameters.Add(cache);

            CodeSnippetStatement getAsyncTReturnStatement = new CodeSnippetStatement($"\t\t\treturn await base.GetAsync<T>(query, new {ClassName}Mapping() as ObjectPropertyMap<T>, token, cache: cache);");

            getAsyncT.Statements.Add(getAsyncTReturnStatement);

            typeDeclaration.Members.Add(getAsyncT);

            //Add the override abstract get method
            CodeMemberMethod lookupAsyncT = new CodeMemberMethod
            {
                Name = "LookupAsync",
                ReturnType = new CodeTypeReference($"async Task<List<T>>"),
                Attributes = MemberAttributes.Public | MemberAttributes.Override
            };

            lookupAsyncT.Parameters.Add(query);
            lookupAsyncT.Parameters.Add(token);
            lookupAsyncT.Parameters.Add(cache);

            CodeSnippetStatement lookupAsyncTReturnStatement = new CodeSnippetStatement($"\t\t\treturn await base.LookupAsync<List<T>>(query, new {ClassName}Mapping() as ObjectPropertyMap<T>, token, cache: cache);");

            lookupAsyncT.Statements.Add(lookupAsyncTReturnStatement);

            typeDeclaration.Members.Add(lookupAsyncT);

            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            StringWriter stringWriter = new StringWriter();
            provider.GenerateCodeFromCompileUnit(unit, stringWriter, options);
            return stringWriter.ToString();
        }

        public string CreateSaveServiceInterface()
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace codeNamespace = new CodeNamespace(Settings.Default.MappingNamespace);
            codeNamespace.Imports.Add(new CodeNamespaceImport(Settings.Default.InfrastructureEntityNamespace));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Data"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Threading"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Threading.Tasks"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Services"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Models"));
            unit.Namespaces.Add(codeNamespace);

            //Declare the interface
            CodeTypeDeclaration typeDeclaration = new CodeTypeDeclaration
            {
                Name = $"I{ClassName}SaveService",
                TypeAttributes = TypeAttributes.Public,
                IsInterface = true,
            };
            typeDeclaration.BaseTypes.Add(new CodeTypeReference("IDatabaseSaveService"));
            codeNamespace.Types.Add(typeDeclaration);
            CodeParameterDeclarationExpression value = new CodeParameterDeclarationExpression(new CodeTypeReference(ClassName), "value");
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
            return stringWriter.ToString();
        }

        public string CreateMockDataReader()
        {
            if (MockValues != null)
            {
                CodeCompileUnit unit = new CodeCompileUnit();
                CodeNamespace codeNamespace = new CodeNamespace(Settings.Default.TestDataNamespace);
                codeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
                codeNamespace.Imports.Add(new CodeNamespaceImport("FI.DataUtilities"));
                unit.Namespaces.Add(codeNamespace);
                CodeTypeDeclaration typeDeclaration = new CodeTypeDeclaration
                {
                    Name = $"{ClassName}MockDatareader",
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
                foreach (Dictionary<string, object> values in MockValues)
                {
                    foreach (KeyValuePair<string, object> value in values)
                    {
                        CodeObjectCreateExpression valueExpression = null;
                        if (value.Value == null)
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
                return stringWriter.ToString();
            }
            return "";
        }

        public string CreateTestDataClasses()
        {
            if (MockValues != null)
            {
                CodeCompileUnit unit = new CodeCompileUnit();
                CodeNamespace codeNamespace = new CodeNamespace(Settings.Default.TestDataNamespace);
                codeNamespace.Imports.Add(new CodeNamespaceImport("System.Data"));
                codeNamespace.Imports.Add(new CodeNamespaceImport("System.Threading"));
                codeNamespace.Imports.Add(new CodeNamespaceImport("System.Threading.Tasks"));
                codeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
                codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Services"));
                codeNamespace.Imports.Add(new CodeNamespaceImport(Settings.Default.InfrastructureEntityNamespace));
                codeNamespace.Imports.Add(new CodeNamespaceImport(Settings.Default.QueryNamespace));
                codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Queries"));
                codeNamespace.Imports.Add(new CodeNamespaceImport("FI.Factory"));
                unit.Namespaces.Add(codeNamespace);

                /*
                public {ClassName}TestObjectFactory
                {
                    List<{ClassName}> _ObjectList
                    public {ClassName}TestObjectFactory()
                    {
                         _ObjectList = new List<{ClassName}>();
                        {ClassName}MockDatareader reader = new {ClassName}MockDatareader();
                        while (reader.Read())
                            _ObjectList.Add(ObjectFactory.CreateObject(reader, new {ClassName}Mapping()));
                    }
                    public {ClassName} GetObject(i.IFilters query)
                    {
                        return _ObjectList.Where(v = > query.Filters.GetExpression<{ClassName}>(false).Compile.Invoke(v)).FirstOrDefault();
                    }
                }
                */
                CodeTypeDeclaration typeDeclaration = new CodeTypeDeclaration
                {
                    Name = $"{ClassName}TestObjectFactory",
                    IsClass = true,
                    TypeAttributes = TypeAttributes.Public
                };

                CodeTypeConstructor constructor = new CodeTypeConstructor
                {
                    Attributes = MemberAttributes.Public
                };
                CodeThisReferenceExpression thisExpression = new CodeThisReferenceExpression();
                CodeTypeReferenceExpression objectFactoryRef = new CodeTypeReferenceExpression("ObjectFactory");
                CodeFieldReferenceExpression objectListRef = new CodeFieldReferenceExpression(thisExpression, "_ObjectList");
                CodeObjectCreateExpression createList = new CodeObjectCreateExpression($"List<{ClassName}>");
                CodeAssignStatement setList = new CodeAssignStatement(objectListRef, createList);
                CodeObjectCreateExpression createReader = new CodeObjectCreateExpression($"{ClassName}MockDatareader");
                CodeVariableDeclarationStatement readerDef = new CodeVariableDeclarationStatement($"{ClassName}MockDatareader", "reader");
                CodeVariableReferenceExpression readerRef = new CodeVariableReferenceExpression("reader");
                CodeAssignStatement setReader = new CodeAssignStatement(new CodeVariableReferenceExpression("reader"), createReader);
                CodeSnippetStatement whileRead = new CodeSnippetStatement("\t\twhile(reader.Read)");
                CodeMethodReferenceExpression addRef = new CodeMethodReferenceExpression(objectListRef, "Add");
                CodeMethodReferenceExpression createObjectRef = new CodeMethodReferenceExpression(objectFactoryRef, "CreateObject");
                CodeObjectCreateExpression newMapping = new CodeObjectCreateExpression($"{ClassName}Mapping");
                CodeMethodInvokeExpression createObject = new CodeMethodInvokeExpression(createObjectRef, readerRef, newMapping);
                CodeMethodInvokeExpression addToList = new CodeMethodInvokeExpression(addRef, createObject);

                CodeMethodReturnStatement getReturn = new CodeMethodReturnStatement(new CodeSnippetExpression($"_ObjectList.Where(v = > query.Filters.GetExpression<{ClassName}>(false).Compile.Invoke(v)).FirstOrDefault()"));
                CodeParameterDeclarationExpression filterParameter = new CodeParameterDeclarationExpression("IQuery", "query");

                CodeMemberField objectList = new CodeMemberField
                {
                    Type = new CodeTypeReference($"List<{ClassName}>"), 
                    Name = "_ObjectList",
                };

                CodeMemberMethod getObject = new CodeMemberMethod
                {
                    Name = "GetObject",
                    ReturnType = new CodeTypeReference(ClassName),
                    Attributes = MemberAttributes.Public
                };

                getObject.Parameters.Add(filterParameter);
                getObject.Statements.Add(getReturn);

                constructor.Statements.Add(setList);
                constructor.Statements.Add(readerDef);
                constructor.Statements.Add(setReader);
                constructor.Statements.Add(whileRead);
                constructor.Statements.Add(addToList);

                typeDeclaration.Members.Add(objectList);
                typeDeclaration.Members.Add(constructor);
                typeDeclaration.Members.Add(getObject);

                codeNamespace.Types.Add(typeDeclaration);

                CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
                CodeGeneratorOptions options = new CodeGeneratorOptions();
                options.BracingStyle = "C";
                StringWriter stringWriter = new StringWriter();
                provider.GenerateCodeFromCompileUnit(unit, stringWriter, options);
                return stringWriter.ToString();
            }
            else
                return "";
        }

        private string GetPropertyName(string fieldName, DbType dataType)
        {
            if (_Mappings.ContainsKey(fieldName))
                return _Mappings[fieldName];
            string retVal = fieldName;
            if (RemoveTypePrefix)
            {
                if (_TypePrefixes.ContainsKey(dataType))
                {
                    string[] possibilities = _TypePrefixes[dataType].Split(',');
                    foreach (string p in possibilities)
                        if (retVal.StartsWith(p))
                            retVal = retVal.Substring(p.Length);
                }
            }
            if (string.IsNullOrEmpty(retVal))
                return retVal;
            //Change name to Pascal case
            string[] parts = retVal.Split('_');
            retVal = "";
            foreach (string part in parts)
                retVal += part.Substring(0, 1).ToUpper() + part.Substring(1);
            return retVal;
        }
    }
}
