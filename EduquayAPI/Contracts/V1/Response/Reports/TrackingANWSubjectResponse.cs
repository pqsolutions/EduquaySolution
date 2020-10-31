using EduquayAPI.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.Reports
{
    public class TrackingANWSubjectResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public TrackingANWSubject data { get; set; }
    }
}
