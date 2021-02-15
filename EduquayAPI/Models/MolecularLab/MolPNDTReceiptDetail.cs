using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MolecularLab
{
    public class MolPNDTReceiptDetail:IFill
    {
        public int shipmentId { get; set; }
        public string anwSubjectId { get; set; }
        public string subjectName { get; set; }
        public string rchId { get; set; }
        public string specimenCollectionDate { get; set; }
        public string foetusName { get; set; }
        public string sampleRefId { get; set; }
        public string cvsSampleRefId { get; set; }
        public int pregnancyType { get; set; }
        public int pndTestId { get; set; }
        public int pndtFoetusId { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.shipmentId = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTestId"))
                this.pndTestId = Convert.ToInt32(reader["PNDTestId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTFoetusId"))
                this.pndtFoetusId = Convert.ToInt32(reader["PNDTFoetusId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PregnancyType"))
                this.pregnancyType = Convert.ToInt32(reader["PregnancyType"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWSubjectId"))
                this.anwSubjectId = Convert.ToString(reader["ANWSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpecimenCollectionDate"))
                this.specimenCollectionDate = Convert.ToString(reader["SpecimenCollectionDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FoetusName"))
                this.foetusName = Convert.ToString(reader["FoetusName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleRefId"))
                this.sampleRefId = Convert.ToString(reader["SampleRefId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CVSSampleRefId"))
                this.cvsSampleRefId = Convert.ToString(reader["CVSSampleRefId"]);
        }
    }
}
