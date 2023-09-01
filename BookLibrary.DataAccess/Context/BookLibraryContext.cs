using BookLibrary.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DataAccess.Context
{
	internal class BookLibraryContext : DbContext
	{
		public BookLibraryContext(DbContextOptions<BookLibraryContext> options) : base(options)
		{

		}

		public DbSet<Shelf> Shelves { get; set; }
		public DbSet<Book> Books { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfigurationsFromAssembly(typeof(BookLibraryContext).Assembly);
		}
	}
}
