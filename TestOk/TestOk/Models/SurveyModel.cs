using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DataAccess.Data.DTO;
using DataAccess.DTO;

namespace TestOk.Models
{
    public class SurveyModel
    {
        public SurveyDto SurveyDto;

        public SurveyModel(SurveyDto surveyDto)
        {
            SurveyDto = surveyDto;
        }

        public string TrimQuestion(string question)
        {
            return question.Length > 35
                ? question.Substring(0,35) + "..."
                : question;
        }

        public bool IsChosenAnswer(int answerId)
        {
            return SurveyDto.CurrentQuizAnswers.Select(s => s.QuizAnswer.Id).Contains(answerId);
        }

        public bool IsAnyAnswer(int quizId)
        {
            return SurveyDto.CurrentQuizAnswers.Select(s => s.QuizId).Contains(quizId);
        }
    }
}
