using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using TestOk.Models;

namespace TestOk.Controllers
{
    public class StatisticsController : SharedController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestService _testService;

        public StatisticsController(ILogger<HomeController> logger, ITestService testService) : base(testService)
        {
            _logger = logger;
            _testService = testService;
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}