using EduquayAPI.Models.CHCReceipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.CHCReceipt
{
    public class CHCSampleStatusResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<CHCSampleStatus> sampleStatus { get; set; }
    }
}
