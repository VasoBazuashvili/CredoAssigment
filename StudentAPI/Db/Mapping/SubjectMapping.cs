using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentAPI.Db.Entities;

namespace StudentAPI.Db.Mapping
{
	public class SubjectMapping : IEntityTypeConfiguration<Subjects>
	{
		public void Configure(EntityTypeBuilder<Subjects> builder)
		{
			builder.HasKey(t => t.Id);
			builder.Property(t => t.subjectName).HasMaxLength(50).IsRequired();
			builder.Property(t=>t.Credits).IsRequired();
		}
	}
}
