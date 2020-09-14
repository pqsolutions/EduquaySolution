using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MobilePNDTSpouse:IFill
    {
        public string spouseSubjectId { get; set; }
        public string uniqueSubjectId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobileNo { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWSubjectId"))
                this.spouseSubjectId = Convert.ToString(reader["ANWSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseSubjectId"))
                this.uniqueSubjectId = Convert.ToString(reader["SpouseSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseFirstName"))
                this.firstName = Convert.ToString(reader["SpouseFirstName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseLastName"))
                this.lastName = Convert.ToString(reader["SpouseLastName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseContactNo"))
                this.mobileNo = Convert.ToString(reader["SpouseContactNo"]);
        }
    }
}
