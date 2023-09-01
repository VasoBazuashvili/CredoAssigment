using BookLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DataAccess2.Repository.Abstractions
{
	public interface IBookRepo
	{
		Task AddBookAsync(Book book);
		Task BookMoveTo(Book book);
		Task Delete(int Id);
	}
}
