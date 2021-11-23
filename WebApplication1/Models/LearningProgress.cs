using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication1.Models
{
    public partial class LearningProgress
    {
        public int UId { get; set; }
        public int SetId { get; set; }
        public int ModeId { get; set; }
        public int QuizId { get; set; }
        public int Attempt { get; set; }

        public virtual LearningMode Mode { get; set; }
        public virtual SetStudyQuiz SetStudyQuiz { get; set; }
        public virtual User U { get; set; }
    }
}
