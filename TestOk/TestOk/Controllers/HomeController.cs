using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using DataAccess.DTO;
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
        public async Task<IActionResult> Tests(string subject)
        {
            var tests = await _testService.GetTestsList(subject);

            return View(new TestsModel(subject, tests));
        }

        [Route("Tests")]
        public async Task<IActionResult> Tests()
        {
            var tests = await _testService.GetTestsList();

            return View(new TestsModel(tests));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
