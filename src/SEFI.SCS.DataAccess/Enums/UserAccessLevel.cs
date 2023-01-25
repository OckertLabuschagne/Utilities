using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace SEFI.Domain.Enums
{
    public enum UserAccessLevel : int
    {
        [Description("None")]
        None = 0,
        [Description("View Only")]
        ViewOnly = 1,
        [Description("View and Attach")]
        ViewAndAttach = 2
    }
}
