using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Db.Entities
{
	public class Grades
	{
		public int Id { get; set; }
		public int SubjectId { get; set; }
		public int StudentId { get; set; }
		public int Score { get; set;}
	}
}
