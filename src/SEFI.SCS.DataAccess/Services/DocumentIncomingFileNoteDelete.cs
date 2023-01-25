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
    public class DocumentIncomingFileNoteDelete : DatabaseDeleteService
    {
        public static async Task<Response> DeleteAsync(IDbConnection connection, CancellationToken token, DocumentIncomingFileNote value = null, IQuery query = null)
        {
            return await new DocumentIncomingFileNoteDelete().DeleteAsync(new DocumentIncomingFilesNoteMapping(), connection, token, value, query) ;
        }

        public static Response Delete(IDbConnection connection, DocumentIncomingFileNote value = null, IQuery query = null)
        {
            return new DocumentIncomingFileNoteDelete().Delete(new DocumentIncomingFilesNoteMapping(), connection, value, query);
        }
    }
}
