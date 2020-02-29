using System;
using System.Threading.Tasks;
using DataAccess.Data.Models;
using DataAccess.DTO;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories
{
    public class TestRepository: ITestRepository
    {
        public bool CreateTest(TestDto testDto)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                try
                {
                    dbContext.Tests.Add(new Test
                    {
                        Date = testDto.Date,
                        GroupId = testDto.GroupId,
                        MaxGrade = testDto.MaxGrade,
                        MinimumSuccessPercentage = testDto.MinimumSuccessPercentage,
                        Subject = testDto.Subject,
                        TeacherId = testDto.TeacherId,
                    });

                    dbContext.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}