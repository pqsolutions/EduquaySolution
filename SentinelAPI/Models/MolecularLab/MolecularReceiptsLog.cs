using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.MolecularLab
{
    public class MolecularReceiptsLog : IFill
    {
        public int id { get; set; }
        public string shipmentId { get; set; }
        public string labTechnicianName { get; set; }
        public string shipmentDateTime { get; set; }
        public string molecularLabName { get; set; }
        public string hospitalNameLocation { get; set; }
        public List<MolecularLabReceiptDetail> ReceiptDetail { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentID"))
                this.shipmentId = Convert.ToString(reader["ShipmentID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SenderName"))
                this.labTechnicianName = Convert.ToString(reader["SenderName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MolecularLabName"))
                this.molecularLabName = Convert.ToString(reader["MolecularLabName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HospitalNameLocation"))
                this.hospitalNameLocation = Convert.ToString(reader["HospitalNameLocation"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentDateTime"))
                this.shipmentDateTime = Convert.ToString(reader["ShipmentDateTime"]);
        }
    }
}
