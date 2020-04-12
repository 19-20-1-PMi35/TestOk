using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.DTO;

namespace DataAccess.Data.DTO
{
    public class AnswerDto
    {
        public int Id { get; set; }

        public QuizOptionDto QuizAnswer { get; set; }

        public int QuizId { get; set; }

        public int SurveyId { get; set; }
    }
}
