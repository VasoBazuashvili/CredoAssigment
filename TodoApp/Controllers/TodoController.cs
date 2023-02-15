using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Db.Entities;
using TodoApp.Models.Requests;
using TodoApp.Repositories;

namespace TodoApp.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TodoController : ControllerBase
	{
		private readonly UserManager<UserEntity> _userManager;
		private readonly ITodoRepository _todoRepository;

		public TodoController(
			UserManager<UserEntity> userManager,
			ITodoRepository todoRepository)
		{
			_userManager = userManager;
			_todoRepository = todoRepository;
		}
		[Authorize("ApiUser", AuthenticationSchemes = "Bearer")]
		[HttpPost("create")]
		public async Task<IActionResult> Create([FromBody] CreateTodoRequest request)
		{
			var user = await _userManager.GetUserAsync(User);

			if (user == null)
			{
				return NotFound("User not found");
			}

			var userId = user.Id;
			await _todoRepository.InsertAsync(userId, request.Title, request.Description, request.Deadline);
			await _todoRepository.SaveChangesAsync();
			return Ok();
		}
		[HttpGet("add-todo-status")]
		public async Task<IActionResult> AddTodoStatus(AddTodoStatusRequest request)
		{
			await _todoRepository.SaveChangesAsync();
			return Ok();
		}
		// list/search - Get user todo list / Search
		[HttpPost("search")]
		public async Task<IActionResult> Search([FromBody] SearchTodoRequest request)
		{
			var user = await _userManager.GetUserAsync(User);

			if (user == null)
			{
				return NotFound("User Not Found");
			}

			var userId = user.Id;
			await _todoRepository.SearchAsync(userId, request.Title);
			await _todoRepository.SaveChangesAsync();

			return Ok();
		}
		// update - update todo title, description and deadline
		[HttpPost("update")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateTodoRequest request)
		{
			var user = await _userManager.GetUserAsync(User);

			if (user == null)
			{
				return NotFound("User Not Found");
			}

			var userId = user.Id;
			await _todoRepository.UpdateAsync(userId, request);
			await _todoRepository.SaveChangesAsync();

			return Ok();
		}
		// change-status - Change todo status
		[HttpGet("change-status")]
		public async Task<OkResult> ChangeStatusOfTodo(ChangeStatusOfTodoRequest request)
		{
			await _todoRepository.ChangeStatusOfTodo(request);
			return Ok();
		}
	}

	
}
