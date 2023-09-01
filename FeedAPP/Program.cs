// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
// Create a new instance of the RssFeedService class
using Microsoft.EntityFrameworkCore;
using RSSFeed.Data;
using RSSFeed.Service;

Console.WriteLine("Hello bitches");
var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
	.UseInMemoryDatabase(databaseName: "FeedDb")
	.Options;
var context = new AppDbContext(dbContextOptions);
var rssFeedService = new NewsFeedService(context);

// Add some sample feeds to the database
var feedUrls = new List<string>
{
	"https://www.hanselman.com/blog/rss.aspx",
	"https://feeds.feedburner.com/ScottHanselman"
};
await rssFeedService.AddNewArticlesFromRssFeeds(feedUrls);

// Get the list of articles from the database
var articles = await context.Articles
	.Include(a => a.Tags)
	.ToListAsync();

// Output the list of articles to the console
foreach (var article in articles)
{
	Console.WriteLine($"Title: {article.Title}");
	Console.WriteLine($"Description: {article.Description}");
	Console.WriteLine($"Tags: {string.Join(", ", article.Tags.Select(t => t.Name))}");
	Console.WriteLine();
}


