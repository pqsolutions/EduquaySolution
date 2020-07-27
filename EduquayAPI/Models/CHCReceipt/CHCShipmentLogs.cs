using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.CHCReceipt
{
    public class CHCShipmentLogs : IFill
    {
        public int id { get; set; }
        public string shipmentId { get; set; }
        public string labTechnicianName { get; set; }
        public string testingCHC { get; set; }
        public string receivingCentralLab { get; set; }
        public string logisticsProviderName { get; set; }
        public string deliveryExecutiveName { get; set; }
        public string contactNo { get; set; }
        public string shipmentDateTime { get; set; }

        public List<CHCShipmentLogsDetail> SamplesDetail { get; set; }


        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentID"))
                this.shipmentId = Convert.ToString(reader["ShipmentID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ReceivingCentralLab"))
                this.receivingCentralLab = Convert.ToString(reader["ReceivingCentralLab"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LabTechnicianName"))
                this.labTechnicianName = Convert.ToString(reader["LabTechnicianName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestingCHC"))
                this.testingCHC = Convert.ToString(reader["TestingCHC"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LogisticsProviderName"))
                this.logisticsProviderName = Convert.ToString(reader["LogisticsProviderName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DeliveryExecutiveName"))
                this.deliveryExecutiveName = Convert.ToString(reader["DeliveryExecutiveName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ContactNo"))
                this.contactNo = Convert.ToString(reader["ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentDateTime"))
                this.shipmentDateTime = Convert.ToString(reader["ShipmentDateTime"]);
        }
    }
}
