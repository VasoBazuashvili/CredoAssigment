using BooksAndShelves.Models;
using BooksAndShelves.Requests.BookRequests;
using BooksAndShelves.Requests.ShelfRequests;

namespace BooksAndShelves.Services
{
    public class ShelfService
    {
        public static List<Shelf> Shelves { get; set; }
        private static int _id = 1;
        private static int _bookId = 1;
        static ShelfService()
        {
            Shelves = new List<Shelf>();
        }

        public Shelf Create(CreateShelfRequest request)
        {
            var shelf = new Shelf
            {
                Id = _id++,
                Name = request.Name,

            };
            Shelves.Add(shelf);

            return shelf;
        }

        public Shelf? Rename(RenameShelfRequest request)
        {
            var shelf = Shelves.Find(s => s.Id == request.ShelfId);
            if (shelf == null)
            {
                return null;
            }
            shelf.Name = request.NewName;
            return shelf;
        }

        public Shelf? Get(int shelfId)
        {
            var shelf = Shelves.Find(s => s.Id == shelfId);
            return shelf;
        }

        public List<Shelf> GetAll()
        {
            return Shelves;
        }
        public List<Shelf> Delete(DeleteShelfRequest request)
        {
            var shelf = Shelves.Find(s => s.Id == request.ShelfId);
            if (shelf == null)
            {
                return null;
            }
            if (request.Shelf.ValidateIfEmpty(shelf.Books))
            {
                Shelves.Remove(shelf);
            }

            return Shelves;
        }
        public Book AddToShelf(AddToShelfRequest request)
        {


            Book book = new Book
            {
                Id = _bookId++,
                Title = request.Title,
                ISBN = request.ISBN,
                Description = request.Description,
                ShelfId = request.ShelfId
            };
            var shelf = Shelves.Find(s => s.Id == book.ShelfId);
            shelf?.Books.Add(book);
            return book;

        }
        public void Remove(RemoveBookRequest request)
        {
            foreach (var shelf in Shelves.ToList())
            {
                foreach (var book in shelf.Books.ToList())
                {
                    if (book.Id == request.BookId)
                    {
                        shelf.Books.Remove(book);

                    }
                }
            }
        }
        public void MoveToShelf(MoveToShelfRequest request)
        {
            var NewShelf = Shelves.Find(s => s.Id == request.NewShelfID);

            foreach (var shelf in Shelves.ToList())
            {
                foreach (var book in shelf.Books.ToList())
                {
                    if (book.Id == request.BookId)
                    {
                        book.ShelfId = request.NewShelfID;
                        shelf.Books.Remove(book);
                        NewShelf.Books.Add(book);
                    }
                }
            }

        }
    }
}
