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
    public class BlockData : IBlockData
    {
        private const string FetchAllBlocks = "SPC_FetchAllBlocks";
        private const string FetchBlock = "SPC_FetchBlock";
        private const string AddBlocks = "SPC_AddBlock";
        public BlockData()
        {

        }

        public string AddBlock(BlockRequest bData)
        {
            try
            {
                string stProc = AddBlocks;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@Block_gov_code", bData.Block_gov_code),
                    new SqlParameter("@DistrictID", bData.DistrictId),
                    new SqlParameter("@Blockname", bData.Blockname  ?? bData.Blockname),
                    new SqlParameter("@Isactive", bData.IsActive ?? bData.IsActive),                  
                    new SqlParameter("@Comments", bData.Comments ?? bData.Comments),
                    new SqlParameter("@Createdby", bData.CreatedBy),
                    new SqlParameter("@Updatedby", bData.UpdatedBy),
                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "Block added successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Block> Retrieve(int code)
        {
            string stProc = FetchBlock;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<Block>(stProc, pList);
            return allData;
        }

        public List<Block> Retrieve()
        {
            string stProc = FetchAllBlocks;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<Block>(stProc, pList);
            return allData;
        }
    }
}
