using EduquayAPI.Models.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.Support
{
    public class CheckRCHResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public bool rchExist { get; set; }
        public bool rchValid { get; set; }
        public BarcodeErrorDetail data { get; set; }
    }
}
