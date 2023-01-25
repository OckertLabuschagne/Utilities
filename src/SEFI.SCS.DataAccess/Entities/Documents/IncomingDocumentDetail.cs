using System;

namespace SEFI.SCS.Entities.Documents
{
    public class IncomingDocumentDetail : DocumentDetail
    {
        public DateTime? CycleMonth { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReceiveDate { get; set; }
    }
}
