using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.ANMShipment
{
    public class ANMShipments : IFill
    {
        public int id { get; set; }
        public int subjectId { get; set; }
        public string uniqueSubjectId { get; set; }
        public string subjectName { get; set; }
        public int sampleCollectionId { get; set; }
        public string barcodeNo { get; set; }
        public string shipmentFrom { get; set; }
        public string shipmentId { get; set; }
        public int anmId { get; set; }
        public string anmName { get; set; }
        public int testingCHCId { get; set; }
        public string testingCHC { get; set; }
        public int ilrId { get; set; }
        public string ilrPoint { get; set; }
        public int avdId { get; set; }
        public string avdName { get; set; }
        public string contactNo { get; set; }
        public string shipmentDate { get; set; }
        public string shipmentTime { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectID"))
                this.subjectId = Convert.ToInt32(reader["SubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionID"))
                this.sampleCollectionId = Convert.ToInt32(reader["SampleCollectionID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Barcode"))
                this.barcodeNo = Convert.ToString(reader["Barcode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentFrom"))
                this.shipmentFrom = Convert.ToString(reader["ShipmentFrom"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentID"))
                this.shipmentId = Convert.ToString(reader["ShipmentID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANM_ID"))
                this.anmId = Convert.ToInt32(reader["ANM_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMName"))
                this.anmName = Convert.ToString(reader["ANMName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestingCHCID"))
                this.testingCHCId = Convert.ToInt32(reader["TestingCHCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestingCHC"))
                this.testingCHC = Convert.ToString(reader["TestingCHC"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ILR_ID"))
                this.ilrId = Convert.ToInt32(reader["ILR_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ILRPoint"))
                this.ilrPoint = Convert.ToString(reader["ILRPoint"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AVDID"))
                this.avdId = Convert.ToInt32(reader["AVDID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AVDName"))
                this.avdName = Convert.ToString(reader["AVDName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ContactNo"))
                this.contactNo = Convert.ToString(reader["ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentDate"))
                this.shipmentDate = Convert.ToString(reader["ShipmentDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentTime"))
                this.shipmentTime = Convert.ToString(reader["ShipmentTime"]);
        }
    }
}
