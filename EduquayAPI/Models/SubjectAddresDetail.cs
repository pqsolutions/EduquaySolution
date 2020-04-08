using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class SubjectAddresDetail:IFill
    {
        public int ID { get; set; }
        public int SubjectID { get; set; }       
        public string UniqueSubjectID { get; set; }
        public int Religion_Id { get; set; }
        public string Religionname { get; set; }
        public int Caste_Id { get; set; }
        public string Castename { get; set; }
        public int Community_Id { get; set; }
        public string CommunityName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Pincode { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.ID = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectID"))
                this.SubjectID = Convert.ToInt32(reader["SubjectID"]);           
           
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.UniqueSubjectID = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Religion_Id"))
                this.Religion_Id  = Convert.ToInt32(reader["Religion_Id"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Religionname"))
                this.Religionname  = Convert.ToString(reader["Religionname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Caste_Id"))
                this.Caste_Id  = Convert.ToInt32(reader["Caste_Id"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Castename"))
                this.Castename  = Convert.ToString(reader["Castename"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Community_Id"))
                this.Community_Id = Convert.ToInt32(reader["Community_Id"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CommunityName"))
                this.CommunityName = Convert.ToString(reader["CommunityName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address1"))
                this.Address1  = Convert.ToString(reader["Address1"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address2"))
                this.Address2 = Convert.ToString(reader["Address2"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address3"))
                this.Address3 = Convert.ToString(reader["Address3"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Pincode"))
                this.Pincode = Convert.ToString(reader["Pincode"]);
        }

    }
}
