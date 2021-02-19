using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MolecularLab
{
    public class MLabSpecimenForTestStatus : IFill
    {
        public string subjectName { get; set; }
        public string uniqueSubjectId { get; set; }
        public string rchId { get; set; }
        public string foetusName { get; set; }
        public string sampleRefId { get; set; }
        public string cvsSampleRefId { get; set; }
        public int pndtFoetusId { get; set; }
        public bool? sampleDamaged { get; set; }
        public bool? sampleProcessed { get; set; }
        public int zygosityId { get; set; }
        public int mutation1Id { get; set; }
        public int mutation2Id { get; set; }
        public string mutation3 { get; set; }
        public string testResult { get; set; }
        public string reasonForClose { get; set; }
        public string testDate { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FoetusName"))
                this.foetusName = Convert.ToString(reader["FoetusName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleRefId"))
                this.sampleRefId = Convert.ToString(reader["SampleRefId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CVSSampleRefId"))
                this.cvsSampleRefId = Convert.ToString(reader["CVSSampleRefId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTFoetusId"))
                this.pndtFoetusId = Convert.ToInt32(reader["PNDTFoetusId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleDamaged"))
                this.sampleDamaged = Convert.ToBoolean(reader["SampleDamaged"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleProcessed"))
                this.sampleProcessed = Convert.ToBoolean(reader["SampleProcessed"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ZygosityId"))
                this.zygosityId = Convert.ToInt32(reader["ZygosityId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Mutation1Id"))
                this.mutation1Id = Convert.ToInt32(reader["Mutation1Id"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Mutation2Id"))
                this.mutation2Id = Convert.ToInt32(reader["Mutation2Id"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Mutation3"))
                this.mutation3 = Convert.ToString(reader["Mutation3"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestResult"))
                this.testResult = Convert.ToString(reader["TestResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ReasonForClose"))
                this.reasonForClose = Convert.ToString(reader["ReasonForClose"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestDate"))
                this.testDate = Convert.ToString(reader["TestDate"]);
        }
    }
}
