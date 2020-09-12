using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.DiscrictCoordinator
{
    public class DCPositiveSamples : IFill
    {
        public int sampleCollectionId { get; set; }
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string anmName { get; set; }
        public string anmContactNo { get; set; }
        public string subjectType { get; set; }
        public string barcodeNo { get; set; }
        public string sampleCollectionDate { get; set; }
        public string sampleCollectionTime { get; set; }
        public string gender { get; set; }
        public string gestationalAge { get; set; }
        public string districtName { get; set; }
        public string chcName { get; set; }
        public string phcName { get; set; }
        public string scName { get; set; }
        public string riPoint { get; set; }
        public string age { get; set; }
        public string dob { get; set; }
        public string religion { get; set; }
        public string caste { get; set; }
        public string community { get; set; }
        public string contactNo { get; set; }
        public string rchId { get; set; }
        public string ecNumber { get; set; }
        public string address { get; set; }
        public string lmpDate { get; set; }
        public string gpla { get; set; }
        public string cbcTestResult { get; set; }
        public string ssTestResult { get; set; }
        public string hplcTestResult { get; set; }
        public string followUpStatus { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionId"))
                this.sampleCollectionId = Convert.ToInt32(reader["SampleCollectionId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.SubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.SubjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMName"))
                this.anmName = Convert.ToString(reader["ANMName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMContactNo"))
                this.anmContactNo = Convert.ToString(reader["ANMContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Age"))
                this.age = Convert.ToString(reader["Age"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectType"))
                this.subjectType = Convert.ToString(reader["SubjectType"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.barcodeNo = Convert.ToString(reader["BarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionDate"))
                this.sampleCollectionDate = Convert.ToString(reader["SampleCollectionDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionTime"))
                this.sampleCollectionTime = Convert.ToString(reader["SampleCollectionTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gender"))
                this.gender = Convert.ToString(reader["Gender"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GestationalAge"))
                this.gestationalAge = Convert.ToString(reader["GestationalAge"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "District"))
                this.districtName = Convert.ToString(reader["District"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHC"))
                this.chcName = Convert.ToString(reader["CHC"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PHC"))
                this.phcName = Convert.ToString(reader["PHC"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCName"))
                this.scName = Convert.ToString(reader["SCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RIsite"))
                this.riPoint = Convert.ToString(reader["RIsite"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DateOFBirth"))
                this.dob = Convert.ToString(reader["DateOFBirth"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Religionname"))
                this.religion = Convert.ToString(reader["Religionname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Castename"))
                this.caste = Convert.ToString(reader["Castename"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Communityname"))
                this.community = Convert.ToString(reader["Communityname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ContactNo"))
                this.contactNo = Convert.ToString(reader["ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ECNumber"))
                this.ecNumber = Convert.ToString(reader["ECNumber"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectAddress"))
                this.address = Convert.ToString(reader["SubjectAddress"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LMPDate"))
                this.lmpDate = Convert.ToString(reader["LMPDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GPLA"))
                this.gpla = Convert.ToString(reader["GPLA"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CBCResult"))
                this.cbcTestResult = Convert.ToString(reader["CBCResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SSTResult"))
                this.ssTestResult = Convert.ToString(reader["SSTResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HPLCResult"))
                this.hplcTestResult = Convert.ToString(reader["HPLCResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FollowUPStatus"))
                this.followUpStatus = Convert.ToString(reader["FollowUPStatus"]);
        }
    }
}
