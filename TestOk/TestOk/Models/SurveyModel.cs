﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DataAccess.Data.DTO;
using DataAccess.DTO;

namespace TestOk.Models
{
    public class SurveyModel
    {
        public SurveyDto SurveyDto;

        public SurveyModel(SurveyDto surveyDto)
        {
            SurveyDto = surveyDto;
        }
    }
}
