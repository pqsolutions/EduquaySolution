using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.SampleCollection
{
    public class SampleCollectionList : IFill
    {
        public int mothersId { get; set; }
        public string motherName { get; set; }
        public string motherSubjectId { get; set; }
        public string infantSubjectId { get; set; }
        public string infantName { get; set; }
        public string deliveryDateTime { get; set; }
        public string motherRCHID { get; set; }
        public string contactNo { get; set; }
        public string infantRegisterDate { get; set; }
        public string sampleType { get; set; }
        public string reason { get; set; }


        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MID"))
                this.mothersId = Convert.ToInt32(reader["MID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherName"))
                this.motherName = Convert.ToString(reader["MotherName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherSubjectId"))
                this.motherSubjectId = Convert.ToString(reader["MotherSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectId"))
                this.infantSubjectId = Convert.ToString(reader["UniqueSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "InfantName"))
                this.infantName = Convert.ToString(reader["InfantName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DeliveryDatetime"))
                this.deliveryDateTime = Convert.ToString(reader["DeliveryDatetime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.motherRCHID = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ContactNo"))
                this.contactNo = Convert.ToString(reader["ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RegistrationDate"))
                this.infantRegisterDate = Convert.ToString(reader["RegistrationDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleType"))
                this.sampleType = Convert.ToString(reader["SampleType"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Reason"))
                this.reason = Convert.ToString(reader["Reason"]);
        }
    }
}
