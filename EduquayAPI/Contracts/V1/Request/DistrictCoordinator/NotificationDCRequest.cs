using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.DistrictCoordinator
{
    public class NotificationDCRequest
    {
        public string barcodeNo { get; set; }
        public int userId { get; set; }

    }
}
