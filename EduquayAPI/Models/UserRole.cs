using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class UserRole: IFill
    {
        public int Id { get; set; }
        public int UserTypeId { get; set; }
        public string UserTypename { get; set; }
        public string Userrolename { get; set; }
        public string IsActive { get; set; }
        public string Comments { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.Id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UserTypeId"))
                this.UserTypeId = Convert.ToInt32(reader["UserTypeId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Usertype"))
                this.UserTypename = Convert.ToString(reader["USertype"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Userrolename"))
                this.Userrolename = Convert.ToString(reader["Userrolename"]);

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
