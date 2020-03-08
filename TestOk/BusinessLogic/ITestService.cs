using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Data.DTO;
using DataAccess.DTO;

namespace BusinessLogic
{
    public interface ITestService
    {
        List<CountedSubjectDto> GetCountedTestSubjects();

        Task<List<TestDto>> GetTestsList(string subject = null);
    }
}
