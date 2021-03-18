using EduquayAPI.Models.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.Support
{
    public class CheckBarcodeResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public bool barcodeExist { get; set; }
        public bool barcodeValid { get; set; }
        public BarcodeErrorDetail data { get; set; }
}
}
