using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.ANMShipment
{
    public class ANMShipmentLog : IFill
    {
        public string shipmentId { get; set; }
        public string anmName { get; set; }
        public string testingCHC { get; set; }
        public string avdName { get; set; }
        public string ilrPoint { get; set; }
        public string shipmentDate { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentID"))
                this.shipmentId = Convert.ToString(reader["ShipmentID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMName"))
                this.anmName = Convert.ToString(reader["ANMName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestingCHC"))
                this.testingCHC = Convert.ToString(reader["TestingCHC"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AVDName"))
                this.avdName = Convert.ToString(reader["AVDName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ILRPoint"))
                this.ilrPoint = Convert.ToString(reader["ILRPoint"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentDate"))
                this.shipmentDate = Convert.ToString(reader["ShipmentDate"]);
        }
    }
}
