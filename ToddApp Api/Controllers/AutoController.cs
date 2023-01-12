using Microsoft.AspNetCore.Mvc;
using ToddApp_Api.Auth;

namespace ToddApp_Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AutoController : ControllerBase
	{
		[HttpGet]

		public string Ping()
		{
			return "Pong";
		}
		[HttpPost("{email}")]
		public string Login(string email) 
		{
			// TODO:Check user credentials...
			JwtSettings jwt = new JwtSettings();
			jwt.Issuer = "";
			jwt.Audience = "";
			jwt.SecrectKey = "";
			var tokenGenerator = new TokenGenerator(jwt);
			return tokenGenerator.Generate(email);
		}
	}
}
