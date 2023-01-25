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
    public class DocumentIOutgoingDetailDelete : DatabaseDeleteService
    {
        public static async Task<Response> DeleteAsync(IDbConnection connection, CancellationToken token, OutgoingDocumentDetail value = null, IQuery query = null)
        {
            return await new DocumentIOutgoingDetailDelete().DeleteAsync(new DocumentOutgoingDetailMapping(), connection, token, value, query) ;
        }

        public static Response Delete(IDbConnection connection, OutgoingDocumentDetail value = null, IQuery query = null)
        {
            return new DocumentIOutgoingDetailDelete().Delete(new DocumentOutgoingDetailMapping(), connection, value, query);
        }
    }
}
