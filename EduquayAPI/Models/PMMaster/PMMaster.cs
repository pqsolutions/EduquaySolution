using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.PMMaster
{
    public class PMMaster : IFill
    {
        public int id { get; set; }
        public string name { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Id"))
                this.id = Convert.ToInt32(reader["Id"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Name"))
                this.name = Convert.ToString(reader["Name"]);
        }
    }
}
