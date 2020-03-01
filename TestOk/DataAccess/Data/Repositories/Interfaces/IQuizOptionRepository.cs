using DataAccess.DTO;

namespace DataAccess.Repositories.Interfaces
{
    public interface IQuizOptionRepository
    {
        bool CreateQuizOption(QuizOptionDto quizOptionDto);
    }
}
