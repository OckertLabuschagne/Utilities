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
    public class DocumentIncomingDetailSave : DatabaseSaveService
    {
        public static async Task<Response> SaveAsync(IncomingDocumentDetail value, IDbConnection connection, CancellationToken token)
        {
            return await new DocumentIncomingDetailSave().SaveAsync(value, new DocumentIncomingDetailMapping(), connection, token, useDbTransaction: false, preScript: null, returnIdentity: true) ;
        }

        public static Response Save(IncomingDocumentDetail value, IDbConnection connection)
        {
            return new DocumentIncomingDetailSave().Save(value, new DocumentIncomingDetailMapping(), connection, useDbTransaction: false, preScript: null, returnIdentity: true);
        }
    }
}
