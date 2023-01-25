using System;
using SEFI.Domain.Entities;
namespace SEFI.SCS.Entities.Documents
{
    public class DocumentFiles : CoreEntity
    {
        public virtual Guid? FileUuid { get; set; }
        public virtual string TpaCode { get; set; }
        public virtual int? DetailId { get; set; }
        public virtual string FileName { get; set; }
        public virtual DateTime? LastUpdatedDate { get; set; }
        public virtual int? UpdateUserId { get; set; }
        public virtual int? CreatedByUserId { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual string DocumentRepositoryCode { get; set; }
        public virtual string DocumentRepositoryKey { get; set; }
        public virtual byte[] FileImage { get; set; }
    }
}
