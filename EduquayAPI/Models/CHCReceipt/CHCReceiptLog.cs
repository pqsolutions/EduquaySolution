using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.CHCReceipt
{
    public class CHCReceiptLog : IFill
    {
        public int id { get; set; }
        public string shipmentId { get; set; }
        public string senderName { get; set; }
        public string sendingLocation { get; set; }
        public string shipmentDateTime { get; set; }
        public string riPoint { get; set; }
        public string ilrPoint { get; set; }
        public int shipmentFromId { get; set; }
        public string shipmentFrom { get; set; }
        public string collectionCHC { get; set; }
        public string testingCHC { get; set; }

        public List<CHCReceiptDetail> ReceiptDetail { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentID"))
                this.shipmentId = Convert.ToString(reader["ShipmentID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentFrom"))
                this.shipmentFromId = Convert.ToInt32(reader["ShipmentFrom"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShippedFrom"))
                this.shipmentFrom = Convert.ToString(reader["ShippedFrom"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SenderName"))
                this.senderName = Convert.ToString(reader["SenderName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SendingLocation"))
                this.sendingLocation = Convert.ToString(reader["SendingLocation"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentDateTime"))
                this.shipmentDateTime = Convert.ToString(reader["ShipmentDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RIPoint"))
                this.riPoint = Convert.ToString(reader["RIPoint"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ILRPoint"))
                this.ilrPoint = Convert.ToString(reader["ILRPoint"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CollectionCHC"))
                this.collectionCHC = Convert.ToString(reader["CollectionCHC"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ReceivingTestingCHC"))
                this.testingCHC = Convert.ToString(reader["ReceivingTestingCHC"]);
        }
    }
}
