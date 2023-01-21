namespace ToddApp_Api.Entities
{
	public enum SendEmailRequestStatus
	{
		New = 0,
		Sent = 1,
		Failed = 2,
	}
	public class SendEmailRequestEntity
	{
		public long Id { get; set; }
		public string ToAddress { get; set; }
		public string Body { get; set; }
		public SendEmailRequestStatus Status { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? SentAt { get; set; }
	}
}
