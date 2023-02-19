﻿using Ganss.Xss;
using Microsoft.EntityFrameworkCore;
using RSSFeed.Data;
using RSSFeed.Models;
using Serilog;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Xml;

namespace RSSFeed.Service
{
	public interface INewsFeedService
	{
		Task FetchAndSaveArticlesAsync();
		Task<List<SyndicationFeed>> LoadFeedAsync(List<string> strXML);
	}
	public class NewsFeedService : INewsFeedService
	{
		private readonly AppDbContext _db;

		public NewsFeedService(AppDbContext db)
		{
			_db = db;
		}

		public async Task<List<SyndicationFeed>> LoadFeedAsync(List<string> strXML)
		{
			var tasks = strXML.Select(async url =>
			{
				using var reader = XmlReader.Create(url);
				var feed = SyndicationFeed.Load(reader);

				return await Task.FromResult(feed);
			});

			return (await Task.WhenAll(tasks)).ToList();
		}

		private static string SanitizeText(string input)
		{
			var sanitizer = new HtmlSanitizer();
			sanitizer.AllowedAttributes.Add("class");
			sanitizer.AllowedTags.Remove("script");
			sanitizer.AllowedTags.Remove("style");
			return sanitizer.Sanitize(input);
		}

		public async Task FetchAndSaveArticlesAsync()
		{
			List<string> feedUrl = new List<string>
			{
				"https://stackoverflow.blog/feed/",
				"https://dev.to/feed",
				"https://www.freecodecamp.org/news/rss",
				"https://martinfowler.com/feed.atom",
				"https://codeblog.jonskeet.uk/feed/",
				"https://devblogs.microsoft.com/visualstudio/feed/",
				"https://feed.infoq.com/",
				"https://css-tricks.com/feed/",
				"https://codeopinion.com/feed/",
				"https://andrewlock.net/rss.xml",
				"https://michaelscodingspot.com/index.xml",
				"https://www.tabsoverspaces.com/feed.xml"
			};

			var feeds = await LoadFeedAsync(feedUrl);

			var tags = await _db.Tags.ToListAsync();

			//foreach (var feed in feeds)
			await Task.WhenAll(feeds.Select(async feed =>
			{
				foreach (var item in feed.Items)
				{
					var title = SanitizeText(item.Title.Text);
					var description = SanitizeText(item.Summary.Text);

					var existingArticle = await _db.Articles
						.Where(a => a.Title == title && a.Link.Contains(feed.Links[0].Uri.Host))
						.FirstOrDefaultAsync();

					if (existingArticle == null)
					{
						var exsitingTag = tags.Where(t => title.Contains(t.Name) || description.Contains(t.Name)).ToList();

						var feedentity = new Article
						{
							Link = item.Links[0].Uri.ToString(),
							Title = title,
							Description = description,
							Author = SanitizeText(item.Authors[0].Name),
							Picture = item.Links.FirstOrDefault(l => l.MediaType == "image/jpeg")?.Uri.ToString(),
							Tags = SanitizeText(string.Join(",", item.Categories.Select(c => c.Name))),
							PublishedDate = item.PublishDate.UtcDateTime
						};

						foreach (var category in item.Categories)
						{
							if (!tags.Any(t => t.Name == category.Name))
							{
								var tag = new Tag
								{
									Name = category.Name
								};

								_db.Tags.Add(tag);
								exsitingTag.Add(tag);
							}
						}

						feedentity.Tags += "," + string.Join(",", exsitingTag.Select(t => t.Name));

						_db.Articles.Add(feedentity);
						await _db.SaveChangesAsync();
					}
				}
			}));
		}
	}
}
