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
    public class DocumentOutgoingFileDelete : DatabaseDeleteService
    {
        public static async Task<Response> DeleteAsync(IDbConnection connection, CancellationToken token, DocumentOutgoingFiles value = null, IQuery query = null)
        {
            return await new DocumentOutgoingFileDelete().DeleteAsync(new DocumentOutgoingFilesMapping(), connection, token, value, query) ;
        }

        public static Response Delete(IDbConnection connection, DocumentOutgoingFiles value = null, IQuery query = null)
        {
            return new DocumentOutgoingFileDelete().Delete(new DocumentOutgoingFilesMapping(), connection, value, query);
        }
    }
}
