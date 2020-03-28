using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class UserPassword:IFill
    {
        public string Password { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Userpassword"))
                this.Password = Convert.ToString(reader["Userpassword"]);
        }
    }
}
