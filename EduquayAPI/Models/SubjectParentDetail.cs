using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EduquayAPI.Models
{
    public class SubjectParentDetail : IFill
    {
        public int ID { get; set; }
        public int SubjectID { get; set; }
        public string UniqueSubjectID { get; set; }
        public string Mother_FirstName { get; set; }
        public string Mother_MiddleName { get; set; }
        public string Mother_LastName { get; set; }
        public string Mother_UniquetID { get; set; }
        public string Mother_ContactNo { get; set; }
        public string Father_FirstName { get; set; }
        public string Father_MiddleName { get; set; }
        public string Father_LastName { get; set; }
        public string Father_UniquetID { get; set; }
        public string Father_ContactNo { get; set; }
        public string Gaurdian_FirstName { get; set; }
        public string Gaurdian_MiddleName { get; set; }
        public string Gaurdian_LastName { get; set; }
        public string Gaurdian_ContactNo { get; set; }
        public string RBSKId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress1 { get; set; }
        public string SchoolAddress2 { get; set; }
        public string SchoolAddress3 { get; set; }
        public string SchoolPincode { get; set; }
        public string SchoolCity { get; set; }
        public int SchoolState { get; set; }
        public string StateName { get; set; }
        public string Standard { get; set; }
        public string Section { get; set; }
        public string RollNo { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.ID = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectID"))
                this.SubjectID = Convert.ToInt32(reader["SubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.UniqueSubjectID = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Mother_FirstName"))
                this.Mother_FirstName = Convert.ToString(reader["Mother_FirstName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Mother_MiddleName"))
                this.Mother_MiddleName = Convert.ToString(reader["Mother_MiddleName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Mother_LastName"))
                this.Mother_LastName = Convert.ToString(reader["Mother_LastName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Mother_UniquetID"))
                this.Mother_UniquetID = Convert.ToString(reader["Mother_UniquetID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Mother_ContactNo"))
                this.Mother_ContactNo = Convert.ToString(reader["Mother_ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Father_FirstName"))
                this.Father_FirstName = Convert.ToString(reader["Father_FirstName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Father_MiddleName"))
                this.Father_MiddleName = Convert.ToString(reader["Father_MiddleName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Father_LastName"))
                this.Father_LastName = Convert.ToString(reader["Father_LastName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Father_UniquetID"))
                this.Father_UniquetID = Convert.ToString(reader["Father_UniquetID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Father_ContactNo"))
                this.Father_ContactNo = Convert.ToString(reader["Father_ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gaurdian_FirstName"))
                this.Gaurdian_FirstName = Convert.ToString(reader["Gaurdian_FirstName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gaurdian_MiddleName"))
                this.Gaurdian_MiddleName = Convert.ToString(reader["Gaurdian_MiddleName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gaurdian_LastName"))
                this.Gaurdian_LastName = Convert.ToString(reader["Gaurdian_LastName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gaurdian_ContactNo"))
                this.Gaurdian_ContactNo = Convert.ToString(reader["Gaurdian_ContactNo"]);


            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RBSKId"))
                this.RBSKId = Convert.ToString(reader["RBSKId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SchoolName"))
                this.SchoolName = Convert.ToString(reader["SchoolName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SchoolAddress1"))
                this.SchoolAddress1 = Convert.ToString(reader["SchoolAddress1"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SchoolAddress2"))
                this.SchoolAddress2 = Convert.ToString(reader["SchoolAddress2"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SchoolAddress3"))
                this.SchoolAddress3 = Convert.ToString(reader["SchoolAddress3"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SchoolCity"))
                this.SchoolCity = Convert.ToString(reader["SchoolCity"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SchoolState"))
                this.SchoolState = Convert.ToInt32(reader["SchoolState"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Statename"))
                this.StateName = Convert.ToString(reader["Statename"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SchoolPincode"))
                this.SchoolPincode = Convert.ToString(reader["SchoolPincode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Standard"))
                this.Standard = Convert.ToString(reader["Standard"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Section"))
                this.Section = Convert.ToString(reader["Section"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RollNo"))
                this.RollNo  = Convert.ToString(reader["RollNo"]);
        }


    }
}
