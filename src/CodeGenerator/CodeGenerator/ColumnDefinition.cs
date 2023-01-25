using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class ColumnDefinition
    {
        public DbType DbType { get; set; }
        public Type Type { get; set; }
        public int Length { get; set; }
        public bool Included { get; set; }
        public bool IsKeyField { get; set; }
        public bool IsFilterField { get; set; }
        public string FieldName { get; set; }
    }
}
