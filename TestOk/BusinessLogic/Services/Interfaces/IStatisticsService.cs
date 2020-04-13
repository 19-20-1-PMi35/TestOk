using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Data.DTO;
using DataAccess.DTO;

namespace BusinessLogic.Services.Interfaces
{
    public interface IStatisticsService
    {
        int GetAverageMark();

        int GetMarkForTest(int surveyId);
    }
}