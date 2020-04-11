using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Data.Models
{
    public class Answer
    {
        public int Id { get; set; }

        [ForeignKey("Quiz")]
        public int? QuizId { get; set; }

        [ForeignKey("QuizOption")]
        public int? QuizOptionId { get; set; }

        public QuizOption QuizOption { get; set; }

        public Quiz Quiz { get; set; }

        [ForeignKey("Survey")]
        public int? SurveyId { get; set; }

        public Survey? Survey { get; set; }
    }
}