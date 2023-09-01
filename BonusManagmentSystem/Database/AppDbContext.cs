using BonusManagmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BonusManagmentSystem.Database
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Bonus> Bonuses { get; set; }


	}
}
