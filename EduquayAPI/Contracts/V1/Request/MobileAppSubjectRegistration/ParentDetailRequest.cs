using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.MobileAppSubjectRegistration
{
    public class ParentDetailRequest
    {
        public string uniqueSubjectId { get; set; }
        public string motherFirstName { get; set; }
        public string motherMiddleName { get; set; }
        public string motherLastName { get; set; }
        public int motherGovIdTypeId { get; set; }
        public string motherGovIdDetail { get; set; }
        public string motherContactNo { get; set; }
        public string fatherFirstName { get; set; }
        public string fatherMiddleName { get; set; }
        public string fatherLastName { get; set; }
        public int fatherGovIdTypeId { get; set; }
        public string fatherGovIdDetail { get; set; }
        public string fatherContactNo { get; set; }
        public string gaurdianFirstName { get; set; }
        public string gaurdianMiddleName { get; set; }
        public string gaurdianLastName { get; set; }
        public int gaurdianGovIdTypeId { get; set; }
        public string gaurdianGovIdDetail { get; set; }
        public string gaurdianContactNo { get; set; }
        public string rbskId { get; set; }
        public string schoolName { get; set; }
        public string schoolAddress1 { get; set; }
        public string schoolAddress2 { get; set; }
        public string schoolAddress3 { get; set; }
        public string schoolPincode { get; set; }
        public string schoolCity { get; set; }
        public string schoolState { get; set; }
        public string standard { get; set; }
        public string section { get; set; }
        public string rollNo { get; set; }
        public int updatedBy { get; set; }
    }
}
