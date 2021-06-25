using EduquayAPI.Contracts.V1.Request.AdminSupport;
using EduquayAPI.Contracts.V1.Request.Support;
using EduquayAPI.Models;
using EduquayAPI.Models.AdminiSupport;
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

        private const string FetchDetailForLMPCorrection = "SPC_FetchDetailForLMPCorrection";
        private const string UpdateLMPDetail = "SPC_UpdateLMPDetail";

        private const string FetchDetailForSSTCorrection = "SPC_FetchDetailForSSTCorrection";
        private const string UpdateSSTDetail = "SPC_UpdateSSTDetail";

        private const string FetchBarcodeErrorCorrectionReport = "SPC_FetchBarcodeErrorCorrectionReport";
        private const string FetchRCHIDErrorCorrectionReport = "SPC_FetchRCHIDErrorCorrectionReport";
        private const string FetchLMPErrorCorrectionReport = "SPC_FetchLMPErrorCorrectionReport";
        private const string FetchSSTResultCorrectionReport = "SPC_FetchSSTResultCorrectionReport";

        private const string AddANMUser = "SPC_AddANMUser";

        public SupportData()
        {

        }

        public ANMCreation AddNewANM(AddANMRequest addUser, string password)
        {
            try
            {
                var stProc = AddANMUser;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@User_gov_code", addUser.userGovCode),
                    new SqlParameter("@Password", password),
                    new SqlParameter("@DistrictID", addUser.districtId),
                    new SqlParameter("@BlockID", addUser.blockId),
                    new SqlParameter("@CHCID", addUser.chcId),
                    new SqlParameter("@PHCID", addUser.phcId),
                    new SqlParameter("@SCID", addUser.scId),
                    new SqlParameter("@RIID", addUser.riId ?? addUser.riId),
                    new SqlParameter("@FirstName", addUser.firstName ?? addUser.firstName),
                    new SqlParameter("@MiddleName", addUser.middleName.ToCheckNull()),
                    new SqlParameter("@LastName", addUser.lastName.ToCheckNull()),
                    new SqlParameter("@ContactNo1", addUser.contactNo1 ?? addUser.contactNo1),
                    new SqlParameter("@ContactNo2", addUser.contactNo2.ToCheckNull()),
                    new SqlParameter("@Email", addUser.email.ToCheckNull()),
                    new SqlParameter("@GovIDType_ID", addUser.govIdTypeId),
                    new SqlParameter("@GovIDDetails", addUser.govIdDetails.ToCheckNull()),
                    new SqlParameter("@Address", addUser.address.ToCheckNull()),
                    new SqlParameter("@Pincode", addUser.pincode.ToCheckNull()),
                    new SqlParameter("@UserId", addUser.userId),
                };
                var allData = UtilityDL.FillEntity<ANMCreation>(stProc, pList);
                return allData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public List<BarcodeErrorReportDetail> FetchBarcodeErrorReport(ReportRequest rData)
        {
            string stProc = FetchBarcodeErrorCorrectionReport;
            var pList = new List<SqlParameter>() 
            { 
                new SqlParameter("@FromDate", rData.fromDate),
                new SqlParameter("@ToDate", rData.toDate),
                new SqlParameter("@DistrictID", rData.districtId),
                new SqlParameter("@CHCID", rData.chcId),
                new SqlParameter("@PHCID", rData.phcId),
                new SqlParameter("@ANMID", rData.anmId)
            };
            var allData = UtilityDL.FillData<BarcodeErrorReportDetail>(stProc, pList);
            return allData;
        }

        public BarcodeErrorDetail FetchBarcodeExist(string barcodeNo)
        {
            string stProc = FetchBarcodeExists;
            var pList = new List<SqlParameter>() { new SqlParameter("@BarcodeNo", barcodeNo) };
            var allData = UtilityDL.FillEntity<BarcodeErrorDetail>(stProc, pList);
            return allData;
        }

        public List<BarcodeErrorDetail> FetchDetailsForLMPCorrection(FetchRequest rData)
        {
            string stProc = FetchDetailForLMPCorrection;
            var pList = new List<SqlParameter>() { new SqlParameter("@Input", rData.input) };
            var allData = UtilityDL.FillData<BarcodeErrorDetail>(stProc, pList);
            return allData;
        }

        public List<BarcodeErrorDetail> FetchDetailsForRCHCorrection(string input)
        {
            string stProc = FetchDetailForRCHIDCorrection;
            var pList = new List<SqlParameter>() { new SqlParameter("@Input", input) };
            var allData = UtilityDL.FillData<BarcodeErrorDetail>(stProc, pList);
            return allData;
        }

        public List<SSTErrorDetail> FetchDetailsForSSTCorrection(FetchRequest rData)
        {
            string stProc = FetchDetailForSSTCorrection;
            var pList = new List<SqlParameter>() { new SqlParameter("@Input", rData.input) };
            var allData = UtilityDL.FillData<SSTErrorDetail>(stProc, pList);
            return allData;
        }

        public List<BarcodeErrorDetail> FetchErrorBarcodeDetails()
        {
            string stProc = FetchErrorBarcodeCorrection;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<BarcodeErrorDetail>(stProc, pList);
            return allData;
        }

        public List<LMPErrorReportDetail> FetchLMPErrorReport(ReportRequest rData)
        {
            string stProc = FetchLMPErrorCorrectionReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", rData.fromDate),
                new SqlParameter("@ToDate", rData.toDate),
                new SqlParameter("@DistrictID", rData.districtId),
                new SqlParameter("@CHCID", rData.chcId),
                new SqlParameter("@PHCID", rData.phcId),
                new SqlParameter("@ANMID", rData.anmId)
            };
            var allData = UtilityDL.FillData<LMPErrorReportDetail>(stProc, pList);
            return allData;
        }

        public List<RCHErrorReportDetail> FetchRCHErrorReport(ReportRequest rData)
        {
            string stProc = FetchRCHIDErrorCorrectionReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", rData.fromDate),
                new SqlParameter("@ToDate", rData.toDate),
                new SqlParameter("@DistrictID", rData.districtId),
                new SqlParameter("@CHCID", rData.chcId),
                new SqlParameter("@PHCID", rData.phcId),
                new SqlParameter("@ANMID", rData.anmId)
            };
            var allData = UtilityDL.FillData<RCHErrorReportDetail>(stProc, pList);
            return allData;
        }

        public List<BarcodeErrorDetail> FetchRCHIDExists(string input)
        {
            string stProc = FetchRCHIDExist;
            var pList = new List<SqlParameter>() { new SqlParameter("@RCHID", input) };
            var allData = UtilityDL.FillData<BarcodeErrorDetail>(stProc, pList);
            return allData;
        }

        public List<SSTCorrectionReportDetail> FetchSSTErrorReport(ReportRequest rData)
        {
            string stProc = FetchSSTResultCorrectionReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", rData.fromDate),
                new SqlParameter("@ToDate", rData.toDate),
                new SqlParameter("@DistrictID", rData.districtId),
                new SqlParameter("@CHCID", rData.chcId),
                new SqlParameter("@PHCID", rData.phcId),
                new SqlParameter("@ANMID", rData.anmId)
            };
            var allData = UtilityDL.FillData<SSTCorrectionReportDetail>(stProc, pList);
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

        public ErrorMsgDetail UpdateErrorLMP(UpdateLMPRequest bData)
        {
            string stProc = UpdateLMPDetail;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@SubjectId", bData.subjectId),
                new SqlParameter("@OldLMP", bData.oldLMP),
                new SqlParameter("@NewLMP", bData.newLMP),
                new SqlParameter("@Remarks", bData.remarks),
                new SqlParameter("@UserId", bData.userId),
            };
            var allData = UtilityDL.FillEntity<ErrorMsgDetail>(stProc, pList);
            return allData;
        }

        public ErrorMsgDetail UpdateErrorSST(UpdateSSTRequest bData)
        {
            string stProc = UpdateSSTDetail;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@SSTID", bData.sstId),
                new SqlParameter("@SubjectId", bData.subjectId),
                new SqlParameter("@Barcode", bData.barcode),
                new SqlParameter("@OldSST", bData.oldSST),
                new SqlParameter("@NewSST", bData.newSST),
                new SqlParameter("@Remarks", bData.remarks),
                new SqlParameter("@UserId", bData.userId),
            };
            var allData = UtilityDL.FillEntity<ErrorMsgDetail>(stProc, pList);
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
