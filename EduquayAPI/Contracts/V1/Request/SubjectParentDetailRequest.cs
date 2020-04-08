using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class SubjectParentDetailRequest
    {
        
        public string Mother_FirstName { get; set; }
        public string Mother_MiddleName { get; set; }
        public string Mother_LastName { get; set; }
        public string Mother_UniquetID { get; set; }
        public string Mother_ContactNo { get; set; }
        public string Father_FirstName { get; set; }
        public string Father_MiddleName { get; set; }
        public string Father_LastName { get; set; }
        public string Father_UniquetID { get; set; }
        public string Father_ContactNo { get; set; }
        public string Gaurdian_FirstName { get; set; }
        public string Gaurdian_MiddleName { get; set; }
        public string Gaurdian_LastName { get; set; }
        public string Gaurdian_ContactNo { get; set; }
        public string RBSKId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress1 { get; set; }
        public string SchoolAddress2 { get; set; }
        public string SchoolAddress3 { get; set; }
        public string SchoolPincode { get; set; }
        public string SchoolCity { get; set; }
        public int SchoolState { get; set; }
        public string Standard { get; set; }
        public string Section { get; set; }
        public string RollNo { get; set; }     
        public int UpdatedBy { get; set; }

    }
}
