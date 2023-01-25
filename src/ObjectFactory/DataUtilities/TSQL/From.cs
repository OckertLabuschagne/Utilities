using System;
using System.Collections.Generic;
using System.Text;

namespace SEFI.DataUtilities.TSQL
{
    public class From : IStatement
    {
        public StatementType StatementType { get => StatementType.Query; }

        public ObjectName SourceName { get; set; }

        public Join Join { get; set; }
    }
}
