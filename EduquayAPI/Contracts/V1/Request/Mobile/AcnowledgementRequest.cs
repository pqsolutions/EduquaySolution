using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.Mobile
{
    public class AcnowledgementRequest
    {
        public string deviceId { get; set; }
        public Acknowledgement data { get; set; }
    }

    public class Acknowledge
    {
        public string uniqueSubjectId { get; set; }
        public int userId { get; set; } 
    }

    public class Acknowledgement
    {
        public List<Acknowledge> AcknowledgementRequest { get; set; }
    }
}
