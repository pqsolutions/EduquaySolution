using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class CHC : IFill
    {
        public int id { get; set; }
        public int districtId { get; set; }
        public string districtName { get; set; }
        public int blockId { get; set; }
        public string blockName { get; set; }
        public string hninId { get; set; }
        public string pincode { get; set; }
        public string chcGovCode { get; set; }
        public string chcName { get; set; }
        public int testingCHCId { get; set; }
        public string testingCHC { get; set; }
        public int centralLabId { get; set; }
        public string centralLabName { get; set; }
        public string isTestingFacility { get; set; }
        public string isActive { get; set; }
        public string comments { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }

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

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HNIN_ID"))
                this.hninId = Convert.ToString(reader["HNIN_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHC_gov_code"))
                this.chcGovCode = Convert.ToString(reader["CHC_gov_code"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCname"))
                this.chcName = Convert.ToString(reader["CHCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Istestingfacility"))
                this.isTestingFacility = Convert.ToString(reader["Istestingfacility"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestingCHCID"))
                this.testingCHCId = Convert.ToInt32(reader["TestingCHCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestingCHC"))
                this.testingCHC = Convert.ToString(reader["TestingCHC"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CentralLabId"))
                this.centralLabId = Convert.ToInt32(reader["CentralLabId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CentralLabName"))
                this.centralLabName = Convert.ToString(reader["CentralLabName"]);

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

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CreatedBy"))
                this.createdBy = Convert.ToInt32(reader["CreatedBy"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UpdatedBy"))
                this.updatedBy = Convert.ToInt32(reader["UpdatedBy"]);
        }
    }
}
