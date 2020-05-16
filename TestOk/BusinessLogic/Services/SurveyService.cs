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

        public async Task<SurveyDto> StartSurvey(int testId, string userId)
        {
            //change user id to not hardcoded later :)
            return await _surveyRepository.StartSurvey(userId, testId);
        }

        public async Task<SurveyDto> GetSurvey(string userId)
        {
            //change user id to not hardcoded later :)
            return await _surveyRepository.GetActiveSurvey(userId);
        }

        public async Task ChooseAnswer(int quizId, int optionId, int surveyId)
        {
            var isOneAnswer = _quizOptionRepository.IsOneAnswerQuiz(quizId);

            await _surveyRepository.UpdateAnswer(quizId, optionId, surveyId, isOneAnswer);
        }

        public async Task<SurveyDto> SwitchQuiz(int quizId, string userId)
        {
            //change user id to not hardcoded later :)
            return await _surveyRepository.SwitchQuiz(quizId, userId);
        }

        public async Task FinishSurvey(string userId)
        {
            var survey = await _surveyRepository.GetActiveSurvey(userId);
            if (survey == null)
                return;

            var quizes = survey.Test.Quizes.Select(q => _quizRepository.GetQuizById(q.Id));

            double mark = 0;

            foreach (var quiz in quizes)
            {
                var answers = await _surveyRepository.GetAnswersByQuiz(quiz.Id, survey.Id);

                var markForQuiz = GetNumberOfCorrectAnswers(quiz.CorrectAnswers, answers);

                mark += markForQuiz > 0
                    ? markForQuiz * quiz.PointsPerCorrectAnswer
                    : 0;
            }

            await _surveyRepository.FinishSurvey(survey.Id, mark);
        }

        private int GetNumberOfCorrectAnswers(List<QuizOption> correctAnswers, List<Answer> chosenAnswers)
        {
            var correctAnswerStrings = correctAnswers.Select(q => q.Text).ToList();

            var chosenAnswerStrings = chosenAnswers.Select(q => q.QuizOption.Text).ToList();

            var correctAnswersNumber = chosenAnswerStrings.Count(chosen => correctAnswerStrings.Contains(chosen));
            var notCorrectAnswersNumber =
                chosenAnswerStrings.Count(chosen => correctAnswerStrings.All(correct => chosen != correct));

            return correctAnswersNumber - notCorrectAnswersNumber;
        }
    }
}
