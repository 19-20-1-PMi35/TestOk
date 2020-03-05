using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data.Models;
using DataAccess.DTO;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly DbContextFactory _dbContextFactory;
        public QuizRepository(DbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }


        public bool CreateQuiz(QuizDto quizDto)
        {
            using var dbContext = _dbContextFactory.GetDbContext();

            try
            {
                dbContext.Quizes.Add(new Quiz
                {
                    Question = quizDto.Question,
                    PointsPerCorrectAnswer = quizDto.PointsPerCorrectAnswer,
                    Complexity = quizDto.Complexity,
                    Options = quizDto.Options.Select(
                        quizOptionDto => new QuizOption { Text = quizOptionDto.Text }
                    ).ToList(),
                    CorrectAnswers = quizDto.CorrectAnswers.Select(
                        quizOptionDto => new QuizOption { Text = quizOptionDto.Text }
                    ).ToList()
                });


                dbContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}