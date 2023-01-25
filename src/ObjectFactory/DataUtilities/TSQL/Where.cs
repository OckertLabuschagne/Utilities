using System;
using System.Collections.Generic;
using System.Text;

namespace SEFI.DataUtilities.TSQL
{
    public class Where : IStatement
    {
        public StatementType StatementType { get => StatementType.Query; }

    }
}
