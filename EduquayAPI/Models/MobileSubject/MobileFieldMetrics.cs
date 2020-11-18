using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MobileFieldMetrics : IFill
    {
        public int noOfRegistrations { get; set; }
        public int noOfSamplesCollected { get; set; }
        public int noOfSamplesCollectionPending { get; set; }
        public int totalShipments { get; set; }
        public int unsentSamples { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "NoOfRegistration"))
                this.noOfRegistrations = Convert.ToInt32(reader["NoOfRegistration"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollected"))
                this.noOfSamplesCollected = Convert.ToInt32(reader["SampleCollected"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PendingSampleCollection"))
                this.noOfSamplesCollectionPending = Convert.ToInt32(reader["PendingSampleCollection"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentDone"))
                this.totalShipments = Convert.ToInt32(reader["ShipmentDone"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UnsentSamples"))
                this.unsentSamples = Convert.ToInt32(reader["UnsentSamples"]);
        }
    }
}
