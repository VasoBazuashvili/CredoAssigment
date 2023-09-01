namespace BookLibrary.Models.Request
{
	public class MoveToRequest
	{
		public int Id { get; set; }
		public int ShelfId { get; set; }
		public string Title { get; set; }
		public string ISBN { get; set; }
		public string Description { get; set; }
	}
}
