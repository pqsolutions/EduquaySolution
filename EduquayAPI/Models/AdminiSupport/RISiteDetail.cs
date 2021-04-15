using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.AdminiSupport
{
    public class RISiteDetail : IFill
    {
        public int id { get; set; }
        public int districtId { get; set; }
        public string districtName { get; set; }
        public int blockId { get; set; }
        public string blockName { get; set; }
        public int testingCHCId { get; set; }
        public string testingCHCName { get; set; }
        public int chcId { get; set; }
        public string chcName { get; set; }
        public int phcId { get; set; }
        public string phcName { get; set; }
        public int scId { get; set; }
        public string scName { get; set; }
        public string riGovCode { get; set; }
        public string name { get; set; }
        public string pincode { get; set; }
        public int ilrId { get; set; }
        public string ilrPoint { get; set; }
        public string isActive { get; set; }
        public string comments { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DistrictID"))
                this.districtId = Convert.ToInt32(reader["DistrictId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Districtname"))
                this.districtName = Convert.ToString(reader["Districtname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BlockID"))
                this.blockId = Convert.ToInt32(reader["BlockId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Blockname"))
                this.blockName = Convert.ToString(reader["Blockname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestingCHCID"))
                this.testingCHCId = Convert.ToInt32(reader["TestingCHCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestingCHCName"))
                this.testingCHCName = Convert.ToString(reader["TestingCHCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCID"))
                this.chcId = Convert.ToInt32(reader["CHCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCName"))
                this.chcName = Convert.ToString(reader["CHCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PHCID"))
                this.phcId = Convert.ToInt32(reader["PHCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PHCname"))
                this.phcName = Convert.ToString(reader["PHCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCID"))
                this.scId = Convert.ToInt32(reader["SCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCname"))
                this.scName = Convert.ToString(reader["SCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RI_gov_code"))
                this.riGovCode = Convert.ToString(reader["RI_gov_code"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RIsite"))
                this.name = Convert.ToString(reader["RIsite"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Pincode"))
                this.pincode = Convert.ToString(reader["Pincode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ILRID"))
                this.ilrId = Convert.ToInt32(reader["ILRID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ILRPoint"))
                this.ilrPoint = Convert.ToString(reader["ILRPoint"]);

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