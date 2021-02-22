using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.Hematologist
{
    public class CompletedFoetusMolTestDetail : IFill
    {
        public int pndTestId { get; set; }
        public int pndtFoetusId { get; set; }
        public string foetusName { get; set; }
        public string sampleRefId { get; set; }
        public string cvsSampleRefId { get; set; }
        public string molResult { get; set; }
        public string molucularResultUpdatedBy { get; set; }
        public string molecularResultUpdatedOn { get; set; }
        public int pregnancyType { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTTestID"))
                this.pndTestId = Convert.ToInt32(reader["PNDTTestID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDFoetusId"))
                this.pndtFoetusId = Convert.ToInt32(reader["PNDFoetusId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FoetusName"))
                this.foetusName = Convert.ToString(reader["FoetusName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleRefId"))
                this.sampleRefId = Convert.ToString(reader["SampleRefId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CVSSampleRefId"))
                this.cvsSampleRefId = Convert.ToString(reader["CVSSampleRefId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MolResult"))
                this.molResult = Convert.ToString(reader["MolResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MolucularResultUpdatedBy"))
                this.molucularResultUpdatedBy = Convert.ToString(reader["MolucularResultUpdatedBy"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MolecularResultUpdatedOn"))
                this.molecularResultUpdatedOn = Convert.ToString(reader["MolecularResultUpdatedOn"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PregnancyType"))
                this.pregnancyType = Convert.ToInt32(reader["PregnancyType"]);
        }
    }
}
