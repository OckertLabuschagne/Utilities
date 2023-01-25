using System.Data;

namespace SEFI.Interfaces
{
	public interface IValueObject
	{
		object Value { get; set; }
		SqlDbType? SqlDbType { get; set; }
		DbType? DbType { get; set; }
		int Size { get; set; }
		object[] Values { get; }
        IValueObject HasDbType(DbType dbType);
        IValueObject HasSize(int size);
        IValueObject HasValue(object value);
    }
}
