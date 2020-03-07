using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestOk.Models;

namespace TestOk.Controllers
{
    public class HomeController : SharedController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestService _testService;

        public HomeController(ILogger<HomeController> logger, ITestService testService): base(testService)
        {
            _logger = logger;
            _testService = testService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Tests/{subject}")]
        public IActionResult Tests(string subject)
        {
            return View(new TestsModel(subject));
        }

        [Route("Tests")]
        public IActionResult Tests()
        {
            return View(new TestsModel());

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
