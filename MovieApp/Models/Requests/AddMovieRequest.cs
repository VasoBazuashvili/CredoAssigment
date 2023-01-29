using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models.Requests
{
    public class AddMovie
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Director { get; set; }
        public DateTime ReleaseYear { get; set; }
    }
}
