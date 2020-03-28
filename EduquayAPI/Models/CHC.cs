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
        public int Id { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int BlockId { get; set; }
        public string BlockName { get; set; }
        public int HNIN_ID { get; set; }      
        public string NIN2HFI { get; set; }
        public string CHC_gov_code { get; set; }
        public string CHCname { get; set; }
        public string Istestingfacility { get; set; }
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

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DistrictID"))
                this.DistrictId = Convert.ToInt32(reader["DistrictId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Districtname"))
                this.DistrictName = Convert.ToString(reader["Districtname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BlockID"))
                this.BlockId = Convert.ToInt32(reader["BlockId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Blockname"))
                this.BlockName = Convert.ToString(reader["Blockname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HNIN_ID"))
                this.HNIN_ID = Convert.ToInt32(reader["HNIN_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "NIN2HFI"))
                this.NIN2HFI = Convert.ToString(reader["NIN2HFI"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHC_gov_code"))
                this.CHC_gov_code = Convert.ToString(reader["CHC_gov_code"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCname"))
                this.CHCname = Convert.ToString(reader["CHCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Istestingfacility"))
                this.Istestingfacility = Convert.ToString(reader["Istestingfacility"]);

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
