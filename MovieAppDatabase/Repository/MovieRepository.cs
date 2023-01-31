using Microsoft.EntityFrameworkCore;
using MovieAppDatabase.Db;
using MovieAppDatabase.Models;

namespace MovieAppDatabase.Repository
{
	public interface IMovieRepository
	{
		Task<bool> AddMovie(Movie movie);
		Task<Movie?> GetMovie(int id);
		Task<IQueryable<Movie>> SearchMovie(string query);
		Task<bool> UpdateMovie(int id,Movie movie);
		Task<bool> DeleteMovie(int id);



	}
	public class MovieRepository : IMovieRepository
	{
		private readonly MovieContext _context;

		public MovieRepository(MovieContext context)
		{
			_context = context;
		}

		public async Task<bool> AddMovie(Movie movie)
		{
			if (string.IsNullOrEmpty(movie.Name))
			{
				return false;
			}

			if (string.IsNullOrEmpty(movie.ShortDescription))
			{
				return false;
			}

			if (movie.ReleaseYear < 1895)
			{
				return false;
			}

			if (string.IsNullOrEmpty(movie.Director))
			{
				return false;
			}

			movie.DateOfCreation = DateTime.Now;
			movie.Status = MovieStatus.Active;

			await _context.Movies.AddAsync(movie);
			await _context.SaveChangesAsync();

			return true;
		}

		public async Task<Movie?> GetMovie(int id)
		{
			return await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
		}

		public async Task<IQueryable<Movie>> SearchMovie(string query)
		{
			return await Task.FromResult(_context.Movies
				.Where(m => m.Name.Contains(query) ||
							m.ShortDescription.Contains(query) ||
							m.Director.Contains(query) ||
							m.ReleaseYear.ToString().Contains(query)));
		}

		public async Task<bool> UpdateMovie(int id, Movie movie)
		{
			var movieToUpdate = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

			if (movieToUpdate == null)
			{
				return false;
			}

			movieToUpdate.Name = movie.Name;
			movieToUpdate.ShortDescription = movie.ShortDescription;
			movieToUpdate.ReleaseYear = movie.ReleaseYear;
			movieToUpdate.Director = movie.Director;

			await _context.SaveChangesAsync();

			return true;
		}

		public async Task<bool> DeleteMovie(int id)
		{
			var movieToDelete = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

			if (movieToDelete == null)
			{
				return false;
			}

			movieToDelete.Status = MovieStatus.Deleted;

			await _context.SaveChangesAsync();

			return true;
		}
	}
}

