namespace StudentAPI.Models.Requests
{
	public class AddStudentGradeRequest
	{
		public int StudentId { get; set; }
		public int SubjectId { get; set; }
		public int Score { get; set; }
	}
}
