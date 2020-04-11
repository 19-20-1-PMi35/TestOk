using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data.Models;
using DataAccess.DTO;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class QuizOptionRepository : IQuizOptionRepository
    {
        private readonly DbContextFactory _dbContextFactory;
        public QuizOptionRepository(DbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public bool CreateQuizOption(QuizOptionDto quizOptionDto)
        {
            using var dbContext = _dbContextFactory.GetDbContext();

            try
            {
                dbContext.QuizOptions.Add(new QuizOption
                {
                    Text = quizOptionDto.Text
                });

                dbContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<QuizOption> GetOptionById(int id)
        {
            await using var dbContext = _dbContextFactory.GetDbContext();

            return await dbContext.QuizOptions.FirstOrDefaultAsync(q => q.Id == id);
        }

        public bool IsOneAnswerQuiz(int quizId)
        {
            using var dbContext = _dbContextFactory.GetDbContext();

            return dbContext.Quizes.Select(q => new {q.Id, q.CorrectAnswers}).FirstOrDefault(q => q.Id == quizId)?.CorrectAnswers.Count == 1;
        }
    }
}