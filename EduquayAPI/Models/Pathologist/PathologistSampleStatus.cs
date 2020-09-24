using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.Pathologist
{
    public class PathologistSampleStatus : IFill
    {
        public int id { get; set; }
        public string statusName { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "StatusName"))
                this.statusName = Convert.ToString(reader["StatusName"]);
        }
    }
}