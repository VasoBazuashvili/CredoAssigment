using BonusManagmentSystem.Database;
using BonusManagmentSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BonusManagmentSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly AppDbContext _context;

		public EmployeesController(AppDbContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult GetEmployees()
		{
			var employees = _context.Employees.ToList();
			return Ok(employees);
		}

		[HttpGet("{id}")]
		public IActionResult GetEmployeeById(int id)
		{
			var employee = _context.Employees.FirstOrDefault(e => e.Id == id);

			if (employee == null)
			{
				return NotFound();
			}

			return Ok(employee);
		}

		[HttpPost]
		public IActionResult CreateEmployee(Employee employee)
		{
			_context.Employees.Add(employee);
			_context.SaveChanges();

			return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
		}

		[HttpPost("{id}/bonuses")]
		public IActionResult IssueBonus(Employee employee, decimal amount, DateTime dateIssued)
		{
			if (employee == null)
			{
				return NotFound();
			}

			IssueBonus(employee, amount, dateIssued);

			_context.SaveChanges();

			return Ok();
		}


		[HttpGet("top-bonus-receivers")]
		public IActionResult GetTopBonusReceivers()
		{
			var employees = _context.Employees
				.OrderByDescending(e => e.BonusesReceived.Sum(b => b.Amount))
				.Take(10)
				.ToList();

			return Ok(employees);
		}

		[HttpGet("top-referral-bonuses")]
		public IActionResult GetTopReferralBonuses()
		{
			var employees = _context.Employees
				.Where(e => e.RecommenderId.HasValue)
				.OrderByDescending(e => e.BonusesReceived.Where(b => b.EmployeeId == e.RecommenderId.Value).Sum(b => b.Amount))
				.Take(10)
				.ToList();

			return Ok(employees);
		}
	}
}
