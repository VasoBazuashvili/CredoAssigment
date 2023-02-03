using Microsoft.EntityFrameworkCore;
using StudentAPI.Db;
using StudentAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<StudentDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StudentConnection")));
builder.Services.AddTransient<IStudentRepository,StudentRepository>();
builder.Services.AddTransient<ISubjectRepository,SubjectRepository>();
builder.Services.AddTransient<IGradeRepository,GradeRepository>();
builder.Services.AddTransient<IGPARepository,GPARepository>();
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
