using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.Pathologist
{
    public class HPLCResult : IFill
    {
        public int id { get; set; }
        public string hplcResultName { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HPLCResultName"))
                this.hplcResultName = Convert.ToString(reader["HPLCResultName"]);
        }
    }
}
