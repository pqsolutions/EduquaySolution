using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.AdminiSupport
{
    public class StateDetails : IFill
    {
        public int id { get; set; }
        public string stateGovCode { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public string isActive { get; set; }
        public string comments { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "State_gov_code"))
                this.stateGovCode = Convert.ToString(reader["State_gov_code"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Statename"))
                this.name = Convert.ToString(reader["Statename"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Shortname"))
                this.shortName = Convert.ToString(reader["Shortname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "IsActive"))
                this.isActive = Convert.ToString(reader["IsActive"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Comments"))
                this.comments = Convert.ToString(reader["Comments"]);
        }
    }
}