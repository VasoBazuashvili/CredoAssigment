using Microsoft.AspNetCore.Mvc;
using ToddApp_Api.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ToddApp_Api.Entities;
using ToddApp_Api.Models.Requests;
using ToddApp_Api.DB;
using ToddApp_Api.Repositories;

namespace ToddApp_Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private TokenGenerator _tokenGenerator;
		private IConfiguration _configuration;
		private UserManager<UserEntity> _userManager;
		private readonly ISendEmailRequestRepository _sendEmailRequestRepository;

		public AuthController(
			IConfiguration configuration,
			ISendEmailRequestRepository sendEmailRequestRepository,
			UserManager<UserEntity> userManager,
			TokenGenerator tokenGenerator)
		{
			_tokenGenerator = tokenGenerator;
			_userManager = userManager;
			_sendEmailRequestRepository= sendEmailRequestRepository;
			_configuration = configuration;
		}

		[HttpGet("ping")]
		public string Ping()
		{
			return "Pong";
		}



		//TODO: Register
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody]RegisterUserRequest request)
		{
			//Create
			var entity = new UserEntity();
			entity.Email = request.Email;
			entity.UserName = request.Email;
			var result = await _userManager.CreateAsync(entity, request.Password);
			if (!result.Succeeded)
			{
				var firstError = result.Errors.First();
				return BadRequest(firstError.Description);
			}
			return Ok();

		}


		//TODO: RequestPasswordReset
		//1.Generate password reset token
		//2.Insert email into SendEmailRequest table
		//3.Return result
		[HttpPost("request-password-reset")]
		public async Task<IActionResult> RequestPasswordReset([FromBody]RequestPasswordResetRequest request)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);
			if (user == null)
			{
				return NotFound("User not found");
			}
			var token = await _userManager.GeneratePasswordResetTokenAsync(user);
			var sendEmailRequestEntity = new SendEmailRequestEntity();
			sendEmailRequestEntity.ToAddress = request.Email;
			sendEmailRequestEntity.Status = SendEmailRequestStatus.New;
			sendEmailRequestEntity.CreatedAt = DateTime.Now;
			var url = _configuration["ConnectionStrings:PasswordResetUrl"]!
				.Replace("{userId}", user.Id.ToString())
				.Replace("{token}", token);
			var resultUrl = $"<a href=\"{url}\">Reset Password </a>";
			sendEmailRequestEntity.Body = $"Hello, your password reset link is: {resultUrl}";
			await _sendEmailRequestRepository.SaveChangesAsync();
			return Ok();
		}


		//TODO: Reset Password
		//0.Find user
		//1.Validate token
		//2.Validate new password
		//3.Reset password
		//4.Return result

		[HttpPost("reset-password")]
		public async Task<IActionResult> ResetPassword([FromBody]PasswordResetRequest request)
		{
			var user = await _userManager.FindByIdAsync(request.UserId.ToString());
			if (user == null)
			{
				return NotFound("User not found");
			}

			var resetResult = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);
			//TODO: return result
			if (!resetResult.Succeeded)
			{
				var firstError = resetResult.Errors.First();
				return StatusCode(500, firstError.Description);
			}
			return Ok();
		}

		//TODO: Login
		[HttpPost("{login}")]
		public async Task<IActionResult> Login([FromBody]LoginRequest request) 
		{
			// TODO:Check user credentials...

			var user = await _userManager.FindByEmailAsync(request.Email);
			if (user == null)
			{
				//user not found 
				return NotFound("User not found");
			}
			var isCorrectPassword = await _userManager.CheckPasswordAsync(user,request.Password);
			if (!isCorrectPassword)
			{
				return BadRequest("Invalid email or password");
			}
			return Ok(_tokenGenerator.Generate(request.Email));

		}
	}
}
