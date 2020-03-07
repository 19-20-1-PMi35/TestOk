using DataAccess.Data.Models;
using System.Collections.Generic;

namespace DataAccess.DTO
{
    public class TestDto
    {
        public int Id { get; set; }

        public int MaxGrade { get; set; }

        public List<QuizDto> Quizes { get; set; }

        public string Subject { get; set; }

        public int MinimumSuccessPercentage { get; set; }
    }
}
