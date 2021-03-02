using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject.MobileSampleCollection
{
    public class ErrorBarcodeId : IFill
    {
        public int getId { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GetId"))
                this.getId = Convert.ToInt32(reader["GetId"]);
        }
    }
}
