using Microsoft.AspNetCore.Identity;

namespace ToddApp_Api.Entities
{
	public class ToDoEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime DeadLine { get; set; }
		public TodoStatus Status { get; set; }

	}
}
