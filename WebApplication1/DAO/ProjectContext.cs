using MovieList.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieList.DAL
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("ProjectContext") { }
        public DbSet<User> users { get; set; }

        public DbSet<Person> people { get; set; }

        public DbSet<Rating> ratings { get; set; }

        public DbSet<ToWatchMovieList> toWatchMovieLists { get; set; }

        public DbSet<WatchedMovieList> watchedMovieLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}