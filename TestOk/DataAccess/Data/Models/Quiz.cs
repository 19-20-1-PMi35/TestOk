using System.Collections.Generic;

namespace DataAccess.Data.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public decimal PointsPerCorrectAnswer { get; set; }
        public decimal Complexity { get; set; }
        public List<QuizOption> Options { get; set; }
        public List<QuizOption> CorrectAnswers { get; set; }
    }
}
