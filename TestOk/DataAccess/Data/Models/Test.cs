using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Data.Models
{
    public class Test
    {
        public int Id { get; set; }

        [Required]
        public int MaxGrade { get; set; }

        public List<Quiz> Quizes { get; set; } = new List<Quiz>();

        [Required]
        public string Subject { get; set; }
        [Required]
        [Range(1, 100)]
        public int MinimumSuccessPercentage { get; set; }
    }
}