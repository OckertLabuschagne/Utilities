using System.ComponentModel;

namespace SEFI.Domain.Enums
{
    public enum PaymentType : int
    {
        [Description("ACH")]
        Cash = 1,
        [Description("CHK")]
        Check = 2,
        [Description("CRD")]
        CreditCard = 3
    }
}
