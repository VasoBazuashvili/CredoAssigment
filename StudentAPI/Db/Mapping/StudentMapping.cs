using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentAPI.Db.Entities;

namespace StudentAPI.Db.Mapping
{
	public class StudentMapping : IEntityTypeConfiguration<Students>
	{
		public void Configure(EntityTypeBuilder<Students> builder)
		{
			builder.HasKey(t => t.Id);
			builder.Property(t => t.FirstName).HasMaxLength(200).IsRequired();
			builder.Property(t => t.LastName).HasMaxLength(200).IsRequired();
			builder.Property(t => t.IdNumber).HasMaxLength(11).IsRequired();
			builder.Property(t => t.Course).IsRequired();
		}
	}
}
