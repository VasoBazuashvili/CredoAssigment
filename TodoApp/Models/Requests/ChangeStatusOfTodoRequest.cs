using static TodoApp.Db.Entities.TodoEntity;

namespace TodoApp.Models.Requests
{
	public class ChangeStatusOfTodoRequest
	{
		public int TodoId { get; set; }
		public TodoStatus NewStatus { get; set; }
	}
}
