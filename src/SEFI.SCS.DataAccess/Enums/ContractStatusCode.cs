using System.ComponentModel;

namespace SEFI.Domain.Enums
{
    public enum ContractStatusCode
    {
        [Description("Approved")]
        A,
        [Description("Closed")]
        C,
        [Description("Expired")]
        E,
        [Description("Pending")]
        P,
        [Description("Rejected")]
        R,
        [Description("Void")]
        V
    }
}
