using EduquayAPI.Contracts.V1.Request.PNDTC;
using EduquayAPI.Models.PNDT;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.PNDT
{
    public class PNDTData : IPNDTData
    {
        private const string FetchSubjectsPrePNDTScheduling = "SPC_FetchSubjectsPrePNDTScheduling";
        private const string FetchSubjectsPrePNDTScheduled = "SPC_FetchSubjectsPrePNDTScheduled";
        private const string AddPrePNDTScheduling = "SPC_AddPrePNDTScheduling";
        private const string FetchSubjectsPrePNDTCounselling = "SPC_FetchSubjectsPrePNDTCounselling";
        private const string AddPrePNDTCounselling = "SPC_AddPrePNDTCounselling";
        private const string FetchSubjectsPrePNDTCounseledYes = "SPC_FetchSubjectsPrePNDTCounseledYes";
        private const string FetchSubjectsPrePNDTCounseledNo = "SPC_FetchSubjectsPrePNDTCounseledNo";
        private const string FetchSubjectsPrePNDTCounseledPending = "SPC_FetchSubjectsPrePNDTCounseledPending";
        private const string UpdatePrePNDTCounsellingByAutomatic = "SPC_UpdatePrePNDTCounsellingByAutomatic";


        public PNDTData()
        {

        }

        public PrePNDTScheduleDateTime AddCounselling(AddPrePNDTCounsellingRequest acData)
        {
            string stProc = AddPrePNDTCounselling;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@PrePNDTSchedulingId", acData.prePNDTSchedulingId),
                new SqlParameter("@ANWSubjectId", acData.anwsubjectId ?? acData.anwsubjectId),
                new SqlParameter("@SpouseSubjectId", acData.spouseSubjectId ?? acData.spouseSubjectId),
                new SqlParameter("@CounsellingRemarks", acData.counsellingRemarks ?? acData.counsellingRemarks),
                new SqlParameter("@AssignedObstetricianId", acData.assignedObstetricianId),
                new SqlParameter("@CounsellorId", acData.counsellorId),
                new SqlParameter("@IsPNDTAgreeYes", acData.isPNDTAgreeYes),
                new SqlParameter("@IsPNDTAgreeNo", acData.isPNDTAgreeNo),
                new SqlParameter("@IsPNDTAgreePending", acData.isPNDTAgreePending),
                new SqlParameter("@SchedulePNDTDate", acData.schedulePNDTDate ?? acData.schedulePNDTDate),
                new SqlParameter("@SchedulePNDTtime", acData.schedulePNDTTime ?? acData.schedulePNDTTime),
                new SqlParameter("@CreatedBy", acData.userId),
            };
            var schedulingData = UtilityDL.FillEntity<PrePNDTScheduleDateTime>(stProc, pList);
            return schedulingData;
        }

        public CounsellingDateTime AddScheduling(AddSchedulingRequest asData)
        {
            string stProc = AddPrePNDTScheduling;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@ANWSubjectId", asData.anwsubjectId ?? asData.anwsubjectId),
                new SqlParameter("@SpouseSubjectId", asData.spouseSubjectId ?? asData.spouseSubjectId),
                new SqlParameter("@CounsellorId", asData.counsellorId),
                new SqlParameter("@CounsellingDateTime", asData.counsellingDateTime ?? asData.counsellingDateTime),
                new SqlParameter("@CreatedBy", asData.userId),
            };
            var schedulingData = UtilityDL.FillEntity<CounsellingDateTime>(stProc, pList);
            return schedulingData;
        }

        public void AutomaticPrePNDTCousellingUpdate()
        {
            try
            {
                var stProc = UpdatePrePNDTCounsellingByAutomatic;
                var pList = new List<SqlParameter>();
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PrePNDTScheduling> GetPositiveSubjectsScheduling(PNDTSchedulingRequest psData)
        {
            string stProc = FetchSubjectsPrePNDTScheduling;
            var pList = new List<SqlParameter>()
            { 
                new SqlParameter("@UserId", psData.userId),
                new SqlParameter("@DistrictId", psData.districtId),
                new SqlParameter("@CHCId", psData.chcId),
                new SqlParameter("@PHCId", psData.phcId),
                new SqlParameter("@ANMId", psData.anmId)
            };
            var schedulingData = UtilityDL.FillData<PrePNDTScheduling>(stProc, pList);
            return schedulingData;
        }

        public List<PrePNDTCounselling> GetScheduledForCounselling(PNDTSchedulingRequest psData)
        {
            string stProc = FetchSubjectsPrePNDTCounselling;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserId", psData.userId),
                new SqlParameter("@DistrictId", psData.districtId),
                new SqlParameter("@CHCId", psData.chcId),
                new SqlParameter("@PHCId", psData.phcId),
                new SqlParameter("@ANMId", psData.anmId)
            };
            var counsellingData = UtilityDL.FillData<PrePNDTCounselling>(stProc, pList);
            return counsellingData;
        }

        public List<PrePNDTCounselled> GetSubjectsCounselledNo(PNDTSchedulingRequest pcData)
        {
            string stProc = FetchSubjectsPrePNDTCounseledNo;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserId", pcData.userId),
                new SqlParameter("@DistrictId", pcData.districtId),
                new SqlParameter("@CHCId", pcData.chcId),
                new SqlParameter("@PHCId", pcData.phcId),
                new SqlParameter("@ANMId", pcData.anmId)
            };
            var counseledNoData = UtilityDL.FillData<PrePNDTCounselled>(stProc, pList);
            return counseledNoData;
        }

        public List<PrePNDTCounselled> GetSubjectsCounselledPending(PNDTSchedulingRequest pcData)
        {
            string stProc = FetchSubjectsPrePNDTCounseledPending;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserId", pcData.userId),
                new SqlParameter("@DistrictId", pcData.districtId),
                new SqlParameter("@CHCId", pcData.chcId),
                new SqlParameter("@PHCId", pcData.phcId),
                new SqlParameter("@ANMId", pcData.anmId)
            };
            var counseledPendingData = UtilityDL.FillData<PrePNDTCounselled>(stProc, pList);
            return counseledPendingData;
        }

        public List<PrePNDTCounselled> GetSubjectsCounselledYes(PNDTSchedulingRequest pcData)
        {
            string stProc = FetchSubjectsPrePNDTCounseledYes;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserId", pcData.userId),
                new SqlParameter("@DistrictId", pcData.districtId),
                new SqlParameter("@CHCId", pcData.chcId),
                new SqlParameter("@PHCId", pcData.phcId),
                new SqlParameter("@ANMId", pcData.anmId)
            };
            var counseledYesData = UtilityDL.FillData<PrePNDTCounselled>(stProc, pList);
            return counseledYesData;
        }

        public List<PrePNDTScheduled> GetSubjectsScheduled(PNDTSchedulingRequest psData)
        {
            string stProc = FetchSubjectsPrePNDTScheduled;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserId", psData.userId),
                new SqlParameter("@DistrictId", psData.districtId),
                new SqlParameter("@CHCId", psData.chcId),
                new SqlParameter("@PHCId", psData.phcId),
                new SqlParameter("@ANMId", psData.anmId)
            };
            var scheduledData = UtilityDL.FillData<PrePNDTScheduled>(stProc, pList);
            return scheduledData;
        }
    }
}
