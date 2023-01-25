using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ProjectClasses
{
    public class CRUDService
    {
        public string ClassName { get; set; }
        public bool CreateCreateService { get; set; }
        public bool CreateReadService { get; set; }
        public bool CreateUpdateService { get; set; }
        public bool CreateDeleteService { get; set; }
        public string DataTable { get; set; }
        public string StoredProcedureName { get; set; }
        public string CustomSQL { get; set; }
        public string ModelNamespace { get; set; }
        public string MappingNamespace { get; set; }
        public string ServiceNamespace { get; set; }
        public List<ColumnMapping> ColumnMappings { get; set; }
    }
}
