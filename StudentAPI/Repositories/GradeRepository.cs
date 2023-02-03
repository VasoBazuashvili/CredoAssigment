using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Db;
using StudentAPI.Db.Entities;
using StudentAPI.Models.Requests;
using System.Collections;
using System.Net;

namespace StudentAPI.Repositories
{
	public interface IGradeRepository
	{
		Task Add(AddStudentGradeRequest request);
		Task<IEnumerable<Grades>> GetAllAsync();
	}
	public class GradeRepository : IGradeRepository
	{
		private readonly StudentDbContext _db;
		public GradeRepository(StudentDbContext db) 
		{
			_db = db;
		}
		public async Task Add(AddStudentGradeRequest request)
		{
			var entity = new Grades();
			entity.SubjectId= request.SubjectId;
			entity.Score = request.Score;
			entity.StudentId = request.StudentId;
			if (request.Score < 0 && request.Score > 100)
			{
				throw new ArgumentException("Grade can not be less than 0 and more than 100");
			}
			await _db.AddAsync(entity);
			await _db.SaveChangesAsync();
		}

		public async Task<IEnumerable<Grades>> GetAllAsync()
		{
			await _db.Grades.ToListAsync();
			await _db.SaveChangesAsync();
			return _db.Grades;
		}
	}
}
