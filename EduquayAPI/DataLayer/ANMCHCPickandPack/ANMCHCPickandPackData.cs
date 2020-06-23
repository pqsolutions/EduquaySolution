using EduquayAPI.Contracts.V1.Request.ANMCHCPickandPack;
using EduquayAPI.Models.ANMCHCPickandPack;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.ANMCHCPickandPack
{
    public class ANMCHCPickandPackData : IANMCHCPickandPackData
    {
        private const string FetchSampleCollection = "SPC_FetchSampleCollection";
        public ANMCHCPickandPackData()
        {

        }

        public List<ANMCHCPickandPackSamples> Retrieve(ANMCHCPickandPackRequest acppData)
        {
            string stProc = FetchSampleCollection;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserID", acppData.userId),
                new SqlParameter("@CollectionFrom", acppData.collectionFrom),
            };
            var allData = UtilityDL.FillData<ANMCHCPickandPackSamples>(stProc, pList);
            return allData;
        }
    }
}
