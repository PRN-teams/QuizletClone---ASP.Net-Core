using System;
using System.Collections.Generic;

#nullable disable

namespace QuizletClone.Models
{
    public partial class SetStudy
    {
        public SetStudy()
        {
            SetStudyQuizzes = new HashSet<SetStudyQuiz>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<SetStudyQuiz> SetStudyQuizzes { get; set; }
    }
}
