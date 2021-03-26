using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.MolecularLab
{
    public class MolecularSubjectsForBloodTestStatus : IFill
    {
        public string babyName { get; set; }
        public string babySubjectId { get; set; }
        public string motherName { get; set; }
        public string motherRCHID { get; set; }
        public string barcodeNo { get; set; }
        public string babyHospitalNo { get; set; }
        public string district { get; set; }
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
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestDate"))
                this.testDate = Convert.ToString(reader["TestDate"]);

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

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleDamaged"))
                this.sampleDamaged = Convert.ToBoolean(reader["SampleDamaged"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabyName"))
                this.babyName = Convert.ToString(reader["BabyName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabySubjectId"))
                this.babySubjectId = Convert.ToString(reader["BabySubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherName"))
                this.motherName = Convert.ToString(reader["MotherName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.motherRCHID = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Barcode"))
                this.barcodeNo = Convert.ToString(reader["Barcode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabyHospitalNo"))
                this.babyHospitalNo = Convert.ToString(reader["BabyHospitalNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Districtname"))
                this.district = Convert.ToString(reader["Districtname"]);
        }
    }
}
