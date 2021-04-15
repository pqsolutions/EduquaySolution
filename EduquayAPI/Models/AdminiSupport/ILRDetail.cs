using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.AdminiSupport
{
    public class ILRDetail : IFill
    {
        public int id { get; set; }
        public int districtId { get; set; }
        public string districtName { get; set; }
        public int chcId { get; set; }
        public string chcName { get; set; }
        public string ilrCode { get; set; }
        public string name { get; set; }
        public string isActive { get; set; }
        public string comments { get; set; }

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

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ILRCode"))
                this.ilrCode = Convert.ToString(reader["ILRCode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ILRPoint"))
                this.name = Convert.ToString(reader["ILRPoint"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "IsActive"))
                this.isActive = Convert.ToString(reader["IsActive"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Comments"))
                this.comments = Convert.ToString(reader["Comments"]);
        }
    }
}