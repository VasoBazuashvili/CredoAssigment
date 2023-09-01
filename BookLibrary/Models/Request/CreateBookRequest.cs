namespace BookLibrary.Models.Request
{
	public class CreateBookRequest
	{
		public int ShelfId { get; set; }
		public string Title { get; set; }
		public string ISBN { get; set; }
		public string Description { get; set; }
	}
}
