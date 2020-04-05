using BusinessLogic;
using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TestOk.Controllers
{
    public class QuizOptionController : SharedController
    {
        public QuizOptionController(ITestService testService) : base(testService)
        {
        }

        public ActionResult Create(QuizOptionDto quizOptionDto, string prefix)
        {
            ViewData["prefix"] = prefix;

            return PartialView(quizOptionDto);
        }
    }
}