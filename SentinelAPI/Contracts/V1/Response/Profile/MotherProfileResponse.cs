using SentinelAPI.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Response.Profile
{
    public class MotherProfileResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<MOMProfile> data { get; set; }
    }
    public class MOMProfile
    {
        public string motherSubjectId { get; set; }
        public string dateofRegistration { get; set; }
        public string hospitalNo { get; set; }
        public string motherFirstName { get; set; }
        public string motherLastName { get; set; }
        public string dob { get; set; }
        public int age { get; set; }
        public string rchId { get; set; }
        public int motherGovIdTypeId { get; set; }
        public string motherGovIdDetail { get; set; }
        public string motherContactNo { get; set; }
        public string ecNumber { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public int districtId { get; set; }
        public string districtName { get; set; }
        public int stateId { get; set; }
        public string stateName { get; set; }
        public string pincode { get; set; }
        public string fatherFirstName { get; set; }
        public string fatherLastName { get; set; }
        public string fatherContactNo { get; set; }
        public string guardianFirstName { get; set; }
        public string guardianLastName { get; set; }
        public string guardianContactNo { get; set; }
        public string religionName { get; set; }
        public string casteName { get; set; }
        public string communityName { get; set; }
        public string gpla { get; set; }
        public string motherHospitalName { get; set; }
        public string motherHospitalAddress { get; set; }
        public string motherHospitalContactNo { get; set; }
        public List<MotherBabiesDetail> babyDetail { get; set; }

    }
 
}
