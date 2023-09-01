using AuthenticationAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private static readonly StudentModel[] StudentNames = new[]
   {
		new StudentModel() {
			Name = "Methran",
			Age = 19,
			Gender = Gender.Male
		},
		new StudentModel() {
			Name = "Sridhar",
			Age = 22,
			Gender = Gender.Male
		},
		new StudentModel() {
			Name = "Pownraj",
			Age = 19,
			Gender = Gender.Male
		}
	};

		private readonly ILogger<StudentController> _logger;

		public StudentController(ILogger<StudentController> logger)
		{
			_logger = logger;
		}

		[HttpGet(Name = "students")]
		public IEnumerable<StudentModel> Get()
		{
			return StudentNames.ToArray();
		}
	}
}
