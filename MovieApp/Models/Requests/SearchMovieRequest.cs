﻿namespace MovieApp.Models.Requests
{
    public class SearchMovie
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseYear { get; set; }
    }
}
