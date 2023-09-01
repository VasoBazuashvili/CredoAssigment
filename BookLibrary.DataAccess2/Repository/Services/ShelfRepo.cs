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
	public class ShelfRepo : IShelfRepo
	{
		private readonly BookLibraryContext _context;

		public ShelfRepo(BookLibraryContext context)
		{
			_context = context;
		}
		public async Task AddEntityAsync(Shelf shelf)
		{
			await _context.AddAsync(shelf);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(int Id)
		{
			var shelf = await GetByKey(Id);
			if (shelf is null)
				throw new NullReferenceException("Object is Null");
			_context.Remove(shelf);
			await _context.SaveChangesAsync();
		}

		public async Task<Shelf> GetByKey(int Id)
		{
			return await _context.Shelves.SingleOrDefaultAsync(x => x.Id == Id);
		}

		public async Task Update(Shelf shelf)
		{
			_context.Update(shelf);
			await _context.SaveChangesAsync();
		}
	}
}
