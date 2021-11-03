using System;
using System.Collections.Generic;

#nullable disable

namespace QuizletClone.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            SetStudyQuizzes = new HashSet<SetStudyQuiz>();
        }

        public int Id { get; set; }
        public string Term { get; set; }
        public string Definition { get; set; }

        public virtual ICollection<SetStudyQuiz> SetStudyQuizzes { get; set; }
    }
}
