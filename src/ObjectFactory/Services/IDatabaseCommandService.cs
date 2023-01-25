using System.Data;
using System.Threading;
using System.Threading.Tasks;

using SEFI.Models;
namespace SEFI.Services
{
    public interface IDatabaseCommandService
    {
        Task<Response> BeginTransactionAsync(string name, IDbConnection connection, CancellationToken token, string mark = null);
        Task<Response> CommitTransactionAsync(string name, IDbConnection connection, CancellationToken token);
        Task<Response> RollbackTransactionAsync(string name, IDbConnection connection, CancellationToken token, string savePoint = null);
        Task<Response> SaveTransactionAsync(string savePointName, IDbConnection connection, CancellationToken token);
        Response BeginTransaction(string name, IDbConnection connection, string mark = null);
        Response CommitTransaction(string name, IDbConnection connection);
        Response RollbackTransaction(string name, IDbConnection connection, string savePoint = null);
        Response SaveTransaction(string savePointName, IDbConnection connection);
    }
}
