using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestOk.Models;

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
            ViewBag.Subjects = _testService.GetFormattedTestSubjects();
            base.OnActionExecuting(filterContext);
        }
    }
}