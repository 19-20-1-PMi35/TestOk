using BusinessLogic;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
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
            var average = _statisticsService.GetAverageMark();

            int forCertain = 0;
            try
            {
                forCertain = _statisticsService.GetMarkForTest(surveyID);
            }
            catch
            {
                return View(new StatisticsModel { AverageMark = average, ForCertain = 0, CurrentSurveyID = surveyID });
            }
            return View(new StatisticsModel
            {
                AverageMark = average,
                ForCertain = forCertain,
                CurrentSurveyID = surveyID
            });
        }
    }
}