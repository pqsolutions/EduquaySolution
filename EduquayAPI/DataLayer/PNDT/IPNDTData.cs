using EduquayAPI.Contracts.V1.Request.PNDTC;
using EduquayAPI.Models.PNDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.PNDT
{
    public interface IPNDTData
    {
        List<PrePNDTScheduling> GetPositiveSubjectsScheduling(PNDTSchedulingRequest psData);
        List<PrePNDTScheduled> GetSubjectsScheduled(PNDTSchedulingRequest psData);
        CounsellingDateTime AddScheduling(AddSchedulingRequest asData);
        List<PrePNDTCounselling> GetScheduledForCounselling(PNDTSchedulingRequest psData);
        PrePNDTScheduleDateTime AddCounselling(AddPrePNDTCounsellingRequest acData);
        List<PrePNDTCounselled> GetSubjectsCounselledYes(PNDTSchedulingRequest pcData);
        List<PrePNDTCounselled> GetSubjectsCounselledNo(PNDTSchedulingRequest pcData);
        List<PrePNDTCounselled> GetSubjectsCounselledPending(PNDTSchedulingRequest pcData);
        void AutomaticPrePNDTCousellingUpdate();

    }
    public interface IPNDTDataFactory
    {
        IPNDTData Create();
    }
    public class PNDTDataFactory : IPNDTDataFactory
    {
        public IPNDTData Create()
        {
            return new PNDTData();
        }
    }
}
