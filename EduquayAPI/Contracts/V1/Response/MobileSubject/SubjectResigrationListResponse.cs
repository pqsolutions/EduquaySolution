using EduquayAPI.Models.MobileSubject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.MobileSubject
{
    public class SubjectResigrationListResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<SubjectResigration> SubjectResigrations { get; set; }
        public List<SampleCollection> SampleCollections { get; set; }
        public List<ShipmentLogs> ShipmentLogDetail { get; set; }


    }

    public class SubjectResigration
    {
        public SubjectPrimary PrimaryDetail { get; set; }
        public SubjectAddress AddressDetail { get; set; }
        public SubjectPregnancy PregnancyDetail { get; set; }
        public SubjectParent ParentDetail { get; set; }

    }


    public class ShipmentLogs
    {
        public string shipmentId { get; set; }
        public int anmId { get; set; }
        public string anmName { get; set; }
        public int testingCHCId { get; set; }
        public string testingCHC { get; set; }
        public int avdId { get; set; }
        public string avdName { get; set; }
        public string avdContactNo { get; set; }
        public string alternateAVD { get; set; }
        public string alternateAVDContactNo { get; set; }
        public int ilrId { get; set; }
        public string ilrPoint { get; set; }
        public int riId { get; set; }
        public string riPoint { get; set; }
        public string dateOfShipment { get; set; }
        public string timeOfShipment { get; set; }
        public int createdBy { get; set; }
        public string source { get; set; }

        public List<MobileShipmentSample> SamplesDetail { get; set; }

    }

}

