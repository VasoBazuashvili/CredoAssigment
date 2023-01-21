﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using ToddApp_Api.DB;
using ToddApp_Api.Entities;

namespace ToddApp_Api.Auth
{
	public static class AuthConfigurator
	{
		public static void Configure(WebApplicationBuilder builder)
		{
			var issuer = builder.Configuration["Jwt:Issuer"]!;
			var audience = builder.Configuration["Jwt:Audience"]!;
			var key = builder.Configuration["Jwt:Key"]!;

			builder.Services.Configure<JwtSettings>(s =>
			{
				s.Issuer= issuer;
				s.Audience = audience;
				s.SecrectKey= key;
			});
			builder.Services.AddTransient<TokenGenerator>();

			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				ValidIssuer = issuer,
				ValidAudience = audience,
				ClockSkew = TimeSpan.Zero,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
			};
			builder.Services
			.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = tokenValidationParameters;
			});

			builder.Services.AddAuthorization(options =>
			{
				options.AddPolicy("ApiUser",
					policy => policy.RequireClaim(ClaimTypes.Role, "api-user"));

				options.AddPolicy("ApiAdmin",
					policy => policy.RequireClaim(ClaimTypes.Role, "api-admin"));
			});

			builder.Services.AddIdentity<UserEntity, RoleEntity>(o =>
			{
				o.Password.RequireDigit = false;
				o.Password.RequireLowercase = false;
				o.Password.RequireUppercase = false;
				o.Password.RequireNonAlphanumeric = false;
				o.Password.RequiredLength = 8;
			})
				.AddEntityFrameworkStores<AppDbContext>()
				.AddDefaultTokenProviders();
		}
	}
}