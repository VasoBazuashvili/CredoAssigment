using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models.Requests;
using StudentAPI.Repositories;

namespace StudentAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly IGPARepository _gpaRepository;
		private readonly IStudentRepository _studentRepository;
		private readonly IGradeRepository _gradeRepository;
		

		public StudentController(IStudentRepository studentRepository, IGradeRepository gradeRepository, IGPARepository gpaRepository)
		{
			_studentRepository = studentRepository;
			_gradeRepository = gradeRepository;
			_gpaRepository = gpaRepository;

		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterStudentRequest studentRequest)
		{
			await _studentRepository.AddStudentAsync(studentRequest);
			return Ok();
		}
		[HttpPost("add-student-grades")]
		public async Task<IActionResult> AddStundetGrade(AddStudentGradeRequest request)
		{
			await _gradeRepository.Add(request);
			return Ok();
		}
		[HttpGet("get-student-grades")]
		public async Task<IActionResult> GetStundentGrades()
		{
			await _gradeRepository.GetAllAsync();
			return Ok();
		}

		[HttpGet("calculate-student-gpa")]
		public async Task<IActionResult> GPACalc(int id)
		{
			var gpa = await _gpaRepository.CalculateGPA(id);
			return Ok(gpa);
		}

	}
}
