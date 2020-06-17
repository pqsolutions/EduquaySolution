using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.LoadMasters
{
    public class LoadRIs : IFill
    {
        public int id { get; set; }
        public string riSite { get; set; }
        public string riGovCode { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RIsite"))
                this.riSite = Convert.ToString(reader["RIsite"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RI_gov_code"))
                this.riGovCode  = Convert.ToString(reader["RI_gov_code"]);


        }
    }
}

   
