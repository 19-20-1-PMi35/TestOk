using System.Threading.Tasks;
using BusinessLogic;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TestOk.Models;

namespace TestOk.Controllers
{
    public class SurveyController : SharedController
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ITestService testService,
            ISurveyService surveyService) : base(testService)
        {
            _surveyService = surveyService;
        }

        public async Task<IActionResult> GetSurvey(int testId)
        {
            var surveyStarted = _surveyService.GetSurvey() ?? await _surveyService.StartSurvey(testId);

            return View("Survey", new SurveyModel(surveyStarted));
        }
    }
}