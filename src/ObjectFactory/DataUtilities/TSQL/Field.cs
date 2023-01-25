using System.Data;

namespace SEFI.DataUtilities.TSQL
{
    public class Field
    {
        public ObjectName SourceObjectName { get; set; }
        public string ColumnName { get; set; }
        public string Alias { get; set; }
        public Function Function { get; set; }
        public DbType DbType { get; set; }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Alias) ?
                SourceObjectName == null ? ColumnName : string.IsNullOrEmpty(SourceObjectName.Alias) ? $"{SourceObjectName}.{ColumnName}" : $"{SourceObjectName.Alias}.{ColumnName}" :
                SourceObjectName == null ? $"{ColumnName} as {Alias}" : string.IsNullOrEmpty(SourceObjectName.Alias) ? $"{SourceObjectName}.{ColumnName} as {Alias}" : $"{SourceObjectName.Alias}.{ColumnName} as {Alias}";
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }
    }
}
