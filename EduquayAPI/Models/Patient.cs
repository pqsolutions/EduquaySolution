using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class Patient : IFill
    {
        public int Id { get; set; }
        public int GovtId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.Id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GID"))
                this.GovtId = Convert.ToInt32(reader["GID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FIRSTNAME"))
                this.FirstName = Convert.ToString(reader["FIRSTNAME"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LASTNAME"))
                this.LastName = Convert.ToString(reader["LASTNAME"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CITY"))
                this.Location = Convert.ToString(reader["CITY"]);


        }
    }
}
