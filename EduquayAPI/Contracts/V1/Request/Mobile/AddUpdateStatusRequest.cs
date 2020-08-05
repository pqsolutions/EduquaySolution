using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.Mobile
{
    public class AddUpdateStatusRequest
    {
        public string deviceId { get; set; }
        public AddUpdateStatus data { get; set; }
    }
    public class SampleUpdateStatus
    {
        public UpdateStatusRequest Samples { get; set; }
    }

    public class AddUpdateStatus
    {
        public List<SampleUpdateStatus> UpdateStatusRequest { get; set; }
    }
}
