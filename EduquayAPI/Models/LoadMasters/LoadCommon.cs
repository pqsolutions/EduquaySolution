using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.LoadMasters
{
    public class LoadCommon : IFill
    {
        public int id { get; set; }
        public string name { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Name"))
                this.name = Convert.ToString(reader["Name"]);

        }
    }
}
