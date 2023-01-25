using SEFI.Extensions;
using SEFI.Interfaces;

namespace SEFI.Classes
{
	public sealed class ConnectionStrings :  IConnectionStrings
	{
		string _DefaultConnection;
		string _DocumentConnection;

		public string TRXDefaultConnection { get; set; }
		public string TRNDefaultConnection { get; set; }
		public string TRXDocumentConnection { get; set; }
		public string TRNDocumentConnection { get; set; }
		public string DefaultConnection { 
			get => GetDefaultConnectionString(); 
			set => _DefaultConnection = value; 
		}
		public string DocumentConnection { 
			get => GetDocumentConnectionString(); 
			set => _DocumentConnection = value; 
		}
		public string ServerInstanceKey { get; set; }
		public  string Tenant { get; set; }

		string GetDefaultConnectionString()
		{
			switch(ServerInstanceKey)
			{
				case "TRX":
					return Tenant != null ?  TRXDefaultConnection?.DoFormat(Tenant) : TRXDefaultConnection;
				case "TRN":
					return Tenant != null ? TRNDefaultConnection?.DoFormat(Tenant) : TRNDefaultConnection;
				default:
					return Tenant != null ? _DefaultConnection?.DoFormat(Tenant) : _DefaultConnection;
			}
		}

		string GetDocumentConnectionString()
		{
			switch (ServerInstanceKey)
			{
				case "TRX":
					return Tenant != null ? TRXDocumentConnection?.DoFormat(Tenant) : TRXDocumentConnection;
				case "TRN":
					return Tenant != null ? TRNDocumentConnection?.DoFormat(Tenant) : TRNDocumentConnection;
				default:
					return Tenant != null ? _DocumentConnection?.DoFormat(Tenant) : _DocumentConnection;
			}
		}
	}
}
