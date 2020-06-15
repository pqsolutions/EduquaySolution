using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.ANMCHCShipment
{
    public class AddANMCHCShipmentRequest
    {
        public int subjectId { get; set; }
        public string uniqueSubjectId { get; set; }
        public int sampleCollectionId { get; set; }
        public string shipmentFrom { get; set; }
        public string shipmentId { get; set; }
        public int anmId { get; set; }
        public int testingCHCId { get; set; }
        public int riId { get; set; }
        public int ilrId { get; set; }
        public int avdId { get; set; }
        public string deliveryExecutiveName { get; set; }
        public string contactNo { get; set; }
        public string dateOfShipment { get; set; }
        public string timeOfShipment { get; set; }
        public int createdBy { get; set; }
    }
}
