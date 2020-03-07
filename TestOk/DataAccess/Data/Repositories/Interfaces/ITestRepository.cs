using System.Collections.Generic;
using DataAccess.Data.DTO;
using DataAccess.DTO;

namespace DataAccess.Repositories.Interfaces
{
    public interface ITestRepository
    {
        bool CreateTest(TestDto testDto);

        List<CountedSubjectDto> GetCountedSubjects();
    }
}