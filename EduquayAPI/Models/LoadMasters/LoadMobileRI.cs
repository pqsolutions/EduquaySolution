using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.LoadMasters
{
    public class LoadMobileRI : IFill
    {
        public int id { get; set; }
        public string riSite { get; set; }
        public string riGovCode { get; set; }
        public int ilrId { get; set; }
        public string ilrPoint { get; set; }
        public int testingCHCId { get; set; }
        public string testingCHCName { get; set; }
        public int avdId { get; set; }
        public string avdName { get; set; }
        public string avdContactNo { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RIsite"))
                this.riSite = Convert.ToString(reader["RIsite"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RI_gov_code"))
                this.riGovCode = Convert.ToString(reader["RI_gov_code"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ILRID"))
                this.ilrId = Convert.ToInt32(reader["ILRID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestingCHCID"))
                this.testingCHCId = Convert.ToInt32(reader["TestingCHCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AVDID"))
                this.avdId = Convert.ToInt32(reader["AVDID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ILRPoint"))
                this.ilrPoint = Convert.ToString(reader["ILRPoint"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestingCHCName"))
                this.testingCHCName = Convert.ToString(reader["TestingCHCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AVDName"))
                this.avdName = Convert.ToString(reader["AVDName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AVDContactNo"))
                this.avdContactNo = Convert.ToString(reader["AVDContactNo"]);

        }
    }
}


