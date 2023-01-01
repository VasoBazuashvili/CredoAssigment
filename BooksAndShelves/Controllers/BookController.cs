using BooksAndShelves.Models;
using BooksAndShelves.Requests.BookRequests;
using BooksAndShelves.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace BooksAndShelves.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private ShelfService _shelfService;
        public BookController()
        {
            _shelfService = new ShelfService();
        }
        [HttpPost]
        [Route("addToShelf")]
        public Book AddToShelf(AddToShelfRequest request)
        {
            return _shelfService.AddToShelf(request);
        }
        [HttpPost]
        [Route("Remove Book")]
        public void Remove(RemoveBookRequest request)
        {
            _shelfService.Remove(request);
        }
        [HttpPost]
        [Route("Move Book")]
        public void MoveToShelf(MoveToShelfRequest request)
        {
            _shelfService.MoveToShelf(request);
        }
    }
}
