using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models.Requests;
using StudentAPI.Repositories;

namespace StudentAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SubjectController : ControllerBase
	{
		private readonly ISubjectRepository _subjectRepository;

		public SubjectController(ISubjectRepository subjectRepository)
		{
			_subjectRepository = subjectRepository;
		}

		[HttpPost("add-subject")]
		public async Task<IActionResult> Add([FromBody] RegisterSubjectRequest request)
		{
			await _subjectRepository.AddSubjectAsync(request);
			return Ok();
		}
	}
}
