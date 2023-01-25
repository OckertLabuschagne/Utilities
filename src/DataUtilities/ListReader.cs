using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
namespace SEFI.Infrastructure.Common.DataUtilities
{
	/// <summary>
	/// This class provide a data reader functionality for an Enumerable object
	/// </summary>
	/// <typeparam name="T">The type of the elements of the enumerable objects</typeparam>
	public class ListReader<T> : IDataReader
	{
		List<T> _List;
		Type _ItemType;
		int _CurrentRow = -1;
		T _CurrentValue;
		Dictionary<int, string> _Fields = new Dictionary<int, string>();
		Dictionary<int, PropertyInfo> _Properties = new Dictionary<int, PropertyInfo>();
		public ListReader(IEnumerable<T> list)
		{
			_List = list.ToList();
			_ItemType = list.GetType().GetGenericArguments().First();
			PropertyInfo[] properties = _ItemType.GetProperties();
			for (int i = 0; i < properties.Length; i++)
			{
				_Fields.Add(i, properties[i].Name);
				_Properties.Add(i, properties[i]);
			}
		}
		public object this[int i] => _CurrentValue != null ? _Properties[i].GetValue(_CurrentValue, null) : throw new NullReferenceException();

		public object this[string name] => _CurrentValue != null ? _ItemType.GetProperty(name)?.GetValue(_CurrentValue, null) ?? throw new InvalidProgramException() : throw new NullReferenceException();

		public int Depth => 1;

		public bool IsClosed => false;

		public int RecordsAffected => 0;

		public int FieldCount => _Fields.Count;

		public void Close()
		{
			
		}

		public void Dispose()
		{
		}

		public bool GetBoolean(int i)
		{
			if (!_Properties.ContainsKey(i))
				throw new IndexOutOfRangeException();
			if (_Properties[i].PropertyType == typeof(bool))
			{
				object retVal = _CurrentValue != null ? _Properties[i].GetValue(_CurrentValue, null) : throw new NullReferenceException();
				if (retVal != null)
					return (bool)retVal;
				else
					throw new InvalidCastException();
			}
			else
				throw new InvalidCastException();
		}

		public byte GetByte(int i)
		{
			throw new NotImplementedException();
		}

		public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
		{
			throw new NotImplementedException();
		}

		public char GetChar(int i)
		{
			if (!_Properties.ContainsKey(i))
				throw new IndexOutOfRangeException();
			if (_Properties[i].PropertyType == typeof(char))
			{
				object retVal = _CurrentValue != null ? _Properties[i].GetValue(_CurrentValue, null) : throw new NullReferenceException();
				if (retVal != null)
					return (char)retVal;
				else
					throw new InvalidCastException();
			}
			else
				throw new InvalidCastException();
		}

		public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
		{
			throw new NotImplementedException();
		}

		public IDataReader GetData(int i)
		{
			throw new NotImplementedException();
		}

		public string GetDataTypeName(int i)
		{
			return _Properties[i].PropertyType.FullName;
		}

		public DateTime GetDateTime(int i)
		{
			if (!_Properties.ContainsKey(i))
				throw new IndexOutOfRangeException();
			if (_Properties[i].PropertyType == typeof(DateTime))
			{
				object retVal = _CurrentValue != null ? _Properties[i].GetValue(_CurrentValue, null) : throw new NullReferenceException();
				if (retVal != null)
					return (DateTime)retVal;
				else
					throw new InvalidCastException();
			}
			else
				throw new InvalidCastException();
		}

		public decimal GetDecimal(int i)
		{
			if (!_Properties.ContainsKey(i))
				throw new IndexOutOfRangeException();
			if (_Properties[i].PropertyType == typeof(decimal))
			{
				object retVal = _CurrentValue != null ? _Properties[i].GetValue(_CurrentValue, null) : throw new NullReferenceException();
				if (retVal != null)
					return (decimal)retVal;
				else
					throw new InvalidCastException();
			}
			else
				throw new InvalidCastException();
		}

		public double GetDouble(int i)
		{
			if (!_Properties.ContainsKey(i))
				throw new IndexOutOfRangeException();
			if (_Properties[i].PropertyType == typeof(double))
			{
				object retVal = _CurrentValue != null ? _Properties[i].GetValue(_CurrentValue, null) : throw new NullReferenceException();
				if (retVal != null)
					return (double)retVal;
				else
					throw new InvalidCastException();
			}
			else
				throw new InvalidCastException();
		}

