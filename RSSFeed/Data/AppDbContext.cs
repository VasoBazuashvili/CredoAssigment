using Microsoft.EntityFrameworkCore;
using RSSFeed.Models;

namespace RSSFeed.Data
{
	public class AppDbContext : DbContext 
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Article> Articles { get; set; }
		public DbSet<Tag> Tags { get; set; }
	}
}
