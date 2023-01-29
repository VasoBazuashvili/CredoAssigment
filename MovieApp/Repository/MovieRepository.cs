using Microsoft.EntityFrameworkCore;
using MovieApp.Db;
using MovieApp.Models;
using MovieApp.Models.Requests;
using System.Linq;

namespace MovieApp.Repository
{
	public interface IMovieRepository
	{
		Task Add(AddMovie request);
		Task<Movie> Get(GetMovieRequest request);
		Task<List<Movie>> Search(SearchMovie request, int pageSize, int pageIndex);
		Task UpdateAsync(UpdateMovie request);
		Task Delete(DeleteMovie request);
	}

	public class MovieRepository : IMovieRepository
	{
		private readonly AppDbContext _db;
		public MovieRepository(AppDbContext db)
		{
			_db = db;
		}
		public async Task Add(AddMovie request)
		{
			var entity = new Movie();
			entity.CreatedDate = DateTime.Now;
			entity.Title = request.Title;
			entity.Description = request.Description;
			entity.Director = request.Director;
			entity.Status = Models.Enums.MovieStatus.Active;
			entity.MovieCreatedYear = request.ReleaseYear;

			await _db.Movies.AddAsync(entity);
		}

		public async Task<Movie> Get(GetMovieRequest request)
		{
			var entity = await _db.Movies.FirstAsync(m => m.Id == request.Id);
			return new Movie
			{
				Id = entity.Id
			};
		}

		public async Task<List<Movie>> Search(SearchMovie request, int pageSize, int pageIndex)
		{
			var entity = _db.Movies
				.Where(t => t.Description == request.Description ||
							t.Director == request.Director ||
							t.Title == request.Title ||
							t.MovieCreatedYear == request.ReleaseYear)
				.Skip(pageIndex * pageSize)
				.Take(pageSize)
				.ToList();

			return entity;
		}

		public async Task UpdateAsync(UpdateMovie request)
		{
			var movie = _db.Movies.FindAsync(request).Result;
			if (request.Title != null) { movie.Title = request.Title; }
			if (request.Description != null) { movie.Description = request.Description; }
			if (request?.ReleaseYear != null) { movie.MovieCreatedYear = request.ReleaseYear; }
			if (request?.Director != null) { movie.Director = request.Director; }
			movie.CreatedDate = DateTime.Now;
			movie.Status = Models.Enums.MovieStatus.Active;
			movie.Id = request.Id;
			await _db.AddAsync(movie);
		}

		public async Task Delete(DeleteMovie request)
		{
			var entity = _db.Movies.Where(t => t.Id == request.Id);
			_db.Remove(entity);
			await _db.SaveChangesAsync();
		}
	}
}
