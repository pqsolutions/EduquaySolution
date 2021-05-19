using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MolecularLab
{
    public class MolecularLabFoetusResult : IFill
    {
        public string uniqueSubjectId { get; set; }
        public string foetusName { get; set; }
        public string sampleRefId { get; set; }
        public string cvsSampleRefId { get; set; }
        public int pndTestId { get; set; }
        public int pndtFoetusId { get; set; }
        public string specimenTestResult { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FoetusName"))
                this.foetusName = Convert.ToString(reader["FoetusName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleRefId"))
                this.sampleRefId = Convert.ToString(reader["SampleRefId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CVSSampleRefId"))
                this.cvsSampleRefId = Convert.ToString(reader["CVSSampleRefId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTestId"))
                this.pndTestId = Convert.ToInt32(reader["PNDTestId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTFoetusId"))
                this.pndtFoetusId = Convert.ToInt32(reader["PNDTFoetusId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpecimenTestResult"))
                this.specimenTestResult = Convert.ToString(reader["SpecimenTestResult"]);
        }
    }
}
