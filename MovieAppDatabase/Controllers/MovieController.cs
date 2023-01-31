using Microsoft.AspNetCore.Mvc;
using MovieAppDatabase.Models;
using MovieAppDatabase.Repository;

namespace MovieAppDatabase.Controllers
{
	public class MoviesController : ControllerBase
	{
		private readonly IMovieRepository _movieRepository;

		public MoviesController(IMovieRepository movieRepository)
		{
			_movieRepository = movieRepository;
		}

		[HttpPost]
		[Route("add")]
		public async Task<IActionResult> AddMovie([FromBody] Movie movie)
		{
			try
			{
				if (string.IsNullOrEmpty(movie.Name))
				{
					return BadRequest("Movie name is required");
				}

				if (string.IsNullOrEmpty(movie.ShortDescription))
				{
					return BadRequest("Short description is required");
				}

				if (movie.ReleaseYear < 1895)
				{
					return BadRequest("Release year must be at least 1895");
				}

				if (string.IsNullOrEmpty(movie.Director))
				{
					return BadRequest("Director is required");
				}

				await _movieRepository.AddMovie(movie);
				return Ok();
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpGet]
		[Route("get/{id}")]
		public IActionResult GetMovie(int id)
		{
			var movie = _movieRepository.GetMovie(id);
			if (movie == null)
			{
				return NotFound();
			}

			return Ok(movie);
		}

		[HttpGet]
		[Route("search")]
		public async Task<ActionResult<IEnumerable<Movie>>> SearchMovie(string query)
		{
			var movies = await _movieRepository.SearchMovie(query);
			return Ok(movies);
		}

		[HttpPut]
		[Route("update")]
		public async Task<ActionResult<bool>> UpdateMovie(int id, [FromBody] Movie movie)
		{
			var result = await _movieRepository.UpdateMovie(id, movie);
			if (!result)
			{
				return NotFound();
			}

			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMovie(int id)
		{
			var success = await _movieRepository.DeleteMovie(id);
			if (!success)
			{
				return NotFound();
			}

			return NoContent();
		}
	}

}

