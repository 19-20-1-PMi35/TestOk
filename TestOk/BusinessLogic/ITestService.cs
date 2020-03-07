using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Data.DTO;

namespace BusinessLogic
{
    public interface ITestService
    {
        List<CountedSubjectDto> GetCountedTestSubjects();
    }
}
