using EduquayAPI.Contracts.V1.Request.Support;
using EduquayAPI.Models.MobileSubject.MobileSampleCollection;
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
        private const string FetchErrorBarcodeDetailForSMS = "SPC_FetchErrorBarcodeDetailForSMS";
        private const string FetchUpdateBarcodeDetail = "SPC_FetchUpdateBarcodeDetail";

        private const string FetchDetailForRCHIDCorrection = "SPC_FetchDetailForRCHIDCorrection";
        private const string UpdateRCHIdDetail = "SPC_UpdateRCHIdDetail";
        private const string FetchUpdateRCHIDDetail = "SPC_FetchUpdateRCHIDDetail";
        private const string FetchRCHIDExist = "SPC_FetchRCHIDExist";

        public SupportData()
        {

        }

        public ErrorBarcodeSMSDetail ErrorSMSTrigger(int getId)
        {
            try
            {
                var stProc = FetchErrorBarcodeDetailForSMS;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@Id", getId),
                };
                var smsDetail = UtilityDL.FillEntity<ErrorBarcodeSMSDetail>(stProc, pList);
                return smsDetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public List<BarcodeErrorDetail> FetchDetailsForRCHCorrection(string input)
        {
            string stProc = FetchDetailForRCHIDCorrection;
            var pList = new List<SqlParameter>() { new SqlParameter("@Input", input) };
            var allData = UtilityDL.FillData<BarcodeErrorDetail>(stProc, pList);
            return allData;
        }

        public List<BarcodeErrorDetail> FetchErrorBarcodeDetails()
        {
            string stProc = FetchErrorBarcodeCorrection;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<BarcodeErrorDetail>(stProc, pList);
            return allData;
        }

        public List<BarcodeErrorDetail> FetchRCHIDExists(string input)
        {
            string stProc = FetchRCHIDExist;
            var pList = new List<SqlParameter>() { new SqlParameter("@RCHID", input) };
            var allData = UtilityDL.FillData<BarcodeErrorDetail>(stProc, pList);
            return allData;
        }

        public List<BarcodeUpdationDetails> FetchUpdatedBarcodeDetails(string ids)
        {
            string stProc = FetchUpdateBarcodeDetail;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", ids) };
            var allData = UtilityDL.FillData<BarcodeUpdationDetails>(stProc, pList);
            return allData;
        }

        public List<RCHUpdationDetails> FetchUpdatedRCHIDDetails(string ids)
        {
            string stProc = FetchUpdateRCHIDDetail;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", ids) };
            var allData = UtilityDL.FillData<RCHUpdationDetails>(stProc, pList);
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

        public UpdateRCHIDMsg UpdateRCHId(UpdateRCHIDRequest rData)
        {
            string stProc = UpdateRCHIdDetail;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@OldRCHId", rData.rchId),
                new SqlParameter("@NewRCHId", rData.revisedRCHID),
                new SqlParameter("@UserId", rData.userId),
            };
            var allData = UtilityDL.FillEntity<UpdateRCHIDMsg>(stProc, pList);
            return allData;
        }
    }
}
