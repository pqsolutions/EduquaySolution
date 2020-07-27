using EduquayAPI.Models.CHCNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.CHCNotifications
{
    public class HPLCPositiveSubjectsResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<CHCHPLCPositiveSamples> positiveSubjects { get; set; }
    }
}
