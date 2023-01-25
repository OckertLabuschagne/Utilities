using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITester.Models.Enums
{
    public enum FilterOperator
    {
        Equal = 0,
        Not_Equal = 1,
        Less_Than = 2,
        Less_Than_Or_Equal = 3,
        Greater_Than = 4,
        Greater_Than_Or_Equal = 5,
        In = 6,
        Between = 7,
        Like = 8,
        Contains = 9,
        Is_Null = 10,
        Is_Not_Null = 11,
        Start_With = 12,
        ISNULL_Equal = 13,
        ISNULL_Not_Equal = 14,
        ISNULL_Less_Than = 15,
        ISNULL_Less_Than_Or_Equal = 16,
        ISNULL_Greater_Than = 17,
        ISNULL_Greater_Than_Or_Equal = 18
    }
}
