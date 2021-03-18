using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.Support
{
    public class UpdateBarcodeMsg : IFill
    {
        public string msg { get; set; }
        public int revisedExistCheck { get; set; }
        public string barcodeUpdateCode { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MSG"))
                this.msg = Convert.ToString(reader["MSG"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RevisedExistCheck"))
                this.revisedExistCheck = Convert.ToInt16(reader["RevisedExistCheck"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeUpdateCode"))
                this.barcodeUpdateCode = Convert.ToString(reader["BarcodeUpdateCode"]);
          
        }
    }
}
