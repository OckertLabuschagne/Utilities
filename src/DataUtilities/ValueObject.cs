using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;

using Newtonsoft.Json;
using SEFI.Infrastructure.Common.Enums;
using SEFI.Infrastructure.Common.Interfaces;
namespace SEFI.Infrastructure.Common
{
    public class ValueObject : IValueObject
    {
        public object Value { get; set; }
        public DbType DbType { get; set; }
        public int Size { get; set; }
        [JsonIgnore]
        public object[] Values
        {
            get
            {
                List<object> retVal = new List<object>();
                if (Value is Array)
                {
                    object[] vals = new object[(Value as Array).Length];
                    (Value as Array).CopyTo(vals, 0);
                    retVal.AddRange(vals);
                }
                else
                    retVal.Add(Value);
                return retVal.ToArray();
            }
        }

		public override int GetHashCode()
		{
			return Value.GetHashCode() + DbType.GetHashCode() + Size.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return obj.GetHashCode() == GetHashCode();
		}
	}
}
