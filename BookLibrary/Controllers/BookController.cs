using BookLibrary.DataAccess2.Repository.Abstractions;
using BookLibrary.Domain.Models;
using BookLibrary.Models.Request;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private readonly IBookRepo _bookRepo;
		public BookController(IBookRepo bookRepo)
		{
			_bookRepo = bookRepo;
		}

		[HttpPost]
		public async Task<IActionResult> AddBook(CreateBookRequest createBookRequest)
		{
			if (createBookRequest == null)
				return BadRequest();
			await _bookRepo.AddBookAsync(createBookRequest.Adapt<Book>());
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> MoveTo(MoveToRequest moveToRequest)
		{
			if (moveToRequest == null)
				return BadRequest();
			await _bookRepo.BookMoveTo(moveToRequest.Adapt<Book>());
			return Ok();
		}

		[HttpDelete("{Id}")]
		public async Task<IActionResult> Delete(int Id)
		{
			await _bookRepo.Delete(Id);
			return Ok();
		}
	}
}
