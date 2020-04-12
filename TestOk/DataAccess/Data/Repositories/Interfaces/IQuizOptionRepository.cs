using System.Threading.Tasks;
using DataAccess.Data.Models;
using DataAccess.DTO;

namespace DataAccess.Repositories.Interfaces
{
    public interface IQuizOptionRepository
    {
        bool CreateQuizOption(QuizOptionDto quizOptionDto);

        Task<QuizOption> GetOptionById(int id);

        bool IsOneAnswerQuiz(int quizId);
    }
}
