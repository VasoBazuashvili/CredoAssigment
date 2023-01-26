using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoApp.Db.Entities;

namespace TodoApp.Db
{
	public class AppDbContext : IdentityDbContext<UserEntity, RoleEntity, int>
	{
		public DbSet<SendEmailRequestEntity> SendEmailRequests { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
	}
}
