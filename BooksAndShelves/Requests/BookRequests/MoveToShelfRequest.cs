namespace BooksAndShelves.Requests.BookRequests
{
    public class MoveToShelfRequest
    {
        public int BookId { get; set; }
        public int NewShelfID { get; set; }
    }
}
