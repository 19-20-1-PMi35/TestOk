using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data.Models;
using DataAccess.DTO;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories
{
    public class TestRepository: ITestRepository
    {
        public bool CreateTest(TestDto testDto)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                try
                {
                    dbContext.Tests.Add(new Test
                    {
                        MinimumSuccessPercentage = testDto.MinimumSuccessPercentage,
                        Subject = testDto.Subject,
                        Quizes = testDto.Quizes.Select(quizDto => new Quiz
                        {
                            Question = quizDto.Question,
                            PointsPerCorrectAnswer = quizDto.PointsPerCorrectAnswer,
                            Complexity = quizDto.Complexity,
                            Options = quizDto.Options.Select(quizOption => new QuizOption
                            { 
                            Text = quizOption.Text
                            }).ToList(),
                            CorrectAnswers = quizDto.CorrectAnswers.Select(quizOption => new QuizOption
                            {
                                Text = quizOption.Text
                            }).ToList(),
                        }).ToList()
                    });

                    dbContext.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}