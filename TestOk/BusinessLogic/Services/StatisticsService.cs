using BusinessLogic.Services.Interfaces;
using DataAccess.Data.Repositories.Interfaces;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly ITestRepository _testRepository;


        public StatisticsService(ISurveyRepository surveyRepository, ITestRepository testRepository)
        {
            _surveyRepository = surveyRepository;
            _testRepository = testRepository;
        }

        public int GetAverageMark(string userId)
        {
            var surveys = _surveyRepository.FinishedSurveys(userId);
            var marks = surveys.Select(x => x.Mark);

            return marks.Sum() / marks.Count();
        }

        public int GetMarkForTest(int surveyId, string userId)
        {
            var surveys = _surveyRepository.FinishedSurveys(userId);
            var certainSurveys = surveys.Where(x => x.Id == surveyId).FirstOrDefault();

            return certainSurveys.Mark;
        }

        public int GetMarkToPass(int surveyId, string userId)
        {
            var surveys = _surveyRepository.FinishedSurveys(userId);
            var certainSurvey = surveys.Where(x => x.Id == surveyId).FirstOrDefault();
            var tests = _testRepository.GetTestById(certainSurvey.Test.Id);

            return tests.MaxGrade * tests.MinimumSuccessPercentage / 100;
        }
    }
}