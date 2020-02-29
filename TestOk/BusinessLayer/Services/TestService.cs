using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using BusinessLayer.Interfaces;
using DataAccess.DTO;
using DataAccess.Repositories.Interfaces;

namespace BusinessLayer.Services
{
    public class TestService: ITestService
    {
        private readonly ITestRepository testRepository;

        public TestService(ITestRepository testRepository)
        {
            this.testRepository = testRepository;

        }

        public bool CreateTest(TestDto testDto)
        {
            return testRepository.CreateTest(testDto);
        }
    }
}
