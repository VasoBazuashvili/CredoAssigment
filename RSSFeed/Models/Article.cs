﻿namespace RSSFeed.Models
{
	public class Article
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public string? Link { get; set; }
		public string? Author { get; set; }
		public string? Picture { get; set; }
		public string? Summery { get; set; }
		public string? Tags { get; set; }
		public DateTimeOffset PublishedDate { get; set; }

	}
}
