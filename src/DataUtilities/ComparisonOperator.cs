using System;
using System.Collections.Generic;
using System.Text;

namespace SEFI.Infrastructure.Common.Enums
{
    public enum ComparisonOperator
    {
        Equal,
        NotEqual,
        IsNull,
        IsNotNull,
        GreaterThan,
        GreaterThanOrEqual,
        SmallerThan,
        SmallerThanOrEqual,
        In,
        Like,
        Between,
        IsNullOrWhiteSpace,
        IsNotNullNorWhiteSpace,
        Contains,
        StartsWith,
        EndsWith,
        IsEmpty,
        IsNotEmpty
    }
}
