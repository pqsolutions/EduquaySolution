using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.ANMNotifications
{
    public class NotificationUpdateStatusRequest
    {
        public string barcodeNo { get; set; } // Array of Barcode Nos
        public int anmId { get; set; }
    }
}
