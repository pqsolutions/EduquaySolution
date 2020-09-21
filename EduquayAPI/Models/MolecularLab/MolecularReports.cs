using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MolecularLab
{
    public class MolecularReports : IFill
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
        public string barcodeNo { get; set; }
        public string district { get; set; }

        public string shipmentDate { get; set; }
        public string sampleStatus { get; set; }
        public string diagnosis { get; set; }
        public string molecularResult { get; set; }
        public bool processed { get; set; }
        public bool damaged { get; set; }

        public void Fill(SqlDataReader reader)
        {
           
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

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.barcodeNo = Convert.ToString(reader["BarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Districtname"))
                this.district = Convert.ToString(reader["Districtname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentDate"))
                this.shipmentDate = Convert.ToString(reader["ShipmentDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleStatus"))
                this.sampleStatus = Convert.ToString(reader["SampleStatus"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Diagnosis"))
                this.diagnosis = Convert.ToString(reader["Diagnosis"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MolecularResult"))
                this.molecularResult = Convert.ToString(reader["MolecularResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Processed"))
                this.processed = Convert.ToBoolean(reader["Processed"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Damaged"))
                this.damaged = Convert.ToBoolean(reader["Damaged"]);

        }
    }
}
