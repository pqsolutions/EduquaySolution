using NLog.LayoutRenderers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.Pathologist
{
    public class HPLCTestDetails : IFill
    {
        public string uniqueSubjectId { get; set; }
        public string subjectName { get; set; }
        public string barcodeNo { get; set; }
        public string rchId { get; set; }
        public string ga { get; set; }
        public string dateOfTest { get; set; }
        public string district { get; set; }
        public string testingCHC { get; set; }
        public string riPoint { get; set; }
        public int age { get; set; }
        public string contactNo { get; set; }
        public string address { get; set; }
        public string spouseName { get; set; }
        public string spouseContact { get; set; }
        public string lmpDate { get; set; }
        public string obstetricsScore { get; set; }
        public string sstResult { get; set; }
        public string cbcResult { get; set; }
        public string mcv { get; set; }
        public string rdw { get; set; }
        public string hbF { get; set; }
        public string hbA0 { get; set; }
        public string hbA2 { get; set; }
        public string hbC { get; set; }
        public string hbD { get; set; }
        public string hbS{ get; set; }
        public bool isNormal { get; set; }
        public int hplcTestResultId { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.barcodeNo = Convert.ToString(reader["BarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GestationalAge"))
                this.ga = Convert.ToString(reader["GestationalAge"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DateOfTest"))
                this.dateOfTest = Convert.ToString(reader["DateOfTest"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "District"))
                this.district = Convert.ToString(reader["District"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestingCHC"))
                this.testingCHC = Convert.ToString(reader["TestingCHC"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RIPoint"))
                this.riPoint  = Convert.ToString(reader["RIPoint"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Age"))
                this.age = Convert.ToInt32(reader["Age"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ContactNo"))
                this.contactNo = Convert.ToString(reader["ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectAddress"))
                this.address = Convert.ToString(reader["SubjectAddress"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseName"))
                this.spouseName = Convert.ToString(reader["SpouseName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseContact"))
                this.spouseContact  = Convert.ToString(reader["SpouseContact"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LMPDate"))
                this.lmpDate = Convert.ToString(reader["LMPDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LMPDate"))
                this.lmpDate = Convert.ToString(reader["LMPDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ObstetricsScore"))
                this.obstetricsScore = Convert.ToString(reader["ObstetricsScore"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SSTResult"))
                this.sstResult = Convert.ToString(reader["SSTResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CBCResult"))
                this.cbcResult = Convert.ToString(reader["CBCResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MCV"))
                this.mcv = Convert.ToString(reader["MCV"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RDW"))
                this.rdw = Convert.ToString(reader["RDW"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HbA0"))
                this.hbA0 = Convert.ToString(reader["HbA0"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HbA2"))
                this.hbA2 = Convert.ToString(reader["HbA2"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HbF"))
                this.hbF = Convert.ToString(reader["HbF"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HbC"))
                this.hbC = Convert.ToString(reader["HbC"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HbD"))
                this.hbD = Convert.ToString(reader["HbD"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HbS"))
                this.hbS = Convert.ToString(reader["HbS"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "IsNormal"))
                this.isNormal = Convert.ToBoolean(reader["IsNormal"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HPLCTestResultId"))
                this.hplcTestResultId  = Convert.ToInt32(reader["HPLCTestResultId"]);
        }
    }
}
