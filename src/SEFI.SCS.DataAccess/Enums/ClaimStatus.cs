using System.ComponentModel;

namespace SEFI.Domain.Enums
{
    public enum ClaimStatus : int
    {
        [Description("Paid")]
        Paid = 1,
        [Description("Requested")]
        Requested = 2,
        [Description("Authorized")]
        Authorized = 3,
        [Description("Approved To Pay")]
        ApprovedToPay = 4,
        [Description("Cancelled")]
        Cancelled = 5,
        [Description("Denied")]
        Denied = 6
    }
}
