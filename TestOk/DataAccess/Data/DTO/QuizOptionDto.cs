
using System.ComponentModel.DataAnnotations;

namespace DataAccess.DTO
{
    public class QuizOptionDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Text { get; set; }

        public bool IsCorrectAnswer { get; set; } = false;
    }
}
