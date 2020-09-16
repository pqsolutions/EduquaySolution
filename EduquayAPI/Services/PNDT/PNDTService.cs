using EduquayAPI.Contracts.V1.Request.PNDTC;
using EduquayAPI.Contracts.V1.Response.PNDT;
using EduquayAPI.DataLayer.PNDT;
using EduquayAPI.Models.PNDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.PNDT
{
    public class PNDTService : IPNDTService
    {

        private readonly IPNDTData _pndtData;

        public PNDTService(IPNDTDataFactory pndtData)
        {
            _pndtData = new PNDTDataFactory().Create();
        }

        public async Task<AddCounsellingResponse> AddCounselling(AddPrePNDTCounsellingRequest acData)
        {
            var sResponse = new AddCounsellingResponse();
            try
            {
                var schedulingDateTime = _pndtData.AddCounselling(acData);
                sResponse.Status = "true";
                sResponse.Message = string.Empty;
                sResponse.data = schedulingDateTime;
                return sResponse;
            }
            catch (Exception e)
            {
                sResponse.Status = "false";
                sResponse.Message = $"Unable to add counselling - {e.Message}";
                return sResponse;
            }

        }

        public async Task<AddPostCounsellingResponse> AddPostPNDTCounselling(AddPostPNDTCounsellingRequest acData)
        {
            var sResponse = new AddPostCounsellingResponse();
            try
            {
                var schedulingDateTime = _pndtData.AddPostPNDTCounselling(acData);
                sResponse.Status = "true";
                sResponse.Message = string.Empty;
                sResponse.data = schedulingDateTime;
                return sResponse;
            }
            catch (Exception e)
            {
                sResponse.Status = "false";
                sResponse.Message = $"Unable to add counselling - {e.Message}";
                return sResponse;
            }
        }

        public async Task<AddSchedulingResponse> AddPostPNDTScheduling(AddSchedulingRequest asData)
        {
            var sResponse = new AddSchedulingResponse();
            try
            {
                if (string.IsNullOrEmpty(asData.counsellingDateTime))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Counselling date and time is missing";
                    return sResponse;
                }
                else if (asData.counsellorId <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid counsellor Id";
                    return sResponse;
                }
                else
                {
                    var counsellingDate = _pndtData.AddPostPNDTScheduling(asData);
                    sResponse.Status = "true";
                    sResponse.Message = string.Empty;
                    sResponse.data = counsellingDate;
                    return sResponse;
                }
            }
            catch (Exception e)
            {
                sResponse.Status = "false";
                sResponse.Message = $"Unable to add scheduling - {e.Message}";
                return sResponse;
            }
        }

        public async Task<AddSchedulingResponse> AddScheduling(AddSchedulingRequest asData)
        {
            var sResponse = new AddSchedulingResponse();
            try
            {
                if (string.IsNullOrEmpty(asData.counsellingDateTime))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Counselling date and time is missing";
                    return sResponse;
                }
                else if (asData.counsellorId <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid counsellor Id";
                    return sResponse;
                }
                else
                {
                    var counsellingDate = _pndtData.AddScheduling(asData);
                    sResponse.Status = "true";
                    sResponse.Message = string.Empty;
                    sResponse.data = counsellingDate;
                    return sResponse;
                }
            }
            catch (Exception e)
            {
                sResponse.Status = "false";
                sResponse.Message = $"Unable to add scheduling - {e.Message}";
                return sResponse;
            }
        }

        public List<PrePNDTScheduling> GetPositiveSubjectsScheduling(PNDTSchedulingRequest psData)
        {
            var schedulingData = _pndtData.GetPositiveSubjectsScheduling(psData);
            return schedulingData;
        }

        public List<PostPNDTScheduling> GetPostPNDTScheduling(PNDTSchedulingRequest psData)
        {
            var schedulingData = _pndtData.GetPostPNDTScheduling(psData);
            return schedulingData;
        }

        public List<PrePNDTCounselling> GetScheduledForCounselling(PNDTSchedulingRequest psData)
        {
            _pndtData.AutomaticPrePNDTCousellingUpdate();
            var counsellingData = _pndtData.GetScheduledForCounselling(psData);
            return counsellingData;
        }

        public List<PostPNDTCounselling> GetScheduledForPostPNDTCounselling(PNDTSchedulingRequest psData)
        {
            _pndtData.AutomaticPostPNDTCousellingUpdate();
            var counsellingData = _pndtData.GetScheduledForPostPNDTCounselling(psData);
            return counsellingData;
        }

        public List<PrePNDTCounselled> GetSubjectsCounselledNo(PNDTSchedulingRequest pcData)
        {
            var counseledNoData = _pndtData.GetSubjectsCounselledNo(pcData);
            return counseledNoData;
        }

        public List<PrePNDTCounselled> GetSubjectsCounselledPending(PNDTSchedulingRequest pcData)
        {
            var counseledPendingData = _pndtData.GetSubjectsCounselledPending(pcData);
            return counseledPendingData;
        }

        public List<PrePNDTCounselled> GetSubjectsCounselledYes(PNDTSchedulingRequest pcData)
        {
            var counseledYesData = _pndtData.GetSubjectsCounselledYes(pcData);
            return counseledYesData;
        }

        public List<PostPNDTCounselled> GetSubjectsPostPNDTCounselledNo(PNDTSchedulingRequest pcData)
        {
            var counseledNoData = _pndtData.GetSubjectsPostPNDTCounselledNo(pcData);
            return counseledNoData;
        }

        public List<PostPNDTCounselled> GetSubjectsPostPNDTCounselledPending(PNDTSchedulingRequest pcData)
        {
            var counseledNoData = _pndtData.GetSubjectsPostPNDTCounselledPending(pcData);
            return counseledNoData;
        }

        public List<PostPNDTCounselled> GetSubjectsPostPNDTCounselledYes(PNDTSchedulingRequest pcData)
        {
            var counseledNoData = _pndtData.GetSubjectsPostPNDTCounselledYes(pcData);
            return counseledNoData;
        }

        public List<PostPNDTScheduled> GetSubjectsPostPNDTScheduled(PNDTSchedulingRequest psData)
        {
            var scheduledData = _pndtData.GetSubjectsPostPNDTScheduled(psData);
            return scheduledData;
        }

        public List<PrePNDTScheduled> GetSubjectsScheduled(PNDTSchedulingRequest psData)
        {
            var scheduledData = _pndtData.GetSubjectsScheduled(psData);
            return scheduledData;
        }
    }
}
