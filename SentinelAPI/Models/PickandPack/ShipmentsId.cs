using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.PickandPack
{
    public class ShipmentsId : IFill
    {
        public string shipmentId { get; set; }
        public string errorMessage { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentID"))
                this.shipmentId = Convert.ToString(reader["ShipmentID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ErrorMessage"))
                this.errorMessage = Convert.ToString(reader["ErrorMessage"]);

        }
    }
}
