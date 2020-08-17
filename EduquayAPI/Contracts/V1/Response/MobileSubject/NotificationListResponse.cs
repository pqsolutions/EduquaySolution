using EduquayAPI.Models.MobileSubject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.MobileSubject
{
    public class NotificationListResponse
    {
        public string Status { get; set; }
        public bool Valid { get; set; }
        public string Message { get; set; }
        public int totalNotifications { get; set; }
        public List<MobileNotificationSamples> DamagedSamples { get; set; }
        public List<MobileNotificationSamples> TimeoutExpirySamples { get; set; }
        public List<MobilePositiveSubjects> PositiveSubjects  { get; set; }
        public List<CHCSubjectResigration> chcSubjectResigrations { get; set; }
        public List<SampleCollection> chcSampleCollections { get; set; }
        public List<TestResult> Results { get; set; }

    }

    public class CHCSubjectResigration
    {
        public SubjectPrimary PrimaryDetail { get; set; }
        public SubjectAddress AddressDetail { get; set; }
        public SubjectPregnancy PregnancyDetail { get; set; }
        public SubjectParent ParentDetail { get; set; }
        public TestResult Results { get; set; }

    }

}
