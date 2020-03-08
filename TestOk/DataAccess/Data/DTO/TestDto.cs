using System.Collections.Generic;

namespace DataAccess.DTO
{
    public class TestDto
    {
        public int Id { get; set; }

        public int MaxGrade { get; set; }

        public List<QuizDto> Quizes { get; set; } = new List<QuizDto>();

        public string Subject { get; set; }

        public int MinimumSuccessPercentage { get; set; }
    }
}
