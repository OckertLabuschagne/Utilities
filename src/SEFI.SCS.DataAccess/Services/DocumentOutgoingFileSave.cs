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
    public class DocumentOutgoingFileSave : DatabaseSaveService
    {
        public static async Task<Response> SaveAsync(DocumentOutgoingFiles value, IDbConnection connection, CancellationToken token)
        {
            return await new DocumentOutgoingFileSave().SaveAsync(value, new DocumentOutgoingFilesMapping(), connection, token, useDbTransaction: false, preScript: null, returnIdentity: true) ;
        }

        public static Response Save(DocumentOutgoingFiles value, IDbConnection connection)
        {
            return new DocumentOutgoingFileSave().Save(value, new DocumentOutgoingFilesMapping(), connection, useDbTransaction: false, preScript: null, returnIdentity: true);
        }
    }
}
