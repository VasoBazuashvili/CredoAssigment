using TodoApp.Db;
using TodoApp.Db.Entities;

namespace TodoApp.Repositories
{
	public interface ITodoRepository
	{
		Task InsertAsync(int userId, string title, string description, DateTime deadline);
		Task SaveChangesAsync();
	}
	public class TodoRepository : ITodoRepository
	{
		private readonly AppDbContext _db;

		public TodoRepository(AppDbContext db)
		{
			_db = db;
		}

		public async Task InsertAsync(
			int userId,
			string title,
			string description,
			DateTime deadline)
		{
			var entity = new TodoEntity();
			entity.UserId = userId;
			entity.Title = title;
			entity.Description = description;
			entity.Deadline = deadline;
			entity.Status = TodoEntity.TodoStatus.New;
			entity.CreatedAt = DateTime.UtcNow;

			await _db.Todos.AddAsync(entity);
		}

		public List<TodoEntity> Search(string filter, int pageSize, int pageIndex)
		{
			var entities = _db.Todos
				.Where(t => t.UserId == 1)
				.Where(t => t.Title.Contains(filter))
				.Skip(pageIndex * pageSize)
				.Take(pageSize)
				.OrderBy(t => t.Deadline)
				.ToList();

			return entities;
		}

		public async Task SaveChangesAsync()
		{
			await _db.SaveChangesAsync();
		}
	}
}
