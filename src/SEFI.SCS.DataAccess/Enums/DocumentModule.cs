using System;
using System.Collections.Generic;
using System.Text;

namespace SEFI.Domain.Enums
{
    public enum DocumentModule : int
    {
        CLAIM = 1,
        CONTRACT = 2,
        SELLER = 3,
        CCFAX = 4,
        CANCEL = 5,
        SELLERRPT = 6,
        AGENT = 7,
        REMIT = 8,
        ALL = 9
    }
}
