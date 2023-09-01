using BonusManagmentSystem.Database;
using BonusManagmentSystem.Models;

namespace BonusManagmentSystem.Repository
{
	public class EmployeeRepository
	{
		private readonly AppDbContext _context;
		public EmployeeRepository(AppDbContext context)
		{
			_context = context;
		}
		public void IssueBonus(Employee employee, decimal amount, DateTime dateIssued)
		{
			employee.BonusesReceived.Add(new Bonus
			{
				EmployeeId = employee.Id,
				Amount = amount,
				DateIssued = dateIssued
			});

			// If the employee has a recommender, issue a bonus to them as well
			if (employee.RecommenderId.HasValue)
			{
				Employee recommender = GetEmployeeById(employee.RecommenderId.Value);

				decimal referralBonus = amount * 0.5M;

				IssueBonus(recommender, referralBonus, dateIssued);

				// If the recommender has a recommender, issue a bonus to them as well
				if (recommender.RecommenderId.HasValue)
				{
					Employee secondLevelRecommender = GetEmployeeById(recommender.RecommenderId.Value);

					decimal secondLevelReferralBonus = referralBonus * 0.5M;

					IssueBonus(secondLevelRecommender, secondLevelReferralBonus, dateIssued);

					// If the second-level recommender has a recommender, issue a bonus to them as well
					if (secondLevelRecommender.RecommenderId.HasValue)
					{
						Employee thirdLevelRecommender = GetEmployeeById(secondLevelRecommender.RecommenderId.Value);

						decimal thirdLevelReferralBonus = secondLevelReferralBonus * 0.5M;

						IssueBonus(thirdLevelRecommender, thirdLevelReferralBonus, dateIssued);
					}
				}
			}
		}

		public decimal GetTotalBonusesIssued(DateTime date)
		{
			return _context.Bonuses.Where(b => b.DateIssued.Date == date.Date).Sum(b => b.Amount);
		}

		public List<Employee> GetTop10EmployeesByBonusesReceived()
		{
			return _context.Employees.OrderByDescending(e => e.BonusesReceived.Sum(b => b.Amount)).Take(10).ToList();
		}

		public List<Employee> GetTop10EmployeesByReferralBonus()
		{
			return _context.Employees
					.Where(e => e.RecommenderId.HasValue)
					.OrderByDescending(e => e.BonusesReceived.Where(b => b.EmployeeId == e.RecommenderId.Value).Sum(b => b.Amount))
					.Take(10)
					.ToList();
		}

		public Employee GetEmployeeById(int employeeId)
		{
			return _context.Employees.FirstOrDefault(e => e.Id == employeeId);
		}
	}
}
