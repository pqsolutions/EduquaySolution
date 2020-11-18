using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MobileAlert : IFill
    {
        public string alertMsg { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AlertMsg"))
                this.alertMsg = Convert.ToString(reader["AlertMsg"]);
        }
    }
}
