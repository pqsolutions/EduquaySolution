using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MobileShipment : IFill
    {
        public string shipmentId { get; set; }
        public int anmId { get; set; }
        public string anmName { get; set; }
        public int testingCHCId { get; set; }
        public string testingCHC { get; set; }
        public int avdId { get; set; }
        public string avdName { get; set; }
        public string avdContactNo { get; set; }
        public string alternateAVD { get; set; }
        public string alternateAVDContactNo { get; set; }
        public int ilrId { get; set; }
        public string ilrPoint { get; set; }
        public int riId { get; set; }
        public string riPoint { get; set; }
        public string dateOfShipment { get; set; }
        public string timeOfShipment { get; set; }
        public int createdBy { get; set; }
        public string source { get; set; }


        public List<MobileShipmentSample> SamplesDetail { get; set; }


        public void Fill(SqlDataReader reader)
        {

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GenratedShipmentID"))
                this.shipmentId = Convert.ToString(reader["GenratedShipmentID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANM_ID"))
                this.anmId = Convert.ToInt32(reader["ANM_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMName"))
                this.anmName = Convert.ToString(reader["ANMName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestingCHCID"))
                this.testingCHCId = Convert.ToInt32(reader["TestingCHCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ReceivingTestingCHC"))
                this.testingCHC = Convert.ToString(reader["ReceivingTestingCHC"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AVDID"))
                this.avdId = Convert.ToInt32(reader["AVDID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AVDName"))
                this.avdName = Convert.ToString(reader["AVDName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AVDContactNo"))
                this.avdContactNo = Convert.ToString(reader["AVDContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AlternateAVD"))
                this.alternateAVD = Convert.ToString(reader["AlternateAVD"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AlternateAVDContactNo"))
                this.alternateAVDContactNo = Convert.ToString(reader["AlternateAVDContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ILR_ID"))
                this.ilrId = Convert.ToInt32(reader["ILR_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ILRPoint"))
                this.ilrPoint = Convert.ToString(reader["ILRPoint"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RIID"))
                this.riId = Convert.ToInt32(reader["RIID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RIPoint"))
                this.riPoint = Convert.ToString(reader["RIPoint"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentDate"))
                this.dateOfShipment = Convert.ToString(reader["ShipmentDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentTime"))
                this.timeOfShipment = Convert.ToString(reader["ShipmentTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CreatedBy"))
                this.createdBy = Convert.ToInt32(reader["CreatedBy"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Sources"))
                this.source = Convert.ToString(reader["Sources"]);
        }
    }
}
