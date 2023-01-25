using System;
using System.Collections.Generic;
using System.Text;

using SEFI.Enums;
namespace SEFI.DataUtilities.TSQL
{
	public class JoinField
	{
		public Field FieldName { get; set; }
		public Field ForeignFieldName { get; set; }
        public object Value { get; set; }
        public ComparisonOperator Operator { get; set; }
        public LogicOperator? LogicOperator { get; set; }

        public override string ToString()
        {
            switch (Operator)
            {
                case ComparisonOperator.IsNull:
                    return $"{FieldName} IS NULL";
                case ComparisonOperator.IsNotNull:
                    return $"{FieldName} IS NOT";
                case ComparisonOperator.Equal:
                    return Value == null ? $"{FieldName} = {ForeignFieldName}" : $"{FieldName} = {Value}";
                case ComparisonOperator.NotEqual:
                    return Value == null ? $"{FieldName} <> {ForeignFieldName}" : $"{FieldName} = {Value}";
                case ComparisonOperator.GreaterThan:
                    return Value == null ? $"{FieldName} > {ForeignFieldName}" : $"{FieldName} = {Value}";
                case ComparisonOperator.GreaterThanOrEqual:
                    return Value == null ? $"{FieldName} >= {ForeignFieldName}" : $"{FieldName} = {Value}";
                case ComparisonOperator.SmallerThan:
                    return Value == null ? $"{FieldName} < {ForeignFieldName}" : $"{FieldName} = {Value}";
                case ComparisonOperator.SmallerThanOrEqual:
                    return Value == null ? $"{FieldName} <= {ForeignFieldName}" : $"{FieldName} = {Value}";
                default:
                    return string.Empty;
            }
        }

        public override int GetHashCode()
        {
            return FieldName?.GetHashCode() ?? 0 + ForeignFieldName?.GetHashCode() ?? 0;
        }

        public override bool Equals(object obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }
    }
}
