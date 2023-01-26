namespace TodoApp.Db.Entities
{
	public class TodoEntity
	{
		public enum TodoStatus
		{
			New,
			Done,
			Canceled
		}

		
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime Deadline { get; set; }
		public TodoStatus Status { get; set; }
		public DateTime CreatedAt { get; set; }
		
	}
}
