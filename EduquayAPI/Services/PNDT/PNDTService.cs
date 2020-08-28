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

        public List<PrePNDTScheduled> GetSubjectsScheduled(PNDTSchedulingRequest psData)
        {
            var scheduledData = _pndtData.GetSubjectsScheduled(psData);
            return scheduledData;
        }
    }
}
