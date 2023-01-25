using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ProjectClasses
{
    public class ColumnMapping
    {
        public string DatabaseObjectName { get; set; }
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
    }
}
