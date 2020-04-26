using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace EduquayAPI.Models
{
    public class TestType : IFill
    {
        public int Id { get; set; }
        public string TestTypeName { get; set; }
        public string Isactive { get; set; }
        public string Comments { get; set; }
        public int Createdby { get; set; }
        public int Updatedby { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.Id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestType"))
                this.TestTypeName = Convert.ToString(reader["TestType"]);

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
