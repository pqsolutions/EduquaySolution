using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.Mobile
{
    public class AddPNDTMTPAckRequest
    {
        public string uniqueSubjectId { get; set; }
        public int inputRequest { get; set; }
        public int userId { get; set; }

    }
}
