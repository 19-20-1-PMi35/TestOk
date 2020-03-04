using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestOk.Models;

namespace TestOk.Controllers
{
    public abstract class SharedController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.Subjects = new List<string> { "heeelloog", "asss", "asddddddddddddddddddddddd293234" };
            base.OnActionExecuting(filterContext);
        }
    }
}