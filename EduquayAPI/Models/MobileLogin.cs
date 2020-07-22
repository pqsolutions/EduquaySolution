using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class MobileLogin : IFill
    {
        public bool allow { get; set; }
        public string msg { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Allow"))
                this.allow = Convert.ToBoolean(reader["Allow"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Msg"))
                this.msg = Convert.ToString(reader["Msg"]);
        }
    }
}

