using System;
using System.Collections.Generic;
using System.Text;

namespace SEFI.DataUtilities.TSQL
{
    public class BeginTransaction : IStatement
    {
        public string Name { get; set; }
        public string Mark { get; set; }

        public StatementType StatementType { get => StatementType.Command; }

        public override string ToString()
        {
            return $"BEGIN TRANSACTION {Name} WITH MARK '{Mark}'";
        }

    }
}
