using Microsoft.EntityFrameworkCore;
using StudentsVersion2.Models;

namespace StudentsVersion2.Db
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		public DbSet<Student> Studentss { get; set; }
		public DbSet<Subject> Subjectss { get; set; }
		public DbSet<Grade> Gradess { get; set; }
	}
}
