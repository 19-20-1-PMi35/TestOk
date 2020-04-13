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

        public IActionResult GetCurrent()
        {
            var average = _statisticsService.GetAverageMark();

            //currently not working
            //var forCertain = _statisticsService.GetMarkForTest(0);

            return View(new StatisticsModel { AverageMark = average/*, ForCertain = forCertain*/ });
        }
    }
}