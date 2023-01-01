namespace BooksAndShelves.Models
{
    public class Shelf
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Book> Books { get; set; }

        public Shelf()
        {
            Books = new List<Book>();
        }
        public bool ValidateIfEmpty(List<Book> Books)
        {
            if (Books == null || Books.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
