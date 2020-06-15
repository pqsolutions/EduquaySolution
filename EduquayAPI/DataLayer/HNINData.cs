using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer
{
    public class HNINData : IHNINData
    {
        private const string FetchHNINs = "SPC_FetchAllHNIN";
        private const string FetchHNIN = "SPC_FetchHNIN";
        private const string AddHNIN = "SPC_AddHNIN";
        public HNINData()
        {

        }
        public string Add(HNINRequest hData)
        {
            try
            {
                string stProc = AddHNIN;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@Facilitytype_ID", hData.facilityTypeId),
                    new SqlParameter("@Facility_name", hData.facilityName ?? hData.facilityName),
                    new SqlParameter("@NIN2HFI", hData.nin2hfi ?? hData.nin2hfi),
                    new SqlParameter("@StateID", hData.stateId),
                    new SqlParameter("@DistrictID", hData.districtId),
                    new SqlParameter("@Taluka", hData.taluka ?? hData.taluka),
                    new SqlParameter("@BlockID", hData.blockId),
                    new SqlParameter("@Address", hData.address ?? hData.address),
                    new SqlParameter("@Pincode", hData.pincode ?? hData.pincode),
                    new SqlParameter("@Landline", hData.landline ?? hData.landline),
                    new SqlParameter("@Incharge_name", hData.inchargeName ?? hData.inchargeName),
                    new SqlParameter("@Incharge_contactno", hData.inchargeContactNo ?? hData.inchargeContactNo),
                    new SqlParameter("@Incharge_EmailId", hData.inchargeEmailId ?? hData.inchargeEmailId),
                    new SqlParameter("@Isactive", hData.isActive ?? hData.isActive),
                    new SqlParameter("@Latitude", hData.latitude ?? hData.latitude),
                    new SqlParameter("@Longitude", hData.longitude ?? hData.longitude),
                    new SqlParameter("@Comments", hData.comments ?? hData.comments),
                    new SqlParameter("@Createdby", hData.createdBy),
                    new SqlParameter("@Updatedby", hData.updatedBy),

                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "HNIN added successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<HNIN> Retrieve(int code)
        {
            string stProc = FetchHNIN;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<HNIN>(stProc, pList);
            return allData;
        }

        public List<HNIN> Retrieve()
        {
            string stProc = FetchHNINs;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<HNIN>(stProc, pList);
            return allData;
        }
    }
}
