using System;
using System.Collections.Generic;
using System.Text;

namespace SEFI.DataUtilities.TSQL
{
    public interface IStatement
    {
        StatementType StatementType { get;  }
    }
}
