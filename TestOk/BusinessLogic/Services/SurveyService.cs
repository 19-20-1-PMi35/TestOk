using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using BusinessLogic.Services.Interfaces;
using DataAccess.Data.DTO;
using DataAccess.Data.Models;
using DataAccess.Data.Repositories.Interfaces;
using DataAccess.DTO;
using DataAccess.Repositories.Interfaces;

namespace BusinessLogic.Services
{
    public class SurveyService: ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IQuizOptionRepository _quizOptionRepository;
        private readonly IQuizRepository _quizRepository;

        public SurveyService(ISurveyRepository surveyRepository, IQuizOptionRepository quizOptionRepository,
            IQuizRepository quizRepository)
        {
            _surveyRepository = surveyRepository;
            _quizOptionRepository = quizOptionRepository;
            _quizRepository = quizRepository;
        }

        public async Task<SurveyDto> StartSurvey(int testId)
        {
            //change user id to not hardcoded later :)
            return await _surveyRepository.StartSurvey(0, testId);
        }

        public async Task<SurveyDto> GetSurvey()
        {
            //change user id to not hardcoded later :)
            return await _surveyRepository.GetActiveSurvey(0);
        }

        public async Task ChooseAnswer(int quizId, int optionId, int surveyId)
        {
            var isOneAnswer = _quizOptionRepository.IsOneAnswerQuiz(quizId);

            await _surveyRepository.UpdateAnswer(quizId, optionId, surveyId, isOneAnswer);
        }

        public async Task<SurveyDto> SwitchQuiz(int quizId)
        {
            //change user id to not hardcoded later :)
            return await _surveyRepository.SwitchQuiz(quizId, 0);
        }

        public async Task FinishSurvey()
        {
            var survey = await _surveyRepository.GetActiveSurvey(0);
            if (survey == null)
                return;

            var quizes = survey.Test.Quizes.Select(q => _quizRepository.GetQuizById(q.Id));

            decimal mark = 0;

            foreach (var quiz in quizes)
            {
                var answers = await _surveyRepository.GetAnswersByQuiz(quiz.Id, survey.Id);

                if (IsCorrectAnswers(quiz.CorrectAnswers, answers))
                {
                    mark += quiz.PointsPerCorrectAnswer;
                }
            }

            await _surveyRepository.FinishSurvey(survey.Id, mark);
        }

        private bool IsCorrectAnswers(List<QuizOption> correctAnswers, List<Answer> chosenAnswers)
        {
            var correctIds = correctAnswers.Select(q => q.Id).ToList();

            var chosenIds = chosenAnswers.Select(q => q.QuizOption.Id).ToList();

            var firstNotSecond = correctIds.Except(chosenIds);
            var secondNotFirst = chosenIds.Except(correctIds);

            return !firstNotSecond.Any() && !secondNotFirst.Any();
        }
    }
}
