using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

using SEFI.Models;
using SEFI.Mappings;
using SEFI.Queries;
using SEFI.DataUtilities;
namespace SEFI.Services
{
	public class DatabaseDeleteService : DatabaseCommandService, IDatabaseDeleteService
	{
		public virtual async Task<Response> DeleteAsync<T>(ObjectPropertyMap<T> mapping
			, IDbConnection connection
			, CancellationToken token
			, T source = default
			, IQuery query = null
			, string preScript = null
			, string postScript = null
			, Response response = null)
		{
			if (response != null)
				return response;

			Response resp = new Response();

			int recordsAffected = 0;
			await Task.Run(() =>
			{
				recordsAffected = (int)SQLServer.DeleteData(connection, mapping, source, query.Filters, preScript, postScript);
			});

			resp.DataID = $"{recordsAffected} records deleted";
			resp.StatusCode = recordsAffected > 0 ? "204" : "507";
			resp.StatusDescription = recordsAffected > 0 ? "Success" : "Fail";
			return resp;
		}

		public virtual Response Delete<T>(ObjectPropertyMap<T> mapping
			, IDbConnection connection
			, T source = default
			, IQuery query = null
			, string preScript = null
			, string postScript = null
			, Response response = null)
		{
			if (response != null)
				return response;

			Response resp = new Response();

			int recordsAffected = 0;
			recordsAffected = (int)SQLServer.DeleteData(connection, mapping, source, query.Filters, preScript, postScript);

			resp.DataID = $"{recordsAffected} records deleted";
			resp.StatusCode = recordsAffected > 0 ? "204" : "507";
			resp.StatusDescription = recordsAffected > 0 ? "Success" : "Fail";
			return resp;
		}
	}
}