using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EduquayAPI.Models
{
    public class Threshold :IFill
    {
        public int id { get; set; }
        public int testTypeId { get; set; }
        public string testType { get; set; }
        public string testName { get; set; }
        public decimal thresholdValue { get; set; }
        public string isActive { get; set; }
        public string comments { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestTypeID"))
                this.testTypeId = Convert.ToInt32(reader["TestTypeID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestType"))
                this.testType = Convert.ToString(reader["TestType"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestName"))
                this.testName = Convert.ToString(reader["TestName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ThresholdValue"))
                this.thresholdValue = Convert.ToDecimal(reader["ThresholdValue"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Isactive"))
                this.isActive = Convert.ToString(reader["Isactive"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Comments"))
                this.comments = Convert.ToString(reader["Comments"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Createdby"))
                this.createdBy = Convert.ToInt32(reader["Createdby"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Updatedby"))
                this.updatedBy = Convert.ToInt32(reader["Updatedby"]);
        }
    }
}

