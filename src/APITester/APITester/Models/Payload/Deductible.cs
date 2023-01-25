namespace APITester.Models.Payload
{
	public class deductible 
	{
		public string DeductibleId { get; set; }
		public string Status { get; set; }
		public string StatusReason { get; set; }
		public string RequestedQuantity { get; set; }
		public string AgreedQuantity { get; set; }
		public string Amount { get; set; }
		public string FinalAmount { get; set; }
		public Servicer Servicer { get; set; }
		public IssueRef[] Issues { get; set; }
		public Payee Payee { get; set; }
	}
}
