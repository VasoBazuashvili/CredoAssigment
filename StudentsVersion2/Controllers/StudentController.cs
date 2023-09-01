using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsVersion2.Db;
using StudentsVersion2.Models;

namespace StudentsVersion2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly AppDbContext _context;

		public StudentController(AppDbContext context)
		{
			_context = context;
		}

		[HttpPost]
		public async Task<ActionResult<Student>> RegisterStudent(Student student)
		{
			_context.Studentss.Add(student);
			await _context.SaveChangesAsync();
			return Ok(student);

			//return CreatedAtAction("GetStudent", new { id = student.Id }, student);
		}

		[HttpGet("{id}/grades")]
		public async Task<ActionResult<IEnumerable<Grade>>> GetStudentGrades(int id)
		{
			var studentGrades = await _context.Gradess
				.Where(g => g.StudentId == id)
				.ToListAsync();

			if (studentGrades == null)
			{
				return NotFound();
			}

			return studentGrades;
		}
	}
}
