using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Auth;
using TodoApp.Db.Entities;
using TodoApp.Models.Requests;

namespace TodoApp.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly TokenGenerator _tokenGenerator;
		private readonly UserManager<UserEntity> _userManager;
		public AuthController(TokenGenerator tokenGenerator, UserManager<UserEntity> userManager)
		{
			_tokenGenerator = tokenGenerator;
			_userManager = userManager;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
		{
			//Create
			var entity = new UserEntity();
			entity.UserName = request.Email;
			entity.Email= request.Email;
			var result = await _userManager.CreateAsync(entity,request.Password);
			if (!result.Succeeded) 
			{
				var fistError = result.Errors.First();
				return BadRequest(fistError.Description);
			}
			return Ok();
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequest request)
		{
			// TODO:Check user credentials...
			var user = await _userManager.FindByEmailAsync(request.Email);
			if (user == null)
			{
				// User not found
				return NotFound("User not found");
			}
			var isCorrectPassword = await _userManager.CheckPasswordAsync(user, request.Password);

			if (!isCorrectPassword)
			{
				return BadRequest("Invalid email or password");
			}

			return Ok(_tokenGenerator.Generate(user.Id.ToString()));
		}
	}
}
