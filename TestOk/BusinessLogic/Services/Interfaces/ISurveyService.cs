using System.Threading.Tasks;
using DataAccess.Data.DTO;

namespace BusinessLogic.Services.Interfaces
{
    public interface ISurveyService
    {
        Task<SurveyDto> StartSurvey(int testId);

        Task<SurveyDto> GetSurvey();

        Task ChooseAnswer(int quizId, int optionId, int surveyId);

        Task<SurveyDto> SwitchQuiz(int quizId);

        Task FinishSurvey();
    }
}