		public Type GetFieldType(int i)
		{
			throw new NotImplementedException();
		}

		public float GetFloat(int i)
		{
			if (!_Properties.ContainsKey(i))
				throw new IndexOutOfRangeException();
			if (_Properties[i].PropertyType == typeof(float))
			{
				object retVal = _CurrentValue != null ? _Properties[i].GetValue(_CurrentValue, null) : throw new NullReferenceException();
				if (retVal != null)
					return (float)retVal;
				else
					throw new InvalidCastException();
			}
			else
				throw new InvalidCastException();
		}

		public Guid GetGuid(int i)
		{
			if (!_Properties.ContainsKey(i))
				throw new IndexOutOfRangeException();
			if (_Properties[i].PropertyType == typeof(Guid))
			{
				object retVal = _CurrentValue != null ? _Properties[i].GetValue(_CurrentValue, null) : throw new NullReferenceException();
				if (retVal != null)
					return (Guid)retVal;
				else
					throw new InvalidCastException();
			}
			else
				throw new InvalidCastException();
		}

		public short GetInt16(int i)
		{
			if (!_Properties.ContainsKey(i))
				throw new IndexOutOfRangeException();
			if (_Properties[i].PropertyType == typeof(short))
			{
				object retVal = _CurrentValue != null ? _Properties[i].GetValue(_CurrentValue, null) : throw new NullReferenceException();
				if (retVal != null)
					return (short)retVal;
				else
					throw new InvalidCastException();
			}
			else
				throw new InvalidCastException();
		}

		public int GetInt32(int i)
		{
			if (!_Properties.ContainsKey(i))
				throw new IndexOutOfRangeException();
			if (_Properties[i].PropertyType == typeof(int))
			{
				object retVal = _CurrentValue != null ? _Properties[i].GetValue(_CurrentValue, null) : throw new NullReferenceException();
				if (retVal != null)
					return (int)retVal;
				else
					throw new InvalidCastException();
			}
			else
				throw new InvalidCastException();
		}

		public long GetInt64(int i)
		{
			if (_Properties[i].PropertyType == typeof(long))
			{
				if (!_Properties.ContainsKey(i))
					throw new IndexOutOfRangeException();
				object retVal = _CurrentValue != null ? _Properties[i].GetValue(_CurrentValue, null) : throw new NullReferenceException();
				if (retVal != null)
					return (long)retVal;
				else
					throw new InvalidCastException();
			}
			else
				throw new InvalidCastException();
		}

		public string GetName(int i)
		{
			return _Fields[i];
		}

		public int GetOrdinal(string name)
		{
			List<KeyValuePair<int, string>> result = _Fields.Where(k => k.Value == name).ToList();
			if (result.Any())
				return result.First().Key;
			return -1;
		}

		public DataTable GetSchemaTable()
		{
			throw new NotImplementedException();
		}

		public string GetString(int i)
		{
			if (!_Properties.ContainsKey(i))
				throw new IndexOutOfRangeException();
			if (_Properties[i].PropertyType == typeof(string))
			{
				object retVal = _CurrentValue != null ? _Properties[i].GetValue(_CurrentValue, null) : throw new NullReferenceException();
				if (retVal != null)
					return (string)retVal;
				else
					throw new InvalidCastException();
			}
			else
				throw new InvalidCastException();
		}

		public object GetValue(int i)
		{
			if (!_Properties.ContainsKey(i))
				throw new IndexOutOfRangeException();
			return _CurrentValue != null ? _Properties[i].GetValue(_CurrentValue, null) : throw new NullReferenceException();
		}

		public int GetValues(object[] values)
		{
			if (values.Length < _Fields.Count)
				throw new IndexOutOfRangeException();
			for (int cnt = 0; cnt < _Fields.Count; cnt++)
			{
				values[cnt] = this[cnt];
			}
			return _Fields.Count;
		}

		public bool IsDBNull(int i)
		{
			if (!_Properties.ContainsKey(i))
				throw new IndexOutOfRangeException();
			return _Properties[i].PropertyType == typeof(DBNull);
		}

		public bool NextResult()
		{
			if (_CurrentRow < _List.Count - 1)
			{
				_CurrentRow++;
				_CurrentValue = _List[_CurrentRow];
				return true;
			}
			return false;
		}

		public bool Read()
		{
			return NextResult();
		}
	}
}
