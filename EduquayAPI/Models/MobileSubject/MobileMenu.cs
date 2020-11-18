using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MobileMenu : IFill
    {
        public string name { get; set; }
        public string link { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MenuName"))
                this.name = Convert.ToString(reader["MenuName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MenuLink"))
                this.link = Convert.ToString(reader["MenuLink"]);
        }
    }
}
