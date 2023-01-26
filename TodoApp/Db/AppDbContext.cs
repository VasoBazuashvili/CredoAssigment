using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoApp.Db.Entities;

namespace TodoApp.Db
{
	public class AppDbContext : IdentityDbContext<UserEntity, RoleEntity, int>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
	}
}
