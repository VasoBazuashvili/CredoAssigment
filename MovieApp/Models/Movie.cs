using MovieApp.Models.Enums;

namespace MovieApp.Models
{
    public class Movie
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime MovieCreatedYear { get; set; }
		public string Director { get; set; }
		public MovieStatus Status { get; set; }
		public DateTime CreatedDate { get; set;
		}
	}
}
