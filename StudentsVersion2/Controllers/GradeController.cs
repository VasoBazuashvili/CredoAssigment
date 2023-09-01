using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsVersion2.Db;
using StudentsVersion2.Models;

namespace StudentsVersion2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GradeController : ControllerBase
	{
		private readonly AppDbContext _context;
		public GradeController(AppDbContext context)
		{
			_context = context;
		}

		[HttpPost]
		public async Task<ActionResult<Grade>> AddGrade(int studentId, Grade grade)
		{
			grade.StudentId = studentId;

			_context.Gradess.Add(grade);
			await _context.SaveChangesAsync();
			return Ok(grade);

			//return CreatedAtAction("GetGrade", new { id = grade.Id }, grade);
		}

		[HttpGet("{id}/gpa")]
		public async Task<ActionResult<double>> GetStudentGPA(int id)
		{
			var student = await _context.Studentss.FindAsync(id);
			if (student == null)
			{
				return NotFound();
			}

			var studentGrades = _context.Gradess.Where(g => g.StudentId == id);
			if (!studentGrades.Any())
			{
				return NotFound();
			}

			double totalCredits = 0;
			double total = 0;
			foreach (var grade in studentGrades)
			{
				var subject = await _context.Subjectss.FindAsync(grade.SubjectId);
				if (subject == null)
				{
					return NotFound();
				}

				if (grade.Score >= 91 && grade.Score <= 100)
				{
					total += 4 * subject.Credits;
					totalCredits+= subject.Credits;
				}
				else if (grade.Score >= 81 && grade.Score <= 90)
				{
					total += 3 * subject.Credits;
					totalCredits+= subject.Credits;
				}
				else if (grade.Score >= 71 && grade.Score <= 80)
				{
					total += 2*subject.Credits;
					totalCredits+= subject.Credits;
				}
				else if (grade.Score >= 61 && grade.Score <= 70)
				{
					total += 1* subject.Credits;
					totalCredits+= subject.Credits;
				}
				else if (grade.Score >= 51 && grade.Score <= 60)
				{
					total += 0.5*subject.Credits;
					totalCredits+= subject.Credits;
				}
				//totalCredits += subject.Credits;
				//total += subject.Credits * grade.Score;
			}

			double gpa = total / totalCredits;
			return Ok(gpa);
		}


	}
}
