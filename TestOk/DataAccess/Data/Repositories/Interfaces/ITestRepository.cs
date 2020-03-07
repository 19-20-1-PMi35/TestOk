using DataAccess.DTO;

namespace DataAccess.Repositories.Interfaces
{
    public interface ITestRepository
    {
        bool CreateTest(TestDto testDto);
    }
}