using System;
using System.Collections.Generic;
using System.Text;

using SEFI.Domain.Enums;
using SEFI.Domain.Entities;
namespace SEFI.SCS.Entities.Documents
{
    public class DocumentDetail : CoreEntity
    {
        public DocumentModule Module { get; set; }
        public int ModuleKeyId { get; set; }
        public string Notes { get; set; }
        public string TypeCode { get; set; }
        public string TypeDescription { get; set; }
        public DocumentCondition? Condition { get; set; }
        public int? DueInDays { get; set; } = 0;
        public bool? CanDelete { get; set; } = true;
        public int? CreateUserId { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
