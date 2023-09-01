using BookLibrary.DataAccess2.Repository.Abstractions;
using BookLibrary.Domain.Models;
using BookLibrary.Models.Request;
using BookLibrary.Models.Response;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShelfController : ControllerBase
	{
		private readonly IShelfRepo _shelfRepo;

		public ShelfController(IShelfRepo shelfRepo)
		{
			_shelfRepo = shelfRepo;
		}
		[HttpGet("{Id}")]
		public async Task<IActionResult> GetById(int Id)
		{
			var result = await _shelfRepo.GetByKey(Id);

			return Ok(result.Adapt<ShelfResponse>());
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateShelfRequest shelfRequest)
		{
			await _shelfRepo.AddEntityAsync(shelfRequest.Adapt<Shelf>());
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> Rename(RenameShelfRequest renameShelfRequest)
		{
			await _shelfRepo.Update(renameShelfRequest.Adapt<Shelf>());
			return Ok();
		}

		[HttpDelete("{Id}")]
		public async Task<IActionResult> Delete(int Id)
		{
			await _shelfRepo.Delete(Id);
			return Ok();
		}
	}
}
