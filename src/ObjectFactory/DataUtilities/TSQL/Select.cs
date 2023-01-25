using System;
using System.Collections.Generic;
using System.Text;

namespace SEFI.DataUtilities.TSQL
{
    public class Select : IStatement
    {
        public StatementType StatementType { get => StatementType.Query; }

        public From From { get; set; }
        public Where Where { get; set; }
    }
}
