using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Shipment
{
    public class ShipmentLogs : IFill
    {
        public int id { get; set; }
        public string generatedShipmentId { get; set; }
        public string sentinelHospitalName { get; set; }
        public string receivingMolecularLab { get; set; }
        public string logisticsProvider { get; set; }
        public string contactNo { get; set; }
        public string shipmentDateTime { get; set; }
        public List<ShipmentDetail> samplesDetail { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GeneratedShipmentID"))
                this.generatedShipmentId = Convert.ToString(reader["GeneratedShipmentID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentDateTime"))
                this.shipmentDateTime = Convert.ToString(reader["ShipmentDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SentinalHospitalName"))
                this.sentinelHospitalName = Convert.ToString(reader["SentinalHospitalName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ReceivingMolecularLab"))
                this.receivingMolecularLab = Convert.ToString(reader["ReceivingMolecularLab"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LogisticsProvider"))
                this.logisticsProvider = Convert.ToString(reader["LogisticsProvider"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ContactNo"))
                this.contactNo = Convert.ToString(reader["ContactNo"]);
        }
    }
}
