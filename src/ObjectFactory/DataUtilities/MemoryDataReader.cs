using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SEFI.DataUtilities
{
    public class MemoryDataReader : IDataReader
    {
        private List<Dictionary<int, object>> _DataStore = new List<Dictionary<int, object>>();
        private int _RowIndex = -1;
        private Dictionary<int, object> _CurrentRow => _RowIndex >= 0 && _RowIndex < _DataStore.Count  ? _DataStore[_RowIndex] : null;
        private Dictionary<string, int> _FieldNames = new Dictionary<string, int>();
        private Dictionary<string, DbType> _FieldTypes = new Dictionary<string, DbType>();
        private bool _IsClosed = true;

        public MemoryDataReader AddValues(int row, params KeyValuePair<string, object>[]  values)
        {
            if (row >= _DataStore.Count)
                _DataStore.Add(new Dictionary<int, object>());
            foreach (KeyValuePair<string, object> value in values)
            {
                if (!_FieldNames.ContainsKey(value.Key))
                    _FieldNames.Add(value.Key,_FieldNames.Count);
                SetValue(row, value.Key, value.Value);
            }
            return this;
        }

        public MemoryDataReader SetValue(int row, string fieldName, object value)
        {
            if(row < 0)
                throw new IndexOutOfRangeException($"{row} is an invalid row. Row must be between 0 and {_DataStore.Count - 1}");
            if (row >= _DataStore.Count)
                throw new IndexOutOfRangeException($"The reader does not have {row} rows");
            if (!_FieldNames.ContainsKey(fieldName))
                throw new IndexOutOfRangeException($"The reader does not have a field called {fieldName}");
            _DataStore[row][_FieldNames[fieldName]] = value;
            return this;
        }

        public MemoryDataReader AddField(string fieldName, DbType dbType)
        {
            _FieldNames.Add(fieldName, _FieldNames.Count);
            _FieldTypes.Add(fieldName, dbType);
            return this;
        }

        public object this[int i] => _CurrentRow[i];

        public object this[string name] => _CurrentRow[_FieldNames[name]];

        public int Depth => 1;

        public bool IsClosed => _IsClosed;

        public int RecordsAffected => 0;

        public int FieldCount => _FieldNames.Count;

        public void Close()
        {
            _IsClosed = true;
        }

        public void Dispose()
        {
            Close();
        }

        public bool GetBoolean(int i) => (bool)this[i];

        public byte GetByte(int i) => (byte)this[i];

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length) => 0;

        public char GetChar(int i) => (char)this[i];

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length) => 0;

        public IDataReader GetData(int i) => null;

        public string GetDataTypeName(int i) => this[i].GetType().FullName;

        public DateTime GetDateTime(int i) => (DateTime)this[i];

        public decimal GetDecimal(int i) => (decimal)this[i];

        public double GetDouble(int i) => (double)this[i];

        public Type GetFieldType(int i) => this[i].GetType();

        public float GetFloat(int i) => (float) this[i];

        public Guid GetGuid(int i) => (Guid) this[i];

        public short GetInt16(int i) => (short) this[i];

        public int GetInt32(int i) => (int) this[i];

        public long GetInt64(int i) => (long) this[i];

        public string GetName(int i) => (string) this[i];

        public int GetOrdinal(string name) => _FieldNames[name];

        public DataTable GetSchemaTable()
        {
            throw new NotImplementedException();
        }

        public string GetString(int i) => (string) this[i];

        public object GetValue(int i) => this[i];

        public int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public bool IsDBNull(int i)
        {
            throw new NotImplementedException();
        }

        public bool NextResult()
        {
            _RowIndex++;
            return _RowIndex < _DataStore.Count;
        }

        public bool Read()
        {
            _RowIndex++;
            _IsClosed = false;
            return _RowIndex < _DataStore.Count;
        }
    }
}
