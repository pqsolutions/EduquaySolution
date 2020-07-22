using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class LastIds : IFill
    {
        public string LastUniqueSubjectId { get; set; }
        public string LastShipmentId { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LastSubjectId"))
                this.LastUniqueSubjectId = Convert.ToString(reader["LastSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LastShipmentId"))
                this.LastShipmentId = Convert.ToString(reader["LastShipmentId"]);
        }
    }
}
