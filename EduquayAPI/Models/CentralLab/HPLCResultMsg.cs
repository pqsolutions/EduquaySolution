using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.CentralLab
{
    public class HPLCResultMsg : IFill
    {
        public string msg { get; set; }

       public bool isNormal { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MSG"))
                this.msg = Convert.ToString(reader["MSG"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "IsNormal"))
                this.isNormal = Convert.ToBoolean(reader["IsNormal"]);
        }
    }
}
