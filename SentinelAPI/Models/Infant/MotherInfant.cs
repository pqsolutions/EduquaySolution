using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Infant
{
    public class MotherInfant : IFill
    {
        public int mothersId { get; set; }
        public string infantSubjectId { get; set; }
        public string infantName { get; set; }
        public string gender { get; set; }
        public string deliveryDateTime { get; set; }
        public string infantRCHID { get; set; }
        public bool allowCollect { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MothersId"))
                this.mothersId = Convert.ToInt32(reader["MothersId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectId"))
                this.infantSubjectId = Convert.ToString(reader["UniqueSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "InfantName"))
                this.infantName = Convert.ToString(reader["InfantName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gender"))
                this.gender = Convert.ToString(reader["Gender"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DeliveryDatetime"))
                this.deliveryDateTime = Convert.ToString(reader["DeliveryDatetime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "InfantRCHID"))
                this.infantRCHID = Convert.ToString(reader["InfantRCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AllowCollect"))
                this.allowCollect = Convert.ToBoolean(reader["AllowCollect"]);
        }
    }
}
