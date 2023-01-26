using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoApp.Db.Entities;
using TodoApp.Repositories;

namespace TodoApp.Db
{
	public class AppDbContext : IdentityDbContext<UserEntity, RoleEntity, int>
	{
		public DbSet<SendEmailRequestEntity> SendEmailRequests { get; set; }
		public DbSet<TodoEntity> Todos { get; set; }
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
	}
}
