using System;
using System.Collections.Generic;
using System.Text;

namespace SEFI.Domain.Enums
{
	public enum CreditPaymentStatus : int
	{
		CreditCardIssued = 1,
		Reconciled = 2,
		Voided = 3,
		ReconciledAdjusted = 4,
		Reissued = 5,
		Pending = 6
	}
}
