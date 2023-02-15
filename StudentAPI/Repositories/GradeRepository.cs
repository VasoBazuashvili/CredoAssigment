using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Db;
using StudentAPI.Db.Entities;
using StudentAPI.Models;
using StudentAPI.Models.Requests;
using System.Collections;
using System.Net;

namespace StudentAPI.Repositories
{
	public interface IGradeRepository
	{
		Task Add(AddStudentGradeRequest request);
		Task<IEnumerable<Grades>> GetAllAsync();
		Task UpdateStudentGPA(int studentId, double gpa);
		Task<List<StudentGrade>> GetStudentGradesAsync(int id);

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
			entity.SubjectId = request.SubjectId;
			entity.Score = request.Score;
			entity.StudentId = request.StudentId;
			if (request.Score < 0 && request.Score > 100)
			{
				throw new ArgumentException("Grade can not be less than 0 and more than 100");
			}
			await _db.AddAsync(entity);
			await _db.SaveChangesAsync();
		}

		public async Task<List<StudentGrade>> GetStudentGradesAsync(int id)
		{
			var student = await _db.Students.FindAsync(id);

			if (student == null)
			{
				throw new ArgumentException("student not found");
			}

			var studentGrades = _db.Grades
				.Include(g => g.Subject)
				.Where(g => g.StudentId == id)
				.Select(g => new StudentGrade
				{
					Credits = g.Subject.Credits,
					Score = g.Score,
				})
				.ToList();

			return studentGrades;
		}

		public async Task UpdateStudentGPA(int studentId, double gpa)
		{
			var student = await _db.Students.FindAsync(studentId);
			student!.GPA = gpa;
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
