using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

using SEFI.Models;
using SEFI.Services;
using SEFI.SCS.Mappings.Documents;
using SEFI.SCS.Entities.Documents;
namespace SEFI.SCS.DataAccess.Services
{
    public class DocumentOutgoingDetailSave : DatabaseSaveService
    {
        public static async Task<Response> SaveAsync(OutgoingDocumentDetail value, IDbConnection connection, CancellationToken token)
        {
            return await new DocumentOutgoingDetailSave().SaveAsync(value, new DocumentOutgoingDetailMapping(), connection, token, useDbTransaction: false, preScript: null, returnIdentity: true) ;
        }

        public static Response Save(OutgoingDocumentDetail value, IDbConnection connection)
        {
            return new DocumentOutgoingDetailSave().Save(value, new DocumentOutgoingDetailMapping(), connection, useDbTransaction: false, preScript: null, returnIdentity: true);
        }
    }
}
