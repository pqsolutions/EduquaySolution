using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MolecularLab
{
    public class MolPNDTReceiptsLog:IFill
    {
        public int id { get; set; }
        public string shipmentId { get; set; }
        public string shipmentDateTime { get; set; }
        public string senderName { get; set; }
        public string senderContact { get; set; }
        public string senderLocation { get; set; }
        public string receivingMolecularLab { get; set; }
        public string pndtLocation { get; set; }
        public List<MolPNDTReceiptDetail> ReceiptDetail { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentID"))
                this.shipmentId = Convert.ToString(reader["ShipmentID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentDateTime"))
                this.shipmentDateTime = Convert.ToString(reader["ShipmentDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SenderName"))
                this.senderName = Convert.ToString(reader["SenderName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SenderContact"))
                this.senderContact = Convert.ToString(reader["SenderContact"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SenderLocation"))
                this.senderLocation = Convert.ToString(reader["SenderLocation"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ReceivingMolecularLab"))
                this.receivingMolecularLab = Convert.ToString(reader["ReceivingMolecularLab"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTLocation"))
                this.pndtLocation = Convert.ToString(reader["PNDTLocation"]);
        }
    }
}
