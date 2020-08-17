using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MolecularLab
{
    public class MolecularLabReceiptDetail : IFill
    {

        public int shipmentId { get; set; }
        public string subjectName { get; set; }
        public string subjectId { get; set; }
        public string rchId { get; set; }
        public string barcodeNo { get; set; }
        public string sampleCollectionDateTime { get; set; }
        public string hplcTestDateTime { get; set; }

        public void Fill(SqlDataReader reader)
        {

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.shipmentId = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.subjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.barcodeNo = Convert.ToString(reader["BarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionDateTime"))
                this.sampleCollectionDateTime = Convert.ToString(reader["SampleCollectionDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HPLCTestDateTime"))
                this.hplcTestDateTime = Convert.ToString(reader["HPLCTestDateTime"]);
        }
    }
}
