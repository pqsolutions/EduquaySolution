using SentinelAPI.Models.PickandPack;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.DataLayer.PickandPack
{
    public class PickandPackData : IPickandPackData
    {

        private const string FetchSampleCollection = "SPC_FetchSampleCollection";
        public PickandPackData()
        {

        }
        public List<PickandPackDetails> RetrivePickandPackSamples(int hospitalId)
        {
            string stProc = FetchSampleCollection;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@HospitalId", hospitalId),

            };
            var allData = UtilityDL.FillData<PickandPackDetails>(stProc, pList);
            return allData;
        }
    }
}
