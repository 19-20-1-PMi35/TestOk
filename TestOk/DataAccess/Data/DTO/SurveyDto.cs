using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Data.Models;
using DataAccess.DTO;

namespace DataAccess.Data.DTO
{
    public class SurveyDto
    {
        public int Id { get; set; }

        public int UserId { get; set; } = 1;

        public QuizDto CurrentQuiz { get; set; }

        public bool IsFinished { get; set; }

        public int CorrectAnswers { get; set; }

        public TestDto Test { get; set; }

        public List<AnswerDto> Answers { get; set; }
    }
}
