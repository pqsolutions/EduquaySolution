using EduquayAPI.Contracts.V1.Request.CentralLab;
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
                    new SqlParameter("@BarcodNo", hplcData.barcodeNo ?? hplcData.barcodeNo),
                    new SqlParameter("@CentralLabId",Convert.ToInt32(hplcData.centralLabId)),
                    new SqlParameter("@HbF",Convert.ToDecimal(hplcData.HbF)),
                    new SqlParameter("@HbA0",Convert.ToDecimal(hplcData.HbA0)),
                    new SqlParameter("@HbA2",Convert.ToDecimal(hplcData.HbA2)),
                    new SqlParameter("@HbS",Convert.ToDecimal(hplcData.HbS)),
                    new SqlParameter("@HbC",Convert.ToDecimal(hplcData.HbC)),
                    new SqlParameter("@HbD",Convert.ToDecimal(hplcData.HbD)),
                    new SqlParameter("@CreatedBy", Convert.ToInt32(hplcData.createdBy)),

                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
