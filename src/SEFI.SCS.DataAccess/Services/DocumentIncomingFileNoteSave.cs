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
    public class DocumentIncomingFileNoteSave : DatabaseSaveService
    {
        public static async Task<Response> SaveAsync(DocumentIncomingFileNote value, IDbConnection connection, CancellationToken token)
        {
            return await new DocumentIncomingFileNoteSave().SaveAsync(value, new DocumentIncomingFilesNoteMapping(), connection, token, useDbTransaction: false, preScript: null, returnIdentity: true) ;
        }

        public static Response Save(DocumentIncomingFileNote value, IDbConnection connection)
        {
            return new DocumentIncomingFileNoteSave().Save(value, new DocumentIncomingFilesNoteMapping(), connection, useDbTransaction: false, preScript: null, returnIdentity: true);
        }
    }
}
