using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.Db
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Movie>	Movies { get; set; }


	}
}
