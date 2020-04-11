using System.Data.Entity;
using DataAccess.Data.Models;
using DataAccess.DTO;
using DataAccess.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

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
                    CorrectAnswers = quizDto.CorrectAnswers
                        .Where(
                            quizOptionDto => quizOptionDto.IsCorrectAnswer
                        )
                        .Select(
                            quizOptionDto => new QuizOption { Text = quizOptionDto.Text }
                        )
                        .ToList()
                });


                dbContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Quiz GetQuizById(int quizId)
        {
            using var dbContext = _dbContextFactory.GetDbContext();

            return dbContext.Quizes.Select(q => new Quiz
            {
                Id = q.Id,
                CorrectAnswers = q.CorrectAnswers,
                Question = q.Question,
                Options = q.Options,
                Complexity = q.Complexity,
                PointsPerCorrectAnswer = q.PointsPerCorrectAnswer
            }).FirstOrDefault(q => q.Id == quizId);
        }
    }
}