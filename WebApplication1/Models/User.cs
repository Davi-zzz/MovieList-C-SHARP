using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieList.Models
{
    public class User
    {

        public User(string email, string password, DateTime created_at, Person person)
        {
            this.email = email;
            this.password = password;
            this.created_at = created_at;
            this.person = person;
        }

        public User()
        {
        }

        public int Id { get; set; }

        private string email;

        private string password;

        private DateTime created_at;

        private DateTime updated_at;

        private Person person;

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public DateTime Updated_at { get => updated_at; set => updated_at = value; }
        public Person Person { get => person; set => person = value; }
    }
}