using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.ANMReport
{
    public class ANMReports : IFill
    {
        public string anmId { get; set; }
        public string anmName { get; set; }
        public string subjectId { get; set; }
        public string subjectType { get; set; }
        public string subjectName { get; set; }
        public string  rchId { get; set; }
        public string dateOfRegister { get; set; }
        public string barcodeNo { get; set; }
        public string ri { get; set; }
        public string mobileNo { get; set; }
        public string ga { get; set; }
        public string sampleCollectionDateTime { get; set; }
        public string firstTimeReCollected { get; set; }
        public string recollectionDateTime { get; set; }
        public string shipmentDateTime { get; set; }
        public string shipmentId { get; set; }
        public string testResult { get; set; }
        public string chcShipmentDateTime { get; set; }
        public string hplcPathoDiagnosis { get; set; }
        public string pndt { get; set; }
        public string mtp { get; set; }
        public string currentStatus { get; set; }

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

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DateOfRegister"))
                this.dateOfRegister = Convert.ToString(reader["DateOfRegister"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Barcode"))
                this.barcodeNo = Convert.ToString(reader["Barcode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RI"))
                this.ri = Convert.ToString(reader["RI"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MobileNo"))
                this.mobileNo = Convert.ToString(reader["MobileNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GA"))
                this.ga = Convert.ToString(reader["GA"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionDateTime"))
                this.sampleCollectionDateTime = Convert.ToString(reader["SampleCollectionDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FirstTimeRecollected"))
                this.firstTimeReCollected = Convert.ToString(reader["FirstTimeRecollected"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RecollectedDateTime"))
                this.recollectionDateTime = Convert.ToString(reader["RecollectedDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentDateTime"))
                this.shipmentDateTime = Convert.ToString(reader["ShipmentDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentId"))
                this.shipmentId = Convert.ToString(reader["ShipmentId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestResult"))
                this.testResult = Convert.ToString(reader["TestResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCShipmentDateTime"))
                this.chcShipmentDateTime = Convert.ToString(reader["CHCShipmentDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HPLCPathoDiagnosis"))
                this.hplcPathoDiagnosis = Convert.ToString(reader["HPLCPathoDiagnosis"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDT"))
                this.pndt = Convert.ToString(reader["PNDT"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MTP"))
                this.mtp = Convert.ToString(reader["MTP"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CurrentStatus"))
                this.currentStatus = Convert.ToString(reader["CurrentStatus"]);
        }
    }
}
