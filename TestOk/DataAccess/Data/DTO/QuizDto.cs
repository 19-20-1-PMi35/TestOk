using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.DTO
{
    public class QuizDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength =10)]
        public string Question { get; set; }

        [Required]
        public decimal PointsPerCorrectAnswer { get; set; }
        public decimal Complexity { get; set; }
        public List<QuizOptionDto> Options { get; set; } = new List<QuizOptionDto>();
        public List<QuizOptionDto> CorrectAnswers { get; set; } = new List<QuizOptionDto>();
    }
}
