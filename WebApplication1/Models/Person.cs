using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace MovieList.Models
{
    public class Person
    {
        public Person(string name, DateTime birthday, string tags)
        {
            this.name = name;
            this.birthday = birthday;
            this.tags = tags;
            Ratings = new List<Rating>();
            WatchedMovieList = new List<WatchedMovieList>();
            ToWatchMovieLists = new List<ToWatchMovieList>();
        }

        public Person()
        {
        }

        public int Id { get; set; }

        private string name;

        private DateTime birthday;

        private string tags;

        [Required]
        [DisplayName("NAME")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "NOME DEVE TER AO MENOS 2 CARACTERES")]
        public string Name { get => name; set => name = value; }

        [Required]
        [DisplayName("DATA DE NASCIMENTO")]
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public string Tags { get => tags; set => tags = value; }
        
        public virtual ICollection<Rating> Ratings { get ; set; }
        public virtual ICollection<WatchedMovieList> WatchedMovieList { get; set; }
        public virtual ICollection<ToWatchMovieList> ToWatchMovieLists { get; set; }
    }
}