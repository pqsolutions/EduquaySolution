using EduquayAPI.Contracts.V1.Request.Support;
using EduquayAPI.Models.Support;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.Support
{
    public class SupportData : ISupportData
    {
        private const string FetchErrorBarcodeCorrection = "SPC_FetchErrorBarcodeCorrection";
        private const string FetchBarcodeForErrorCorrection = "SPC_FetchBarcodeForErrorCorrection";
        private const string FetchBarcodeExists = "SPC_FetchBarcodeExist";
        private const string UpdateErrorBarcodeDetail = "SPC_UpdateErrorBarcodeDetail";
        public SupportData()
        {

        }

        public List<BarcodeErrorDetail> FetchBarcodeDetailsForErrorCorrection(string barcodeNo)
        {
            string stProc = FetchBarcodeForErrorCorrection;
            var pList = new List<SqlParameter>() { new SqlParameter("@BarcodeNo", barcodeNo) };
            var allData = UtilityDL.FillData<BarcodeErrorDetail>(stProc, pList);
            return allData;
        }

        public BarcodeErrorDetail FetchBarcodeExist(string barcodeNo)
        {
            string stProc = FetchBarcodeExists;
            var pList = new List<SqlParameter>() { new SqlParameter("@BarcodeNo", barcodeNo) };
            var allData = UtilityDL.FillEntity<BarcodeErrorDetail>(stProc, pList);
            return allData;
        }

        public List<BarcodeErrorDetail> FetchErrorBarcodeDetails()
        {
            string stProc = FetchErrorBarcodeCorrection;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<BarcodeErrorDetail>(stProc, pList);
            return allData;
        }

        public UpdateBarcodeMsg UpdateErrorBarcode(UpdateBarcodeRequest bData)
        {
            string stProc = UpdateErrorBarcodeDetail;
            var pList = new List<SqlParameter>()
            { 
                new SqlParameter("@OldBarcode", bData.barcodeNo),
                new SqlParameter("@NewBarcode", bData.revisedBarcodeNo),
                new SqlParameter("@UserId", bData.userId),
            };
            var allData = UtilityDL.FillEntity<UpdateBarcodeMsg>(stProc, pList);
            return allData;
        }
    }
}
