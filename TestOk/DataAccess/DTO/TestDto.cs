using System;

namespace DataAccess.DTO
{
    public class TestDto
    {
        public int TestId { get; set; }

        public DateTime Date { get; set; }

        public int MaxGrade { get; set; }

        public int GroupId { get; set; }

        public int TeacherId { get; set; }

        public int? QuizId { get; set; }

        public string Subject { get; set; }

        public int MinimumSuccessPercentage { get; set; }
    }
}
