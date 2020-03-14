using DataAccess.Data.DTO;
using DataAccess.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface ITestRepository
    {
        bool SaveTest(TestDto testDto);

        List<CountedSubjectDto> GetCountedSubjects();

        Task<List<TestDto>> GetTestsList(string subject);

        TestDto EditTest(TestDto test);

        void DeleteTest(int id);
    }
}