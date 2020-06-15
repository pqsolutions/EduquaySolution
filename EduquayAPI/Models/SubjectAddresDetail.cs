using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class SubjectAddresDetail:IFill
    {
        public int id { get; set; }
        public int subjectId { get; set; }       
        public string uniqueSubjectId { get; set; }
        public int religionId { get; set; }
        public string religionName { get; set; }
        public int casteId { get; set; }
        public string casteName { get; set; }
        public int communityId { get; set; }
        public string communityName { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string pincode { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectID"))
                this.subjectId = Convert.ToInt32(reader["SubjectID"]);           
           
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Religion_Id"))
                this.religionId  = Convert.ToInt32(reader["Religion_Id"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Religionname"))
                this.religionName  = Convert.ToString(reader["Religionname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Caste_Id"))
                this.casteId  = Convert.ToInt32(reader["Caste_Id"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Castename"))
                this.casteName  = Convert.ToString(reader["Castename"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Community_Id"))
                this.communityId = Convert.ToInt32(reader["Community_Id"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CommunityName"))
                this.communityName = Convert.ToString(reader["CommunityName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address1"))
                this.address1  = Convert.ToString(reader["Address1"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address2"))
                this.address2 = Convert.ToString(reader["Address2"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address3"))
                this.address3 = Convert.ToString(reader["Address3"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Pincode"))
                this.pincode = Convert.ToString(reader["Pincode"]);
        }

    }
}
