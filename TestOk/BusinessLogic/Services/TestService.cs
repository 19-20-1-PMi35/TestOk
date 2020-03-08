using DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Data.DTO;
using DataAccess.DTO;

namespace BusinessLogic.Services
{
    public class TestService: ITestService
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
    }
}
