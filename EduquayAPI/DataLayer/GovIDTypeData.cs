using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using EduquayAPI.Models.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer
{
    public class GovIDTypeData : IGovIDTypeData
    {

        private const string FetchGovIDTypes = "SPC_FetchAllGovIDType";
        private const string FetchGovIDType = "SPC_FetchGovIDType";
        private const string AddGovIDType = "SPC_AddGovIDType";
        public GovIDTypeData()
        {

        }
        public AddEditMasters Add(GovIDTypeRequest gtData)
        {
            try
            {
                string stProc = AddGovIDType;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@GovIDType", gtData.govIdTypeName ?? gtData.govIdTypeName),
                    new SqlParameter("@Isactive", gtData.isActive ?? gtData.isActive),
                    new SqlParameter("@Comments", gtData.comments ?? gtData.comments),
                    new SqlParameter("@Createdby", gtData.createdBy),
                    new SqlParameter("@Updatedby", gtData.updatedBy),
                };
                var returnData = UtilityDL.FillEntity<AddEditMasters>(stProc, pList);
                return returnData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<GovIDType> Retrieve(int code)
        {
            string stProc = FetchGovIDType;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<GovIDType>(stProc, pList);
            return allData;
        }

        public List<GovIDType> Retrieve()
        {
            string stProc = FetchGovIDTypes;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<GovIDType>(stProc, pList);
            return allData;
        }
    }
}