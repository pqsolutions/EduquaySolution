using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.LoadMasters
{
    public class LoadConstantValues : IFill
    {
        public int registeredFrom { get; set; }
        public string shipmentFrom { get; set; }
        public int sampleCollectionFrom { get; set; }

        public void Fill(SqlDataReader reader)
        {

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RegisteredFrom"))
                this.registeredFrom = Convert.ToInt32(reader["RegisteredFrom"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentFrom"))
                this.shipmentFrom = Convert.ToString(reader["ShipmentFrom"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionFrom"))
                this.sampleCollectionFrom = Convert.ToInt32(reader["SampleCollectionFrom"]);
        }
    }
}