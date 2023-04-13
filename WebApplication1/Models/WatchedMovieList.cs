using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieList.Models
{
    public class WatchedMovieList
    {

        public WatchedMovieList(string moviesIds)
        {
            this.moviesIds = moviesIds;
        }

        public WatchedMovieList()
        {
        }

        public int Id { get; set; }

        private string moviesIds;

        public string MoviesIds { get => moviesIds; set => moviesIds = value; }
    }
}