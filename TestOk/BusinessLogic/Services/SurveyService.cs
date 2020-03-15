using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using BusinessLogic.Services.Interfaces;
using DataAccess.Data.DTO;
using DataAccess.Data.Models;
using DataAccess.Data.Repositories.Interfaces;

namespace BusinessLogic.Services
{
    public class SurveyService: ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository;

        public SurveyService(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        public async Task<SurveyDto> StartSurvey(int testId)
        {
            //change user id to not hardcoded later :)
            return await _surveyRepository.StartSurvey(0, testId);
        }

        public SurveyDto GetSurvey()
        {
            //change user id to not hardcoded later :)
            return _surveyRepository.GetActiveSurvey(0);
        }
    }
}
