using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToddApp_Api.Entities;

namespace ToddApp_Api.DB
{
	public class AppDbContext : IdentityDbContext<UserEntity,RoleEntity,int>
	{
		public DbSet<SendEmailRequestEntity> SendEmailRequests { get; set; }	

		public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
		{
				
		}
		//public DbSet<ToDoEntity> Todos{ get; set; }
		//public DbSet<RoleEntity> Roles { get; set; }	
	}
}
