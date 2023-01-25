using System.Data;

using SEFI.SCS.Entities.Documents;
using SEFI.Mappings;
namespace SEFI.SCS.Mappings.Documents
{
    public class DocumentIncomingFilesMapping : ObjectPropertyMap<DocumentIncomingFiles>
    {
        public DocumentIncomingFilesMapping()
        {
            DatabaseObject = "scs_document_incoming_files";
            Property(p => p.Id).HasFieldName("iincoming_file_id").HasDbType(DbType.Int32).IsMemberOfKeyField(true);
            Property(p => p.FileUuid).HasFieldName("uincoming_file_uuid").HasDbType(DbType.Guid);
            Property(p => p.TpaCode).HasFieldName("stpa_code").HasDbType(DbType.StringFixedLength).HasLength(4).MustTrimString(true);
            Property(p => p.DetailId).HasFieldName("iincoming_detail_id").HasDbType(DbType.Int32);
            Property(p => p.FileName).HasFieldName("sincoming_file_name").HasDbType(DbType.AnsiString).HasLength(1024).MustTrimString(true);
            Property(p => p.FileImage).HasFieldName("imgincoming_file").HasDbType(DbType.Binary);
            Property(p => p.FileSize).HasFieldName("ifile_size").HasDbType(DbType.Int32);
            Property(p => p.LastUpdatedDate).HasFieldName("dtupdate_last").HasDbType(DbType.DateTime);
            Property(p => p.UpdateUser).HasFieldName("supdate_user_id").HasDbType(DbType.String).HasLength(30).MustTrimString(true);
            Property(p => p.UpdateUserId).HasFieldName("iupdate_user_id").HasDbType(DbType.Int32);
            Property(p => p.CreatedByUserId).HasFieldName("icreated_by").HasDbType(DbType.Int32);
            Property(p => p.CreatedDate).HasFieldName("dtcreated").HasDbType(DbType.DateTime);
            Property(p => p.DocumentRepositoryCode).HasFieldName("sdocument_repository_code").HasDbType(DbType.String).HasLength(15).MustTrimString(true);
            Property(p => p.DocumentRepositoryKey).HasFieldName("sdocument_repository_key").HasDbType(DbType.AnsiString).HasLength(-1).MustTrimString(true);
        }
    }
}
