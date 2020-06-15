using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class District : IFill
    {
        public int id { get; set; }
        public int stateId { get; set; }
        public string stateName { get; set; }
        public string districtGovCode { get; set; }
        public string districtName { get; set; }
        public string isActive { get; set; }
        public string comments { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "StateId"))
                this.stateId = Convert.ToInt32(reader["StateId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Statename"))
                this.stateName = Convert.ToString(reader["Statename"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "District_gov_code"))
                this.districtGovCode = Convert.ToString(reader["District_gov_code"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Districtname"))
                this.districtName = Convert.ToString(reader["Districtname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "IsActive"))
                this.isActive = Convert.ToString(reader["IsActive"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Comments"))
                this.comments = Convert.ToString(reader["Comments"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CreatedBy"))
                this.createdBy = Convert.ToInt32(reader["CreatedBy"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UpdatedBy"))
                this.updatedBy = Convert.ToInt32(reader["UpdatedBy"]);
        }
    }
}
