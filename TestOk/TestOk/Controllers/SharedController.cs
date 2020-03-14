using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TestOk.Controllers
{
    public abstract class SharedController : Controller
    {
        private readonly ITestService _testService;

        protected SharedController(ITestService testService)
        {
            _testService = testService;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.Subjects = _testService.GetCountedTestSubjects();
            base.OnActionExecuting(filterContext);
        }
    }
}