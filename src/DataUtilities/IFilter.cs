using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

using SEFI.Infrastructure.Common.Enums;
namespace SEFI.Infrastructure.Common.Interfaces
{
    public interface IFilter
    {
        string Name { get; set; }
        string FieldName { get; set; }
        ComparisonOperator Operator { get; set; }
        IValueObject Value { get; set; }
		string ValueString { get; set; }
		Expression<Func<T, bool>> GetExpression<T>();
        Expression GetExpression(ParameterExpression param, string propertyName = null);
    }
}
