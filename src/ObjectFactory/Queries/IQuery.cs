using i = SEFI.Classes;
namespace SEFI.Queries
{
    public interface IQuery
    {
        i.Filters Filters { get; }
    }
}
