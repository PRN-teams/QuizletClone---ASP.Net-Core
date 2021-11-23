using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication1.Models
{
    public partial class SetStudy
    {
        public SetStudy()
        {
            SetStudyQuiz = new HashSet<SetStudyQuiz>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? IsPrivate { get; set; }
        public string Description { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<SetStudyQuiz> SetStudyQuiz { get; set; }
    }
}
