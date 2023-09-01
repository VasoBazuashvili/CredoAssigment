using BookLibrary.DataAccess2.Context;
using BookLibrary.DataAccess2.Repository.Abstractions;
using BookLibrary.DataAccess2.Repository.Services;
using Microsoft.EntityFrameworkCore;


namespace BookLibrary.Infastructure
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddBookLibraryService (this IServiceCollection services,IConfiguration configuration) 
		{
			services.AddDbContext<BookLibraryContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("BookLibraryConnection")));
			services.AddScoped<IShelfRepo, ShelfRepo>();
			services.AddScoped<IBookRepo, BookRepo>();
			return services;
		}
	}
}
