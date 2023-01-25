using System;

namespace SEFI.SCS.Entities.Documents
{
    public class OutgoingDocumentDetail : DocumentDetail
    {
        public DateTime? LastDateGenerated { get; set; }
        public string AdditionalInfo { get; set; }
        public int? TemplateId { get; set; }
        public bool? AllowFreeEntry { get; set; }
    }
}
