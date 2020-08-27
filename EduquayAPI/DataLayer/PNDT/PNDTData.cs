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


        public PNDTData()
        {

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
