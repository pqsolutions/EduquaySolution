using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.ANMCHCShipment
{
    public class ANMCHCShipmentLogs : IFill
    {
        public int id { get; set; }
        public string shipmentId { get; set; }
        public string anmName { get; set; }
        public string testingCHC { get; set; }
        public string avdName { get; set; }
        public string contactNo { get; set; }
        public string alternateAVD { get; set; }
        public string alternateAVDContactNo { get; set; }
        public string ilrPoint { get; set; }
        public string riPoint { get; set; }
        public string shipmentDateTime { get; set; }

        public List<ANMCHCShipmentLogsDetail> SamplesDetail { get; set; }


        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentID"))
                this.shipmentId = Convert.ToString(reader["ShipmentID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMName"))
                this.anmName = Convert.ToString(reader["ANMName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ReceivingTestingCHC"))
                this.testingCHC = Convert.ToString(reader["ReceivingTestingCHC"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AVDName"))
                this.avdName = Convert.ToString(reader["AVDName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ContactNo"))
                this.contactNo = Convert.ToString(reader["ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AlternateAVD"))
                this.alternateAVD = Convert.ToString(reader["AlternateAVD"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AlternateAVDContactNo"))
                this.alternateAVDContactNo = Convert.ToString(reader["AlternateAVDContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ILRPoint"))
                this.ilrPoint = Convert.ToString(reader["ILRPoint"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentDateTime"))
                this.shipmentDateTime = Convert.ToString(reader["ShipmentDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RIPoint"))
                this.riPoint = Convert.ToString(reader["RIPoint"]);
        }
    }
}
