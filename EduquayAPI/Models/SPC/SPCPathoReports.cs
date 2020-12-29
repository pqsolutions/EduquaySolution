using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.SPC
{
    public class SPCPathoReports : IFill
    {
        public string subjectName { get; set; }
        public string subjectId { get; set; }
        public string spouseName { get; set; }
        public string address { get; set; }
        public string subjectType { get; set; }
        public string rchId { get; set; }
        public string age { get; set; }
        public string gender { get; set; }
        public string dob { get; set; }
        public string contactNo { get; set; }
        public string spouseContactNo { get; set; }
        public string ecNumber { get; set; }
        public string lmpDate { get; set; }
        public string ga { get; set; }
        public string obstetricScore { get; set; }
        public string barcodeNo { get; set; }
        public string district { get; set; }
        public string chcName { get; set; }
        public string riPoint { get; set; }
        public string sampleStatus { get; set; }
        public string mcv { get; set; }
        public string rdw { get; set; }
        public string rbc { get; set; }
        public string cbcTestResult { get; set; }
        public string sstResult { get; set; }
        public string hbA0 { get; set; }
        public string hbA2 { get; set; }
        public string hbD { get; set; }
        public string hbF { get; set; }
        public string hbS { get; set; }
        public string hplcResult { get; set; }
        public string diagnosis { get; set; }
        public string seniorPathologistRemarks { get; set; }
        public string diagnosisSummary { get; set; }
        public string graphFileName { get; set; }
        public string anmName { get; set; }
        public string blockName { get; set; }
        public string scName { get; set; }
        public string phcName { get; set; }
        public string diagnosisDateTime { get; set; }
        public string dateOfRegister { get; set; }
        public string sampleCollectionDate { get; set; }
        public string referringDepartment { get; set; }
        public string orderingPhysician { get; set; }
        public string labTechnicianName { get; set; }
        public string pathologistName { get; set; }


        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PathologistName"))
                this.pathologistName = Convert.ToString(reader["PathologistName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LabTechnicianName"))
                this.labTechnicianName = Convert.ToString(reader["LabTechnicianName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "OrderingPhysician"))
                this.orderingPhysician = Convert.ToString(reader["OrderingPhysician"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ReferringDepartment"))
                this.referringDepartment = Convert.ToString(reader["ReferringDepartment"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionDate"))
                this.sampleCollectionDate = Convert.ToString(reader["SampleCollectionDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DateOfRegister"))
                this.dateOfRegister = Convert.ToString(reader["DateOfRegister"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMName"))
                this.anmName = Convert.ToString(reader["ANMName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BlockName"))
                this.blockName = Convert.ToString(reader["BlockName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCName"))
                this.scName = Convert.ToString(reader["SCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PHCName"))
                this.phcName = Convert.ToString(reader["PHCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DiagnosisDateTime"))
                this.diagnosisDateTime = Convert.ToString(reader["DiagnosisDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DiagnosisSummary"))
                this.diagnosisSummary = Convert.ToString(reader["DiagnosisSummary"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SeniorPathologistRemarks"))
                this.seniorPathologistRemarks = Convert.ToString(reader["SeniorPathologistRemarks"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PDFFileName"))
                this.graphFileName = Convert.ToString(reader["PDFFileName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectType"))
                this.subjectType = Convert.ToString(reader["SubjectType"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.subjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseName"))
                this.spouseName = Convert.ToString(reader["SpouseName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectAddress"))
                this.address = Convert.ToString(reader["SubjectAddress"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ContactNo"))
                this.contactNo = Convert.ToString(reader["ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseContactNo"))
                this.spouseContactNo = Convert.ToString(reader["SpouseContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ECNumber"))
                this.ecNumber = Convert.ToString(reader["ECNumber"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LMPDate"))
                this.lmpDate = Convert.ToString(reader["LMPDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GestationalAge"))
                this.ga = Convert.ToString(reader["GestationalAge"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ObstetricScore"))
                this.obstetricScore = Convert.ToString(reader["ObstetricScore"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Age"))
                this.age = Convert.ToString(reader["Age"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gender"))
                this.gender = Convert.ToString(reader["Gender"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DOB"))
                this.dob = Convert.ToString(reader["DOB"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.barcodeNo = Convert.ToString(reader["BarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Districtname"))
                this.district = Convert.ToString(reader["Districtname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCname"))
                this.chcName = Convert.ToString(reader["CHCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RIPoint"))
                this.riPoint = Convert.ToString(reader["RIPoint"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleStatus"))
                this.sampleStatus = Convert.ToString(reader["SampleStatus"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MCV"))
                this.mcv = Convert.ToString(reader["MCV"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RDW"))
                this.rdw = Convert.ToString(reader["RDW"]);


            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RBC"))
                this.rbc = Convert.ToString(reader["RBC"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CBCResult"))
                this.cbcTestResult = Convert.ToString(reader["CBCResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SSTResult"))
                this.sstResult = Convert.ToString(reader["SSTResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HbA0"))
                this.hbA0 = Convert.ToString(reader["HbA0"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HbA2"))
                this.hbA2 = Convert.ToString(reader["HbA2"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HbD"))
                this.hbD = Convert.ToString(reader["HbD"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HbF"))
                this.hbF = Convert.ToString(reader["HbF"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HbS"))
                this.hbS = Convert.ToString(reader["HbS"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HPLCResult"))
                this.hplcResult = Convert.ToString(reader["HPLCResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LabDiagnosis"))
                this.diagnosis = Convert.ToString(reader["LabDiagnosis"]);

        }
    }
}