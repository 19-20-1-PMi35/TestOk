using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Data.DTO;
using DataAccess.DTO;

namespace BusinessLogic.Services.Interfaces
{
    public interface IStatisticsService
    {
        int GetAverageMark(string userId);

        int GetMarkForTest(int surveyId, string userId);

        int GetMarkToPass(int surveyId, string userId);
    }
}