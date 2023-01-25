using System;
using System.Collections.Generic;
using System.Text;

namespace SEFI.DataUtilities.TSQL
{
    public class Exists : IStatement
    {
        public IStatement Condition { get; set; }

        public StatementType StatementType { get => StatementType.Logical; }

        public override string ToString()
        {
            return $"EXISTS({Condition})";
        }
    }
}
