namespace SEFI.SCS.Entities.Documents
{
    public class DocumentIncomingFiles : DocumentFiles
    {
        public virtual int? FileSize { get; set; }
        public virtual string UpdateUser { get; set; }
    }
}
