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

        private static TestDto test = new TestDto
        {
            Subject = "Programming",
            MinimumSuccessPercentage = 51,
            Quizes = new List<QuizDto>
            {
                new QuizDto
                {
                    Options = QuizOptionDtos,
                    Complexity = 25,
                    Question = "hello world ?"
                }
            },
            MaxGrade = 144
        };

        public List<TestDto> Tests = new List<TestDto>
        {
            test, test, test, test, test, test
        };

        public int GetMinPoints(TestDto test)
        {
            return (int)(test.MaxGrade * ((float)test.MinimumSuccessPercentage / 100));
        }

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
