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
    public class DocumentOutgoingDertailLookup : DatabaseLookupService
    {
        public static async Task<List<OutgoingDocumentDetail>> LookupAsync(IQuery query, IDbConnection connection, CancellationToken token)
        {
            return await new DocumentOutgoingDertailLookup().LookupAsync(query, new DocumentOutgoingDetailMapping(), connection, token);
        }

        public static List<OutgoingDocumentDetail> Lookup(IQuery query, IDbConnection connection)
        {
            return new DocumentOutgoingDertailLookup().Lookup(query, new DocumentOutgoingDetailMapping(), connection);
        }

        public async static Task<OutgoingDocumentDetail> GetAsync(IQuery query, IDbConnection connection, CancellationToken token)
        {
            return await new DocumentOutgoingDertailLookup().GetAsync(query, new DocumentOutgoingDetailMapping(), connection, token);
        }

        public static OutgoingDocumentDetail Get(IQuery query, IDbConnection connection)
        {
            return new DocumentOutgoingDertailLookup().Get(query, new DocumentOutgoingDetailMapping(), connection);
        }
    }
}
