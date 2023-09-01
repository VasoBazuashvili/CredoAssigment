namespace BonusManagment2.Models
{
	public class MostBonusEmployeeRequest
	{
		public Guid Id { get; set; }
		public double Amount { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
	}
}
