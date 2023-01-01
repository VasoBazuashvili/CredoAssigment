using BooksAndShelves.Models;

namespace BooksAndShelves.Requests.ShelfRequests
{
    public class DeleteShelfRequest
    {
        public int ShelfId { get; set; }
        public Shelf? Shelf { get; set; }
    }
}
