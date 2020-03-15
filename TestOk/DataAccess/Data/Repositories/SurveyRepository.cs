using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data.DTO;
using DataAccess.Data.Models;
using DataAccess.Data.Repositories.Interfaces;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data.Repositories
{
    public class SurveyRepository: ISurveyRepository
    {
        private readonly DbContextFactory _dbContextFactory;

        private readonly ITestRepository _testRepository;

        public SurveyRepository(DbContextFactory dbContextFactory,
            ITestRepository testRepository)
        {
            _dbContextFactory = dbContextFactory;
            _testRepository = testRepository;
        }

        public SurveyDto GetActiveSurvey(int userId)
        {
            using var dbContext = _dbContextFactory.GetDbContext();

            try
            {
                var survey = dbContext.Surveys.FirstOrDefault(s => s.UserId == userId && !s.IsFinished);

                var surveyDto = survey?.ConvertToDto(_testRepository.GetTestById(survey.TestId).ConvertToDto(),
                    _testRepository.GetQuizById(survey.CurrentQuizId).ConvertToDto());

                return surveyDto;
            }
            catch (Exception e)
            {
                var err = e.Message;

                return null;
            }
        }

        public async Task<SurveyDto> StartSurvey(int userId, int testId)
        {
            try
            {
                await using var dbContext = _dbContextFactory.GetDbContext();

                var test = _testRepository.GetTestById(testId);


                var survey = new Survey
                {
                    TestId = test.Id,
                    Answers = new List<Answer>(),
                    CorrectAnswers = 0,
                    CurrentQuizId = test.Quizes.First().Id,
                    IsFinished = false,
                    UserId = userId
                };

                dbContext.Surveys.Add(survey);

                //dbContext.Database.OpenConnection();
                //dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Quizes ON");
                await dbContext.SaveChangesAsync();
                //dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Quizes OFF");
                //dbContext.Database.CloseConnection();

                return survey.ConvertToDto(test.ConvertToDto(), test.Quizes.First().ConvertToDto());
            }
            catch
            {
                return null;
            }
        }
    }
}
