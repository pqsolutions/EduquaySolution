using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class TestResult: IFill
    {
        public string uniqueSubjectId { get; set; }
        public string cbcTestResult { get; set; }
        public string sstResult { get; set; }
        public string hplcTestResult { get; set; }
        public bool isHplcPositive { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CBCTestResult"))
                this.cbcTestResult = Convert.ToString(reader["CBCTestResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SSTestResult"))
                this.sstResult = Convert.ToString(reader["SSTestResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HPLCTestResult"))
                this.hplcTestResult = Convert.ToString(reader["HPLCTestResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "IsHPLCPositive"))
                this.isHplcPositive = Convert.ToBoolean(reader["IsHPLCPositive"]);
        }
    }
}
