using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Db;
using StudentAPI.Db.Entities;
using StudentAPI.Models.Requests;
using StudentAPI.Repositories;

namespace StudentAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SubjectController : ControllerBase
	{
		private readonly ISubjectRepository _subjectRepository;
		private readonly StudentDbContext _db;

		public SubjectController(ISubjectRepository subjectRepository, StudentDbContext db)
		{
			_subjectRepository = subjectRepository;
			_db = db;
		}

		[HttpPost("add-subject")]
		public async Task<IActionResult> Add([FromBody] RegisterSubjectRequest request)
		{
			await _subjectRepository.AddSubjectAsync(request);
			return Ok();
		}


		[HttpGet("top-3-subject")]
		public ActionResult<IEnumerable<Subjects>> GetTop3ByAverage()
		{
			var subjects = _db.Subjects.Select(sub => new
			{
				Subject = sub,
				AverageScore = _db.Grades.Where(g => g.SubjectId == sub.Id).Average(g => g.Score)
			}).OrderByDescending(sub => sub.AverageScore).Take(3).Select(sub => sub.Subject);

			return Ok(subjects);
		}

		[HttpGet("bottom-3-subject")]
		public ActionResult<IEnumerable<Subjects>> GetBottom3ByAverage()
		{
			var subjects = _db.Subjects.Select(sub => new
			{
				Subject = sub,
				AverageScore = _db.Grades.Where(g => g.SubjectId == sub.Id).Average(g => g.Score)
			}).OrderBy(sub => sub.AverageScore).Take(3).Select(sub => sub.Subject);

			return Ok(subjects);
		}
	}
}
