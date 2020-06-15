using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace EduquayAPI.Models
{
    public class HNIN :IFill
    {
        public int id { get; set; }
        public int facilityTypeId { get; set; }
        public string facilityType { get; set; }
        public string facilityName { get; set; }
        public string nin2hfi { get; set; }     
        public int stateId { get; set; }
        public string stateName { get; set; }
        public int districtId { get; set; }
        public string districtName { get; set; }
        public string taluka { get; set; }
        public int blockId { get; set; }
        public string blockName { get; set; }
        public string address { get; set; }
        public string pincode { get; set; }
        public string landline { get; set; }
        public string inchargeName { get; set; }
        public string inchargeContactNo { get; set; }
        public string inchargeEmailId { get; set; }
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

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Facilitytype_ID"))
                this.facilityTypeId = Convert.ToInt32(reader["Facilitytype_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Facility_name"))
                this.facilityName = Convert.ToString(reader["Facility_name"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "NIN2HFI"))
                this.nin2hfi = Convert.ToString(reader["NIN2HFI"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "StateID"))
                this.stateId = Convert.ToInt32(reader["StateID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "StateName"))
                this.stateName = Convert.ToString(reader["StateName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DistrictID"))
                this.districtId = Convert.ToInt32(reader["DistrictID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Districtname"))
                this.districtName = Convert.ToString(reader["Districtname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Taluka"))
                this.taluka = Convert.ToString(reader["Taluka"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BlockID"))
                this.blockId = Convert.ToInt32(reader["BlockID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Blockname"))
                this.blockName = Convert.ToString(reader["Blockname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address"))
                this.address = Convert.ToString(reader["Address"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Pincode"))
                this.pincode = Convert.ToString(reader["Pincode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Landline"))
                this.landline = Convert.ToString(reader["Landline"]);
            
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Incharge_name"))
                this.inchargeName = Convert.ToString(reader["Incharge_name"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Incharge_contactno"))
                this.inchargeContactNo = Convert.ToString(reader["Incharge_contactno"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Incharge_EmailId"))
                this.inchargeEmailId = Convert.ToString(reader["Incharge_EmailId"]);

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
