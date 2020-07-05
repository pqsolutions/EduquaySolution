using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class SubjectSamples : IFill
    {
        public int id { get; set; }
        public string uniqueSubjectId { get; set; }
        public string subjectName { get; set; }
        public string rchId { get; set; }
        public int subjectTypeId { get; set; }
        public string subjectType { get; set; }
        public string spouseName { get; set; }
        public string dateOfRegister { get; set; }
        public string contactNo { get; set; }
        public string gestationalAge { get; set; }
        public string sampleType { get; set; }
        public string Reason { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectTypeID"))
                this.subjectTypeId = Convert.ToInt32(reader["SubjectTypeID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectType"))
                this.subjectType = Convert.ToString(reader["SubjectType"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseName"))
                this.spouseName = Convert.ToString(reader["SpouseName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DateofRegister"))
                this.dateOfRegister = Convert.ToString(reader["DateofRegister"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ContactNo"))
                this.contactNo = Convert.ToString(reader["ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GestationalAge"))
                this.gestationalAge = Convert.ToString(reader["GestationalAge"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleType"))
                this.sampleType = Convert.ToString(reader["SampleType"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Reason"))
                this.Reason = Convert.ToString(reader["Reason"]);

        }
    }
}
