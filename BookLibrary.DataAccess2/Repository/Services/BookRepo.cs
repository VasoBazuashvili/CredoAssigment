using BookLibrary.DataAccess2.Context;
using BookLibrary.DataAccess2.Repository.Abstractions;
using BookLibrary.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DataAccess2.Repository.Services
{
	public class BookRepo : IBookRepo
	{
		private readonly BookLibraryContext _context;

		public BookRepo(BookLibraryContext context)
		{
			_context = context;
		}
		public async Task AddBookAsync(Book book)
		{
			await _context.AddAsync(book);
			await _context.SaveChangesAsync();
		}

		public async Task BookMoveTo(Book book)
		{
			_context.Update(book);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(int Id)
		{
			var result = await _context.Books.SingleOrDefaultAsync(x => x.Id == Id);
			if (result == null)
				throw new ArgumentNullException("Object is Null");
			_context.Remove(result);
			await _context.SaveChangesAsync();
		}
	}
}
