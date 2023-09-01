using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Models
{
	public class Book
	{
		public int Id { get; set; }
		public int ShelfId { get; set; }
		public string Title { get; set; }
		public string ISBN { get; set; }
		public string Description { get; set; }

		public Shelf Shelf { get; set; }
	}
}
