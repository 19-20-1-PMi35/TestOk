﻿using BusinessLogic;
using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TestOk.Controllers
{
    public class QuizOptionController : SharedController
    {
        public QuizOptionController(ITestService testService) : base(testService)
        {
        }

        public ActionResult Create()
        {
            return PartialView(new QuizOptionDto());
        }
    }
}