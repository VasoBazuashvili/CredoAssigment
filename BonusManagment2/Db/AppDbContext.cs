using BonusManagment2.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace BonusManagment2.Db
{
	public class AppDbContext : DbContext
	{
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Bonus> Bonuses { get; set; }


		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}
	}
}
