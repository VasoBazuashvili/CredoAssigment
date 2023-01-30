using System.ComponentModel.DataAnnotations;

namespace MovieAppDatabase.Models
{
	public class Movie
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(200)]
		public string Name { get; set; }

		[Required]
		[MaxLength(2000)]
		public string ShortDescription { get; set; }

		[Required]
		public int ReleaseYear { get; set; }

		[Required]
		public string Director { get; set; }

		[Required]
		public MovieStatus Status { get; set; }

		[Required]
		public DateTime DateOfCreation { get; set; }
	}
	public enum MovieStatus
	{
		Active,
		Deleted
	}
}
