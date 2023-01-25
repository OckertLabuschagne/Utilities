using System.ComponentModel;
namespace SEFI.Domain.Enums
{
    public enum DocumentDirection : int
    {
        [Description("Both")]
        BOTH = 0,
        [Description("Incoming")]
        IN = 1,
        [Description("Outgoing")]
        OUT = 2
    }
}
