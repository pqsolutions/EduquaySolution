using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class State:IFill
    {
        public int Id { get; set; }
        public string State_Gov_Code { get; set; }
        public string StateName { get; set; }
        public string Shortname { get; set; }
        public string IsActive { get; set; }
        public string Comments { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.Id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "State_gov_code"))
                this.State_Gov_Code = Convert.ToString(reader["State_gov_code"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Statename"))
                this.StateName = Convert.ToString(reader["Statename"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Shortname"))
                this.Shortname = Convert.ToString(reader["Shortname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "IsActive"))
                this.IsActive = Convert.ToString(reader["IsActive"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Comments"))
                this.Comments = Convert.ToString(reader["Comments"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CreatedBy"))
                this.CreatedBy = Convert.ToInt32(reader["CreatedBy"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UpdatedBy"))
                this.UpdatedBy = Convert.ToInt32(reader["UpdatedBy"]);
        }
    }
}
