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
    public class DocumentIncomingFileNoteLookup : DatabaseLookupService
    {
        public async Task<List<DocumentIncomingFileNote>> LookupAsync(IQuery query, IDbConnection connection, CancellationToken token)
        {
            return await base.LookupAsync(query, new DocumentIncomingFilesNoteMapping(), connection, token);
        }

        public  List<DocumentIncomingFileNote> Lookup(IQuery query, IDbConnection connection)
        {
            return base.Lookup(query, new DocumentIncomingFilesNoteMapping(), connection);
        }

        public async Task<DocumentIncomingFileNote> GetAsync(IQuery query, IDbConnection connection, CancellationToken token)
        {
            return await base.GetAsync(query, new DocumentIncomingFilesNoteMapping(), connection, token);
        }

        public DocumentIncomingFileNote Get(IQuery query, IDbConnection connection)
        {
            return base.Get(query, new DocumentIncomingFilesNoteMapping(), connection);
        }
    }
}
