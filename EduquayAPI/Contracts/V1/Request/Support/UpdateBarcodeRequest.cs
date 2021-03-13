using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.Support
{
    public class UpdateBarcodeRequest
    {
        public string barcodeNo { get; set; }
        public string revisedBarcodeNo { get; set; }
        public int userId { get; set; }
    }
}
