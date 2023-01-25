using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System;

using SEFI.DataUtilities;
using SEFI.Models;
using SEFI.Mappings;
namespace SEFI.Services
{
    public abstract class DatabaseCommandService : IDatabaseCommandService
    {
		public virtual async Task<Response> BeginTransactionAsync(string name
			, IDbConnection connection
			, CancellationToken token
			, string mark = null)
		{
			Response resp = new Response();
			if (connection == null)
			{
				resp.Status = Enums.ResponseStatusCode.Failed;
				resp.Messages.Add(new ResponseMessage(Enums.ResponseDetailStatusCode.BadRequest, "Cannot create a transaction on a connection that is null", nameof(connection)));
				return resp;
			}

			try
			{
				if (connection.State != ConnectionState.Open)
					connection.Open();

				IDbCommand command = connection.CreateCommand();
				string withMark = string.IsNullOrEmpty(mark) ? "" : $" WITH MARK {mark}";
				command.CommandText = $"BEGIN TRANSACTION {name}{withMark}";
				int execResponse = 0;
				await Task.Run(() =>
				{
					execResponse = command.ExecuteNonQuery();
				});
				resp.Status = Enums.ResponseStatusCode.Success;
				resp.Data = execResponse;
			}
			catch (Exception excp)
			{
				resp.Status = Enums.ResponseStatusCode.Failed;
				resp.Messages.Add(new ResponseMessage(Enums.ResponseDetailStatusCode.UnprocessableEntity, $"Error creating transaction: {excp.Message}", null));
			}
			return resp;
		}

		public virtual async Task<Response> CommitTransactionAsync(string name
			, IDbConnection connection
			, CancellationToken token)
		{
			Response resp = new Response();
			if (connection == null)
			{
				resp.Status = Enums.ResponseStatusCode.Failed;
				resp.Messages.Add(new ResponseMessage(Enums.ResponseDetailStatusCode.BadRequest, "Cannot commit a transaction on a connection that is null", nameof(connection)));
				return resp;
			}

			try
			{
				if (connection.State != ConnectionState.Open)
				{
					resp.Status = Enums.ResponseStatusCode.Failed;
					resp.Messages.Add(new ResponseMessage(Enums.ResponseDetailStatusCode.BadRequest, "Cannot commit a transaction on a connection that is not open", null));
					return resp;
				}
				IDbCommand command = connection.CreateCommand();
				command.CommandText = $"COMMIT TRANSACTION {name}";
				int execResponse = 0;
				await Task.Run(() =>
				{
					execResponse = command.ExecuteNonQuery();
				});
				resp.Status = Enums.ResponseStatusCode.Success;
				resp.Data = execResponse;
			}
			catch (Exception excp)
			{
				resp.Status = Enums.ResponseStatusCode.Failed;
				resp.Messages.Add(new ResponseMessage(Enums.ResponseDetailStatusCode.UnprocessableEntity, $"Error committing transaction: {excp.Message}", null));
			}
			return resp;
		}

		public virtual async Task<Response> RollbackTransactionAsync(string name
			, IDbConnection connection
			, CancellationToken token
			, string savePoint = null)
		{
			Response resp = new Response();
			if (connection == null)
			{
				resp.Status = Enums.ResponseStatusCode.Failed;
				resp.Messages.Add(new ResponseMessage(Enums.ResponseDetailStatusCode.BadRequest, "Cannot roll back a transaction on a connection that is null", nameof(connection)));
				return resp;
			}

			try
			{
				if (connection.State != ConnectionState.Open)
				{
					resp.Status = Enums.ResponseStatusCode.Failed;
					resp.Messages.Add(new ResponseMessage(Enums.ResponseDetailStatusCode.BadRequest, "Cannot roll back a transaction on a connection that is not open", null));
					return resp;
				}
				IDbCommand command = connection.CreateCommand();
				string savePointName = string.IsNullOrEmpty(savePoint) ? "" : $" {savePoint}";
				command.CommandText = $"ROLLBACK TRANSACTION {name}{savePointName}";
				int execResponse = 0;
				await Task.Run(() =>
				{
					execResponse = command.ExecuteNonQuery();
				});
				resp.Status = Enums.ResponseStatusCode.Success;
				resp.Data = execResponse;
			}
			catch (Exception excp)
			{
				resp.Status = Enums.ResponseStatusCode.Failed;
				resp.Messages.Add(new ResponseMessage(Enums.ResponseDetailStatusCode.UnprocessableEntity, $"Error rolling back transaction: {excp.Message}", null));
			}
			return resp;
		}

		public virtual async Task<Response> SaveTransactionAsync(string savePointName
			, IDbConnection connection
			, CancellationToken token)
		{
			Response resp = new Response();
			if (connection == null)
			{
				resp.Status = Enums.ResponseStatusCode.Failed;
				resp.Messages.Add(new ResponseMessage(Enums.ResponseDetailStatusCode.BadRequest, "Cannot roll back a transaction on a connection that is null", nameof(connection)));
				return resp;
			}

			try
			{
				if (connection.State != ConnectionState.Open)
				{
					resp.Status = Enums.ResponseStatusCode.Failed;
					resp.Messages.Add(new ResponseMessage(Enums.ResponseDetailStatusCode.BadRequest, "Cannot save a transaction on a connection that is not open", null));
					return resp;
				}

				IDbCommand command = connection.CreateCommand();
				command.CommandText = $"SAVE TRANSACTION {savePointName}";
				int execResponse = 0;
				await Task.Run(() =>
				{
					execResponse = command.ExecuteNonQuery();
				});
				resp.Status = Enums.ResponseStatusCode.Success;
				resp.Data = execResponse;
			}
			catch (Exception excp)
			{
				resp.Status = Enums.ResponseStatusCode.Failed;
				resp.Messages.Add(new ResponseMessage(Enums.ResponseDetailStatusCode.UnprocessableEntity, $"Error saving transaction: {excp.Message}", null));
			}
			return resp;
		}


