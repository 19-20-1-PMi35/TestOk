using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.DTO
{
    public class TestDto
    {
        public int Id { get; set; }

        [Required]
        public int MaxGrade { get; set; }

        public List<QuizDto> Quizes { get; set; } = new List<QuizDto>();
        
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Subject { get; set; }

        [Required]
        [Range(1,100)]
        public int MinimumSuccessPercentage { get; set; }
    }
}
