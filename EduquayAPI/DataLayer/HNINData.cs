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
                    new SqlParameter("@Facilitytype_ID", hData.Facilitytype_ID),
                    new SqlParameter("@Facility_name", hData.@Facility_name ?? hData.Facility_name),
                    new SqlParameter("@NIN2HFI", hData.NIN2HFI ?? hData.NIN2HFI),
                    new SqlParameter("@StateID", hData.StateId),
                    new SqlParameter("@DistrictID", hData.DistrictId),
                    new SqlParameter("@Taluka", hData.Taluka ?? hData.Taluka),
                    new SqlParameter("@BlockID", hData.BlockId),
                    new SqlParameter("@Address", hData.Address ?? hData.Address),
                    new SqlParameter("@Pincode", hData.Pincode ?? hData.Pincode),
                    new SqlParameter("@Landline", hData.Landline ?? hData.Landline),
                    new SqlParameter("@Incharge_name", hData.Incharge_name ?? hData.Incharge_name),
                    new SqlParameter("@Incharge_contactno", hData.Incharge_contactno ?? hData.Incharge_contactno),
                    new SqlParameter("@Incharge_EmailId", hData.Incharge_EmailId ?? hData.Incharge_EmailId),
                    new SqlParameter("@Isactive", hData.IsActive ?? hData.IsActive),
                    new SqlParameter("@Latitude", hData.Latitude ?? hData.Latitude),
                    new SqlParameter("@Longitude", hData.Longitude ?? hData.Longitude),
                    new SqlParameter("@Comments", hData.Comments ?? hData.Comments),
                    new SqlParameter("@Createdby", hData.CreatedBy),
                    new SqlParameter("@Updatedby", hData.UpdatedBy),

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
