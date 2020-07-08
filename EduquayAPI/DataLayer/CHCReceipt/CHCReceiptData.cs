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
    }
}
