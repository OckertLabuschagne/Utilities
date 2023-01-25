using System.Data;

using SEFI.SCS.Entities.Documents;
using SEFI.Mappings;
namespace SEFI.SCS.Mappings.Documents
{
    public class DocumentOutgoingDetailMapping : ObjectPropertyMap<OutgoingDocumentDetail>
    {
        
        public DocumentOutgoingDetailMapping()
        {
            DatabaseObject = "scs_document_outgoing_detail";
            Property(p => p.Id).HasFieldName("ioutgoing_detail_id").HasDbType(DbType.Int32).IsMemberOfKeyField(true);
            Property(p => p.Module).HasFieldName("idoc_module_id").HasDbType(DbType.Int32);
            Property(p => p.ModuleKeyId).HasFieldName("imodule_key_id").HasDbType(DbType.Int32);
            Property(p => p.AllowFreeEntry).HasFieldName("btallow_free_entry").HasDbType(DbType.Boolean);
            Property(p => p.Condition).HasFieldName("idoc_condition_id").HasDbType(DbType.Int32);
            Property(p => p.DueInDays).HasFieldName("idue_in_days").HasDbType(DbType.Int32);
            Property(p => p.CanDelete).HasFieldName("btcan_delete").HasDbType(DbType.Boolean);
            Property(p => p.TemplateId).HasFieldName("idoc_template_id").HasDbType(DbType.Int32);
            Property(p => p.TypeCode).HasFieldName("sdoc_type_code").HasDbType(DbType.AnsiString).HasLength(30).MustTrimString(true);
            Property(p => p.TypeDescription).HasFieldName("sdoc_type_desc").HasDbType(DbType.AnsiString).HasLength(200).MustTrimString(true);
            Property(p => p.Notes).HasFieldName("snotes").HasDbType(DbType.AnsiString).HasLength(100).MustTrimString(true);
            Property(p => p.LastDateGenerated).HasFieldName("dtgenerate_last").HasDbType(DbType.DateTime);
            Property(p => p.AdditionalInfo).HasFieldName("sadditional_info").HasDbType(DbType.AnsiString).HasLength(1000).MustTrimString(true);
            Property(p => p.UpdateDate).HasFieldName("dtupdate_last").HasDbType(DbType.DateTime);
            Property(p => p.UpdateUserId).HasFieldName("iupdate_user_id").HasDbType(DbType.Int32);
            Property(p => p.CreateUserId).HasFieldName("icreated_by").HasDbType(DbType.Int32);
            Property(p => p.CreateDate).HasFieldName("dtcreated").HasDbType(DbType.DateTime);
        }
    }
}
