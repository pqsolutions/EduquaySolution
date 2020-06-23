using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class SubjectPrimaryDetailRequest
    {
        public int subjectTypeId { get; set; }
        public int childSubjectTypeId { get; set; }
        public string uniqueSubjectId { get; set; }
        public int districtId { get; set; }
        public int chcId { get; set; }
        public int phcId { get; set; }
        public int scId { get; set; }
        public int riId { get; set; }
        public string subjectTitle { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string dob { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string maritalStatus { get; set; }
        public string mobileNo { get; set; }
        public string emailId { get; set; }
        public int govIdTypeId { get; set; }
        public string govIdDetail { get; set; }
        public string spouseSubjectId { get; set; }
        public string spouseFirstName { get; set; }
        public string spouseMiddleName { get; set; }
        public string spouseLastName { get; set; }
        public string spouseContactNo { get; set; }
        public int spouseGovIdTypeId { get; set; }
        public string spouseGovIdDetail { get; set; }
        public int assignANMId { get; set; }
        public string dateOfRegister { get; set; }
        public int registeredFrom { get; set; }
        public int createdBy { get; set; }
        public string source { get; set; }
    }
}
