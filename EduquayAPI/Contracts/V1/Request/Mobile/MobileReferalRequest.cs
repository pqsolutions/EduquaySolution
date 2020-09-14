using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.Mobile
{
    public class MobileReferalRequest
    {
        public int userId { get; set; }
        public string uniqueSubjectId { get; set; }
    }
}
