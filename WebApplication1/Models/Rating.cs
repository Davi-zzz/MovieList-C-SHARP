﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieList.Models
{
    public class Rating
    {
        public Rating(string movieId, string comment, bool like, bool deslike, Awards[] awards)
        {
            this.movieId = movieId;
            this.comment = comment;
            this.like = like;
            this.deslike = deslike;
            this.awards = awards;
        }

        public Rating()
        {
        }

        public int Id { get; set; }

        private string movieId;

        private string comment;

        private bool like;

        private bool deslike;

        private Awards[] awards;

        public string MovieId { get => movieId; set => movieId = value; }
        public string Comment { get => comment; set => comment = value; }
        public bool Like { get => like; set => like = value; }
        public bool Deslike { get => deslike; set => deslike = value; }
        public Awards[] Awards { get => awards; set => awards = value; }
    }
}