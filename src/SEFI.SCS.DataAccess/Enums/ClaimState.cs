using System.ComponentModel;

namespace SEFI.Domain.Enums
{
    public enum ClaimState
    {
        [Description("Cancelled")]
        C,
        [Description("Denied")]
        D,
        [Description("Open")]
        O,
        [Description("Paid")]
        P,
        [Description("Void")]
        V
    }
}
