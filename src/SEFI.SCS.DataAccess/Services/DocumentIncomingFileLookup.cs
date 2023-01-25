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
    public class DocumentIncomingFileLookup : DatabaseLookupService
    {
        public async Task<List<DocumentIncomingFiles>> LookupAsync(IQuery query, IDbConnection connection, CancellationToken token)
        {
            return await base.LookupAsync(query, new DocumentIncomingFilesMapping(), connection, token);
        }

        public  List<DocumentIncomingFiles> Lookup(IQuery query, IDbConnection connection)
        {
            return base.Lookup(query, new DocumentIncomingFilesMapping(), connection);
        }

        public async Task<DocumentIncomingFiles> GetAsync(IQuery query, IDbConnection connection, CancellationToken token)
        {
            return await base.GetAsync(query, new DocumentIncomingFilesMapping(), connection, token);
        }

        public DocumentIncomingFiles Get(IQuery query, IDbConnection connection)
        {
            return base.Get(query, new DocumentIncomingFilesMapping(), connection);
        }
    }
}
