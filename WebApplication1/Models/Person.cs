using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieList.Models
{
    public class Person
    {
        public Person(string name, DateTime birthday, FavoriteTags[] tags, Rating[] ratings, WatchedMovieList watchedMovieList, ToWatchMovieList[] toWatchMovieLists)
        {
            this.name = name;
            this.birthday = birthday;
            this.tags = tags;
            this.ratings = ratings;
            this.watchedMovieList = watchedMovieList;
            this.toWatchMovieLists = toWatchMovieLists;
        }

        public Person()
        {
        }

        public int Id { get; set; }

        private string name;

        private DateTime birthday;

        private FavoriteTags[] tags; 

        private Rating[] ratings;

        private WatchedMovieList watchedMovieList;

        private ToWatchMovieList[] toWatchMovieLists;

        public string Name { get => name; set => name = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public FavoriteTags[] Tags { get => tags; set => tags = value; }
        public Rating[] Ratings { get => ratings; set => ratings = value; }
        public WatchedMovieList WatchedMovieList { get => watchedMovieList; set => watchedMovieList = value; }
        public ToWatchMovieList[] ToWatchMovieLists { get => toWatchMovieLists; set => toWatchMovieLists = value; }
    }
}