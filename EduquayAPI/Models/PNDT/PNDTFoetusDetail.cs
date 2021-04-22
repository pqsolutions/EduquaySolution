using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.PNDT
{
    public class PNDTFoetusDetail : IFill
    {
        public int pndTestId { get; set; }
        public int pndtFoetusId { get; set; }
        public string foetusName { get; set; }
        public string sampleRefId { get; set; }
        public string cvsSampleRefId { get; set; }
        public string molResult { get; set; }
        public string molucularResultUpdatedBy { get; set; }
        public string molecularResultUpdatedOn { get; set; }
        public string resultReviewedBy { get; set; }
        public string resultReviewedOn { get; set; }
        public int pregnancyType { get; set; }
        public string planforPregnancy { get; set; }


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

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ResultReviewedBy"))
                this.resultReviewedBy = Convert.ToString(reader["ResultReviewedBy"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ResultReviewedOn"))
                this.resultReviewedOn = Convert.ToString(reader["ResultReviewedOn"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PlanforPregnancy"))
                this.planforPregnancy = Convert.ToString(reader["PlanforPregnancy"]);
        }
    }
}