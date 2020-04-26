using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data.DTO;
using DataAccess.Data.Models;
using DataAccess.Data.Repositories.Interfaces;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data.Repositories
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly DbContextFactory _dbContextFactory;

        private readonly ITestRepository _testRepository;
        private readonly IQuizRepository _quizRepository;

        public SurveyRepository(DbContextFactory dbContextFactory, ITestRepository testRepository, IQuizRepository quizRepository)
        {
            _dbContextFactory = dbContextFactory;
            _testRepository = testRepository;
            _quizRepository = quizRepository;
        }

        public async Task<SurveyDto> GetActiveSurvey(int userId)
        {
            try
            {
                await using var dbContext = _dbContextFactory.GetDbContext();

                var survey = GetSurveyByUserId(userId, dbContext).FirstOrDefault(s => !s.IsFinished);

                var answers = await GetAnswersByQuiz(survey.CurrentQuiz.Id, survey.Id);

                var surveyDto = survey.ConvertToDto(answers);

                return surveyDto;
            }
            catch
            {
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
                    Mark = 0,
                    CurrentQuizId = test.Quizes.First().Id,
                    IsFinished = false,
                    UserId = userId
                };

                dbContext.Surveys.Add(survey);

                await dbContext.SaveChangesAsync();

                return survey.ConvertToDto(test, test.Quizes.First(), new List<Answer>());
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Answer>> GetAnswersByQuiz(int quizId, int surveyId)
        {
            await using var dbContext = _dbContextFactory.GetDbContext();

            return await dbContext.Answers.Where(a => a.SurveyId == surveyId && a.QuizId == quizId).Select(a => new Answer
            {
                Id = a.Id,
                Quiz = a.Quiz,
                Survey = a.Survey,
                QuizOption = a.QuizOption
            }).ToListAsync();
        }

        public async Task UpdateAnswer(int quizId, int optionId, int surveyId, bool isOneAnswer)
        {
            await using var dbContext = _dbContextFactory.GetDbContext();

            var existingAnswers = dbContext.Answers.Where(a => a.QuizId == quizId && a.SurveyId == surveyId);

            if (await existingAnswers.CountAsync() > 0)
            {
                var alreadySavedAnswer = await existingAnswers.FirstOrDefaultAsync(a => a.QuizOptionId == optionId);

                if (alreadySavedAnswer != null)
                {
                    dbContext.Answers.Remove(alreadySavedAnswer);
                    goto SaveChanges;
                }
                if (isOneAnswer)
                {
                    dbContext.RemoveRange(existingAnswers);
                }
            }

            dbContext.Answers.Add(new Answer
            {
                QuizId = quizId,
                QuizOptionId = optionId,
                SurveyId = surveyId
            });

        SaveChanges:
            await dbContext.SaveChangesAsync();
        }

        public async Task<SurveyDto> SwitchQuiz(int quizId, int userId)
        {
            await using var dbContext = _dbContextFactory.GetDbContext();
            var surveyId = GetSurveyByUserId(userId, dbContext).Select(s => new { s.Id, s.IsFinished })
                .FirstOrDefault(s => !s.IsFinished).Id;

            dbContext.Surveys.FirstOrDefault(s => s.Id == surveyId).CurrentQuizId = quizId;

            await dbContext.SaveChangesAsync();

            return await GetActiveSurvey(userId);
        }

        public async Task FinishSurvey(int surveyId, double mark)
        {
            await using var dbContext = _dbContextFactory.GetDbContext();

            var survey = await dbContext.Surveys.FirstAsync(s => s.Id == surveyId);

            survey.IsFinished = true;
            survey.Mark = (int)mark;

            await dbContext.SaveChangesAsync();
        }

        public List<SurveyDto> FinishedSurveys(int userId)
        {
            using var dbContext = _dbContextFactory.GetDbContext();

            var surveys = GetSurveyByUserId(userId, dbContext);

            return surveys.Select(x => x.ConvertToDto(new List<Answer>())).ToList();
        }

        private IEnumerable<Survey> GetSurveyByUserId(int userId, ApplicationDbContext dbContext)
        {
            return dbContext.Surveys.Select(s => new Survey
            {
                Id = s.Id,
                Test = _testRepository.GetTestById(s.TestId.Value),
                CurrentQuiz = _quizRepository.GetQuizById(s.CurrentQuizId.Value),
                IsFinished = s.IsFinished,
                Mark = s.Mark,
                UserId = s.UserId,
                CurrentQuizId = s.CurrentQuizId,
                TestId = s.TestId
            }).Where(a => a.UserId == userId).AsEnumerable();
        }
    }
}
