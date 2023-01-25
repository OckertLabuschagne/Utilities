using System.Data;

namespace SEFI.Infrastructure.Common.Interfaces
{
	public interface IValueObject
	{
		object Value { get; set; }
		DbType DbType { get; set; }
		int Size { get; set; }
		object[] Values { get; }
	}
}
