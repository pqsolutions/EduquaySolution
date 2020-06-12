using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.ANMCHCShipment
{
    public class AddANMCHCShipmentRequest
    {
        public int SubjectID { get; set; }
        public string UniqueSubjectID { get; set; }
        public int SampleCollectionID { get; set; }
        public string ShipmentFrom { get; set; }
        public string ShipmentID { get; set; }
        public int ANM_ID { get; set; }
        public int TestingCHCID { get; set; }
        public int RIID { get; set; }
        public int ILR_ID { get; set; }
        public int AVDID { get; set; }
        public string DeliveryExecutiveName { get; set; }
        public string ContactNo { get; set; }
        public string DateofShipment { get; set; }
        public string TimeofShipment { get; set; }
        public int CreatedBy { get; set; }
    }
}
