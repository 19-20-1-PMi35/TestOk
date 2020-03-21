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
        public ActionResult Create()
        {
            return View(new TestDto());
        }

        [HttpPost]
        public IActionResult Create(TestDto testDto)
        {
            if (ModelState.IsValid && TryValidateModel(testDto.Quizes))
            {
                _testService.SaveTest(testDto);

                return RedirectToAction("Create");
            }

            return View(testDto);
        }
    }
}