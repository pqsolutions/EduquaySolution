using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.LoadMasters
{
    public class LoadFollowUps : IFill
    {
        public int id { get; set; }
        public string statusName { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Id"))
                this.id = Convert.ToInt32(reader["Id"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Name"))
                this.statusName = Convert.ToString(reader["Name"]);
           
        }
    }
}
