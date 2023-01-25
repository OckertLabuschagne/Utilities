using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

using Newtonsoft.Json;
using SEFI.Infrastructure.Common.Enums;
using SEFI.Infrastructure.Common.Interfaces;
namespace SEFI.Infrastructure.Common
{
    public class Filter : IFilter
    {
        public Filter() { }
        public Filter(Filters filters)
        {
            Name = filters.Name;
            FieldName = filters.FieldName;
            Operator = filters.Operator;
            Value = filters.Value;
        }
        public string Name { get; set; }
        public string FieldName { get; set; }
		public virtual ComparisonOperator Operator { get; set; }
		[JsonIgnore]
		public IValueObject Value { get; set; } = null;
		public virtual string ValueString { get => SerializeValue(Value); set => DeserializeValue(value); }

		public static Filter Parse(string value)
		{
			Regex expression = new Regex("\\(*(?'field'[0-9a-zA-Z_]+)[ \\t]+(?'operator'[=<>BEWLKNOTISUbnotisulkew ]*)[ \\t]*(?'value'.+)");
			Match match = expression.Match(value);
			if (match.Success)
			{
				string fieldName = match.Groups["field"].Value.Trim();
				ComparisonOperator op = ParseOperator(match.Groups["operator"].Value);
				return new Filter
				{
					Name = $"By {fieldName}",
					FieldName = fieldName,
					Operator = op,
					Value = new ValueObject
					{
						Value = match.Groups["field"].Value
					}
				};
			}
			return null;
		}

		private static ComparisonOperator ParseOperator(string value)
		{
			switch (value.Trim().ToUpper())
			{
				case "=":
					return ComparisonOperator.Equal;
				case "<":
					return ComparisonOperator.SmallerThan;
				case "<=":
					return ComparisonOperator.SmallerThanOrEqual;
				case ">":
					return ComparisonOperator.GreaterThan;
				case ">=":
					return ComparisonOperator.GreaterThanOrEqual;
				case "IS NULL":
					return ComparisonOperator.IsNull;
				case "IS NOT NULL":
					return ComparisonOperator.IsNotNull;
				case "LIKE":
					return ComparisonOperator.Like;
				case "IN":
					return ComparisonOperator.In;
				case "BETWEEN":
					return ComparisonOperator.Between;
				default:
					throw new InvalidCastException($"{value} is not a valid operator");
			}
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode() + FieldName.GetHashCode() + Operator.GetHashCode() + Value?.GetHashCode() ?? 0;
		}

		public override bool Equals(object obj)
		{
			return obj.GetHashCode() == GetHashCode();
		}

		public virtual Expression<Func<T, bool>> GetExpression<T>()
        {
            ParameterExpression param = Expression.Parameter(typeof(T), "x");
            Expression expression = GetExpression(param);
            expression = expression ?? Expression.Constant(true);
            return Expression.Lambda<Func<T, bool>>(expression, param);
        }

        public Expression GetExpression(ParameterExpression param, string propertyName = null)
        {
            Expression resultExpr = null;
            string memberName = propertyName ?? FieldName;
            Expression member = GetMemberExpression(param, memberName);
            Expression constant = GetConstantExpression(member, Value.Values.Length > 0 ? Value.Values[0] : null);
            Expression constant2 = GetConstantExpression(member, Value.Values.Length > 1 ? Value.Values[1] : null);

            if (Nullable.GetUnderlyingType(member.Type) != null && Value != null)
            {
                resultExpr = Expression.Property(member, "HasValue");
                member = Expression.Property(member, "Value");
            }

            var safeStringExpression = GetSafeStringExpression(member, Operator, constant, constant2);
            resultExpr = resultExpr != null ? Expression.AndAlso(resultExpr, safeStringExpression) : safeStringExpression;
            resultExpr = GetSafePropertyMember(param, memberName, resultExpr);

            if ((Operator == ComparisonOperator.IsNull || Operator == ComparisonOperator.IsNullOrWhiteSpace) && memberName.Contains("."))
            {
                resultExpr = Expression.OrElse(CheckIfParentIsNull(param, member, memberName), resultExpr);
            }

            return resultExpr;
        }

