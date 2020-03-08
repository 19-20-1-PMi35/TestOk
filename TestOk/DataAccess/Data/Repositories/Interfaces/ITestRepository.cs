using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Data.DTO;
using DataAccess.DTO;

namespace DataAccess.Repositories.Interfaces
{
    public interface ITestRepository
    {
        bool CreateTest(TestDto testDto);

        List<CountedSubjectDto> GetCountedSubjects();

        Task<List<TestDto>> GetTestsList(string subject);
    }
}