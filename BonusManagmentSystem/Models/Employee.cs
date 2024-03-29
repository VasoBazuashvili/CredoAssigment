﻿namespace BonusManagmentSystem.Models
{
	public class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string PersonalNumber { get; set; }
		public decimal Remuneration { get; set; }
		public int? RecommenderId { get; set; }
		public Employee Recommender { get; set; }
		public DateTime EmploymentStartDate { get; set; }
		public List<Bonus> BonusesReceived { get; set; }
	}
}
