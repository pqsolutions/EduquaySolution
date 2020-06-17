using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.LoadMasters
{
    public class LoadSCs : IFill
    {
        public int id { get; set; }
        public string scName { get; set; }
        public string scGovCode { get; set; }


        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCname"))
                this.scName = Convert.ToString(reader["SCname"]);
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SC_gov_code"))
                this.scGovCode = Convert.ToString(reader["SC_gov_code"]);
        }
    }
}
