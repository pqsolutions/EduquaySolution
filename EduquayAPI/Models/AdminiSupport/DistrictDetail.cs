using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.AdminiSupport
{
    public class DistrictDetail : IFill
    {
        public int id { get; set; }
        public string districtGovCode { get; set; }
        public string name { get; set; }
        public int stateId { get; set; }
        public string stateName { get; set; }
        public string isActive { get; set; }
        public string comments { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "StateID"))
                this.stateId = Convert.ToInt32(reader["StateID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "District_gov_code"))
                this.districtGovCode = Convert.ToString(reader["District_gov_code"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Statename"))
                this.stateName = Convert.ToString(reader["Statename"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Districtname"))
                this.name = Convert.ToString(reader["Districtname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "IsActive"))
                this.isActive = Convert.ToString(reader["IsActive"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Comments"))
                this.comments = Convert.ToString(reader["Comments"]);
        }
    }
}