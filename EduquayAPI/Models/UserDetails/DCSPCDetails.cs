using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.UserDetails
{
    public class DCSPCDetails : IFill
    {
        public string scName { get; set; }
        public string scContactNo { get; set; }
        public string scEmail { get; set; }
        public string dcName { get; set; }
        public string dcContactNo { get; set; }
        public string dcEmail { get; set; }
        public string existDCName { get; set; }
        public string existDCContactNo { get; set; }
        public string existDCEmail { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCName"))
                this.scName = Convert.ToString(reader["SCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCContactNo"))
                this.scContactNo = Convert.ToString(reader["SCContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCEmail"))
                this.scEmail = Convert.ToString(reader["SCEmail"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DCName"))
                this.dcName = Convert.ToString(reader["DCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DCContactNo"))
                this.dcContactNo = Convert.ToString(reader["DCContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DCEmail"))
                this.dcEmail = Convert.ToString(reader["DCEmail"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ExistDCName"))
                this.existDCName = Convert.ToString(reader["ExistDCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ExistDCContactNo"))
                this.existDCContactNo = Convert.ToString(reader["ExistDCContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ExistDCEmail"))
                this.existDCEmail = Convert.ToString(reader["ExistDCEmail"]);
        }
    }
}
