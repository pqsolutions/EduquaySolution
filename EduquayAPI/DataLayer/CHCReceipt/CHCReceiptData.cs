using EduquayAPI.Contracts.V1.Request.CHCReceiptProcessing;
using EduquayAPI.Models.CHCReceipt;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.CHCReceipt
{
    public class CHCReceiptData : ICHCReceiptData
    {
        private const string FetchShipmentReceiptInCHC = "SPC_FetchShipmentReceiptInCHC";
        private const string AddCHCReceipt = "SPC_AddCHCReceipt";
        private const string FetchDetailforSSTest = "SPC_FetchDetailforSSTest";
        private const string FetchDetailforCBCTest = "SPC_FetchDetailforCBCTest";
        private const string AddCBCTests = "SPC_AddCBCTest";
        private const string AddSSTests = "SPC_AddSSTest";
        private const string FetchSamplesCHCCentralPickPack = "SPC_FetchSamplesCHCCentralPickPack";
        private const string AddCHCShipments = "SPC_AddCHCCentralShipments";
        private const string FetchCHCCentralShipmentLog = "SPC_FetchCHCCentralShipmentLog";
        public CHCReceiptData()
        {

        }
        public void AddReceivedShipment(AddReceivedShipmentRequest rsData)
        {
            try
            {
                var stProc = AddCHCReceipt;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@ShipmentId", rsData.shipmentId ?? rsData.shipmentId),
                    new SqlParameter("@ReceivedDate", rsData.receivedDate ?? rsData.receivedDate),
                    new SqlParameter("@ProcessingDateTime", rsData.proceesingDateTime ?? rsData.proceesingDateTime),
                    new SqlParameter("@ILRInDateTime", rsData.ilrInDateTime ?? rsData.ilrInDateTime),
                    new SqlParameter("@ILROutDateTime", rsData.ilrOutDateTime ?? rsData.ilrOutDateTime),
                    new SqlParameter("@SampleDamaged", rsData.sampleDamaged),
                    new SqlParameter("@SampleTimeout", rsData.sampleTimeout),
                    new SqlParameter("@BarcodeDamaged", rsData.barcodeDamaged),
                    new SqlParameter("@IsAccept", rsData.isAccept),
                    new SqlParameter("@Barcode", rsData.barcodeNo ?? rsData.barcodeNo),
                    new SqlParameter("@UpdatedBy", rsData.updatedBy),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CBCSSTest> RetrieveCBC(int testingCHCId)
        {
            string stProc = FetchDetailforCBCTest;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@TestingCHCId", testingCHCId),
            };
            var allCBC = UtilityDL.FillData<CBCSSTest>(stProc, pList);
            return allCBC;
        }

        public List<CBCSSTest> RetrieveSST(int testingCHCId)
        {
            string stProc = FetchDetailforSSTest;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@TestingCHCId", testingCHCId),
            };
            var allSST = UtilityDL.FillData<CBCSSTest>(stProc, pList);
            return allSST;
        }

        public CHCReceipts RetrieveCHCReceipts(int testingCHCId)
        {
            string stProc = FetchShipmentReceiptInCHC;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@TestingCHCId", testingCHCId),
            };
            var allCHCReceiptLog = UtilityDL.FillData<CHCReceiptLog>(stProc, pList);
            var allReceiptDetail = UtilityDL.FillData<CHCReceiptDetail>(stProc, pList);
            var chcReceipt = new CHCReceipts();
            chcReceipt.ReceiptLog = allCHCReceiptLog;
            chcReceipt.ReceiptDetail = allReceiptDetail;
            return chcReceipt;
        }
        public void AddCBCTest(AddCBCTestRequest cbcData)
        {
            try
            {
                var stProc = AddCBCTests;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@UniqueSubjectId", cbcData.subjectId ?? cbcData.subjectId),
                    new SqlParameter("@Barcode", cbcData.barcodeNo ?? cbcData.barcodeNo),
                    new SqlParameter("@TestingCHCId",Convert.ToInt32(cbcData.testingCHCId)),
                    new SqlParameter("@MCV",Convert.ToDecimal(cbcData.mcv)),
                    new SqlParameter("@RDW",Convert.ToDecimal(cbcData.rdw)),
                    new SqlParameter("@TestCompleteOn", cbcData.testCompleteOn ?? cbcData.testCompleteOn),
                    new SqlParameter("@SampleDateTime", cbcData.sampleDateTime ?? cbcData.sampleDateTime),
                    new SqlParameter("@CreatedBy", Convert.ToInt32(cbcData.createdBy)),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddSSTest(AddSSTestRequest ssData)
        {
            try
            {
                var stProc = AddSSTests;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@UniqueSubjectId", ssData.subjectId ?? ssData.subjectId),
                    new SqlParameter("@Barcode", ssData.barcodeNo ?? ssData.barcodeNo),
                    new SqlParameter("@TestingCHCId",Convert.ToInt32(ssData.testingCHCId)),
                    new SqlParameter("@IsPositive",ssData.isPositive),
                    new SqlParameter("@CreatedBy", Convert.ToInt32(ssData.createdBy)),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CHCCentralPickandPackSample> RetrievePickandPack(int testingCHCId)
        {
            string stProc = FetchSamplesCHCCentralPickPack;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@CHCID", testingCHCId),
            };
            var allData = UtilityDL.FillData<CHCCentralPickandPackSample>(stProc, pList);
            return allData;
        }

        public List<CHCShipmentID> AddCHCShipment(AddCHCShipmentRequest csData)
        {
            try
            {
                string stProc = AddCHCShipments;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@BarcodeNo", csData.barcodeNo ?? csData.barcodeNo),
                    new SqlParameter("@LabTechnicianName", csData.labTechnicianName ?? csData.labTechnicianName),
                    new SqlParameter("@CHCUserID", csData.chcUserId),
                    new SqlParameter("@TestingCHCID", csData.testingCHCId),
                    new SqlParameter("@ReceivingCentralLabId", csData.receivingCentralLabId),
                    new SqlParameter("@LogicsProviderID", csData.logisticsProviderId),
                    new SqlParameter("@DeliveryExecutiveName", csData.deliveryExecutiveName ?? csData.deliveryExecutiveName),
                    new SqlParameter("@ExecutiveContactNo", csData.executiveContactNo ?? csData.executiveContactNo),
                    new SqlParameter("@DateofShipment", csData.dateOfShipment ?? csData.dateOfShipment),
                    new SqlParameter("@TimeofShipment", csData.timeOfShipment ?? csData.timeOfShipment),
                    new SqlParameter("@Createdby", csData.createdBy),
                    new SqlParameter("@Source",csData.source ?? csData.source),
                };
                var allData = UtilityDL.FillData<CHCShipmentID>(stProc, pList);
                return allData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public CHCShipments RetrieveCHCShipmentLog(int testingCHCId)
        {
            string stProc = FetchCHCCentralShipmentLog;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@TestingCHCID", testingCHCId ),
            };
            var allCHCShipmentLogs = UtilityDL.FillData<CHCShipmentLogs>(stProc, pList);
            var allCHCShipmentSubjects = UtilityDL.FillData<CHCShipmentLogsDetail>(stProc, pList);
            var shiplogDetail = new CHCShipments();
            shiplogDetail.ShipmentLog = allCHCShipmentLogs;
            shiplogDetail.ShipmentSubjectDetail = allCHCShipmentSubjects;
            return shiplogDetail;
        }
    }
}
