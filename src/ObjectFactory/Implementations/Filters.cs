using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

using Newtonsoft.Json;
using SEFI.Enums;
using SEFI.Interfaces;
namespace SEFI.Classes
{
    public class Filters : Filter, IFilters
    {
        public Filters()
        {
            FilterList = new List<KeyValuePair<IFilter, LogicOperator>>();
        }

        public Filters(params KeyValuePair<IFilter, LogicOperator>[] filters)
            : this()
        {
            FilterList.AddRange(filters);
        }

		public Filters(params IFilter[] filters)
            : this()
        {
            foreach(IFilter filter in filters)
                FilterList.Add(new KeyValuePair<IFilter, LogicOperator>(filter, FilterList.Count == 0 ? LogicOperator.Empty : LogicOperator.And));
        }

        public virtual string FilterListString { get => SerializeFilterList(); set => Deserialize(value); }
        [JsonIgnore]
        public List<KeyValuePair<IFilter, LogicOperator>> FilterList { get; protected set; }
		[JsonIgnore]
		public override ComparisonOperator Operator { get => base.Operator; set => base.Operator = value; }
		public override string ValueString { get => base.ValueString; set => base.ValueString = value; }

		public override Expression<Func<T, bool>> GetExpression<T>(bool databaseFields = true)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), "x");
            Expression expression = null;
            foreach (KeyValuePair<IFilter, LogicOperator> filter in FilterList)
            {
                Expression fexpression = filter.Key.GetExpression(param, databaseFields? null : filter.Key.PropertyName ?? filter.Key.Name);
                expression = expression == null ? fexpression :
                    CombineExpressions(expression, fexpression, filter.Value);
            }
            expression = expression ?? Expression.Constant(true);
            return Expression.Lambda<Func<T, bool>>(expression, param);
        }

        private IFilters Deserialize(string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString))
                return null;

			FilterList.Clear();
			List<KeyValuePair<Filters, LogicOperator>> filterList = JsonConvert.DeserializeObject<List<KeyValuePair<Filters, LogicOperator>>>(jsonString);
            foreach(KeyValuePair<Filters, LogicOperator> filter in filterList)
            {
                if (string.IsNullOrEmpty(filter.Key.FilterListString.Trim('[',']')))
                {
                    FilterList.Add(new KeyValuePair<IFilter, LogicOperator>(new Filter(filter.Key), filter.Value));
                }
                else
                    FilterList.Add(new KeyValuePair<IFilter, LogicOperator>(filter.Key, filter.Value));
            }
            return null;
        }

        protected string SerializeFilterList()
        {
            StringBuilder retVal = new StringBuilder();
            retVal.Append("[");
            bool isFirst = true;
            foreach (KeyValuePair<IFilter, LogicOperator> filter in FilterList)
            {
                if (isFirst)
                    isFirst = false;
                else
                    retVal.Append(",");
                retVal.Append($"{{\"Key\":{JsonConvert.SerializeObject(filter.Key, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })},\"Value\":{(int)filter.Value}}}");
            }
            retVal.Append("]");
            return retVal.ToString();
        }

		public override int GetHashCode()
		{
			return FilterListString.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return obj.GetHashCode() == GetHashCode();
		}
	}
}
