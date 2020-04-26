using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace EduquayAPI.Models
{
    public class Community :IFill
    {
        public int Id { get; set; }
        public int CasteID { get; set; }
        public string Castename { get; set; }
        public string Communityname { get; set; }
        public string IsActive { get; set; }
        public string Comments { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.Id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CasteID"))
                this.CasteID = Convert.ToInt32(reader["CasteID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Castename"))
                this.Castename = Convert.ToString(reader["Castename"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Communityname"))
                this.Communityname = Convert.ToString(reader["Communityname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "IsActive"))
                this.IsActive = Convert.ToString(reader["IsActive"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Comments"))
                this.Comments = Convert.ToString(reader["Comments"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CreatedBy"))
                this.CreatedBy = Convert.ToInt32(reader["CreatedBy"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UpdatedBy"))
                this.UpdatedBy = Convert.ToInt32(reader["UpdatedBy"]);
        }
    }
}
