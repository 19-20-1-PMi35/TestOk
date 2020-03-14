using BusinessLogic;
using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TestOk.Controllers
{
    public class QuizController : SharedController
    {
        public QuizController(ITestService testService) : base(testService)
        {
        }

        public ActionResult Create()
        {
            return PartialView(new QuizDto());
        }

    }
}