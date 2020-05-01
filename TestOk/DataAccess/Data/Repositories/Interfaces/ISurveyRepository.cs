using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Data.DTO;
using DataAccess.Data.Models;

namespace DataAccess.Data.Repositories.Interfaces
{
    public interface ISurveyRepository
    {
        Task<SurveyDto> StartSurvey(int userId, int testId);

        Task<SurveyDto> GetActiveSurvey(int userId);

        Task UpdateAnswer(int quizId, int optionId, int surveyId, bool isOneAnswer);

        Task<List<Answer>> GetAnswersByQuiz(int quizId, int surveyId);

        Task<SurveyDto> SwitchQuiz(int quizId, int userId);

        List<SurveyDto> FinishedSurveys(int userId);

        Task FinishSurvey(int surveyId, double mark);
    }
}