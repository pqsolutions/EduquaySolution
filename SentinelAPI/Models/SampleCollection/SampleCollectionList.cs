using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.SampleCollection
{
    public class SampleCollectionList : IFill
    {
        public string babySubjectId { get; set; }
        public string babyName { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public string hospitalNo { get; set; }
        public string babyRegisterDate { get; set; }
        public string motherName { get; set; }
        public string fatherName { get; set; }
        public string motherSubjectId { get; set; }
        public string motherRCHID { get; set; }
        public string motherContactNo { get; set; }
        public void Fill(SqlDataReader reader)
        {

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabySubjectId"))
                this.babySubjectId = Convert.ToString(reader["BabySubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabyName"))
                this.babyName = Convert.ToString(reader["BabyName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DateOfBirth"))
                this.dob = Convert.ToString(reader["DateOfBirth"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gender"))
                this.gender = Convert.ToString(reader["Gender"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HospitalNo"))
                this.hospitalNo = Convert.ToString(reader["HospitalNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RegistrationDate"))
                this.babyRegisterDate = Convert.ToString(reader["RegistrationDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherName"))
                this.motherName = Convert.ToString(reader["MotherName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FatherName"))
                this.fatherName = Convert.ToString(reader["FatherName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherSubjectId"))
                this.motherSubjectId = Convert.ToString(reader["MotherSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.motherRCHID = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherContactNo"))
                this.motherContactNo = Convert.ToString(reader["MotherContactNo"]);

           

          

          
        }
    }
}