		private void DeserializeValue(string valueString)
		{
			if (string.IsNullOrEmpty(valueString))
				Value = null;
			else
				Value = JsonConvert.DeserializeObject<ValueObject>(valueString);
		}

		private string SerializeValue(IValueObject value)
		{
			if (value == null)
				return null;
			return JsonConvert.SerializeObject(value, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
		}

		private Expression GetMemberExpression(Expression param, string propertyName)
        {
            if (propertyName.Contains("."))
            {
                int index = propertyName.IndexOf(".");
                var subParam = Expression.Property(param, propertyName.Substring(0, index));
                return GetMemberExpression(subParam, propertyName.Substring(index + 1));
            }

            return Expression.Property(param, propertyName);
        }
		
        private Expression GetSafeStringExpression(Expression member, ComparisonOperator operation, Expression constant, Expression constant2)
        {
            if (member.Type != typeof(string))
            {
                return Expressions[operation].Invoke(member, constant, constant2);
            }

            Expression newMember = member;

            if (operation != ComparisonOperator.IsNullOrWhiteSpace && operation != ComparisonOperator.IsNotNullNorWhiteSpace)
            {
                var trimMemberCall = Expression.Call(member, TrimMethod);
                newMember = Expression.Call(trimMemberCall, ToLowerMethod);
            }

            Expression resultExpr = operation != ComparisonOperator.IsNull ?
                                    Expressions[operation].Invoke(newMember, constant, constant2) :
                                    Expressions[operation].Invoke(member, constant, constant2);

            if (member.Type == typeof(string) && operation != ComparisonOperator.IsNull)
            {
                if (operation != ComparisonOperator.IsNullOrWhiteSpace && operation != ComparisonOperator.IsNotNullNorWhiteSpace)
                {
                    Expression memberIsNotNull = Expression.NotEqual(member, Expression.Constant(null));
                    resultExpr = Expression.AndAlso(memberIsNotNull, resultExpr);
                }
            }

            return resultExpr;
        }

        private Dictionary<ComparisonOperator, Func<Expression, Expression, Expression, Expression>> _Expressions;

        private Dictionary<ComparisonOperator, Func<Expression, Expression, Expression, Expression>> Expressions { get => GetOperatorExpression(); }

        internal Dictionary<ComparisonOperator, Func<Expression, Expression, Expression, Expression>> GetOperatorExpression()
        {
            if (_Expressions == null)
                _Expressions = new Dictionary<ComparisonOperator, Func<Expression, Expression, Expression, Expression>>
                {
                    { ComparisonOperator.Equal, (member, constant, constant2) => Expression.Equal(member, constant) },
                    { ComparisonOperator.NotEqual, (member, constant, constant2) => Expression.NotEqual(member, constant) },
                    { ComparisonOperator.GreaterThan, (member, constant, constant2) => Expression.GreaterThan(member, constant) },
                    { ComparisonOperator.GreaterThanOrEqual, (member, constant, constant2) => Expression.GreaterThanOrEqual(member, constant) },
                    { ComparisonOperator.SmallerThan, (member, constant, constant2) => Expression.LessThan(member, constant) },
                    { ComparisonOperator.SmallerThanOrEqual, (member, constant, constant2) => Expression.LessThanOrEqual(member, constant) },
                    { ComparisonOperator.Contains, (member, constant, constant2) => Contains(member, constant) },
                    { ComparisonOperator.StartsWith, (member, constant, constant2) => Expression.Call(member, StartsWithMethod, constant) },
                    { ComparisonOperator.EndsWith, (member, constant, constant2) => Expression.Call(member, EndsWithMethod, constant) },
                    { ComparisonOperator.Between, (member, constant, constant2) => Between(member, constant, constant2) },
                    { ComparisonOperator.In, (member, constant, constant2) => Contains(member, constant) },
                    { ComparisonOperator.IsNull, (member, constant, constant2) => Expression.Equal(member, Expression.Constant(null)) },
                    { ComparisonOperator.IsNotNull, (member, constant, constant2) => Expression.NotEqual(member, Expression.Constant(null)) },
                    { ComparisonOperator.IsEmpty, (member, constant, constant2) => Expression.Equal(member, Expression.Constant(String.Empty)) },
                    { ComparisonOperator.IsNotEmpty, (member, constant, constant2) => Expression.NotEqual(member, Expression.Constant(String.Empty)) },
                    { ComparisonOperator.IsNullOrWhiteSpace, (member, constant, constant2) => IsNullOrWhiteSpace(member) },
                    { ComparisonOperator.IsNotNullNorWhiteSpace, (member, constant, constant2) => IsNotNullNorWhiteSpace(member) }
                };
            return _Expressions;
        }

        public Expression GetSafePropertyMember(ParameterExpression param, String memberName, Expression expr)
        {
            if (!memberName.Contains("."))
            {
                return expr;
            }

            string parentName = memberName.Substring(0, memberName.IndexOf("."));
            Expression parentMember = GetMemberExpression(param, parentName);
            return Expression.AndAlso(Expression.NotEqual(parentMember, Expression.Constant(null)), expr);
        }

        private Expression CheckIfParentIsNull(Expression param, Expression member, string memberName)
        {
            string parentName = memberName.Substring(0, memberName.IndexOf("."));
            Expression parentMember = GetMemberExpression(param, parentName);
            return Expression.Equal(parentMember, Expression.Constant(null));
        }

        private Expression GetConstantExpression(Expression member, object value)
        {
            if (value == null) return null;

            Expression constant = Expression.Constant(value);

            if (value is string)
            {
                var trimConstantCall = Expression.Call(constant, TrimMethod);
                constant = Expression.Call(trimConstantCall, ToLowerMethod);
            }

            return constant;
        }

        protected readonly MethodInfo TrimMethod = typeof(string).GetMethod("Trim", new Type[0]);

        protected readonly MethodInfo ToLowerMethod = typeof(string).GetMethod("ToLower", new Type[0]);

        protected readonly MethodInfo StringContainsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });

