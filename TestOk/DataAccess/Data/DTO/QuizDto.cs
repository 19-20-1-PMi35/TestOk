using System.Collections.Generic;

namespace DataAccess.DTO
{
    public class QuizDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public decimal PointsPerCorrectAnswer { get; set; }
        public decimal Complexity { get; set; }
        public List<QuizOptionDto> Options { get; set; }
        public List<QuizOptionDto> CorrectAnswers { get; set; }
    }
}
