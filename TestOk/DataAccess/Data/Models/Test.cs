using System;

namespace DataAccess.Data.Models
{
    public class Test
    {
        public int TestId { get; set; }

        public DateTime Date { get; set; }

        public int MaxGrade { get; set; } //let`s calculate it from our quiz

        public int GroupId { get; set; } //when group model will be created we should add it to use constraint

        public int TeacherId { get; set; } //when teacher model will be created we should add it to use constraint

        public int? QuizId { get; set; } //when quiz model will be created we should add it to use constraint

        public string Subject { get; set; }

        public int MinimumSuccessPercentage { get; set; }
    }
}