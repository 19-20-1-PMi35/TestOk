using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces 
{ 
    public interface ITestService
    {
        bool CreateTest(TestDto testDto);
    }
}
