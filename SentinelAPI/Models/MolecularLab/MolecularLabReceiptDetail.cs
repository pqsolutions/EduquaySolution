using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.MolecularLab
{
    public class MolecularLabReceiptDetail : IFill
    {

        public int shipmentId { get; set; }
        public string babyName { get; set; }
        public string babySubjectId { get; set; }
        public string motherName { get; set; }
        public string rchId { get; set; }
        public string barcodeNo { get; set; }
        public string sampleCollectionDateTime { get; set; }

        public void Fill(SqlDataReader reader)
        {

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.shipmentId = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabyName"))
                this.babyName = Convert.ToString(reader["BabyName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabySubjectId"))
                this.babySubjectId = Convert.ToString(reader["BabySubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherName"))
                this.motherName = Convert.ToString(reader["MotherName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.barcodeNo = Convert.ToString(reader["BarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionDateTime"))
                this.sampleCollectionDateTime = Convert.ToString(reader["SampleCollectionDateTime"]);
        }
    }
}
