using DataAccess.Data.DTO;
using DataAccess.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface ITestService
    {
        List<CountedSubjectDto> GetCountedTestSubjects();

        Task<List<TestDto>> GetTestsList(string subject = null);
        bool SaveTest(TestDto testDto);
    }
}
