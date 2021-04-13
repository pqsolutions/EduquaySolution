using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.AdminiSupport
{
    public class BlockDetail : IFill
    {
        public int id { get; set; }
        public int districtId { get; set; }
        public string districtName { get; set; }
        public string blockGovCode { get; set; }
        public string name { get; set; }
        public string isActive { get; set; }
        public string comments { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DistrictId"))
                this.districtId = Convert.ToInt32(reader["DistrictId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Districtname"))
                this.districtName = Convert.ToString(reader["Districtname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Blockname"))
                this.name = Convert.ToString(reader["Blockname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Block_gov_code"))
                this.blockGovCode = Convert.ToString(reader["Block_gov_code"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "IsActive"))
                this.isActive = Convert.ToString(reader["IsActive"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Comments"))
                this.comments = Convert.ToString(reader["Comments"]);
        }
    }
}
