using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using DataAccess.Data.Models;
using DataAccess.DTO;

namespace TestOk.Models
{
    public class TestsModel
    {
        public string Title;

        public readonly List<TestDto> Tests;

        public int GetMinPoints(TestDto test)
        {
            return (int)(test.MaxGrade * ((float)test.MinimumSuccessPercentage / 100));
        }

        public TestsModel(List<TestDto> tests)
        {
            Title = "Here is list of all available tests:";
            Tests = tests;
        }

        public TestsModel(string subject, List<TestDto> tests)
        {
            Title = $"Here is list of available tests for {subject}:";
            Tests = tests;
        }

    }
}
