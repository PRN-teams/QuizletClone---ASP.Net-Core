using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication1.Models
{
    public partial class SetStudyQuiz
    {
        public int QuizId { get; set; }
        public int SetStudyId { get; set; }

        public virtual Quiz Quiz { get; set; }
        public virtual SetStudy SetStudy { get; set; }
    }
}
