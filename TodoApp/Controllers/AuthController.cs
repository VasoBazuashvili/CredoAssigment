using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Auth;
using TodoApp.Db.Entities;
using TodoApp.Models.Requests;
using TodoApp.Repositories;

namespace TodoApp.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly TokenGenerator _tokenGenerator;
		private readonly UserManager<UserEntity> _userManager;
		private readonly IConfiguration _configuration;
		private readonly ISendEmailRequestRepository _sendEmailRequestRepository;
		public AuthController(TokenGenerator tokenGenerator, UserManager<UserEntity> userManager,IConfiguration configuration,ISendEmailRequestRepository sendEmailRequestRepository)
		{
			_tokenGenerator = tokenGenerator;
			_userManager = userManager;
			_configuration = configuration;
			_sendEmailRequestRepository= sendEmailRequestRepository;
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
		[HttpPost("")]
		[HttpPost("request-password-reset")]
		public async Task<IActionResult> RequestPasswordReset([FromBody] RequestPasswordResetRequest request)
		{
			// 0. Find user
			var user = await _userManager.FindByEmailAsync(request.Email);
			if (user == null)
			{
				return NotFound("User not found");
			}

			// 1. Generate password reset token
			var token = await _userManager.GeneratePasswordResetTokenAsync(user);

			// 2. Insert email into SendEmailRequest table
			var sendEmailRequestEntity = new SendEmailRequestEntity();
			sendEmailRequestEntity.ToAddress = request.Email;
			sendEmailRequestEntity.Status = SendEmailRequestStatus.New;
			sendEmailRequestEntity.CreatedAt = DateTime.Now;

			var url = _configuration["PasswordResetUrl"]!
				.Replace("{userId}", user.Id.ToString())
				.Replace("{token}", token);
			var resetUrl = $"<a href=\"{url}\">Reset password</a>";
			sendEmailRequestEntity.Body = $"Hello, your password reset link is: {resetUrl}";

			_sendEmailRequestRepository.Insert(sendEmailRequestEntity);
			await _sendEmailRequestRepository.SaveChangesAsync();

			return Ok();
		}
		[HttpPost("reset-password")]
		public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
		{
			var user = await _userManager.FindByIdAsync(request.UserId.ToString());
			if (user == null)
			{
				return NotFound("User not found");
			}
			var resetResult = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);

			// TODO: Return result
			if (!resetResult.Succeeded)
			{
				var firstError = resetResult.Errors.First();
				return StatusCode(500, firstError.Description);
			}

			return Ok();
		}
	}
}
