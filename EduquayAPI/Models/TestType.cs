using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace EduquayAPI.Models
{
    public class TestType : IFill
    {
        public int id { get; set; }
        public string testTypeName { get; set; }
        public string isActive { get; set; }
        public string comments { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestType"))
                this.testTypeName = Convert.ToString(reader["TestType"]);

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
