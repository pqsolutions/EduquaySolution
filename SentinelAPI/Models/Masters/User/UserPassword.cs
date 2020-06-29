using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Masters.User
{
    public class UserPassword : IFill
    {
        public string Password { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Password"))
                this.Password = Convert.ToString(reader["Password"]);
        }
    }
}
