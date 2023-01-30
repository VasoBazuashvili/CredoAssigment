using Microsoft.EntityFrameworkCore;
using MovieAppDatabase.Models;

namespace MovieAppDatabase.Db
{
	public class MovieContext : DbContext
	{
		public MovieContext(DbContextOptions<MovieContext> options)
	   : base(options)
		{
		}
		public DbSet<Movie>	Movies { get; set; }
	}
}
