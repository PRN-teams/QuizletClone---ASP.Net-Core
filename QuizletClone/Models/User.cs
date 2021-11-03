using System;
using System.Collections.Generic;

#nullable disable

namespace QuizletClone.Models
{
    public partial class User
    {
        public User()
        {
            SetStudies = new HashSet<SetStudy>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AvatarUrl { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }

        public virtual ICollection<SetStudy> SetStudies { get; set; }

    }
}
