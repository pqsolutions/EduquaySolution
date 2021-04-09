using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.AdminiSupport
{
    public class AddUpdateMaster : IFill
    {
        public string message { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Msg"))
                this.message = Convert.ToString(reader["Msg"]);
        }
    }
}
