using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data.Models;
using DataAccess.DTO;

namespace TestOk.Models
{
    public class TestsModel
    {
        public string Title;

        public static List<QuizOptionDto> QuizOptionDtos = new List<QuizOptionDto>
        {
            new QuizOptionDto
            {
                Text = "First"
            },
            new QuizOptionDto
            {
                Text = "Second"
            }
        };

        public List<TestDto> Tests = new List<TestDto>
        {
            new TestDto
            {
                Subject = "Programming",
                MinimumSuccessPercentage = 25,
                Quizes = new List<QuizDto>
                {
                  new QuizDto
                  {
                      Options = QuizOptionDtos,
                      Complexity = 25,
                      Question = "hello world ?"
                  }
                },
                MaxGrade = 150
            }
        };

        public TestsModel()
        {
            Title = "Here is list of all available tests:";
        }

        public TestsModel(string subject)
        {
            Title = $"Here is list of available tests for {subject}:";
        }

    }
}
