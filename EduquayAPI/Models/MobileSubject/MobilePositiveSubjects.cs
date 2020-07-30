using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MobilePositiveSubjects : IFill
    {
        public string uniqueSubjectId { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string rchID { get; set; }
        public string barcodeNo { get; set; }
        public string mobileNo { get; set; }
        public string ecNumber { get; set; }
        public bool isNotified { get; set; }
        public string lmpDate { get; set; }
        public string hplcTestResult { get; set; }
        public int subjectTypeId { get; set; }
        public int childSubjectTypeId { get; set; }
        public decimal gestationalAge { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FirstName"))
                this.firstName = Convert.ToString(reader["FirstName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MiddleName"))
                this.middleName = Convert.ToString(reader["MiddleName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LastName"))
                this.lastName = Convert.ToString(reader["LastName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchID = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.barcodeNo = Convert.ToString(reader["BarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MobileNo"))
                this.mobileNo = Convert.ToString(reader["MobileNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ECNumber"))
                this.ecNumber = Convert.ToString(reader["ECNumber"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LMPDate"))
                this.lmpDate = Convert.ToString(reader["LMPDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "IsNotified"))
                this.isNotified = Convert.ToBoolean(reader["IsNotified"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HPLCTestResult"))
                this.hplcTestResult = Convert.ToString(reader["HPLCTestResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectTypeID"))
                this.subjectTypeId = Convert.ToInt32(reader["SubjectTypeID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ChildSubjectTypeID"))
                this.childSubjectTypeId = Convert.ToInt32(reader["ChildSubjectTypeID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GestationalAge"))
                this.gestationalAge = Convert.ToDecimal(reader["GestationalAge"]);
        }
    }
}
