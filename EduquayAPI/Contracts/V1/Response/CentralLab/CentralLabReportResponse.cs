﻿using EduquayAPI.Models.CentralLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.CentralLab
{
    public class CentralLabReportResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<CentralLabReports> Subjects { get; set; }
    }
}
