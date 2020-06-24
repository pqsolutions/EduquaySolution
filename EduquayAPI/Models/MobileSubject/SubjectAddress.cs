using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class SubjectAddress:IFill
    {
        public string uniqueSubjectId { get; set; }
        public int religionId { get; set; }
        public int casteId { get; set; }
        public int communityId { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string pincode { get; set; }
        public string stateName { get; set; }
        public int updatedBy { get; set; }

        public void Fill(SqlDataReader reader)
        {

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SAD_UniqueSubjectId"))
                this.uniqueSubjectId = Convert.ToString(reader["SAD_UniqueSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Religion_Id"))
                this.religionId = Convert.ToInt32(reader["Religion_Id"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Caste_Id"))
                this.casteId = Convert.ToInt32(reader["Caste_Id"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Community_Id"))
                this.communityId = Convert.ToInt32(reader["Community_Id"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address1"))
                this.address1 = Convert.ToString(reader["Address1"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address2"))
                this.address2 = Convert.ToString(reader["Address2"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address3"))
                this.address3 = Convert.ToString(reader["Address3"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Pincode"))
                this.pincode = Convert.ToString(reader["Pincode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "StateName"))
                this.stateName = Convert.ToString(reader["StateName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "A_UpdatedBy"))
                this.updatedBy = Convert.ToInt32(reader["A_UpdatedBy"]);
        }
    }
}
