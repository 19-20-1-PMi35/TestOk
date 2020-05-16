using BusinessLogic;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using TestOk.Models;

namespace TestOk.Controllers
{
    public class StatisticsController : SharedController
    {
        private readonly ITestService _testService;
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(ITestService testService, IStatisticsService statisticsService) : base(testService)
        {
            _statisticsService = statisticsService;
            _testService = testService;
        }

        public IActionResult GetCurrent(int surveyID = 1)
        {
            var userId = User.Identity.GetUserId();

            var average = _statisticsService.GetAverageMark(userId);
            int toPass = 0;
            int forCertain = 0;
            try
            {
                forCertain = _statisticsService.GetMarkForTest(surveyID, userId);
                toPass = _statisticsService.GetMarkToPass(surveyID, userId); 
            }
            catch
            {
                return View(new StatisticsModel
                {
                    AverageMark = average,
                    ForCertain = 0,
                    CurrentSurveyID = surveyID,
                    ToPass = toPass
                });
            }
            return View(new StatisticsModel
            {
                AverageMark = average,
                ForCertain = forCertain,
                CurrentSurveyID = surveyID,
                ToPass = toPass
            });
        }
    }
}