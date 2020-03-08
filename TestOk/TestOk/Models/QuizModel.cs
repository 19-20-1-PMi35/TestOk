using DataAccess.DTO;

namespace TestOk.Models
{
    public class QuizModel
    {
        public QuizDto Quiz { get; set; }

        public QuizModel()
        {
            Quiz = new QuizDto();
        }
    }
}
