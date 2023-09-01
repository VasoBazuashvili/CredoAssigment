using BookLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DataAccess2.Repository.Abstractions
{
	public interface IShelfRepo
	{
		Task<Shelf> GetByKey(int Id);
		Task AddEntityAsync(Shelf shelf);
		Task Update(Shelf shelf);
		Task Delete(int Id);
	}
}
