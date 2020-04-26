using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class SubjectSamples : IFill
    {

        public int ID { get; set; }
        public string UniqueSubjectID { get; set; }
        public string SubjectName { get; set; }
        public int SubjectTypeID { get; set; }
        public string SubjectType { get; set; }
        public string DateofRegister { get; set; }
        public string ContactNo { get; set; }
        public string GestationalAge { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.ID = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.UniqueSubjectID = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.SubjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectTypeID"))
                this.SubjectTypeID = Convert.ToInt32(reader["SubjectTypeID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectType"))
                this.SubjectType = Convert.ToString(reader["SubjectType"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DateofRegister"))
                this.DateofRegister = Convert.ToString(reader["DateofRegister"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ContactNo"))
                this.ContactNo = Convert.ToString(reader["ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GestationalAge"))
                this.GestationalAge = Convert.ToString(reader["GestationalAge"]);

        }
    }
}
