using EduquayAPI.Contracts.V1.Request.CentralLab;
using EduquayAPI.Models;
using EduquayAPI.Models.CentralLab;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.CentralLab
{
    public class CentralLabData : ICentralLabData
    {
        private const string FetchShipmentReceiptInCentralLab = "SPC_FetchShipmentReceiptInCentralLab";
        private const string AddCentralLabReceipt = "SPC_AddCentralLabReceipt";
        private const string FetchDetailforHPLCTest = "SPC_FetchDetailforHPLCTest";
        private const string AddHPLCTests = "SPC_AddHPLCTest";
        private const string FetchSamplesCentralMolecularPickPack = "SPC_FetchSamplesCentralMolecularPickPack";
        private const string AddCentralLabShipments = "SPC_AddCentralLabShipments";
        private const string FetchCentralMolecularShipmentLog = "SPC_FetchCentralMolecularShipmentLog";
        private const string FetchCentralLabSampleStatus = "SPC_FetchCentralLabSampleStatus"; 
        private const string FetchCentralLabStatusReports = "SPC_FetchCentralLabStatusReports";

        public CentralLabData()
        {

        }

        public void AddReceivedShipment(AddCentralShipmentRequest csData)
        {
            try
            {
                var stProc = AddCentralLabReceipt;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@ShipmentId", csData.shipmentId ?? csData.shipmentId),
                    new SqlParameter("@ReceivedDate", csData.receivedDate ?? csData.receivedDate),
                    new SqlParameter("@ProcessingDateTime", csData.proceesingDateTime ?? csData.proceesingDateTime),
                    new SqlParameter("@SampleDamaged", csData.sampleDamaged),
                    new SqlParameter("@SampleTimeout", csData.sampleTimeout),
                    new SqlParameter("@BarcodeDamaged", csData.barcodeDamaged),
                    new SqlParameter("@IsAccept", csData.isAccept),
                    new SqlParameter("@Barcode", csData.barcodeNo ?? csData.barcodeNo),
                    new SqlParameter("@UpdatedBy", csData.updatedBy),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HPLCTest> RetrieveHPLC(int centralLabId)
        {
            string stProc = FetchDetailforHPLCTest;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@CentralLabId", centralLabId),
            };
            var allHPLC = UtilityDL.FillData<HPLCTest>(stProc, pList);
            return allHPLC;
        }

        public CentralLabReceipts RetrieveCentralLabReceipts(int centralLabId)
        {
            string stProc = FetchShipmentReceiptInCentralLab;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@CentralLabId", centralLabId),
            };
            var allCentralLabReceiptLog = UtilityDL.FillData<CentralLabReceiptsLog>(stProc, pList);
            var allReceiptDetail = UtilityDL.FillData<CentralLabReceiptDetail>(stProc, pList);
            var centralLabReceipt = new CentralLabReceipts();
            centralLabReceipt.ReceiptLog = allCentralLabReceiptLog;
            centralLabReceipt.ReceiptDetail = allReceiptDetail;
            return centralLabReceipt;
        }

        public void AddHPLCTest(AddHPLCTestRequest hplcData)
        {
            try
            {
                var stProc = AddHPLCTests;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@UniqueSubjectId", hplcData.subjectId ?? hplcData.subjectId),
                    new SqlParameter("@BarcodeNo", hplcData.barcodeNo ?? hplcData.barcodeNo),
                    new SqlParameter("@CentralLabId",Convert.ToInt32(hplcData.centralLabId)),
                    new SqlParameter("@HbF",Convert.ToDecimal(hplcData.HbF)),
                    new SqlParameter("@HbA0",Convert.ToDecimal(hplcData.HbA0)),
                    new SqlParameter("@HbA2",Convert.ToDecimal(hplcData.HbA2)),
                    new SqlParameter("@HbS",Convert.ToDecimal(hplcData.HbS)),
                    new SqlParameter("@HbC",Convert.ToDecimal(hplcData.HbC)),
                    new SqlParameter("@HbD",Convert.ToDecimal(hplcData.HbD)),
                    new SqlParameter("@TestCompleteOn", hplcData.testCompleteOn ?? hplcData.testCompleteOn),
                    new SqlParameter("@CreatedBy", Convert.ToInt32(hplcData.createdBy)),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CentralLabPickandPack> RetrievePickandPack(int centralLabId)
        {
            string stProc = FetchSamplesCentralMolecularPickPack;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@CentralLabId", centralLabId),
            };
            var allData = UtilityDL.FillData<CentralLabPickandPack>(stProc, pList);
            return allData;
        }

        public List<CentralLabShipmentId> AddCentralLabShipment(AddCentralLabShipmentRequest csData)
        {
            try
            {
                string stProc = AddCentralLabShipments;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@BarcodeNo", csData.barcodeNo ?? csData.barcodeNo),
                    new SqlParameter("@LabTechnicianName", csData.labTechnicianName ?? csData.labTechnicianName),
                    new SqlParameter("@CentralLabUserId", csData.centralLabUserId),
                    new SqlParameter("@CentralLabId", csData.centralLabId),
                    new SqlParameter("@CentralLabLocation", csData.centralLabLocation ?? csData.centralLabLocation),
                    new SqlParameter("@ReceivingMolecularLabId", csData.receivingMolecularLabId),
                    new SqlParameter("@LogisticsProviderName", csData.logisticsProviderName ?? csData.logisticsProviderName),
                    new SqlParameter("@DeliveryExecutiveName", csData.deliveryExecutiveName ?? csData.deliveryExecutiveName),
                    new SqlParameter("@ExecutiveContactNo", csData.executiveContactNo ?? csData.executiveContactNo),
                    new SqlParameter("@DateofShipment", csData.dateOfShipment ?? csData.dateOfShipment),
                    new SqlParameter("@TimeofShipment", csData.timeOfShipment ?? csData.timeOfShipment),
                    new SqlParameter("@Source",csData.source ?? csData.source),
                };
                var allData = UtilityDL.FillData<CentralLabShipmentId>(stProc, pList);
                return allData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public CentralLabShipments RetrieveCentralLabShipmentLog(int centralLabId)
        {
            string stProc = FetchCentralMolecularShipmentLog;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@CentralLabId", centralLabId ),
            };
            var allCLShipmentLogs = UtilityDL.FillData<CentralLabShipmentsLogs>(stProc, pList);
            var allCLShipmentSubjects = UtilityDL.FillData<CentralLabShipmentLogsDetail>(stProc, pList);
            var shiplogDetail = new CentralLabShipments();
            shiplogDetail.ShipmentLog = allCLShipmentLogs;
            shiplogDetail.ShipmentSubjectDetail = allCLShipmentSubjects;
            return shiplogDetail;
        }

        public List<CentralLabSampleStatus> RetrieveSampleStatus()
        {
            string stProc = FetchCentralLabSampleStatus;
            var pList = new List<SqlParameter>();

            var allSampleStatus = UtilityDL.FillData<CentralLabSampleStatus>(stProc, pList);
            return allSampleStatus;
        }

        public List<CentralLabReports> RetriveCentralLabReports(CentralLabReportRequest mrData)
        {
            string stProc = FetchCentralLabStatusReports;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@SampleStatus", mrData.sampleStatus),
                new SqlParameter("@CentralLabId", mrData.centralLabId),
                new SqlParameter("@CHCID", mrData.chcId),
                new SqlParameter("@PHCID", mrData.phcId),
                new SqlParameter("@ANMID", mrData.anmId),
                new SqlParameter("@FromDate", mrData.fromDate.ToCheckNull()),
                new SqlParameter("@ToDate", mrData.toDate.ToCheckNull()),
            };
            var allSubjects = UtilityDL.FillData<CentralLabReports>(stProc, pList);
            return allSubjects;
        }
    }
}
