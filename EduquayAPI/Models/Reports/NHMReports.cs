using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.Reports
{
    public class NHMReports : IFill
    {
        public string anmId { get; set; }
        public string anmName { get; set; }
        public string subjectId { get; set; }
        public string subjectType { get; set; }
        public string firstName { get; set; }
        public string spouseSubjectId { get; set; }
        public string rchId { get; set; }
        public string dateOfRegister { get; set; }
        public string barcode { get; set; }
        public string ri { get; set; }
        public string mobileNo { get; set; }
        public string village { get; set; }
        public string ga { get; set; }
        public string sampleCollected { get; set; }
        public string sampleCollectionDateTime { get; set; }
        public string sampleTestDateTime { get; set; }
        public string cbcResult { get; set; }
        public string sstResult { get; set; }
        public string hplcTestDate { get; set; }
        public string hplcLabDiagnosis { get; set; }
        public string hplcPathoLabResult { get; set; }
        public string prePNDTCounselling { get; set; }
        public string pndtResult { get; set; }
        public string postPNDTCounselling { get; set; }
        public string mtpService { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMId"))
                this.anmId = Convert.ToString(reader["ANMId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMName"))
                this.anmName = Convert.ToString(reader["ANMName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectId"))
                this.subjectId = Convert.ToString(reader["UniqueSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectType"))
                this.subjectType = Convert.ToString(reader["SubjectType"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FirstName"))
                this.firstName = Convert.ToString(reader["FirstName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseSubjectId"))
                this.spouseSubjectId = Convert.ToString(reader["SpouseSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DateOfRegister"))
                this.dateOfRegister = Convert.ToString(reader["DateOfRegister"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Barcode"))
                this.barcode = Convert.ToString(reader["Barcode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RI"))
                this.ri = Convert.ToString(reader["RI"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MobileNo"))
                this.mobileNo = Convert.ToString(reader["MobileNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Village"))
                this.village = Convert.ToString(reader["Village"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GA"))
                this.ga = Convert.ToString(reader["GA"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollected"))
                this.sampleCollected = Convert.ToString(reader["SampleCollected"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionDateTime"))
                this.sampleCollectionDateTime = Convert.ToString(reader["SampleCollectionDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleTestedDateTime"))
                this.sampleTestDateTime = Convert.ToString(reader["SampleTestedDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CBCResult"))
                this.cbcResult = Convert.ToString(reader["CBCResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SSTResult"))
                this.sstResult = Convert.ToString(reader["SSTResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HPLCTestedDate"))
                this.hplcTestDate = Convert.ToString(reader["HPLCTestedDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HPLCLabDiagnosis"))
                this.hplcLabDiagnosis = Convert.ToString(reader["HPLCLabDiagnosis"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HPLCPathoLabResult"))
                this.hplcPathoLabResult = Convert.ToString(reader["HPLCPathoLabResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PrePNDTCounselling"))
                this.prePNDTCounselling = Convert.ToString(reader["PrePNDTCounselling"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTResult"))
                this.pndtResult = Convert.ToString(reader["PNDTResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PostPNDTCounselling"))
                this.postPNDTCounselling = Convert.ToString(reader["PostPNDTCounselling"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MTPService"))
                this.mtpService = Convert.ToString(reader["MTPService"]);
        }
    }
}
