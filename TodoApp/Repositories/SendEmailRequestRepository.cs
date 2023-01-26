using TodoApp.Db.Entities;
using TodoApp.Db;

namespace TodoApp.Repositories
{
	public interface ISendEmailRequestRepository
	{
		void Insert(SendEmailRequestEntity entity);
		Task SaveChangesAsync();
	}
	public class SendEmailRequestRepository : ISendEmailRequestRepository
	{
		private readonly AppDbContext _db;

		public SendEmailRequestRepository(AppDbContext db)
		{
			_db = db;
		}

		public void Insert(SendEmailRequestEntity entity)
		{
			_db.SendEmailRequests.Add(entity);
		}

		public async Task SaveChangesAsync()
		{
			await _db.SaveChangesAsync();
		}
	}
}
