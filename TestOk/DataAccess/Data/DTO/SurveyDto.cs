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

        public string UserId { get; set; } = "1";

        public QuizDto CurrentQuiz { get; set; }

        public bool IsFinished { get; set; }

        public int Mark { get; set; }

        public TestDto Test { get; set; }

        public List<AnswerDto> CurrentQuizAnswers { get; set; }
    }
}
