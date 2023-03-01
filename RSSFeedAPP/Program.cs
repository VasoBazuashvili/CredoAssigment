// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RSSFeed.Data;
using RSSFeedAPP;

public class Program
{
	private static async Task Main(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
		optionsBuilder.UseSqlServer("Server=LAPTOP-3VTUC1S3;Database=RSSFeedDb;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=false;");
		var db = new AppDbContext(optionsBuilder.Options);
		db.Database.EnsureCreated();
		var rssFeedFetcherService = new NewsFeedFetcherService(db);
		await rssFeedFetcherService.FetchAndSaveArticlesAsync();
		Console.WriteLine("Parse is Done");
		CreateHostBuilder(args).Build().Run();
	}

	public static IHostBuilder CreateHostBuilder(string[] args) =>
		Host.CreateDefaultBuilder(args)
			.ConfigureServices((hostContext, services) =>
			{
				services.AddHostedService<Worker>();
				services.AddScoped<NewsFeedFetcherService>();
				services.AddDbContext<AppDbContext>(options =>
					options.UseSqlServer("Server=LocalHost;Database=RSSFeedDb;Trusted_Connection=true;MultipleActiveResultSets=True;Encrypt=False;"), ServiceLifetime.Scoped);
			});
}