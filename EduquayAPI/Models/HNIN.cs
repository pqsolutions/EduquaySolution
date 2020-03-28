using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace EduquayAPI.Models
{
    public class HNIN :IFill
    {
        public int Id { get; set; }
        public int Facilitytype_ID { get; set; }
        public string FacilityType { get; set; }
        public string Facility_name { get; set; }
        public string NIN2HFI { get; set; }     
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string Taluka { get; set; }
        public int BlockId { get; set; }
        public string BlockName { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string Landline { get; set; }
        public string Incharge_name { get; set; }
        public string Incharge_contactno { get; set; }
        public string Incharge_EmailId { get; set; }
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

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Facilitytype_ID"))
                this.Facilitytype_ID = Convert.ToInt32(reader["Facilitytype_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Facility_name"))
                this.Facility_name = Convert.ToString(reader["Facility_name"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "NIN2HFI"))
                this.NIN2HFI = Convert.ToString(reader["NIN2HFI"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "StateID"))
                this.StateId = Convert.ToInt32(reader["StateID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "StateName"))
                this.StateName = Convert.ToString(reader["StateName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DistrictID"))
                this.DistrictId = Convert.ToInt32(reader["DistrictID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Districtname"))
                this.DistrictName = Convert.ToString(reader["Districtname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Taluka"))
                this.Taluka = Convert.ToString(reader["Taluka"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BlockID"))
                this.BlockId = Convert.ToInt32(reader["BlockID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Blockname"))
                this.BlockName = Convert.ToString(reader["Blockname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address"))
                this.Address = Convert.ToString(reader["Address"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Pincode"))
                this.Pincode = Convert.ToString(reader["Pincode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Landline"))
                this.Landline = Convert.ToString(reader["Landline"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Incharge_name"))
                this.Incharge_name = Convert.ToString(reader["Incharge_name"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Incharge_contactno"))
                this.Incharge_contactno = Convert.ToString(reader["Incharge_contactno"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Incharge_EmailId"))
                this.Incharge_EmailId = Convert.ToString(reader["Incharge_EmailId"]);

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
