using System.Threading.Tasks;
using DataAccess.Data.DTO;

namespace BusinessLogic.Services.Interfaces
{
    public interface ISurveyService
    {
        Task<SurveyDto> StartSurvey(int testId, string userId);

        Task<SurveyDto> GetSurvey(string userId);

        Task ChooseAnswer(int quizId, int optionId, int surveyId);

        Task<SurveyDto> SwitchQuiz(int quizId, string userId);

        Task FinishSurvey(string userId);
    }
}
