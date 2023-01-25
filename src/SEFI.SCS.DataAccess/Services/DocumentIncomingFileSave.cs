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
    public class DocumentIncomingFileSave : DatabaseSaveService
    {
        public static async Task<Response> SaveAsync(DocumentIncomingFiles value, IDbConnection connection, CancellationToken token)
        {
            return await new DocumentIncomingFileSave().SaveAsync(value, new DocumentIncomingFilesMapping(), connection, token, useDbTransaction: false, preScript: null, returnIdentity: true) ;
        }

        public static Response Save(DocumentIncomingFiles value, IDbConnection connection)
        {
            return new DocumentIncomingFileSave().Save(value, new DocumentIncomingFilesMapping(), connection, useDbTransaction: false, preScript: null, returnIdentity: true);
        }
    }
}
