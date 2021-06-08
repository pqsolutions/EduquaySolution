using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MolecularLab
{
    public class MolecularLabSpecimenReport : IFill
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
        public string spouseSubjectId { get; set; }
        public string spouseName { get; set; }
        public string spouseMolecularTestResult { get; set; }
        public string molecularLabName { get; set; }
        public string orderingPhysician { get; set; }
        public string molecularResultEnteredBy { get; set; }
        public int pndTestId { get; set; }
        public string labTechnician { get; set; }
        public List<MolecularLabFoetusResult> foetusDetail { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LabTechnician"))
                this.labTechnician = Convert.ToString(reader["LabTechnician"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTestId"))
                this.pndTestId = Convert.ToInt32(reader["PNDTestId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ResultEnteredBy"))
                this.molecularResultEnteredBy = Convert.ToString(reader["ResultEnteredBy"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "OrderingPhysician"))
                this.orderingPhysician = Convert.ToString(reader["OrderingPhysician"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MolecularLabName"))
                this.molecularLabName = Convert.ToString(reader["MolecularLabName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectType"))
                this.subjectType = Convert.ToString(reader["SubjectType"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ContactNo"))
                this.contactNo = Convert.ToString(reader["ContactNo"]);

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

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address"))
                this.address = Convert.ToString(reader["Address"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.barcodeNo = Convert.ToString(reader["BarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMName"))
                this.anmName = Convert.ToString(reader["ANMName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RegistrationDate"))
                this.registrationDate = Convert.ToString(reader["RegistrationDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RegistrationDate"))
                this.sampleCollectionDate = Convert.ToString(reader["SampleCollectionDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Districtname"))
                this.district = Convert.ToString(reader["Districtname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Blockname"))
                this.block = Convert.ToString(reader["Blockname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCname"))
                this.chc = Convert.ToString(reader["CHCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PHCname"))
                this.phc = Convert.ToString(reader["PHCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCname"))
                this.sc = Convert.ToString(reader["SCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RIsite"))
                this.ri = Convert.ToString(reader["RIsite"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MolecularSpecimenTestDate"))
                this.testDate = Convert.ToString(reader["MolecularSpecimenTestDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MolecularLabBloodResult"))
                this.molecularTestResult = Convert.ToString(reader["MolecularLabBloodResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseSubjectID"))
                this.spouseSubjectId = Convert.ToString(reader["SpouseSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseName"))
                this.spouseName = Convert.ToString(reader["SpouseName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseMolecularLabBloodResult"))
                this.spouseMolecularTestResult = Convert.ToString(reader["SpouseMolecularLabBloodResult"]);
        }
    }
}
