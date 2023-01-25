using System.Collections.Generic;

namespace SEFI.Interfaces
{
	public interface IConnectionStrings
	{
		string DefaultConnection { get; set; }
		string TRXDefaultConnection { get; set; }
		string TRNDefaultConnection { get; set; }
		string DocumentConnection { get; set; }
		string TRXDocumentConnection { get; set; }
		string TRNDocumentConnection { get; set; }
		string ServerInstanceKey { get; set; }
		string Tenant { get; set; }
	}
}
