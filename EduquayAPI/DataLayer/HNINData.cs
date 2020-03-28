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
        public string Add(HNINRequest hdata)
        {
            try
            {
                string stProc = AddHNIN;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@Facilitytype_ID", hdata.Facilitytype_ID),
                    new SqlParameter("@Facility_name", hdata.@Facility_name ?? hdata.Facility_name),
                    new SqlParameter("@NIN2HFI", hdata.NIN2HFI ?? hdata.NIN2HFI),
                    new SqlParameter("@StateID", hdata.StateId),
                    new SqlParameter("@DistrictID", hdata.DistrictId),
                    new SqlParameter("@Taluka", hdata.Taluka ?? hdata.Taluka),
                    new SqlParameter("@BlockID", hdata.BlockId),
                    new SqlParameter("@Address", hdata.Address ?? hdata.Address),
                    new SqlParameter("@Pincode", hdata.Pincode ?? hdata.Pincode),
                    new SqlParameter("@Landline", hdata.Landline ?? hdata.Landline),
                    new SqlParameter("@Incharge_name", hdata.Incharge_name ?? hdata.Incharge_name),
                    new SqlParameter("@Incharge_contactno", hdata.Incharge_contactno ?? hdata.Incharge_contactno),
                    new SqlParameter("@Incharge_EmailId", hdata.Incharge_EmailId ?? hdata.Incharge_EmailId),
                    new SqlParameter("@Isactive", hdata.IsActive ?? hdata.IsActive),
                    new SqlParameter("@Latitude", hdata.Latitude ?? hdata.Latitude),
                    new SqlParameter("@Longitude", hdata.Longitude ?? hdata.Longitude),
                    new SqlParameter("@Comments", hdata.Comments ?? hdata.Comments),
                    new SqlParameter("@Createdby", hdata.CreatedBy),
                    new SqlParameter("@Updatedby", hdata.UpdatedBy),

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

        public List<HNIN> Retreive(int code)
        {
            string stProc = FetchHNIN;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<HNIN>(stProc, pList);
            return allData;
        }

        public List<HNIN> Retreive()
        {
            string stProc = FetchHNINs;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<HNIN>(stProc, pList);
            return allData;
        }
    }
}
