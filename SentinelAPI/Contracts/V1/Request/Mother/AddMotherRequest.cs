using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Request.Mother
{
    public class AddMotherRequest
    {
        public int districtId { get; set; }
        public int hospitalId { get; set; }
        public string hospitalFileId { get; set; }
        public string dateofRegistration { get; set; }
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
        public int? gaurdianGovIdTypeId { get; set; }
        public string gaurdianGovIdDetail { get; set; }
        public string gaurdianContactNo { get; set; }
        public int religionId { get; set; }
        public int casteId { get; set; }
        public int communityId { get; set; }
        public string ecNumber { get; set; }
        public string rchId { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string state { get; set; }
        public string pincode { get; set; }
        public int createdBy { get; set; }
        public string comments { get; set; }
    }
}
