using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class Device:IFill
    {
        public bool valid { get; set; }
        public string msg { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Valid"))
                this.valid = Convert.ToBoolean(reader["Valid"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Msg"))
                this.msg = Convert.ToString(reader["Msg"]);
        }
    }
}
