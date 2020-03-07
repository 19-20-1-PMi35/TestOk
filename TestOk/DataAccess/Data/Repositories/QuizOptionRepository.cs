using DataAccess.Data.Models;
using DataAccess.DTO;
using DataAccess.Repositories.Interfaces;

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
    }
}