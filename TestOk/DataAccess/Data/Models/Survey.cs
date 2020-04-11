using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Data.Models
{
    public class Survey
    {
        public int Id { get; set; }

        public int? UserId { get; set; } = 1;
        
        [ForeignKey("CurrentQuiz")]
        public int? CurrentQuizId { get; set; }

        public Quiz CurrentQuiz { get; set; }

        public bool IsFinished { get; set; }

        public int Mark { get; set; }

        [ForeignKey("Test")]
        public int? TestId { get; set; }

        public Test Test { get; set; }
    }
}