using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.ANMShipment
{
    public class ANMShipmentLog : IFill
    {
        public string ShipmentID { get; set; }
        public string ANMName { get; set; }
        public string TestingCHC { get; set; }
        public string AVDName { get; set; }
        public string ILRPoint { get; set; }
        public string ShipmentDate { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentID"))
                this.ShipmentID = Convert.ToString(reader["ShipmentID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMName"))
                this.ANMName = Convert.ToString(reader["ANMName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestingCHC"))
                this.TestingCHC = Convert.ToString(reader["TestingCHC"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AVDName"))
                this.AVDName = Convert.ToString(reader["AVDName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ILRPoint"))
                this.ILRPoint = Convert.ToString(reader["ILRPoint"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentDate"))
                this.ShipmentDate = Convert.ToString(reader["ShipmentDate"]);
        }
    }
}
