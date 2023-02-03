using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentAPI.Db.Entities;

namespace StudentAPI.Db.Mapping
{
	public class GradeMapping : IEntityTypeConfiguration<Grades>
	{
		public void Configure(EntityTypeBuilder<Grades> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.StudentId).IsRequired();
			builder.Property(x=>x.SubjectId).IsRequired();
			builder.Property(x=>x.Score).IsRequired();
		}
	}
}
