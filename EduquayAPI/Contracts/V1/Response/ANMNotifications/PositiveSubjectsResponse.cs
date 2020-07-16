using EduquayAPI.Models.ANMNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.ANMNotifications
{
    public class PositiveSubjectsResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<ANMHPLCPositiveSamples> positiveSubjects { get; set; }
    }
}
