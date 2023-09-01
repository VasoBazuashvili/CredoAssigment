namespace BonusManagmentSystem.Models
{
	public class Bonus
	{
		public int Id { get; set; }
		public int EmployeeId { get; set; }
		public Employee Employee { get; set; }
		public decimal Amount { get; set; }
		public DateTime DateIssued { get; set; }
	}
}
