using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EduquayAPI.Models
{
    public class Threshold :IFill
    {
        public int Id { get; set; }
        public int TestTypeID { get; set; }
        public string TestType { get; set; }
        public string TestName { get; set; }
        public decimal ThresholdValue { get; set; }
        public string Isactive { get; set; }
        public string Comments { get; set; }
        public int Createdby { get; set; }
        public int Updatedby { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.Id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestTypeID"))
                this.TestTypeID = Convert.ToInt32(reader["TestTypeID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestType"))
                this.TestType = Convert.ToString(reader["TestType"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestName"))
                this.TestName = Convert.ToString(reader["TestName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ThresholdValue"))
                this.ThresholdValue = Convert.ToDecimal(reader["ThresholdValue"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Isactive"))
                this.Isactive = Convert.ToString(reader["Isactive"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Comments"))
                this.Comments = Convert.ToString(reader["Comments"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Createdby"))
                this.Createdby = Convert.ToInt32(reader["Createdby"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Updatedby"))
                this.Updatedby = Convert.ToInt32(reader["Updatedby"]);
        }
    }
}

