using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TestOk.Controllers
{
    public class TestController : SharedController
    {
        private readonly ITestService _testService;
        public TestController(ITestService testService) : base(testService)
        {
            _testService = testService;
        }
        public IActionResult Create()
        {
            return View(new TestDto());
        }

        [HttpPost]
        public IActionResult Save(TestDto testDto)
        {
            _testService.SaveTest(testDto);

            return RedirectToAction("Create");
        }
    }
}