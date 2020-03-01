using DataAccess.Data.Models;
using DataAccess.DTO;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories
{
    public class QuizOptionRepository : IQuizOptionRepository
    {
        public bool CreateQuizOption(QuizOptionDto quizOptionDto)
        {
            using (var dbContext = new ApplicationDbContext())
            {
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
}