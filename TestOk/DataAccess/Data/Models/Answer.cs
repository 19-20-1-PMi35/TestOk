using System.Collections.Generic;

namespace DataAccess.Data.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public Quiz Quiz { get; set; }

        public List<QuizOption> QuizAnswers { get; set; }
    }
}