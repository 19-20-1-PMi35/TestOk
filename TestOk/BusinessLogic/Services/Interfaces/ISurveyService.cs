using System.Threading.Tasks;
using DataAccess.Data.DTO;

namespace BusinessLogic.Services.Interfaces
{
    public interface ISurveyService
    {
        Task<SurveyDto> StartSurvey(int testId);
        
        SurveyDto GetSurvey();
    }
}
