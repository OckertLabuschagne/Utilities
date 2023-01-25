using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SEFI.Mappings;
using SEFI.SCS.Entities.Documents;

namespace SEFI.SCS.Mappings.Documents
{
    public class DocumentIncomingDetailMapping : ObjectPropertyMap<IncomingDocumentDetail>
    {
        public DocumentIncomingDetailMapping()
        {
            DatabaseObject = "scs_document_incoming_detail";
            Property(p => p.Id).HasDbType(DbType.Int32).HasFieldName("iincoming_detail_id").IsIdentityField(true).IsMemberOfKeyField(true);
            Property(p => p.Module).HasDbType(DbType.Int32).HasFieldName("idoc_module_id").IsRequiredField(true);
            Property(p => p.ModuleKeyId).HasDbType(DbType.Int32).HasFieldName("imodule_key_id").IsRequiredField(true);
            Property(p => p.Notes).HasDbType(DbType.AnsiString).HasFieldName("snotes").HasLength(100);
            Property(p => p.TypeCode).HasDbType(DbType.AnsiString).HasFieldName("sdoc_type_code").IsRequiredField(true).HasLength(30);
            Property(p => p.TypeDescription).HasDbType(DbType.AnsiString).HasFieldName("sdoc_type_desc").HasLength(200);
            Property(p => p.Condition).HasDbType(DbType.Int32).HasFieldName("idoc_condition_id");
            Property(p => p.DueInDays).HasDbType(DbType.Int32).HasFieldName("idue_in_days");
            Property(p => p.CanDelete).HasDbType(DbType.Boolean).HasFieldName("btcan_delete").IsRequiredField(true);
            Property(p => p.UpdateUserId).HasDbType(DbType.Int32).HasFieldName("iupdate_user_id");
            Property(p => p.CreateUserId).HasDbType(DbType.Int32).HasFieldName("icreated_by");
            Property(p => p.CreateDate).HasDbType(DbType.DateTime).HasFieldName("dtcreated");
            Property(p => p.UpdateDate).HasDbType(DbType.DateTime).HasFieldName("dtupdate_last");
            Property(p => p.CycleMonth).HasDbType(DbType.DateTime).HasFieldName("dtcycle_month");
            Property(p => p.DueDate).HasDbType(DbType.DateTime).HasFieldName("dtdue_date");
            Property(p => p.ReceiveDate).HasDbType(DbType.DateTime).HasFieldName("dtreceive_date");
        }
    }
}
