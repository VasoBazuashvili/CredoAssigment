using Microsoft.EntityFrameworkCore;
using StudentAPI.Db.Entities;
using StudentAPI.Db.Mapping;

namespace StudentAPI.Db
{
	public class StudentDbContext : DbContext
	{
		public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
		{
			
		}
		public DbSet<Students>	Students { get; set; }
		public DbSet<Subjects> Subjects { get; set; }
		public DbSet<Grades> Grades { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new StudentMapping());
			builder.ApplyConfiguration(new SubjectMapping());
			builder.ApplyConfiguration(new GradeMapping());

			base.OnModelCreating(builder);
		}
	}
}
