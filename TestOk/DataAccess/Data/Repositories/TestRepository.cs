using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data;
using DataAccess.Data.DTO;
using DataAccess.Data.Models;
using DataAccess.DTO;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class TestRepository: ITestRepository
    {
        private readonly DbContextFactory _dbContextFactory;
        public TestRepository(DbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public bool CreateTest(TestDto testDto)
        {
            using var dbContext = _dbContextFactory.GetDbContext();

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

       public List<CountedSubjectDto> GetCountedSubjects()
       {
           using var dbContext = _dbContextFactory.GetDbContext();

           try
           {
               return dbContext.Tests.GroupBy(t => t.Subject).Select(t => new CountedSubjectDto
               {
                   Subject = t.Key,
                   Count = t.Count()
               }).ToList();
           }
           catch
           {
               return new List<CountedSubjectDto>();
           }
       }

       public async Task<List<TestDto>> GetTestsList(string subject)
       { 
           await using var dbContext = _dbContextFactory.GetDbContext();

           var allTests = dbContext.Tests.Select(t => new TestDto
           {
               Id = t.Id,
               MaxGrade = t.MaxGrade,
               Subject = t.Subject,
               MinimumSuccessPercentage = t.MinimumSuccessPercentage,
               Quizes = t.Quizes.ConvertToDto()
           });

           return string.IsNullOrEmpty(subject)
               ? await allTests.ToListAsync()
               : await allTests.Where(t => t.Subject.Equals(subject)).ToListAsync();
       }
    }
}