		public virtual Response BeginTransaction(string name
			, IDbConnection connection
			, string mark = null)
		{
			Response resp = new Response();
			if (connection == null)
			{
				resp.Status = Enums.ResponseStatusCode.Failed;
				resp.Messages.Add(new ResponseMessage(Enums.ResponseDetailStatusCode.BadRequest, "Cannot create a transaction on a connection that is null", nameof(connection)));
				return resp;
			}

			try
			{
				if (connection.State != ConnectionState.Open)
					connection.Open();

				IDbCommand command = connection.CreateCommand();
				string withMark = string.IsNullOrEmpty(mark) ? "" : $" WITH MARK {mark}";
				command.CommandText = $"BEGIN TRANSACTION {name}{withMark}";
				int execResponse = 0;
				execResponse = command.ExecuteNonQuery();
				resp.Status = Enums.ResponseStatusCode.Success;
				resp.Data = execResponse;
			}
			catch (Exception excp)
			{
				resp.Status = Enums.ResponseStatusCode.Failed;
				resp.Messages.Add(new ResponseMessage(Enums.ResponseDetailStatusCode.UnprocessableEntity, $"Error creating transaction: {excp.Message}", null));
			}
			return resp;
		}

		public virtual Response CommitTransaction(string name, IDbConnection connection)
		{
			Response resp = new Response();
			if (connection == null)
			{
				resp.Status = Enums.ResponseStatusCode.Failed;
				resp.Messages.Add(new ResponseMessage(Enums.ResponseDetailStatusCode.BadRequest, "Cannot commit a transaction on a connection that is null", nameof(connection)));
				return resp;
			}

			try
			{
				if (connection.State != ConnectionState.Open)
				{
					resp.Status = Enums.ResponseStatusCode.Failed;
					resp.Messages.Add(new ResponseMessage(Enums.ResponseDetailStatusCode.BadRequest, "Cannot commit a transaction on a connection that is not open", null));
					return resp;
				}
				IDbCommand command = connection.CreateCommand();
				command.CommandText = $"COMMIT TRANSACTION {name}";
				int execResponse = 0;
				execResponse = command.ExecuteNonQuery();
				resp.Status = Enums.ResponseStatusCode.Success;
				resp.Data = execResponse;
			}
			catch (Exception excp)
			{
				resp.Status = Enums.ResponseStatusCode.Failed;
				resp.Messages.Add(new ResponseMessage(Enums.ResponseDetailStatusCode.UnprocessableEntity, $"Error committing transaction: {excp.Message}", null));
			}
			return resp;
		}

		public virtual Response RollbackTransaction(string name
			, IDbConnection connection
			, string savePoint = null)
		{
			Response resp = new Response();
			if (connection == null)
			{
				resp.Status = Enums.ResponseStatusCode.Failed;
				resp.Messages.Add(new ResponseMessage(Enums.ResponseDetailStatusCode.BadRequest, "Cannot roll back a transaction on a connection that is null", nameof(connection)));
				return resp;
			}

			try
			{
				if (connection.State != ConnectionState.Open)
				{
					resp.Status = Enums.ResponseStatusCode.Failed;
					resp.Messages.Add(new ResponseMessage(Enums.ResponseDetailStatusCode.BadRequest, "Cannot roll back a transaction on a connection that is not open", null));
					return resp;
				}
				IDbCommand command = connection.CreateCommand();
				string savePointName = string.IsNullOrEmpty(savePoint) ? "" : $" {savePoint}";
				command.CommandText = $"ROLLBACK TRANSACTION {name}{savePointName}";
				int execResponse = 0;
				execResponse = command.ExecuteNonQuery();
				resp.Status = Enums.ResponseStatusCode.Success;
				resp.Data = execResponse;
			}
			catch (Exception excp)
			{
				resp.Status = Enums.ResponseStatusCode.Failed;
				resp.Messages.Add(new ResponseMessage(Enums.ResponseDetailStatusCode.UnprocessableEntity, $"Error rolling back transaction: {excp.Message}", null));
			}
			return resp;
		}

		public virtual Response SaveTransaction(string savePointName, IDbConnection connection)
		{
			Response resp = new Response();
			if (connection == null)
			{
				resp.Status = Enums.ResponseStatusCode.Failed;
				resp.Messages.Add(new ResponseMessage(Enums.ResponseDetailStatusCode.BadRequest, "Cannot roll back a transaction on a connection that is null", nameof(connection)));
				return resp;
			}

			try
			{
				if (connection.State != ConnectionState.Open)
				{
					resp.Status = Enums.ResponseStatusCode.Failed;
					resp.Messages.Add(new ResponseMessage(Enums.ResponseDetailStatusCode.BadRequest, "Cannot save a transaction on a connection that is not open", null));
					return resp;
				}

				IDbCommand command = connection.CreateCommand();
				command.CommandText = $"SAVE TRANSACTION {savePointName}";
				int execResponse = 0;
				execResponse = command.ExecuteNonQuery();
				resp.Status = Enums.ResponseStatusCode.Success;
				resp.Data = execResponse;
			}
			catch (Exception excp)
			{
				resp.Status = Enums.ResponseStatusCode.Failed;
				resp.Messages.Add(new ResponseMessage(Enums.ResponseDetailStatusCode.UnprocessableEntity, $"Error saving transaction: {excp.Message}", null));
			}
			return resp;
		}
	}
}
