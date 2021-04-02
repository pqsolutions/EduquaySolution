using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.AdminiSupport
{
    public class ANMCreation : IFill
    {
        public string msg { get; set; }
        public bool success { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MSG"))
                this.msg = Convert.ToString(reader["MSG"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Success"))
                this.success = Convert.ToBoolean(reader["Success"]);
        }
    }
}
