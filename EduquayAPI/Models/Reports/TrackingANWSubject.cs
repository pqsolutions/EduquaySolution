using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.Reports
{
    public class TrackingANWSubject : IFill
    {
        public string subjectName { get; set; }
        public string spouseName { get; set; }
        public int age { get; set; }
        public string ga { get; set; }
        public string gender { get; set; }
        public string lmpDate { get; set; }
        public string subjectId { get; set; }
        public string childSubjectId { get; set; }
        public string spouseSubjectId { get; set; }
        public string dateofRegistration { get; set; }
        public bool samplingStatus { get; set; }
        public string barcodeNo { get; set; }
        public string sampleCollectionDateTime { get; set; }
        public bool shipmentToTestingCHCStatus { get; set; }
        public string shipmentID { get; set; }
        public string shipmentToTestingCHCDateTime { get; set; }
        public bool receivedAtTestingCHCStatus { get; set; }
        public string receivedAtTestingCHCDateTime { get; set; }
        public bool cbcStatus { get; set; }
        public string cbcResult { get; set; }
        public string cbcDateTime { get; set; }
        public bool sstStatus { get; set; }
        public string sstResult { get; set; }
        public string sstDateTime { get; set; }
        public bool shipmentToCentralLabStatus { get; set; }
        public string chcShipmentID { get; set; }
        public string chcShipmentDateTime { get; set; }
        public bool receivedAtCentralLabStatus { get; set; }
        public string receivedAtCentralLabDateTime { get; set; }
        public bool hplcTestStatus { get; set; }
        public string hplcTestedDateTime { get; set; }
        public bool hplcPathoTestStatus { get; set; }
        public string hplcResult { get; set; }
        public string hplcDiagnosisDateTime { get; set; }
        public bool prePNDTCounsellingStatus { get; set; }
        public string prePNDTCounsellingDateTime { get; set; }
        public bool pndTestStatus { get; set; }
        public string pndtStatus { get; set; }
        public string pndtDateTime { get; set; }
        public bool postPNDTCounsellingStatus { get; set; }
        public string postPNDTCounsellingDateTime { get; set; }
        public bool mtpStatus { get; set; }
        public string mtpDateTime { get; set; }

      

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ChildSubjectId"))
                this.childSubjectId = Convert.ToString(reader["ChildSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseName"))
                this.spouseName = Convert.ToString(reader["SpouseName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gestational_period"))
                this.ga = Convert.ToString(reader["Gestational_period"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Age"))
                this.age = Convert.ToInt32(reader["Age"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LMPDate"))
                this.lmpDate = Convert.ToString(reader["LMPDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gender"))
                this.gender = Convert.ToString(reader["Gender"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.subjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseSubjectID"))
                this.spouseSubjectId = Convert.ToString(reader["SpouseSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DateofRegister"))
                this.dateofRegistration = Convert.ToString(reader["DateofRegister"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SamplingStatus"))
                this.samplingStatus = Convert.ToBoolean(reader["SamplingStatus"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.barcodeNo = Convert.ToString(reader["BarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionDateTime"))
                this.sampleCollectionDateTime = Convert.ToString(reader["SampleCollectionDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentToCHC"))
                this.shipmentToTestingCHCStatus = Convert.ToBoolean(reader["ShipmentToCHC"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentID"))
                this.shipmentID = Convert.ToString(reader["ShipmentID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentDateTime"))
                this.shipmentToTestingCHCDateTime = Convert.ToString(reader["ShipmentDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ReceivedAtTestingCHC"))
                this.receivedAtTestingCHCStatus = Convert.ToBoolean(reader["ReceivedAtTestingCHC"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ReceivedDateAtTestingCHC"))
                this.receivedAtTestingCHCDateTime = Convert.ToString(reader["ReceivedDateAtTestingCHC"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CBCTestProcessed"))
                this.cbcStatus = Convert.ToBoolean(reader["CBCTestProcessed"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CBCTestResult"))
                this.cbcResult = Convert.ToString(reader["CBCTestResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CBCTestedDate"))
                this.cbcDateTime = Convert.ToString(reader["CBCTestedDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SSTestProcessed"))
                this.sstStatus = Convert.ToBoolean(reader["SSTestProcessed"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SSTResult"))
                this.sstResult = Convert.ToString(reader["SSTResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SSTTestedDate"))
                this.sstDateTime = Convert.ToString(reader["SSTTestedDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentToCentralLab"))
                this.shipmentToCentralLabStatus = Convert.ToBoolean(reader["ShipmentToCentralLab"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCShipmentID"))
                this.chcShipmentID = Convert.ToString(reader["CHCShipmentID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCShipmentDateTime"))
                this.chcShipmentDateTime = Convert.ToString(reader["CHCShipmentDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ReceivedAtCentralLab"))
                this.receivedAtCentralLabStatus = Convert.ToBoolean(reader["ReceivedAtCentralLab"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ReceivedDateAtCentralLab"))
                this.receivedAtCentralLabDateTime = Convert.ToString(reader["ReceivedDateAtCentralLab"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HPLCTestProcessed"))
                this.hplcTestStatus = Convert.ToBoolean(reader["HPLCTestProcessed"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HPLCTestedDate"))
                this.hplcTestedDateTime = Convert.ToString(reader["HPLCTestedDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HPLCPathoTestProcessed"))
                this.hplcPathoTestStatus = Convert.ToBoolean(reader["HPLCPathoTestProcessed"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HPLCResult"))
                this.hplcResult = Convert.ToString(reader["HPLCResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HPLCDiagnosisCompletedDate"))
                this.hplcDiagnosisDateTime = Convert.ToString(reader["HPLCDiagnosisCompletedDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PrePNDTCounsellingStatus"))
                this.prePNDTCounsellingStatus = Convert.ToBoolean(reader["PrePNDTCounsellingStatus"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PrePNDTCounsellingDateTime"))
                this.prePNDTCounsellingDateTime = Convert.ToString(reader["PrePNDTCounsellingDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTestStatus"))
                this.pndTestStatus = Convert.ToBoolean(reader["PNDTestStatus"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTStatus"))
                this.pndtStatus = Convert.ToString(reader["PNDTStatus"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTDateTime"))
                this.pndtDateTime = Convert.ToString(reader["PNDTDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PostPNDTCounsellingStatus"))
                this.postPNDTCounsellingStatus = Convert.ToBoolean(reader["PostPNDTCounsellingStatus"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PostPNDTCounsellingDateTime"))
                this.postPNDTCounsellingDateTime = Convert.ToString(reader["PostPNDTCounsellingDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MTPStatus"))
                this.mtpStatus = Convert.ToBoolean(reader["MTPStatus"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MTPDateTime"))
                this.mtpDateTime = Convert.ToString(reader["MTPDateTime"]);
        }
    }
}
