using System.Data;
using System.Threading;
using System.Threading.Tasks;

using SEFI.Models;
using SEFI.Mappings;
namespace SEFI.Services
{
    public interface IDatabaseSaveService : IDatabaseCommandService
    {
        Task<Response> SaveAsync<T>(T source, ObjectPropertyMap<T> mapping, IDbConnection connection, CancellationToken token, bool useDbTransaction = false, string preScript = null, bool returnIdentity = false);
        Task<Response> SaveAsync<T>(T source, ObjectPropertyMap<T> mapping, IDbConnection connection, CancellationToken token, bool useDbTransaction = false, string preScript = null, Response response = null, bool returnIdentity = false);
        Response Save<T>(T source, ObjectPropertyMap<T> mapping, IDbConnection connection, bool useDbTransaction = false, string preScript = null, bool returnIdentity = false);
        Response Save<T>(T source, ObjectPropertyMap<T> mapping, IDbConnection connection, bool useDbTransaction = false, string preScript = null, Response response = null, bool returnIdentity = false);
    }
}
