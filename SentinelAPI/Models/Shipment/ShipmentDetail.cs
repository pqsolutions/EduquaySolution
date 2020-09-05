using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Shipment
{
    public class ShipmentDetail:IFill
    {
        public int shipmentId { get; set; }
        public string infantName { get; set; }
        public string subjectId { get; set; }
        public string barcodeNo { get; set; }
        public string motherName { get; set; }
        public string sampleCollectionDateTime { get; set; }


        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentId"))
                this.shipmentId = Convert.ToInt32(reader["ShipmentId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "InfantName"))
                this.infantName = Convert.ToString(reader["InfantName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "InfantSubjectID"))
                this.subjectId = Convert.ToString(reader["InfantSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Barcode"))
                this.barcodeNo = Convert.ToString(reader["Barcode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherName"))
                this.motherName = Convert.ToString(reader["MotherName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionDateTime"))
                this.sampleCollectionDateTime = Convert.ToString(reader["SampleCollectionDateTime"]);

        }
    }
}
