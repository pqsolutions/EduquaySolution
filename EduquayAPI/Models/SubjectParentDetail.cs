using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EduquayAPI.Models
{
    public class SubjectParentDetail : IFill
    {
        public int id { get; set; }
        public int subjectId { get; set; }
        public string uniqueSubjectId { get; set; }
        public string motherFirstName { get; set; }
        public string motherMiddleName { get; set; }
        public string motherLastName { get; set; }
        public string motherContactNo { get; set; }
        public string fatherFirstName { get; set; }
        public string fatherMiddleName { get; set; }
        public string fatherLastName { get; set; }
        public string fatherContactNo { get; set; }
        public string gaurdianFirstName { get; set; }
        public string gaurdianMiddleName { get; set; }
        public string gaurdianLastName { get; set; }
        public string gaurdianContactNo { get; set; }
        public string rbskId { get; set; }
        public string schoolName { get; set; }
        public string schoolAddress1 { get; set; }
        public string schoolAddress2 { get; set; }
        public string schoolAddress3 { get; set; }
        public string schoolPincode { get; set; }
        public string schoolCity { get; set; }
        public int schoolState { get; set; }
        public string stateName { get; set; }
        public string standard { get; set; }
        public string section { get; set; }
        public string rollNo { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectID"))
                this.subjectId = Convert.ToInt32(reader["SubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Mother_FirstName"))
                this.motherFirstName = Convert.ToString(reader["Mother_FirstName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Mother_MiddleName"))
                this.motherMiddleName = Convert.ToString(reader["Mother_MiddleName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Mother_LastName"))
                this.motherLastName = Convert.ToString(reader["Mother_LastName"]);
        
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Mother_ContactNo"))
                this.motherContactNo = Convert.ToString(reader["Mother_ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Father_FirstName"))
                this.fatherFirstName = Convert.ToString(reader["Father_FirstName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Father_MiddleName"))
                this.fatherMiddleName = Convert.ToString(reader["Father_MiddleName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Father_LastName"))
                this.fatherLastName = Convert.ToString(reader["Father_LastName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Father_ContactNo"))
                this.fatherContactNo = Convert.ToString(reader["Father_ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gaurdian_FirstName"))
                this.gaurdianFirstName = Convert.ToString(reader["Gaurdian_FirstName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gaurdian_MiddleName"))
                this.gaurdianMiddleName = Convert.ToString(reader["Gaurdian_MiddleName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gaurdian_LastName"))
                this.gaurdianLastName = Convert.ToString(reader["Gaurdian_LastName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gaurdian_ContactNo"))
                this.gaurdianContactNo = Convert.ToString(reader["Gaurdian_ContactNo"]);


            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RBSKId"))
                this.rbskId = Convert.ToString(reader["RBSKId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SchoolName"))
                this.schoolName = Convert.ToString(reader["SchoolName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SchoolAddress1"))
                this.schoolAddress1 = Convert.ToString(reader["SchoolAddress1"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SchoolAddress2"))
                this.schoolAddress2 = Convert.ToString(reader["SchoolAddress2"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SchoolAddress3"))
                this.schoolAddress3 = Convert.ToString(reader["SchoolAddress3"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SchoolCity"))
                this.schoolCity = Convert.ToString(reader["SchoolCity"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SchoolState"))
                this.schoolState = Convert.ToInt32(reader["SchoolState"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Statename"))
                this.stateName = Convert.ToString(reader["Statename"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SchoolPincode"))
                this.schoolPincode = Convert.ToString(reader["SchoolPincode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Standard"))
                this.standard = Convert.ToString(reader["Standard"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Section"))
                this.section = Convert.ToString(reader["Section"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RollNo"))
                this.rollNo  = Convert.ToString(reader["RollNo"]);
        }


    }
}
