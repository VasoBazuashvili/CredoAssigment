﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Db;
using StudentAPI.Db.Entities;
using StudentAPI.Models.Requests;
using StudentAPI.Repositories;
using StudentAPI.Services;

namespace StudentAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly IStudentRepository _studentRepository;
		private readonly IGradeRepository _gradeRepository;
		private readonly ICalculateGPAService _calculateGPAService;
		private readonly StudentDbContext _db;

		public StudentController(
			IStudentRepository repository,
			IGradeRepository gradeRepository,
			ICalculateGPAService calculateGPAService,
			StudentDbContext db)
		{
			_studentRepository = repository;
			_gradeRepository = gradeRepository;
			_calculateGPAService = calculateGPAService;
			_db = db;
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
			var studentGrades = await _gradeRepository.GetStudentGradesAsync(request.StudentId);
			var gpa = _calculateGPAService.CalculateGPA(studentGrades);
			await _gradeRepository.UpdateStudentGPA(request.StudentId,gpa);
			return Ok();
		}
		[HttpGet("get-student-grades")]
		public async Task<IActionResult> GetStundentGrades()
		{
			await _gradeRepository.GetAllAsync();
			return Ok();
		}

		

		[HttpGet("top-10-student-by-gpa")]
		public  ActionResult<IEnumerable<Students>> Top10Student()
		{
			var top10Student = _db.Students
				.OrderByDescending(x => x.GPA)
				.Take(10);
			return Ok(top10Student);
		}

	}
}
