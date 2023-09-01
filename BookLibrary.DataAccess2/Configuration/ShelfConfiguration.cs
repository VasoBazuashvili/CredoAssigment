using BookLibrary.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DataAccess2.Configuration
{
	public class ShelfConfiguration : IEntityTypeConfiguration<Shelf>
	{
		public void Configure(EntityTypeBuilder<Shelf> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name).IsRequired();
		}
	}
}
