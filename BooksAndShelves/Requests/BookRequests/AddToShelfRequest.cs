namespace BooksAndShelves.Requests.BookRequests
{
    public class AddToShelfRequest
    {
        public int ShelfId { get; set; }
        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public string? Description { get; set; }
    }
}
