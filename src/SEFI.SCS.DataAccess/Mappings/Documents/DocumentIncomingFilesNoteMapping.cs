using System.Data;

using SEFI.SCS.Entities.Documents;
using SEFI.Mappings;
namespace SEFI.SCS.Mappings.Documents
{
    public class DocumentIncomingFilesNoteMapping : ObjectPropertyMap<DocumentIncomingFileNote>
    {
        public DocumentIncomingFilesNoteMapping()
        {
            DatabaseObject = "scs_document_incoming_file_note";
			Property(p => p.Id).HasFieldName("iincoming_file_note_id").HasDbType(DbType.Int32).IsIdentityField(true).IsMemberOfKeyField(true);
			Property(p => p.FileId).HasFieldName("iincoming_file_id").HasDbType(DbType.Int32).IsRequiredField(true);
            Property(p => p.Note).HasFieldName("snote").HasDbType(DbType.AnsiString).HasLength(1000).MustTrimString(true);
            Property(p => p.CreatedDate).HasFieldName("dtcreated").HasDbType(DbType.DateTime);
            Property(p => p.CreatedByUser).HasFieldName("screated_by").HasDbType(DbType.String).HasLength(30).MustTrimString(true);
            Property(p => p.LastUpdateDate).HasFieldName("dtupdate_last").HasDbType(DbType.DateTime);
            Property(p => p.UpdateUserId).HasFieldName("supdate_user_id").HasDbType(DbType.String).HasLength(30).MustTrimString(true);
        }
    }
}
