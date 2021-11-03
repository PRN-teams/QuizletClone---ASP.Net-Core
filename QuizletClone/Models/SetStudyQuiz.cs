using System;
using System.Collections.Generic;

#nullable disable

namespace QuizletClone.Models
{
    public partial class SetStudyQuiz
    {
        public int QuizId { get; set; }
        public int SetStudyId { get; set; }

        public virtual Quiz Quiz { get; set; }
        public virtual SetStudy SetStudy { get; set; }
    }
}
