using MovieList.DAL;
using MovieList.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieList.DAO
{
    public class ProjectSeed : System.Data.Entity.DropCreateDatabaseIfModelChanges<ProjectContext>
    {
        protected override void Seed(ProjectContext context)

        {
            string[] moviesIdSample = { "tt4154796", "tt10025738" };

            string commentSample = "ESTE FILME É INCRÍVEL!!!";

            List<ToWatchMovieList> toWatchMovieLists = new List<ToWatchMovieList>
            {
                new ToWatchMovieList(movieIds: moviesIdSample, moviesTags: new FavoriteTags[] {FavoriteTags.ACAO, FavoriteTags.FICCAO_CIENTIFICA} ),

            };

            List<WatchedMovieList> watchedMovieLists = new List<WatchedMovieList>
            {
                new WatchedMovieList(moviesIds: moviesIdSample),

            };
            
            List<Rating> ratings = new List<Rating>
            {
                new Rating(movieId: moviesIdSample[0],comment: commentSample, like: true, deslike: false, awards: new Awards[] { Awards.MASTERPIECE, Awards.ATORES_SUPIMPAS } ),

            };

            List<Person> people = new List<Person>
            {
                new Person(name: "DAVI", birthday: DateTime.Parse("01-09-1999"), tags: null, ratings: null, watchedMovieList: watchedMovieLists[0], toWatchMovieLists: new ToWatchMovieList[]{ toWatchMovieLists[0] }),
            };
            
            List<User> users = new List<User>
            {
                new User(email: "admin@unitins.br", password: "unitins@2023", DateTime.Now, person: people[0]),

            };

            toWatchMovieLists.ForEach(twml => context.toWatchMovieLists.Add(twml));
            watchedMovieLists.ForEach(wml => context.watchedMovieLists.Add(wml));
            ratings.ForEach(r => context.ratings.Add(r));
            people.ForEach(p => context.people.Add(p));
            users.ForEach(u => context.users.Add(u));
            context.SaveChanges();
        }
    }
}