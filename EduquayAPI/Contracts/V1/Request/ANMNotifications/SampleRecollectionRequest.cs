using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.ANMNotifications
{
    public class SampleRecollectionRequest
    {
        public int SampleCollectionID { get; set; }
        public int SubjectID { get; set; }
        public string UniqueSubjectID { get; set; }
        public string BarcodeNo { get; set; }
        public string SampleCollectionDate { get; set; }
        public string SampleCollectionTime { get; set; }
        public int Reason_Id { get; set; }
        public int CollectionFrom { get; set; }
        public int CollectedBy { get; set; }
        public int CreatedBy { get; set; }
    }
}
