using System.Collections.Generic;

namespace DataAccess.Data.Models
{
    public class Survey
    {
        public int Id { get; set; }

        public int UserId { get; set; } = 1;

        public int CurrentQuizId { get; set; }

        public bool IsFinished { get; set; }

        public int CorrectAnswers { get; set; }

        public int TestId { get; set; }

        public List<Answer> Answers { get; set; }
    }
}