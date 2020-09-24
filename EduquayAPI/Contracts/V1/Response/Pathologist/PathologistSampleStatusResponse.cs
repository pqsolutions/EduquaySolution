using EduquayAPI.Models.Pathologist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.Pathologist
{
    public class PathologistSampleStatusResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<PathologistSampleStatus> sampleStatus { get; set; }
    }
}
