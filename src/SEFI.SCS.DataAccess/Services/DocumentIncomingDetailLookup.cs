using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

using SEFI.Mappings;
using SEFI.Queries;
using SEFI.Services;
using SEFI.SCS.Mappings.Documents;
using SEFI.SCS.Entities.Documents;
namespace SEFI.SCS.DataAccess.Services
{
    public class DocumentIncomingDetailLookup : DatabaseLookupService
    {
        public static async Task<List<IncomingDocumentDetail>> LookupAsync(IQuery query, IDbConnection connection, CancellationToken token)
        {
            return await new DocumentIncomingDetailLookup().LookupAsync(query, new DocumentIncomingDetailMapping(), connection, token);
        }

        public static List<IncomingDocumentDetail> Lookup(IQuery query, IDbConnection connection)
        {
            return new DocumentIncomingDetailLookup().Lookup(query, new DocumentIncomingDetailMapping(), connection);
        }

        public static async Task<IncomingDocumentDetail> GetAsync(IQuery query, IDbConnection connection, CancellationToken token)
        {
            return await new DocumentIncomingDetailLookup().GetAsync(query, new DocumentIncomingDetailMapping(), connection, token);
        }

        public static IncomingDocumentDetail Get(IQuery query, IDbConnection connection)
        {
            return new DocumentIncomingDetailLookup().Get(query, new DocumentIncomingDetailMapping(), connection);
        }
    }
}
