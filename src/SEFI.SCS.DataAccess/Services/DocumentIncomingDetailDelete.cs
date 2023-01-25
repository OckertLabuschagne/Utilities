using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

using SEFI.Models;
using SEFI.Queries;
using SEFI.Services;
using SEFI.SCS.Mappings.Documents;
using SEFI.SCS.Entities.Documents;
namespace SEFI.SCS.DataAccess.Services
{
    public class DocumentIncomingDetailDelete : DatabaseDeleteService, IDocumentIncomingDetailDelete
    {
        public async Task<Response> DeleteAsync(IDbConnection connection, CancellationToken token, IncomingDocumentDetail value = null, IQuery query = null)
        {
            return await new DocumentIncomingDetailDelete().DeleteAsync(new DocumentIncomingDetailMapping(), connection, token, value, query);
        }

        public static async Task<Response> SDeleteAsync(IDbConnection connection, CancellationToken token, IncomingDocumentDetail value = null, IQuery query = null)
        {
            return await new DocumentIncomingDetailDelete().DeleteAsync(new DocumentIncomingDetailMapping(), connection, token, value, query);
        }

        public Response Delete(IDbConnection connection, IncomingDocumentDetail value = null, IQuery query = null)
        {
            return new DocumentIncomingDetailDelete().Delete(new DocumentIncomingDetailMapping(), connection, value, query);
        }

        public static Response SDelete(IDbConnection connection, IncomingDocumentDetail value = null, IQuery query = null)
        {
            return new DocumentIncomingDetailDelete().Delete(new DocumentIncomingDetailMapping(), connection, value, query);
        }
    }
}
