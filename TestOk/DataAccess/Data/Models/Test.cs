using System.Collections.Generic;

namespace DataAccess.Data.Models
{
    public class Test
    {
        public int Id { get; set; }

        public int MaxGrade { get; set; }

        public List<Quiz> Quizes { get; set; }

        public string Subject { get; set; }

        public int MinimumSuccessPercentage { get; set; }
    }
}