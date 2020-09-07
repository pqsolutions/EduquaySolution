using EduquayAPI.Contracts.V1.Request.PNDTC;
using EduquayAPI.Contracts.V1.Response.PNDT;
using EduquayAPI.Models.PNDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.PNDT
{
    public interface IPNDTService
    {
        List<PrePNDTScheduling> GetPositiveSubjectsScheduling(PNDTSchedulingRequest psData);
        List<PrePNDTScheduled> GetSubjectsScheduled(PNDTSchedulingRequest psData);
        Task<AddSchedulingResponse> AddScheduling(AddSchedulingRequest asData);
        List<PrePNDTCounselling> GetScheduledForCounselling(PNDTSchedulingRequest psData);
        Task<AddCounsellingResponse> AddCounselling(AddPrePNDTCounsellingRequest acData);
        List<PrePNDTCounselled> GetSubjectsCounselledYes(PNDTSchedulingRequest pcData);
        List<PrePNDTCounselled> GetSubjectsCounselledNo(PNDTSchedulingRequest pcData);
        List<PrePNDTCounselled> GetSubjectsCounselledPending(PNDTSchedulingRequest pcData);
        List<PostPNDTScheduling> GetPostPNDTScheduling(PNDTSchedulingRequest psData);
        Task<AddSchedulingResponse> AddPostPNDTScheduling(AddSchedulingRequest asData);
        List<PrePNDTScheduled> GetSubjectsPostPNDTScheduled(PNDTSchedulingRequest psData);
        List<PostPNDTCounselling> GetScheduledForPostPNDTCounselling(PNDTSchedulingRequest psData);
        Task<AddPostCounsellingResponse> AddPostPNDTCounselling(AddPostPNDTCounsellingRequest acData);

        List<PostPNDTCounselled> GetSubjectsPostPNDTCounselledYes(PNDTSchedulingRequest pcData);
        List<PostPNDTCounselled> GetSubjectsPostPNDTCounselledNo(PNDTSchedulingRequest pcData);
        List<PostPNDTCounselled> GetSubjectsPostPNDTCounselledPending(PNDTSchedulingRequest pcData);



    }
}
