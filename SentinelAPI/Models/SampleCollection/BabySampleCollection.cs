using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.SampleCollection
{
    public class BabySampleCollection : IFill
    {
        public string msg { get; set; }
        public bool collectStatus { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MSG"))
                this.msg = Convert.ToString(reader["MSG"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CollectStatus"))
                this.collectStatus = Convert.ToBoolean(reader["CollectStatus"]);
        }
    }
}
