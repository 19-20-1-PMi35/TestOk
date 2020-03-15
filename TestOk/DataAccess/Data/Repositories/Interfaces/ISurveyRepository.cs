using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Data.DTO;

namespace DataAccess.Data.Repositories.Interfaces
{
    public interface ISurveyRepository
    {
        Task<SurveyDto> StartSurvey(int userId, int testId);

        SurveyDto GetActiveSurvey(int userId);
    }
}
