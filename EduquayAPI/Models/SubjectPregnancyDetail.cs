using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class SubjectPregnancyDetail : IFill
    {
        public int subjectId { get; set; }
        public string uniqueSubjectId { get; set; }
        public string rchId { get; set; }
        public string ecNumber { get; set; }
        public string lmpDate { get; set; }
        public decimal gestationalperiod { get; set; }
        public int g { get; set; }
        public int p { get; set; }
        public int l { get; set; }
        public int a { get; set; }
        public string barcodes { get; set; }

        public void Fill(SqlDataReader reader)
        {

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SPDSubjectId"))
                this.subjectId = Convert.ToInt32(reader["SPDSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ECNumber"))
                this.ecNumber = Convert.ToString(reader["ECNumber"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LMP_Date"))
                this.lmpDate = Convert.ToString(reader["LMP_Date"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gestational_period"))
                this.gestationalperiod = Convert.ToDecimal(reader["Gestational_period"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "G"))
                this.g = Convert.ToInt32(reader["G"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "P"))
                this.p = Convert.ToInt32(reader["P"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "L"))
                this.l = Convert.ToInt32(reader["L"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "A"))
                this.a = Convert.ToInt32(reader["A"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Barcodes"))
                this.barcodes = Convert.ToString(reader["Barcodes"]);

        }

    }
}
