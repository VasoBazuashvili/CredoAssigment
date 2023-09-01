using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsVersion2.Db;
using StudentsVersion2.Models;

namespace StudentsVersion2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SubjectController : ControllerBase
	{
		private readonly AppDbContext _context;

		public SubjectController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet("top-three-subjects")]
		public ActionResult<IEnumerable<Subject>> GetTop3ByAverage()
		{
			var subjects = _context.Subjectss.Select(sub => new
			{
				Subject = sub,
				AverageScore = _context.Gradess.Where(g => g.SubjectId == sub.Id).Average(g => g.Score)
			}).OrderByDescending(sub => sub.AverageScore).Take(3).Select(sub => sub.Subject);

			return Ok(subjects);
		}

		[HttpGet("bottom3average")]
		public ActionResult<IEnumerable<Subject>> GetBottom3ByAverage()
		{
			var subjects = _context.Subjectss.Select(sub => new
			{
				Subject = sub,
				AverageScore = _context.Gradess.Where(g => g.SubjectId == sub.Id).Average(g => g.Score)
			}).OrderBy(sub => sub.AverageScore).Take(3).Select(sub => sub.Subject);

			return Ok(subjects);
		}
	}
}

