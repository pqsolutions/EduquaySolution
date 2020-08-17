using EduquayAPI.Contracts.V1.Request.MolecularLab;
using EduquayAPI.Models.MolecularLab;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.MolecularLab
{
    public class MolecularLabData : IMolecularLabData 
    {
        private const string FetchShipmentReceiptInMolecularLab = "SPC_FetchShipmentReceiptInMolecularLab";
        private const string AddMolecularLabReceipts = "SPC_AddMolecularLabReceipt";

        
        public MolecularLabData()
        {

        }

        public void AddReceivedShipment(AddMolecularReceiptRequest mrData)
        {
            try
            {
                var stProc = AddMolecularLabReceipts;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@ShipmentId", mrData.shipmentId ?? mrData.shipmentId),
                    new SqlParameter("@ReceivedDate", mrData.receivedDate ?? mrData.receivedDate),
                    new SqlParameter("@SampleDamaged", mrData.sampleDamaged),
                    new SqlParameter("@BarcodeDamaged", mrData.barcodeDamaged),
                    new SqlParameter("@IsAccept", mrData.isAccept),
                    new SqlParameter("@Barcode", mrData.barcodeNo ?? mrData.barcodeNo),
                    new SqlParameter("@UpdatedBy", mrData.userId),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MolecularLabReceipts RetrieveMolecularLabReceipts(int molecularLabId)
        {
            string stProc = FetchShipmentReceiptInMolecularLab;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@MolecularLabId", molecularLabId),
            };
            var allMolecularLabReceiptLog = UtilityDL.FillData<MolecularLabReceiptsLog>(stProc, pList);
            var allReceiptDetail = UtilityDL.FillData<MolecularLabReceiptDetail>(stProc, pList);
            var molecularLabReceipt = new MolecularLabReceipts();
            molecularLabReceipt.ReceiptLog = allMolecularLabReceiptLog;
            molecularLabReceipt.ReceiptDetail = allReceiptDetail;
            return molecularLabReceipt;
        }
    }
}
