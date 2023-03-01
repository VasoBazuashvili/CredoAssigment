using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSFeedAPP
{
	public class Worker : BackgroundService
	{
		private readonly NewsFeedFetcherService _rssFeedFetcherService;

		public Worker(NewsFeedFetcherService rssFeedFetcherService)
		{
			_rssFeedFetcherService = rssFeedFetcherService;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				await _rssFeedFetcherService.FetchAndSaveArticlesAsync();
				await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
			}
		}
	}
}
