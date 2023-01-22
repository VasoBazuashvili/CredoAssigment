namespace ToddApp_Api.Models.Requests
{
	public class PasswordResetRequest
	{
		public int UserId { get; set; }
		//public string Email { get; set; }
		public string Password { get; set; }
		public string Token { get; set;}
	}
}
