using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class SubjectPregnancy: IFill
    {
        public string uniqueSubjectId { get; set; }
        public string rchId { get; set; }
        public string ecNumber { get; set; }
        public string lmpDate { get; set; }
        public int g { get; set; }
        public int p { get; set; }
        public int l { get; set; }
        public int a { get; set; }
        public int updatedBy { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "APD_UniqueSubjectId"))
                this.uniqueSubjectId = Convert.ToString(reader["APD_UniqueSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ECNumber"))
                this.ecNumber = Convert.ToString(reader["ECNumber"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LMPDate"))
                this.lmpDate = Convert.ToString(reader["LMPDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "G"))
                this.g = Convert.ToInt32(reader["G"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "P"))
                this.p = Convert.ToInt32(reader["P"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "L"))
                this.l = Convert.ToInt32(reader["L"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "A"))
                this.a = Convert.ToInt32(reader["A"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PR_UpdatedBy"))
                this.updatedBy = Convert.ToInt32(reader["PR_UpdatedBy"]);

        }
    }
}
