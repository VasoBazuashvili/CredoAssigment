using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TodoApp.Db;
using TodoApp.Db.Entities;
using TodoApp.Models.Requests;

namespace TodoApp.Repositories
{
	public interface ITodoRepository
	{
		Task InsertAsync(int userId, string title, string description, DateTime deadline);
		void InsertAsync(TodoStatusEntity addTodoStatus);
		Task SaveChangesAsync();
		Task<IEnumerable<TodoEntity>> SearchAsync(int userId, string title);
		Task<bool> UpdateAsync(int id, UpdateTodoRequest request);
		Task ChangeStatus(ChangeStatusRequest request);
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

		public void InsertAsync(TodoStatusEntity addTodoStatus)
		{
			var entity = new TodoStatusEntity();
			addTodoStatus.Name = addTodoStatus.Name;
			entity.Name = addTodoStatus.Name;
			_db.AddAsync(entity);
		}

		public async Task<IEnumerable<TodoEntity>> SearchAsync(int userId, string title)
		{
			return await _db.Todos
				.Where(t => t.UserId == 1)
				.Where(t => t.Title.Contains(title))
				.OrderBy(t => t.Deadline)
				.ToListAsync();
		}
		public async Task<bool> UpdateAsync(int id, UpdateTodoRequest request)
		{
			var todo = await _db.Todos.FindAsync(id);

			if (todo == null)
			{
				return false;
			}

			todo.Title = request.Title;
			todo.Description = request.Description;
			todo.Deadline = request.DeadLine;

			await _db.SaveChangesAsync();

			return true;
		}

		public async Task ChangeStatus(ChangeStatusRequest request)
		{
			var todo = await _db.Todos.FirstOrDefaultAsync(t => t.Id == request.TodoId);
			if (todo == null)
			{
				throw new Exception("Could not find Todo");
			}
			todo.Status = request.NewStatus;
			await _db.SaveChangesAsync();
		}
	}
}
