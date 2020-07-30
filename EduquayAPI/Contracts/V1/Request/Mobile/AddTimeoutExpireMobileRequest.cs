using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.Mobile
{
    public class AddTimeoutExpireMobileRequest
    {
        public string deviceId { get; set; }
        public AddTimeoutSample data { get; set; }
    }

    public class SampleTimout
    {
        public  MobileAddExpiryRequest samples { get; set; }
    }

    public class AddTimeoutSample
    {
        public List<SampleTimout> MoveTimeoutRequest { get; set; }
    }

}
