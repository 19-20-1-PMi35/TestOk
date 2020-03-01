using DataAccess.DTO;

namespace DataAccess.Repositories.Interfaces
{
    public interface IQuizRepository
    {
        bool CreateQuiz(QuizDto quizDto);
    }
}
