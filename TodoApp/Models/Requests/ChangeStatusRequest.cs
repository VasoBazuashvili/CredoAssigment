using static TodoApp.Db.Entities.TodoEntity;

namespace TodoApp.Models.Requests
{
	public class ChangeStatusRequest
	{
		public int TodoId { get; set; }
		public TodoStatus NewStatus { get; set; }
	}
}
