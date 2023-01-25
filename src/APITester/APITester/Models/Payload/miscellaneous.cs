namespace APITester.Models.Payload
{
	public class miscellaneous
	{
		public string MiscellaneousId { get; set; }
		public string Type { get; set; }
		public string Status { get; set; }
		public string RequestedUnitCost { get; set; }
		public string RequestedQuantity { get; set; }
		public string TaxAmount { get; set; }
		public string UnitCost { get; set; }
		public string Quantity { get; set; }
		public Servicer Servicer { get; set; }
		public Payee Payee { get; set; }
	}
}
