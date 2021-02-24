using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.Haematologist
{
    public class CVSSampleRefIdDetail : IFill
    {
        public string cvsSampleRefId { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CVSSampleRefId"))
                this.cvsSampleRefId = Convert.ToString(reader["CVSSampleRefId"]);
        }
    }
}
