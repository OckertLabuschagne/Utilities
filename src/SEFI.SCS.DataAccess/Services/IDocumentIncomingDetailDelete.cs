using System.Data;
using System.Threading;
using System.Threading.Tasks;

using SEFI.Models;
using SEFI.Queries;
using SEFI.SCS.Entities.Documents;
using SEFI.Services;
namespace SEFI.SCS.DataAccess.Services
{
    public interface IDocumentIncomingDetailDelete : IDatabaseDeleteService
    {
        Task<Response> DeleteAsync(IDbConnection connection, CancellationToken token, IncomingDocumentDetail value = null, IQuery query = null);
        Response Delete(IDbConnection connection, IncomingDocumentDetail value = null, IQuery query = null);
    }
}
