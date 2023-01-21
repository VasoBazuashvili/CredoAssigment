namespace ToddApp_Api.Models.Requests
{
	public class PasswordResetRequest
	{
		public int UserId { get; set; }
		//public string Email { get; set; }
		public string NewPassword { get; set; }
		public string PasswordResetToken { get; set;}
	}
}
