using EduquayAPI.Models.MolecularLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.MolecularLab
{
    public class SpecimenReportResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<MolecularLabSpecimenReports> data { get; set; }
    }
    public class MolecularLabSpecimenReports
    {
        public string subjectName { get; set; }
        public string uniqueSubjectId { get; set; }
        public string subjectType { get; set; }
        public string rchId { get; set; }
        public string age { get; set; }
        public string gender { get; set; }
        public string dob { get; set; }
        public string contactNo { get; set; }
        public string ecNumber { get; set; }
        public string lmpDate { get; set; }
        public string ga { get; set; }
        public string obstetricScore { get; set; }
        public string address { get; set; }
        public string barcodeNo { get; set; }
        public string district { get; set; }
        public string block { get; set; }
        public string chc { get; set; }
        public string phc { get; set; }
        public string sc { get; set; }
        public string ri { get; set; }
        public string anmName { get; set; }
        public string registrationDate { get; set; }
        public string sampleCollectionDate { get; set; }
        public string molecularTestResult { get; set; }
        public string testDate { get; set; }
        public string spouseBarcodeNo{ get; set; }
        public string spouseSubjectId { get; set; }
        public string spouseName { get; set; }
        public string spouseMolecularTestResult { get; set; }
        public string molecularLabName { get; set; }
        public string orderingPhysician { get; set; }
        public string labInchargeName { get; set; }
        public string labInchargeDesignation { get; set; }
        public string labInchargeDepartment { get; set; }
        public string inCharge { get; set; }
        public string labInchargeAddress { get; set; }
        public int pndTestId { get; set; }
        public string labTechnician { get; set; }
        public List<MolecularLabFoetusResult> foetusDetail { get; set; }
    }
}
