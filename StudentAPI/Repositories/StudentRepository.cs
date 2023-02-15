using StudentAPI.Db;
using StudentAPI.Db.Entities;
using StudentAPI.Models.Requests;


namespace StudentAPI.Repositories
{
	public interface IStudentRepository
	{
		Task<int> AddStudentAsync(RegisterStudentRequest request); 
	}
	public class StudentRepository : IStudentRepository
	{
		private readonly StudentDbContext _db;
		
		public StudentRepository(StudentDbContext db) 
		{
			
			_db= db;
		}
		public async Task<int> AddStudentAsync(RegisterStudentRequest request)
		{
			var student = new Students();
			student.FirstName = request.FirtName;
			student.LastName = request.FirtName;
			student.IdNumber = request.IdNumber;
			student.Course= request.Course;

			await _db.AddAsync(student);
			await _db.SaveChangesAsync();
			return student.Id;
		}

	}
}
