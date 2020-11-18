using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MobileCurrentGA : IFill
    {
        public int currentGAGTE15 { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CurrentGAGTE15"))
                this.currentGAGTE15 = Convert.ToInt32(reader["CurrentGAGTE15"]);
        }
    }
}