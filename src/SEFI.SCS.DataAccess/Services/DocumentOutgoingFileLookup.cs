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
    public class DocumentOutgoingFileLookup : DatabaseLookupService
    {
        public async Task<List<DocumentOutgoingFiles>> LookupAsync(IQuery query, IDbConnection connection, CancellationToken token)
        {
            return await base.LookupAsync(query, new DocumentOutgoingFilesMapping(), connection, token);
        }

        public  List<DocumentOutgoingFiles> Lookup(IQuery query, IDbConnection connection)
        {
            return base.Lookup(query, new DocumentOutgoingFilesMapping(), connection);
        }

        public async Task<DocumentOutgoingFiles> GetAsync(IQuery query, IDbConnection connection, CancellationToken token)
        {
            return await base.GetAsync(query, new DocumentOutgoingFilesMapping(), connection, token);
        }

        public DocumentOutgoingFiles Get(IQuery query, IDbConnection connection)
        {
            return base.Get(query, new DocumentOutgoingFilesMapping(), connection);
        }
    }
}
