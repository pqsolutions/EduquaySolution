using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class SubjectPregnancyDetail : IFill
    {
        public int ID { get; set; }
        public int SubjectID { get; set; }
        public string UniqueSubjectID { get; set; }
        public string RCHID { get; set; }
        public string ECNumber { get; set; }
        public string LMP_Date { get; set; }
        public decimal Gestational_period { get; set; }
        public int G { get; set; }
        public int P { get; set; }
        public int L { get; set; }
        public int A { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.ID = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectID"))
                this.SubjectID = Convert.ToInt32(reader["SubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.UniqueSubjectID = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.RCHID = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ECNumber"))
                this.ECNumber = Convert.ToString(reader["ECNumber"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LMP_Date"))
                this.LMP_Date = Convert.ToString(reader["LMP_Date"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gestational_period"))
                this.Gestational_period = Convert.ToDecimal(reader["Gestational_period"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "G"))
                this.G = Convert.ToInt32(reader["G"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "P"))
                this.P = Convert.ToInt32(reader["P"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "L"))
                this.L = Convert.ToInt32(reader["L"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "A"))
                this.A = Convert.ToInt32(reader["A"]);

        }

    }
}
