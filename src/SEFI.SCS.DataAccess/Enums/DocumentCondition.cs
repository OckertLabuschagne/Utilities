using System.ComponentModel;

namespace SEFI.Domain.Enums
{
    public enum DocumentCondition : int
    {
        [Description("Optional")]
        OPT = 1,
        [Description("Required to deny claim")]
        RDC = 2,
        [Description("Required to pay claim")]
        RPC = 3,
        [Description("Required to send after claim is approved to pay")]
        RAP = 4,
        [Description("Required to send when claim is created")]
        RCC = 5,
        [Description("Required when claim is denied")]
        RCD = 6
    }
}
