using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Data.DTO;
using DataAccess.Data.Models;

namespace DataAccess.Data.Repositories.Interfaces
{
    public interface ISurveyRepository
    {
        Task<SurveyDto> StartSurvey(string userId, int testId);

        Task<SurveyDto> GetActiveSurvey(string userId);

        Task UpdateAnswer(int quizId, int optionId, int surveyId, bool isOneAnswer);

        Task<List<Answer>> GetAnswersByQuiz(int quizId, int surveyId);

        Task<SurveyDto> SwitchQuiz(int quizId, string userId);

        List<SurveyDto> FinishedSurveys(string userId);

        Task FinishSurvey(int surveyId, double mark);
    }
}