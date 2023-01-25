using System.Collections.Generic;

using SEFI.Infrastructure.Common.Enums;
namespace SEFI.Infrastructure.Common.Interfaces
{
    public interface IFilters : IFilter
    {
        List<KeyValuePair<IFilter, LogicOperator>> FilterList { get; }
    }
}
