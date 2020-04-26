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
    public class CommunityData : ICommunityData
    {

        private const string FetchCommunities = "SPC_FetchAllCommunity";
        private const string FetchCommunity = "SPC_FetchCommunity";
        private const string AddCommunity = "SPC_AddCommunity";
        public CommunityData()
        {


        }
        public string Add(CommunityRequest cData)
        {
            try
            {
                string stProc = AddCommunity;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                     new SqlParameter("@CasteID",  cData.CasteID),
                    new SqlParameter("@Communityname",  cData.Communityname   ??  cData.Communityname),
                    new SqlParameter("@Isactive",  cData.IsActive ??  cData.IsActive),
                    new SqlParameter("@Comments",  cData.Comments ??  cData.Comments),
                    new SqlParameter("@Createdby",  cData.CreatedBy),
                    new SqlParameter("@Updatedby",  cData.UpdatedBy),

                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "Community added successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Community> Retrieve(int code)
        {
            string stProc = FetchCommunity;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<Community>(stProc, pList);
            return allData;
        }

        public List<Community> Retrieve()
        {
            string stProc = FetchCommunities;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<Community>(stProc, pList);
            return allData;
        }
    }
}
