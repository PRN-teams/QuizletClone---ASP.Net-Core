using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication1.Models
{
    public partial class Account
    {
        public int UId { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
        public int AccountId { get; set; }

        public virtual User U { get; set; }
    }
}
