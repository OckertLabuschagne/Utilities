using System;
using System.Collections.Generic;
using System.Text;

namespace SEFI.DataUtilities.TSQL
{
    public class CommitTransaction : IStatement
    {
        public string Name { get; set; }
        public bool? DelayedDurability { get; set; }

        public StatementType StatementType { get => StatementType.Command; }

        string DelDurability { get => DelayedDurability.Value ? "ON" : "OFF"; }

        public override string ToString()
        {
            return DelayedDurability == null ? $"COMMIT TRANSACTION {Name}" : $"COMMIT TRANSACTION {Name} DELAYED_DURABILITY = {DelDurability}";
        }
    }
}
