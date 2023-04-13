using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieList.Models
{
    public class ToWatchMovieList
    {
        public ToWatchMovieList(string movieIds, string moviesTags)
        {
            this.movieIds = movieIds;
            this.moviesTags = moviesTags;
        }

        public ToWatchMovieList()
        {
        }

        public int Id { get; set; }

        private string movieIds;

        private string moviesTags;

        public string MoviesTags { get => moviesTags; set => moviesTags = value; }
        public string MovieIds { get => movieIds; set => movieIds = value; }
    }
}