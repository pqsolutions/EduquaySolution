using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Masters.LoadMasters
{
    public class LoadBirthStatus : IFill
    {
        public int id { get; set; }
        public string birthStatus { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BirthStatus"))
                this.birthStatus = Convert.ToString(reader["BirthStatus"]);
        }
    }
}
