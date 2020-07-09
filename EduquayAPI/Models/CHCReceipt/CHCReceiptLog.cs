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

        public List<CHCReceiptDetail> ReceiptDetail { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentID"))
                this.shipmentId = Convert.ToString(reader["ShipmentID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SenderName"))
                this.senderName = Convert.ToString(reader["SenderName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SendingLocation"))
                this.sendingLocation = Convert.ToString(reader["SendingLocation"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentDateTime"))
                this.shipmentDateTime = Convert.ToString(reader["ShipmentDateTime"]);
        }
    }
}
