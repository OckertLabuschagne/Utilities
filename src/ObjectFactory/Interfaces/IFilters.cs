using System.Collections.Generic;

using SEFI.Enums;
namespace SEFI.Interfaces
{
    public interface IFilters : IFilter
    {
        List<KeyValuePair<IFilter, LogicOperator>> FilterList { get; }
    }
}
