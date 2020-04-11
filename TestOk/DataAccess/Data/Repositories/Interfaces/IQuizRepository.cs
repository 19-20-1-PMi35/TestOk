using System.Threading.Tasks;
using DataAccess.Data.Models;
using DataAccess.DTO;

namespace DataAccess.Repositories.Interfaces
{
    public interface IQuizRepository
    {
        bool CreateQuiz(QuizDto quizDto);

        Quiz GetQuizById(int quizId);
    }
}
