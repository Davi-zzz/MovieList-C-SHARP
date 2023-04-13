using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieList.Models
{
    public class User
    {

        public User(string email, string password)
        {
            this.email = email;
            this.password = password;
            this.created_at = DateTime.Now;
            this.updated_at = DateTime.Now;
        }

        public User()
        {
        }

        public int Id { get; set; }

        
        private string email;

        private string password;

        private DateTime created_at;

        private DateTime updated_at;

        private int personId;

        [Required]
        [DisplayName("EMAIL")]
        [EmailAddress]
        [StringLength(50, MinimumLength = 10, ErrorMessage ="EMAIL DEVE TER AO MENOS 10 CARACTERES")]
        public string Email { get => email; set => email = value; }

        [Required]
        [DisplayName("SENHA")]
        [StringLength(50, MinimumLength = 8, ErrorMessage ="SENHA DEVE TER AO MENOS 8 CARACTERES")]
        public string Password { get => password; set => password = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public DateTime Updated_at { get => updated_at; set => updated_at = value; }
        public virtual Person Person { get; set; }
        public int PersonId { get => personId; set => personId = value; }
    }
}