using EduquayAPI.Contracts.V1.Request.Obstetrician;
using EduquayAPI.Models.MTPObstetrician;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.MTPObstetrician
{
    public class MTPObstetricianData: IMTPObstetricianData
    {
        private const string FetchSubjectsMTPPending = "SPC_FetchSubjectsMTPPending";
        private const string AddMTPTest = "SPC_AddMTPTest";
        private const string FetchSubjectsMTPCompleted = "SPC_FetchSubjectsMTPCompleted";
        private const string FetchSubjectsMTPSummary = "SPC_FetchSubjectsMTPSummary";

        public MTPObstetricianData()
        {
           
        }

        public MTPMsg AddMTPService(AddMTPTestRequest aData)
        {
            string stProc = AddMTPTest;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@PostPNDTCounsellingId", aData.postPNDTCounsellingId),
                new SqlParameter("@ANWSubjectId", aData.anwsubjectId ?? aData.anwsubjectId),
                new SqlParameter("@SpouseSubjectId", aData.spouseSubjectId ?? aData.spouseSubjectId),
                new SqlParameter("@CounsellorId", aData.counsellorId),
                new SqlParameter("@ObstetricianId", aData.obstetricianId),
                new SqlParameter("@ClinicalHistory", aData.clinicalHistory ?? aData.clinicalHistory),
                new SqlParameter("@Examination", aData.examination ?? aData.examination),
                new SqlParameter("@ProcedureOfTesting", aData.procedureOfTesting),
                new SqlParameter("@MTPComplecationsId", aData.mtpComplecationsId ?? aData.mtpComplecationsId),
                new SqlParameter("@DischargeConditionId", aData.dischargeConditionId),
                new SqlParameter("@CreatedBy", aData.userId),
            };
            var mtpData = UtilityDL.FillEntity<MTPMsg>(stProc, pList);
            return mtpData;
        }

        public List<MTPCompleted> GetMTPCompleted(ObstetricianRequest oData)
        {
            string stProc = FetchSubjectsMTPCompleted;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@DistrictId", oData.districtId),
                new SqlParameter("@CHCId", oData.chcId),
                new SqlParameter("@PHCId", oData.phcId),
                new SqlParameter("@ANMId", oData.anmId)
            };
            var completedData = UtilityDL.FillData<MTPCompleted>(stProc, pList);
            return completedData;
        }

        public List<MTPPending> GetMTPPending(ObstetricianRequest oData)
        {
            string stProc = FetchSubjectsMTPPending;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@DistrictId", oData.districtId),
                new SqlParameter("@CHCId", oData.chcId),
                new SqlParameter("@PHCId", oData.phcId),
                new SqlParameter("@ANMId", oData.anmId)
            };
            var pendingData = UtilityDL.FillData<MTPPending>(stProc, pList);
            return pendingData;
        }

        public List<MTPSummary> GetMTPSummary()
        {
            string stProc = FetchSubjectsMTPSummary;
            var pList = new List<SqlParameter>();
            var summaryData = UtilityDL.FillData<MTPSummary>(stProc, pList);
            return summaryData;
        }
    }
}
