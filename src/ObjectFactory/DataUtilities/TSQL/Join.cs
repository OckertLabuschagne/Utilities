using System.Collections.Generic;
using System.Text;

using ie = SEFI.Enums;
namespace SEFI.DataUtilities.TSQL
{
    public class Join : IStatement
    {
        public StatementType StatementType { get => StatementType.Query; }
        public ObjectName LeftObjectName { get; set; }
        public ObjectName RightObjectName { get; set; }

        public List<JoinField> JoinFields { get; set; }
        public ie.SQLJoinTypes JoinType { get; set; }

        public override string ToString()
        {
            string joinText;
            switch(JoinType)
            {
                case ie.SQLJoinTypes.INNER:
                    joinText = "INNER JOIN";
                    break;
                default:
                    joinText = $"{JoinType} OUTER JOIN";
                    break;
            }

            return $"{joinText} ON {JoinFieldsString}";
        }

        string JoinFieldsString
        {
            get
            {
                StringBuilder retVal = new StringBuilder();
                bool isFirst = true;
                foreach(JoinField field in JoinFields)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        retVal.Append($" {field.LogicOperator} ");
                    retVal.Append(field);
                }
                return retVal.ToString();
            }
        }

        public Join HasTableName(string tableName)
        {
            RightObjectName = new ObjectName
            {
                Name = tableName
            };
            return this;
        }

        public Join HasJoinFields(string fieldName,  string foreignFieldName, ie.ComparisonOperator op = ie.ComparisonOperator.Equal)
        {
            if (JoinFields == null)
                JoinFields = new List<JoinField>();
            JoinFields.Add(new JoinField
            {
                FieldName = new Field
                {
                    ColumnName = fieldName,
                    SourceObjectName = LeftObjectName
                },
                ForeignFieldName = new Field
                {
                    ColumnName = foreignFieldName,
                    SourceObjectName = RightObjectName
                },
                Operator = op
            });
            return this;
        }

        public Join HasJoinFields(Field fieldName, Field foreignFieldName, ie.ComparisonOperator op = ie.ComparisonOperator.Equal)
        {
            if (JoinFields == null)
                JoinFields = new List<JoinField>();
            JoinFields.Add(new JoinField
            {
                FieldName = fieldName,
                ForeignFieldName = foreignFieldName,
                Operator = op
            });
            LeftObjectName = fieldName.SourceObjectName;
            RightObjectName = foreignFieldName.SourceObjectName;
            return this;
        }

        public Join HasJoinFields(string fieldName, Field foreignFieldName, ie.ComparisonOperator op = ie.ComparisonOperator.Equal)
        {
            if (JoinFields == null)
                JoinFields = new List<JoinField>();
            JoinFields.Add(new JoinField
            {
                FieldName = new Field
                {
                    ColumnName = fieldName,
                    SourceObjectName = LeftObjectName
                },
                ForeignFieldName = foreignFieldName,
                Operator = op
            });
            RightObjectName = foreignFieldName.SourceObjectName;
            return this;
        }

        public Join HasJoinType(ie.SQLJoinTypes joinType)
        {
            JoinType = joinType;
            return this;
        }
    }
}
