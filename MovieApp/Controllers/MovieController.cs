using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Models.Requests;
using MovieApp.Repository;

namespace MovieApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MovieController : ControllerBase
	{
		private readonly IMovieRepository _movieRepository;
		public MovieController(IMovieRepository movieRepository)
		{
			_movieRepository= movieRepository;
		}

		[HttpGet("getMovie")]
		public async Task<Movie> Add([FromBody] GetMovieRequest request)
		{
			return await _movieRepository.Get(request);
		}

		[HttpPost("addMovie")]
		public async Task Add([FromBody] AddMovie request)
		{
			await _movieRepository.Add(request);
		}

		[HttpPost("search")]
		public async Task<List<Movie>> Search([FromBody] SearchMovie request, int pageSize, int pageIndex)
		{
			return await _movieRepository.Search(request, pageSize, pageIndex);
		}

		[HttpPut("updateMovie")]
		public async Task Update([FromBody] UpdateMovie request)
		{
			await _movieRepository.Update(request);
		}

		[HttpDelete("deleteMovie")]
		public async void Delete([FromBody] DeleteMovie request)
		{
			await _movieRepository.Delete(request);
		}
	}
}
