using System.Data;
using System.Threading;
using System.Threading.Tasks;

using SEFI.Models;
using SEFI.Mappings;
using SEFI.Queries;

namespace SEFI.Services
{
    public interface IDatabaseDeleteService : IDatabaseCommandService
    {
        Task<Response> DeleteAsync<T>(ObjectPropertyMap<T> mapping, IDbConnection connection, CancellationToken token, T source = default, IQuery query = null, string preScript = null, string postScript = null, Response response = null);
        Response Delete<T>(ObjectPropertyMap<T> mapping, IDbConnection connection, T source = default, IQuery query = null, string preScript = null, string postScript = null, Response response = null);
    }
}
