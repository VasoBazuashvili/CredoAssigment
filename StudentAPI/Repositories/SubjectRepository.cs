using StudentAPI.Db;
using StudentAPI.Db.Entities;
using StudentAPI.Models.Requests;

namespace StudentAPI.Repositories
{
	public interface ISubjectRepository
	{
		Task AddSubjectAsync(RegisterSubjectRequest request);
	}
	public class SubjectRepository : ISubjectRepository
	{
		private readonly StudentDbContext _db;
		public SubjectRepository(StudentDbContext db) 
		{
			_db= db;
		}
		public async Task AddSubjectAsync(RegisterSubjectRequest request)
		{
			var entity = new Subjects();
			entity.subjectName = request.SubjectName;
			entity.Credits = request.Credits;
			await _db.AddAsync(entity);
			await _db.SaveChangesAsync();
		}
	}
}
