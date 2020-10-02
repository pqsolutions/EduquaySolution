using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Mother
{
    public class MothersBabyDetail : IFill
    {
        public string motherSubjectId { get; set; }
        public string babySubjectId { get; set; }
        public string babyName { get; set; }
        public string gender { get; set; }
        public string deliveryDateTime { get; set; }
        public bool allowCollect { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AllowCollect"))
                this.allowCollect = Convert.ToBoolean(reader["AllowCollect"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherSubjectId"))
                this.motherSubjectId = Convert.ToString(reader["MotherSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabySubjectId"))
                this.babySubjectId = Convert.ToString(reader["BabySubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabyName"))
                this.babyName = Convert.ToString(reader["BabyName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gender"))
                this.gender = Convert.ToString(reader["Gender"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DeliveryDatetime"))
                this.deliveryDateTime = Convert.ToString(reader["DeliveryDatetime"]);
        }
    }
}
