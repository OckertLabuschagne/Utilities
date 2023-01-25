using System.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using SEFI.Mappings;
using SEFI.Queries;

namespace SEFI.Services
{
    public interface IDatabaseLookupService 
    {
        Task<List<T>> LookupAsync<T>(IQuery query, ObjectPropertyMap<T> mapping, IDbConnection connection, CancellationToken token);
        Task<List<T>> LookupAsync<T>(IQuery query, ObjectPropertyMap<T> mapping, IDbConnection connection, CancellationToken token, Dictionary<string, T> cache = null);
        Task<T> GetAsync<T>(IQuery query, ObjectPropertyMap<T> mapping, IDbConnection connection, CancellationToken token);
        Task<T> GetAsync<T>(IQuery query, ObjectPropertyMap<T> mapping, IDbConnection connection, CancellationToken token, Dictionary<string, T> cache = null);
        List<T> Lookup<T>(IQuery query, ObjectPropertyMap<T> mapping, IDbConnection connection);
        List<T> Lookup<T>(IQuery query, ObjectPropertyMap<T> mapping, IDbConnection connection, Dictionary<string, T> cache = null);
        T Get<T>(IQuery query, ObjectPropertyMap<T> mapping, IDbConnection connection);
        T Get<T>(IQuery query, ObjectPropertyMap<T> mapping, IDbConnection connection, Dictionary<string, T> cache = null);
    }
}