        protected readonly MethodInfo StartsWithMethod = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });

        protected readonly MethodInfo EndsWithMethod = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });

        private Expression Contains(Expression member, Expression expression)
        {
            MethodCallExpression contains = null;
            if (expression is ConstantExpression constant && constant.Value is IList && constant.Value.GetType().IsGenericType)
            {
                var type = constant.Value.GetType();
                var containsInfo = type.GetMethod("Contains", new[] { type.GetGenericArguments()[0] });
                contains = Expression.Call(constant, containsInfo, member);
            }

            return contains ?? Expression.Call(member, StringContainsMethod, expression); ;
        }

        private Expression Between(Expression member, Expression constant, Expression constant2)
        {
            var left = Expressions[ComparisonOperator.GreaterThanOrEqual].Invoke(member, constant, null);
            var right = Expressions[ComparisonOperator.SmallerThanOrEqual].Invoke(member, constant2, null);

            return CombineExpressions(left, right, LogicOperator.And);
        }

        private Expression IsNullOrWhiteSpace(Expression member)
        {
            Expression exprNull = Expression.Constant(null);
            var trimMemberCall = Expression.Call(member, TrimMethod);
            Expression exprEmpty = Expression.Constant(string.Empty);
            return Expression.OrElse(
                                    Expression.Equal(member, exprNull),
                                    Expression.Equal(trimMemberCall, exprEmpty));
        }

        private Expression IsNotNullNorWhiteSpace(Expression member)
        {
            Expression exprNull = Expression.Constant(null);
            var trimMemberCall = Expression.Call(member, TrimMethod);
            Expression exprEmpty = Expression.Constant(string.Empty);
            return Expression.AndAlso(
                                    Expression.NotEqual(member, exprNull),
                                    Expression.NotEqual(trimMemberCall, exprEmpty));
        }

        protected Expression CombineExpressions(Expression expr1, Expression expr2, LogicOperator connector)
        {
            return connector == LogicOperator.And ? Expression.AndAlso(expr1, expr2) : Expression.OrElse(expr1, expr2);
        }
    }
}
