using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Request.Mother
{
    public class AddMotherRequest
    {
        public string motherSubjectId { get; set; }
        public string dateofRegistration { get; set; }
        public int districtId { get; set; }
        public int hospitalId { get; set; }
        public string hospitalNo { get; set; }
        public int collectionSiteId { get; set; }
        public string motherFirstName { get; set; }
        public string motherLastName { get; set; }
        public string dob { get; set; }
        public int age { get; set; }
        public string rchId { get; set; }
        public int motherGovIdTypeId { get; set; }
        public string motherGovIdDetail { get; set; }
        public string motherContactNo { get; set; }
        public int g { get; set; }
        public int p { get; set; }
        public int l { get; set; }
        public int a { get; set; }
        public string ecNumber { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public int stateId { get; set; }
        public string pincode { get; set; }
        public int religionId { get; set; }
        public int casteId { get; set; }
        public int communityId { get; set; }
        public string fatherFirstName { get; set; }
        public string fatherLastName { get; set; }
        public string fatherContactNo { get; set; }
        public string guardianFirstName { get; set; }
        public string guardianLastName { get; set; }
        public string guardianContactNo { get; set; }
        public int userId { get; set; }
    }
}
