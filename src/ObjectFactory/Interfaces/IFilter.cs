using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

using SEFI.Enums;
namespace SEFI.Interfaces
{
    public interface IFilter
    {
        string Name { get; set; }
        string PropertyName { get; set; }
        string FieldName { get; set; }
        ComparisonOperator Operator { get; set; }
        IValueObject Value { get; set; }
		string ValueString { get; set; }
		Expression<Func<T, bool>> GetExpression<T>(bool databaseFields = true);
        Expression GetExpression(ParameterExpression param, string propertyName = null);
        IFilter HasName(string name);
        IFilter HasPropertyName(string propertyName);
        IFilter HasFieldName(string fieldName);
        IFilter HasOperator(ComparisonOperator oper);
        IFilter HasValue(IValueObject value);
    }
}
