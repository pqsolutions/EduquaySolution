using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.LoadMasters
{
    public class LoadDistricts : IFill
    {
        public int id { get; set; }
        public string districtName { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Districtname"))
                this.districtName = Convert.ToString(reader["Districtname"]);
        }
    }
}
