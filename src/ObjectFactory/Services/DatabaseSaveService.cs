using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System;

using SEFI.DataUtilities;
using SEFI.Models;
using SEFI.Mappings;
namespace SEFI.Services
{
	public abstract class DatabaseSaveService : DatabaseCommandService, IDatabaseSaveService
	{
		public virtual async Task<Response> SaveAsync<T>(T source
			, ObjectPropertyMap<T> mapping
			, IDbConnection connection
			, CancellationToken token
			, bool useDbTransaction = false
			, string preScript = null
			, bool returnIdentity = false)
		{
			Response resp = new Response();

			if (returnIdentity)
			{
				decimal identityValue = 0;
				await Task.Run(() =>
				{
					var result = SQLServer.SaveData(source, connection, mapping, useDbTransaction, preScript, postScript: "SELECT SCOPE_IDENTITY()");
					identityValue = result == DBNull.Value ? 0 : (decimal)result;
				});
				resp.DataID = $"{identityValue}";
				resp.StatusCode = identityValue > 0 ? "204" : "507";
				resp.StatusDescription = identityValue > 0 ? "Success" : "Fail";
			}
			else
			{
				int recordsAffected = 0;
				await Task.Run(() =>
				{
					recordsAffected = (int)SQLServer.SaveData(source, connection, mapping, useDbTransaction, preScript);
				});

				resp.DataID = $"{recordsAffected} records saved";
				resp.StatusCode = recordsAffected > 0 ? "204" : "507";
				resp.StatusDescription = recordsAffected > 0 ? "Success" : "Fail";
			}
			return resp;
		}

		public virtual Response Save<T>(T source
			, ObjectPropertyMap<T> mapping
			, IDbConnection connection
			, bool useDbTransaction = false
			, string preScript = null
			, bool returnIdentity = false)
		{
			Response resp = new Response();

			if (returnIdentity)
			{
				decimal identityValue = 0;
				var result = SQLServer.SaveData(source, connection, mapping, useDbTransaction, preScript, postScript: "SELECT SCOPE_IDENTITY()");
				identityValue = result == DBNull.Value ? 0 : (decimal)result;
				resp.DataID = $"{identityValue}";
				resp.StatusCode = identityValue > 0 ? "204" : "507";
				resp.StatusDescription = identityValue > 0 ? "Success" : "Fail";
			}
			else
			{
				int recordsAffected = 0;
				recordsAffected = (int)SQLServer.SaveData(source, connection, mapping, useDbTransaction, preScript);

				resp.DataID = $"{recordsAffected} records saved";
				resp.StatusCode = recordsAffected > 0 ? "204" : "507";
				resp.StatusDescription = recordsAffected > 0 ? "Success" : "Fail";
			}
			return resp;
		}

		public virtual async Task<Response> SaveAsync<T>(T source
			, ObjectPropertyMap<T> mapping
			, IDbConnection connection
			, CancellationToken token
			, bool useDbTransaction = false
			, string preScript = null
			, Response response = null
			, bool returnIdentity = false)
		{
			if (response != null)
				return response;
			var resp = new Response();

			if (returnIdentity)
			{
				decimal identityValue = 0;
				await Task.Run(() =>
				{
					var result = SQLServer.SaveData(source, connection, mapping, useDbTransaction, preScript, postScript: "SELECT SCOPE_IDENTITY()");
					identityValue = result == DBNull.Value ? 0 : (decimal)result;
				});
				resp.DataID = $"{identityValue}";
				resp.StatusCode = identityValue > 0 ? "204" : "507";
				resp.StatusDescription = identityValue > 0 ? "Success" : "Fail";
			}
			else
			{
				int recordsAffected = 0;
				await Task.Run(() =>
				{
					recordsAffected = (int)SQLServer.SaveData(source, connection, mapping, useDbTransaction, preScript);
				});

				resp.DataID = $"{recordsAffected} records saved";
				resp.StatusCode = recordsAffected > 0 ? "204" : "507";
				resp.StatusDescription = recordsAffected > 0 ? "Success" : "Fail";
			}
			return resp;
		}

		public virtual Response Save<T>(T source
			, ObjectPropertyMap<T> mapping
			, IDbConnection connection
			, bool useDbTransaction = false
			, string preScript = null
			, Response response = null
			, bool returnIdentity = false)
		{
			if (response != null)
				return response;
			var resp = new Response();

			if (returnIdentity)
			{
				decimal identityValue = 0;
				var result = SQLServer.SaveData(source, connection, mapping, useDbTransaction, preScript, postScript: "SELECT SCOPE_IDENTITY()");
				identityValue = result == DBNull.Value ? 0 : (decimal)result;
				resp.DataID = $"{identityValue}";
				resp.StatusCode = identityValue > 0 ? "204" : "507";
				resp.StatusDescription = identityValue > 0 ? "Success" : "Fail";
			}
			else
			{
				int recordsAffected = 0;
				recordsAffected = (int)SQLServer.SaveData(source, connection, mapping, useDbTransaction, preScript);

				resp.DataID = $"{recordsAffected} records saved";
				resp.StatusCode = recordsAffected > 0 ? "204" : "507";
				resp.StatusDescription = recordsAffected > 0 ? "Success" : "Fail";
			}
			return resp;
		}
    }
}