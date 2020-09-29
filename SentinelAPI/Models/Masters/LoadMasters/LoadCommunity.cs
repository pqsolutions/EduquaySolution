using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Masters.LoadMasters
{
    public class LoadCommunity : IFill
    {
        public int id { get; set; }
        public string name { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Communityname"))
                this.name = Convert.ToString(reader["Communityname"]);
        }
    }
}
