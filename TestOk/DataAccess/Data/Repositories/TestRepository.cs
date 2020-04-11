using DataAccess.Data;
using DataAccess.Data.DTO;
using DataAccess.Data.Models;
using DataAccess.DTO;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly DbContextFactory _dbContextFactory;
        public TestRepository(DbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public bool SaveTest(TestDto testDto)
        {
            using var dbContext = _dbContextFactory.GetDbContext();

            try
            {
                dbContext.Tests.Add(new Test
                {
                    MinimumSuccessPercentage = testDto.MinimumSuccessPercentage,
                    Subject = testDto.Subject,
                    MaxGrade = testDto.MaxGrade,
                    Quizes = testDto.Quizes.Select(quizDto => new Quiz
                    {
                        Question = quizDto.Question,
                        PointsPerCorrectAnswer = quizDto.PointsPerCorrectAnswer,
                        Complexity = quizDto.Complexity,
                        Options = quizDto.Options.Select(quizOption => new QuizOption
                        {
                            Text = quizOption.Text
                        }).ToList(),
                        CorrectAnswers = quizDto.Options
                            .Where(
                                quizOptionDto => quizOptionDto.IsCorrectAnswer
                            )
                            .Select(
                                quizOptionDto => new QuizOption { Text = quizOptionDto.Text }
                            )
                            .ToList()
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
                ? await EntityFrameworkQueryableExtensions.ToListAsync(allTests)
                : await EntityFrameworkQueryableExtensions.ToListAsync(allTests.Where(t => t.Subject.Equals(subject)));
        }

        public TestDto EditTest(TestDto test)
        {
            using var dbContext = _dbContextFactory.GetDbContext();
            Test testToEdit = new Test();

            testToEdit = dbContext.Tests.FirstOrDefault(x => x.Id == test.Id);
            testToEdit.Id = test.Id;
            testToEdit.MaxGrade = test.MaxGrade;
            testToEdit.MinimumSuccessPercentage = test.MinimumSuccessPercentage;
            testToEdit.Quizes = test.Quizes.ConvertToModel();
            testToEdit.Subject = test.Subject;

            dbContext.SaveChanges();
            return test;

        }

        public void DeleteTest(int id)
        {
            using var dbContext = _dbContextFactory.GetDbContext();

            try
            {
                var testToDelete = dbContext.Tests.Select(t => new Test
                {
                    Id = t.Id,
                    MaxGrade = t.MaxGrade,
                    Subject = t.Subject,
                    MinimumSuccessPercentage = t.MinimumSuccessPercentage,
                    Quizes = t.Quizes
                }).FirstOrDefault(x => x.Id == id);

                dbContext.Tests.Remove(testToDelete);
                dbContext.SaveChanges();
            }
            catch
            {
                dbContext.SaveChanges();
            }
        }

        public Test GetTestById(int testId)
        {
            using var dbContext = _dbContextFactory.GetDbContext();

            try
            {
                return dbContext.Tests.Select(t => new Test
                {
                    Subject = t.Subject,
                    Id = t.Id,
                    MinimumSuccessPercentage = t.MinimumSuccessPercentage,
                    MaxGrade = t.MaxGrade,
                    Quizes = t.Quizes
                }).FirstOrDefault(t => t.Id == testId);
            }
            catch
            {
                return new Test();
            }
        }
    }
}