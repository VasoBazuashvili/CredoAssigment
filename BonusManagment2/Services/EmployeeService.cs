using BonusManagment2.Db;
using BonusManagment2.Db.Entities;
using BonusManagment2.Models;
using Microsoft.EntityFrameworkCore;

namespace BonusManagment2.Services
{
	public interface IEmployeeService
	{
		Task<int> GetBonusesFromDateAsync(DateTime from);
		Task<List<MostBonusEmployeeRequest>> Top10EmployeeWithMostBonusAsync();
		Task GiveBonusAsync(Guid employeeId, double bonus);
		Task<List<MostBonusEmployeeRequest>> Top10RecommendatorWithMostBonusAsync();
		Task<Employee> AddEmployeeAsync(AddEmployeeRequest request);
		Task<List<Employee>> GetAllEmployAsync();
		Task SaveChangesAsync();
	}
	public class EmployeeService : IEmployeeService
	{
		private readonly AppDbContext _context;

		public EmployeeService(AppDbContext context)
		{
			_context = context;
		}
		private async Task<List<Bonus>> GenerateBonusForEmployeesAsync(
		   Guid employeeId,
		   double bonus)
		{
			var bonuses = new List<Bonus>();


			for (int i = 0; i < 3; i++)
			{
				var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);

				if (employee == null)
				{
					break;
				}

				var newBonus = new Bonus()
				{
					EmployeeId = employee.Id,
					Amount = bonus,
					CreatedAt = DateTime.UtcNow,
				};
				if (employee.RecommendatorId != Guid.Empty && i != 2)
				{
					newBonus.RecommendatorId = employee.RecommendatorId;
				}


				bonus /= 2;
				employeeId = employee.RecommendatorId;

				bonuses.Add(newBonus);


			}

			return bonuses;
		}

		public async Task GiveBonusAsync(Guid employeeId, double bonus)
		{
			var employee = await _context.Employees
				.FirstOrDefaultAsync(e => e.Id == employeeId);

			if (employee == null)
			{
				//for demo purposes
				throw new Exception("employee id is not correct");
			}
			if (bonus < employee.Salary / 2 || bonus > employee.Salary * 3)
			{
				throw new Exception("Bonus is depend on salary, invalid bonus");
			}

			var bonuses = await GenerateBonusForEmployeesAsync(employeeId, bonus);

			await _context.Bonuses.AddRangeAsync(bonuses);

		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}

		public async Task<int> GetBonusesFromDateAsync(DateTime from)
		{
			var bonuses = await _context.Bonuses.Where(b => b.CreatedAt > from).ToListAsync();
			return bonuses.Count;
		}


		private async Task<List<MostBonusEmployeeRequest>> GetEmployeesWithMostBonusAsync(
			Dictionary<Guid, double> dictionary
			)
		{
			var employees = _context.Employees;
			dictionary = dictionary
				.OrderByDescending(d => d.Value)
				.Take(10)
				.ToDictionary(d => d.Key, d => d.Value);

			var list = new List<MostBonusEmployeeRequest>();

			foreach (var item in dictionary)
			{
				var employee = await employees.FirstOrDefaultAsync(e => e.Id == item.Key);

				if (employee != null)
				{
					var mostBonusEmployee = new MostBonusEmployeeRequest()
					{
						Id = employee.Id,
						Amount = item.Value,
						FirstName = employee.FirstName,
						LastName = employee.LastName,
					};
					list.Add(mostBonusEmployee);
				}
			}

			return list;
		}

		public async Task<List<MostBonusEmployeeRequest>> Top10EmployeeWithMostBonusAsync()
		{
			var bonuses = _context.Bonuses;
			var dictionary = new Dictionary<Guid, double>();

			await bonuses.ForEachAsync(b =>
			{
				if (dictionary.ContainsKey(b.EmployeeId))
				{
					dictionary[b.EmployeeId] += b.Amount;
				}
				else
				{
					dictionary.Add(b.EmployeeId, b.Amount);
				}
			});

			var mostBonusedEmployees = await GetEmployeesWithMostBonusAsync(dictionary);

			return mostBonusedEmployees;
		}

		public async Task<List<MostBonusEmployeeRequest>> Top10RecommendatorWithMostBonusAsync()
		{
			var bonuses = _context.Bonuses;
			var dictionary = new Dictionary<Guid, double>();

			await bonuses.ForEachAsync(b =>
			{

				if (dictionary.ContainsKey(b.RecommendatorId))
				{
					dictionary[b.RecommendatorId] += b.Amount;
				}
				else
				{
					dictionary.Add(b.RecommendatorId, b.Amount);
				}
			});

			var top10 = await GetEmployeesWithMostBonusAsync(dictionary);

			return top10;
		}

		public async Task<Employee> AddEmployeeAsync(AddEmployeeRequest request)
		{
			var recommendator = await _context.Employees.FirstOrDefaultAsync(e => e.Id == request.RecommendatorId);

			var newEmployee = new Employee()
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				PersonalNumber = request.PersonalNumber,
				Salary = request.Salary,
			};

			if (recommendator != null)
			{
				newEmployee.RecommendatorId = recommendator.Id;
			}


			await _context.Employees.AddAsync(newEmployee);

			await _context.SaveChangesAsync();

			return newEmployee;
		}

		public async Task<List<Employee>> GetAllEmployAsync()
		{
			return await _context.Employees.ToListAsync();
		}
	}
}
