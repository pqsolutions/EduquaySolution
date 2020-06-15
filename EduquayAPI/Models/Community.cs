using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace EduquayAPI.Models
{
    public class Community :IFill
    {
        public int id { get; set; }
        public int casteId { get; set; }
        public string casteName { get; set; }
        public string communityName { get; set; }
        public string isActive { get; set; }
        public string comments { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CasteID"))
                this.casteId = Convert.ToInt32(reader["CasteID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Castename"))
                this.casteName = Convert.ToString(reader["Castename"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Communityname"))
                this.communityName = Convert.ToString(reader["Communityname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "IsActive"))
                this.isActive = Convert.ToString(reader["IsActive"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Comments"))
                this.comments = Convert.ToString(reader["Comments"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CreatedBy"))
                this.createdBy = Convert.ToInt32(reader["CreatedBy"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UpdatedBy"))
                this.updatedBy = Convert.ToInt32(reader["UpdatedBy"]);
        }
    }
}
