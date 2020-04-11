using System.Threading.Tasks;
using BusinessLogic;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TestOk.Models;

namespace TestOk.Controllers
{
    /*todo: 
        5. button to finish test
        6. calculate mark 
    */
    
    public class SurveyController : SharedController
    {
        private readonly ISurveyService _surveyService;
        private readonly ITestService _testService;

        public SurveyController(ITestService testService,
            ISurveyService surveyService) : base(testService)
        {
            _surveyService = surveyService;
            _testService = testService;
        }

        public async Task<IActionResult> GetSurvey(int testId)
        {
           var survey = await _surveyService.GetSurvey() ?? await _surveyService.StartSurvey(testId);

            return View("Survey", new SurveyModel(survey));
        }

        public async Task<IActionResult> ChooseAnswer(int quizId, int optionId, int surveyId)
        {
            await _surveyService.ChooseAnswer(quizId, optionId, surveyId);

            var survey = await _surveyService.GetSurvey();

            return View("Survey", new SurveyModel(survey));
        }

        public async Task<IActionResult> SwitchQuiz(int quizId)
        {
            var survey = await _surveyService.SwitchQuiz(quizId);

            return View("Survey", new SurveyModel(survey));
        }

        public async Task<IActionResult> FinishSurvey()
        {
            await _surveyService.FinishSurvey();

            //temporary while we dont have page with mark
            var tests = await _testService.GetTestsList();
            return View("Tests", new TestsModel(tests));
        }
    }
}