using DataAccess.Data.Models;
using DataAccess.DTO;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Data.DTO;

namespace DataAccess.Data
{
    public static class Extensions
    {
        public static List<QuizDto> ConvertToDto(this List<Quiz> quizes)
        {
            return quizes.Select(q => new QuizDto
            {
                Question = q.Question,
                Id = q.Id,
                Complexity = q.Complexity,
                PointsPerCorrectAnswer = q.PointsPerCorrectAnswer,
                Options = q.Options.ConvertToDto(),
                CorrectAnswers = q.Options.ConvertToDto()
            }).ToList();
        }

        public static List<Quiz> ConvertToModel(this List<QuizDto> quizes)
        {
            return quizes.Select(q => new Quiz
            {
                Question = q.Question,
                Id = q.Id,
                Complexity = q.Complexity,
                PointsPerCorrectAnswer = q.PointsPerCorrectAnswer,
                Options = q.Options.ConvertToModel(),
                CorrectAnswers = q.Options.ConvertToModel()
            }).ToList();
        }

        public static List<QuizOptionDto> ConvertToDto(this List<QuizOption> quizOptions)
        {
            try
            {

                return quizOptions.Select(q => new QuizOptionDto
                {
                    Id = q.Id,
                    Text = q.Text
                }).ToList();
            }
            catch
            {
                return new List<QuizOptionDto>();
            }
        }

        public static List<QuizOption> ConvertToModel(this List<QuizOptionDto> quizOptions)
        {
            return new List<QuizOption>();
        }

        public static QuizDto ConvertToDto(this Quiz quiz)
        {
            return new QuizDto
            {
                Id = quiz.Id,
                CorrectAnswers = quiz.CorrectAnswers.ConvertToDto(),
                Options = quiz.Options.ConvertToDto(),
                Question = quiz.Question,
                Complexity = quiz.Complexity,
                PointsPerCorrectAnswer = quiz.PointsPerCorrectAnswer
            };
        }

        public static TestDto ConvertToDto(this Test test)
        {
            return new TestDto
            {
                Subject = test.Subject,
                MinimumSuccessPercentage = test.MinimumSuccessPercentage,
                MaxGrade = test.MaxGrade,
                Id = test.Id,
                Quizes = test.Quizes.ConvertToDto()
            };
        }

        public static List<AnswerDto> ConvertToDto(this List<Answer> answers)
        {
            return answers.Select(a => new AnswerDto
            {
                Id = a.Id,
                SurveyId = a.Survey.Id,
                QuizId = a.Quiz.Id,
                QuizAnswer = a.QuizOption.ConvertToDto()
            }).ToList();
        }

        public static SurveyDto ConvertToDto(this Survey survey, Test test, Quiz quiz, List<Answer> answers)
        {
            return new SurveyDto
            {
                Id = survey.Id,
                Test = test.ConvertToDto(),
                CurrentQuiz = quiz.ConvertToDto(),
                CurrentQuizAnswers = answers.ConvertToDto(),
                IsFinished = survey.IsFinished,
                UserId = survey.UserId.GetValueOrDefault(),
                Mark = survey.Mark
            };
        }

        public static SurveyDto ConvertToDto(this Survey survey, List<Answer> answers)
        {
            return new SurveyDto
            {
                Id = survey.Id,
                Test = survey.Test.ConvertToDto(),
                CurrentQuiz = survey.CurrentQuiz.ConvertToDto(),
                CurrentQuizAnswers = ( answers != null && answers.Count != 0) ? answers.ConvertToDto() : new List<AnswerDto>(),
                IsFinished = survey.IsFinished,
                UserId = survey.UserId.GetValueOrDefault(),
                Mark = survey.Mark
            };
        }

        public static QuizOptionDto ConvertToDto(this QuizOption quizOption)
        {
            return new QuizOptionDto
            {
                Id = quizOption.Id,
                Text = quizOption.Text
            };
        }
    }
}
