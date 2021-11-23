using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication1.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            SetStudyQuiz = new HashSet<SetStudyQuiz>();
        }

        public int Id { get; set; }
        public string Term { get; set; }
        public string Definition { get; set; }

        public virtual ICollection<SetStudyQuiz> SetStudyQuiz { get; set; }
    }
}
