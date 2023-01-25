using System.Collections.Generic;

namespace SEFI.DataUtilities.TSQL
{
    public class Function
    {
        public string Name { get; set; }
        public List<object> Parameters { get; protected set; }
    }
}
