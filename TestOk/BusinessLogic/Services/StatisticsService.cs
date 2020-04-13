using BusinessLogic.Services.Interfaces;
using DataAccess.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ISurveyRepository _surveyRepository;

        public StatisticsService(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        public int GetAverageMark()
        {
            var surveys = _surveyRepository.FinishedSurveys(0);
            var marks = surveys.Select(x => x.Mark);

            return marks.Sum() / marks.Count();
        }

        public int GetMarkForTest(int surveyId)
        {
            var surveys = _surveyRepository.FinishedSurveys(0);
            var certainSurveys = surveys.Where(x => x.Id == surveyId).FirstOrDefault();

            return certainSurveys.Mark;
        }
    }
}