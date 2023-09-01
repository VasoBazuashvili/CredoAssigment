using BookLibrary.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DataAccess.Configuration
{
	internal class BookConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Book> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.Shelf).WithMany(x => x.Books).HasForeignKey(x => x.ShelfId);
		}
	}
}
