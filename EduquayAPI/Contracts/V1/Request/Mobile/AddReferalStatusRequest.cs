using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.Mobile
{
    public class AddReferalStatusRequest
    {
        public string deviceId { get; set; }
        public List<MobileReferalRequest> data { get; set; }
    }

    //public class ReferalUpdateStatus
    //{
    //    public MobileReferalRequest  referalRequest{ get; set; }
    //}

    //public class AddReferalStatus
    //{
    //    public List<ReferalUpdateStatus> updateStatusRequest { get; set; }
    //}
}
