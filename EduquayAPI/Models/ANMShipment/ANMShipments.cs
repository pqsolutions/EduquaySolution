using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.ANMShipment
{
    public class ANMShipments : IFill
    {
        public int ID { get; set; }
        public int SubjectID { get; set; }
        public string UniqueSubjectID { get; set; }
        public string SubjectName { get; set; }
        public int SampleCollectionID { get; set; }
        public string Barcode { get; set; }
        public string ShipmentFrom { get; set; }
        public string ShipmentID { get; set; }
        public int ANM_ID { get; set; }
        public string ANMName { get; set; }
        public int TestingCHCID { get; set; }
        public string TestingCHC { get; set; }
        public int ILR_ID { get; set; }
        public string ILRPoint { get; set; }
        public int AVDID { get; set; }
        public string AVDName { get; set; }
        public string ContactNo { get; set; }
        public string ShipmentDate { get; set; }
        public string ShipmentTime { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.ID = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectID"))
                this.SubjectID = Convert.ToInt32(reader["SubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.UniqueSubjectID = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.SubjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionID"))
                this.SampleCollectionID = Convert.ToInt32(reader["SampleCollectionID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Barcode"))
                this.Barcode = Convert.ToString(reader["Barcode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentFrom"))
                this.ShipmentFrom = Convert.ToString(reader["ShipmentFrom"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentID"))
                this.ShipmentID = Convert.ToString(reader["ShipmentID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANM_ID"))
                this.ANM_ID = Convert.ToInt32(reader["ANM_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMName"))
                this.ANMName = Convert.ToString(reader["ANMName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestingCHCID"))
                this.TestingCHCID = Convert.ToInt32(reader["TestingCHCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestingCHC"))
                this.TestingCHC = Convert.ToString(reader["TestingCHC"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ILR_ID"))
                this.ILR_ID = Convert.ToInt32(reader["ILR_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ILRPoint"))
                this.ILRPoint = Convert.ToString(reader["ILRPoint"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AVDID"))
                this.AVDID = Convert.ToInt32(reader["AVDID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AVDName"))
                this.AVDName = Convert.ToString(reader["AVDName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ContactNo"))
                this.ContactNo = Convert.ToString(reader["ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentDate"))
                this.ShipmentDate = Convert.ToString(reader["ShipmentDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentTime"))
                this.ShipmentTime = Convert.ToString(reader["ShipmentTime"]);
        }
    }
}
