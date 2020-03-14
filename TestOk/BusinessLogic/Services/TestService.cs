using DataAccess.Data.DTO;
using DataAccess.DTO;
using DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public List<CountedSubjectDto> GetCountedTestSubjects()
        {
            return _testRepository.GetCountedSubjects();
        }

        public async Task<List<TestDto>> GetTestsList(string subject = null)
        {
            return await _testRepository.GetTestsList(subject);
        }

        public bool SaveTest(TestDto testDto)
        {
            return _testRepository.SaveTest(testDto);
        }
    }
}
