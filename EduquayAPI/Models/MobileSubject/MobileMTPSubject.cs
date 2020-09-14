using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MobileMTPSubject : IFill
    {
        public string uniqueSubjectId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string rchId { get; set; }
        public string mobileNo { get; set; }
        public string ga { get; set; }
        public string lmpDate { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWSubjectId"))
                this.uniqueSubjectId = Convert.ToString(reader["ANWSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWFirstName"))
                this.firstName = Convert.ToString(reader["ANWFirstName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWLastName"))
                this.lastName = Convert.ToString(reader["ANWLastName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWContactNo"))
                this.mobileNo = Convert.ToString(reader["ANWContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GestationalAge"))
                this.ga = Convert.ToString(reader["GestationalAge"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LMPDate"))
                this.lmpDate = Convert.ToString(reader["LMPDate"]);
        }
    }
}
