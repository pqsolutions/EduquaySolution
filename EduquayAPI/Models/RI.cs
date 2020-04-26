using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class RI : IFill
    {
        public int Id { get; set; }      
        public int PHCId { get; set; }
        public string PHCName { get; set; }       
        public int SCId { get; set; }
        public string SCName { get; set; }
        public string RI_gov_code { get; set; }
        public string RIsite { get; set; }
        public string Pincode { get; set; }
        public int ILRID { get; set; }
        public string ILRPoint { get; set; }
        public string IsActive { get; set; }
        public string Comments { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.Id = Convert.ToInt32(reader["ID"]);           

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PHCID"))
                this.PHCId = Convert.ToInt32(reader["PHCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PHCname"))
                this.PHCName = Convert.ToString(reader["PHCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCID"))
                this.SCId = Convert.ToInt32(reader["SCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCname"))
                this.SCName = Convert.ToString(reader["SCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RI_gov_code"))
                this.RI_gov_code = Convert.ToString(reader["RI_gov_code"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RIsite"))
                this.RIsite = Convert.ToString(reader["RIsite"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Pincode"))
                this.Pincode = Convert.ToString(reader["Pincode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ILRID"))
                this.ILRID = Convert.ToInt32(reader["ILRID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ILRPoint"))
                this.ILRPoint = Convert.ToString(reader["ILRPoint"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "IsActive"))
                this.IsActive = Convert.ToString(reader["IsActive"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Comments"))
                this.Comments = Convert.ToString(reader["Comments"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Latitude"))
                this.Latitude = Convert.ToString(reader["Latitude"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Longitude"))
                this.Longitude = Convert.ToString(reader["Longitude"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CreatedBy"))
                this.CreatedBy = Convert.ToInt32(reader["CreatedBy"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UpdatedBy"))
                this.UpdatedBy = Convert.ToInt32(reader["UpdatedBy"]);
        }
    }
}
