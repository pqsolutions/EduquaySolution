using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class UserRole: IFill
    {
        public int id { get; set; }
        public int userTypeId { get; set; }
        public string userTypeName { get; set; }
        public string userRoleName { get; set; }
        public string isActive { get; set; }
        public string comments { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UserTypeId"))
                this.userTypeId = Convert.ToInt32(reader["UserTypeId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Usertype"))
                this.userTypeName = Convert.ToString(reader["USertype"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Userrolename"))
                this.userRoleName = Convert.ToString(reader["Userrolename"]);

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
