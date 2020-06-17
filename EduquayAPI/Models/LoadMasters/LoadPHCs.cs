using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.LoadMasters
{
    public class LoadPHCs : IFill
    {
        public int id { get; set; }
        public string phcName { get; set; }
        public string phcGovCode { get; set; }


        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PHCname"))
                this.phcName = Convert.ToString(reader["PHCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PHC_gov_code"))
                this.phcGovCode = Convert.ToString(reader["PHC_gov_code"]);

        }
    }
}
