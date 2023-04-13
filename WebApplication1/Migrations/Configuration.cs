namespace WebApplication1.Migrations
{
    using Microsoft.Ajax.Utilities;
    using MovieList.DAL;
    using MovieList.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MovieList.Utils;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MovieList.DAL.ProjectContext";
        }

        protected override void Seed(ProjectContext context)
        {
            string moviesIdSample = string.Join("|", new string[] { "tt4154796", "tt10025738" });

            string commentSample = "ESTE FILME É INCRÍVEL!!!";

            string moviesTags = string.Join("|", Utils.GetEnumValuesFromLabels(new List<Enum> { FavoriteTags.FANTASIA, FavoriteTags.ACAO }));

            List<ToWatchMovieList> toWatchMovieLists = new List<ToWatchMovieList>
            {
                new ToWatchMovieList(movieIds: moviesIdSample, moviesTags: moviesTags),

            };

            List<WatchedMovieList> watchedMovieLists = new List<WatchedMovieList>
            {
                new WatchedMovieList(moviesIds: moviesIdSample),

            };

            List<Rating> ratings = new List<Rating>
            {
                new Rating(movieId: moviesIdSample,comment: commentSample, like: true, deslike: false, award: Awards.ATORES_SUPIMPAS ),

            };

            List<Person> people = new List<Person>
            {
                new Person(name: "DAVI", birthday: DateTime.Now, tags: ""),
            };

            List<User> users = new List<User>
            {
                new User(email: "admin@unitins.br", password: "unitins@2023"),

            };

            toWatchMovieLists.ForEach(twml => context.toWatchMovieLists.AddOrUpdate(twml));
            watchedMovieLists.ForEach(wml => context.watchedMovieLists.AddOrUpdate(wml));
            ratings.ForEach(r => context.ratings.AddOrUpdate(r));
            people.ForEach(p => context.people.AddOrUpdate(p));
            users.ForEach(u => context.users.AddOrUpdate(u));
            context.SaveChanges();
        }
    }
}
