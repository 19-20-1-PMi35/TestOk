using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataAccess.Data.Models;
using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestOk
{
    public class CreateTestModel : PageModel
    {
        private ContainerWrapper containerWrapper;

        public CreateTestModel()
        {
            containerWrapper = ContainerWrapper.GetInstance();
        }

        public readonly List<SelectListItem> Teachers = new List<SelectListItem>(); 
        public readonly List<SelectListItem> Groups = new List<SelectListItem>();
        public void OnGet()
        {
            Teachers.Add(new SelectListItem("Teacher", "1")); //call to get teachers when implemented, same for groups
            Groups.Add(new SelectListItem("PMI-35", "1"));
        }

        public void OnPost(string subject, int successPercentage, int teacherId, int groupId, DateTime date)
        {
            var testService = containerWrapper.ResolveDependency<ITestService>();

            var testDto = new TestDto
            {
                MinimumSuccessPercentage = successPercentage,
                GroupId = groupId,
                TeacherId = teacherId,
                Subject = subject,
                Date = date
            };
            var isStored = testService.CreateTest(testDto); //todo: handle this
        }
    }
}