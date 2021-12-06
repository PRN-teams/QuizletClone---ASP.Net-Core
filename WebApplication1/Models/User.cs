using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication1.Models
{
    public partial class User
    {
        public User()
        {
            Account = new HashSet<Account>();
            Bill = new HashSet<Bill>();
            Contract = new HashSet<Contract>();
            SetStudy = new HashSet<SetStudy>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AvatarUrl { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }

        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<Bill> Bill { get; set; }
        public virtual ICollection<Contract> Contract { get; set; }
        public virtual ICollection<SetStudy> SetStudy { get; set; }
    }
}
