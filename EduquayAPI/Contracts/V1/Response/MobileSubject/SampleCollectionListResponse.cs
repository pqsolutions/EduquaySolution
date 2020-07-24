using EduquayAPI.Models.ANMSubjectRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.MobileSubject
{
    public class SampleCollectionListResponse
    {
        public string Status { get; set; }
        public bool Valid { get; set; }
        public string Message { get; set; }
        public List<BarcodeSampleDetail> Barcodes { get; set; }
    }
}
