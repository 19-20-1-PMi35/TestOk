﻿using DataAccess.Data.Models;
using DataAccess.DTO;
using System.Collections.Generic;
using System.Linq;

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

        public static List<QuizOptionDto> ConvertToDto(this List<QuizOption> quizOptions)
        {
            return new List<QuizOptionDto>();

            //TODO: uncomment when Quizes have non-empty options

            //return quizOptions.Select(q => new QuizOptionDto
            //{
            //    Id = q.Id,
            //    Text = q.Text
            //}).ToList();
        }

    }
}
