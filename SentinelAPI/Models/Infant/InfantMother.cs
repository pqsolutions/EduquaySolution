using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Infant
{
    public class InfantMother : IFill
    {

        public int motherId { get; set; }
        public string motherSubjectId { get; set; }
        public string rchId { get; set; }
        public string MothersName { get; set; }
        public int districtId { get; set; }
        public int hospitalId { get; set; }
      
        public List<MotherInfant> InfantDetail { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherId"))
                this.motherId = Convert.ToInt32(reader["MotherId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DistrictID"))
                this.districtId = Convert.ToInt32(reader["DistrictID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HospitalID"))
                this.hospitalId = Convert.ToInt32(reader["HospitalID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherSubjectId"))
                this.motherSubjectId = Convert.ToString(reader["MotherSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MothersName"))
                this.MothersName = Convert.ToString(reader["MothersName"]);
        }
    }
}
