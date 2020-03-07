using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Data.DTO;

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
    }
}
