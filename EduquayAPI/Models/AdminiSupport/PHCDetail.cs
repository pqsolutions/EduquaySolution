using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.AdminiSupport
{
    public class PHCDetail : IFill
    {
        public int id { get; set; }
        public int districtId { get; set; }
        public string districtName { get; set; }
        public int chcId { get; set; }
        public string chcName { get; set; }
        public string hninId { get; set; }
        public string phcGovCode { get; set; }
        public string name { get; set; }
        public string pincode { get; set; }
        public string isActive { get; set; }
        public string comments { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DistrictID"))
                this.districtId = Convert.ToInt32(reader["DistrictID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Districtname"))
                this.districtName = Convert.ToString(reader["Districtname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCID"))
                this.chcId = Convert.ToInt32(reader["CHCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCname"))
                this.chcName = Convert.ToString(reader["CHCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PHC_gov_code"))
                this.phcGovCode = Convert.ToString(reader["PHC_gov_code"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PHCname"))
                this.name = Convert.ToString(reader["PHCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HNIN_ID"))
                this.hninId = Convert.ToString(reader["HNIN_ID"]);
           
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Pincode"))
                this.pincode = Convert.ToString(reader["Pincode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "IsActive"))
                this.isActive = Convert.ToString(reader["IsActive"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Comments"))
                this.comments = Convert.ToString(reader["Comments"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Latitude"))
                this.latitude = Convert.ToString(reader["Latitude"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Longitude"))
                this.longitude = Convert.ToString(reader["Longitude"]);
        }
    }
}
