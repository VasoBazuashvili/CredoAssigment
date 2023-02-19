namespace RSSFeed.Service
{
	public class BackGroundService : BackgroundService
	{
		private readonly NewsFeedService _newsFeedService;

		public BackGroundService(NewsFeedService newsFeedService)
		{
			_newsFeedService = newsFeedService;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				await _newsFeedService.FetchAndSaveArticlesAsync();
				await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
			}
		}
	}
}
