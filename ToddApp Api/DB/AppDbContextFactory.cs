using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ToddApp_Api.DB
{
	public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
	{
		public AppDbContext CreateDbContext(string[] args)
		{
			Console.WriteLine(args[0]);
			var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
			optionBuilder.UseSqlServer(args[0]);
			return new AppDbContext(optionBuilder.Options);
		}
	}
}
