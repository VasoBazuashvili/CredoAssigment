using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
		// list/search - Get user todo list / Search
		// update - update todo title, description and deadline
		// change-status - Change todo status
	}
}
