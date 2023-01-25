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
    public class DocumentIncomingFileDelete : DatabaseDeleteService
    {
        public static async Task<Response> DeleteAsync(IDbConnection connection, CancellationToken token, DocumentIncomingFiles value = null, IQuery query = null)
        {
            return await new DocumentIncomingFileDelete().DeleteAsync(new DocumentIncomingFilesMapping(), connection, token, value, query);
        }

        public static Response Delete(IDbConnection connection, DocumentIncomingFiles value = null, IQuery query = null)
        {
            return new DocumentIncomingFileDelete().Delete(new DocumentIncomingFilesMapping(), connection, value, query);
        }
    }
}
