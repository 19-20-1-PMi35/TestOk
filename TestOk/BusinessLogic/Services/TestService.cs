using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Services
{
    public class TestService: ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository) 
        {
            _testRepository = testRepository;
        }

        public List<string> GetFormattedTestSubjects()
        {
            var countedSubjects = _testRepository.GetCountedSubjects();

            return countedSubjects.Select(s => $"{s.Subject} ({s.Count})").ToList();
        }

    }
}
