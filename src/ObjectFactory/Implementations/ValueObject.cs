using System;
using System.Collections.Generic;
using System.Data;

using Newtonsoft.Json;

using SEFI.Interfaces;
namespace SEFI.Classes
{
    public class ValueObject : IValueObject
    {
        public object Value { get; set; }
        public SqlDbType? SqlDbType { get; set; }
        public DbType? DbType { get; set; }
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

		[JsonIgnore]
		public string[] ValuesStrings
		{
			get
			{
				List<string> retVal = new List<string>();
				foreach(object value in Values)
				{
                    retVal.Add(value.ToString());
				}
				return retVal.ToArray();
			}
		}

		public override int GetHashCode()
		{
            int retval = 0;
            foreach (string val in ValuesStrings)
                retval += val.GetHashCode();
			return retval + DbType.GetHashCode() + Size.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return obj.GetHashCode() == GetHashCode();
		}

        public IValueObject HasDbType(DbType dbType)
        {
            DbType = dbType;
            return this; ;
        }

        public IValueObject HasSize(int size)
        {
            Size = size;
            return this;
        }

        public IValueObject HasValue(object value)
        {
            if (Value == null)
                Value = value;
            else if(Value is Array)
            {
                List<object> vals = new List<object>(Values);
                vals.Add(value);
                Value = vals.ToArray();
            }
            else
            {
                Value = new object[] { Value, value };
            }
            return this;
        }
    }
}
