using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class SubjectPrimaryDetailRequest
    {
        public int SubjectTypeID { get; set; }
        public string UniqueSubjectID { get; set; }
        public int DistrictID { get; set; }
        public int CHCID { get; set; }
        public int PHCID { get; set; }
        public int SCID { get; set; }
        public int RIID { get; set; }
        public string SubjectTitle { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string SpouseSubjectID { get; set; }
        public string Spouse_FirstName { get; set; }
        public string Spouse_MiddleName { get; set; }
        public string Spouse_LastName { get; set; }
        public string Spouse_ContactNo { get; set; }
        public int GovIdType_ID { get; set; }
        public string GovIdDetail { get; set; }
        public int AssignANM_ID { get; set; }
        public DateTime DateofRegister { get; set; }
        public string IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string Source { get; set; }
    }
}
