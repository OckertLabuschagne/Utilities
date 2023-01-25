using System;

using SEFI.Domain.Entities;

namespace SEFI.SCS.Entities.Documents
{
    public class DocumentIncomingFileNote : CoreEntity
    {
        public virtual int? FileId{ get; set; }
        public virtual string Note{ get; set; }
        public virtual DateTime? CreatedDate{ get; set; }
        public virtual string CreatedByUser{ get; set; }
        public virtual DateTime? LastUpdateDate{ get; set; }
        public virtual string UpdateUserId{ get; set; }}
}
