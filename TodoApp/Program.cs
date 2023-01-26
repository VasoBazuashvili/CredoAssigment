using Microsoft.EntityFrameworkCore;
using TodoApp.Auth;
using TodoApp.Db;
using TodoApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
AuthConfigurator.Configure(builder);
builder.Services.AddDbContext<AppDbContext>(c =>
	c.UseSqlServer(builder.Configuration["AppDbContextConnection"]));

builder.Services.AddTransient<ISendEmailRequestRepository, SendEmailRequestRepository>();
builder.Services.AddTransient<ITodoRepository, TodoRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
