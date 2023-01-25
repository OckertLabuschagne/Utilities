using System;
using System.Collections.Generic;
using System.Text;

namespace SEFI.DataUtilities.TSQL
{
    public class ObjectName
    {
        public string Name { get; set; }
        public string SchemaName { get; set; }
        public string Alias { get; set; }

        public override string ToString()
        {
            return string.IsNullOrEmpty(SchemaName) ? string.IsNullOrEmpty(Alias) ? Name : $"{Name} AS {Alias}" : string.IsNullOrEmpty(Alias) ? $"{SchemaName}.{Name}" : $"{SchemaName}.{Name} AS {Alias}";
        }
    }
}
